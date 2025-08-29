#include <algorithm>
#include <iostream>
#include <map>
#include <string>
#include <vector>
#include <3ds.h>
#include "cipher.h"
#include "data.h"
#include "edit.h"
#include "struct.h"

extern "C" {
    int draw(const char *path, u32 width, u32 height, float x, float y); // Declaration of the C function
}


/// Media types.
// typedef enum
// {
// 	MEDIATYPE_NAND      = 0, ///< NAND.
// 	MEDIATYPE_SD        = 1, ///< SD card.
// 	MEDIATYPE_GAME_CARD = 2, ///< Game card.
// } FS_MediaType;

int main(int argc, char* argv[])
{
	gfxInitDefault();
	consoleInit(GFX_TOP, NULL);

	printf("Hello, world!\n");

	Result ret;
	FS_Archive save_archive;			  //0x0017C200 and 0x001B2800
	u32 archivePathData[3] = {MEDIATYPE_SD, 0x0017C200, 0x00040000}; // TODO list of TIDs
	const FS_Path archivePath = {PATH_BINARY, 12, (const void*)archivePathData};
	printf("Opening archive...\n");
	ret = FSUSER_OpenArchive(&save_archive, ARCHIVE_USER_SAVEDATA, archivePath);
	Handle file;
	printf("Opening file...\n");
	ret = FSUSER_OpenFile(&file, save_archive, fsMakePath(PATH_ASCII, "/game1.yw"), FS_OPEN_READ | FS_OPEN_WRITE, 0);
	u64 file_size;
	ret = FSFILE_GetSize(file, &file_size);
	printf("File size: %llu bytes\n", file_size);

	std::vector<uint8_t> encryptedData(file_size);
	u32 bytes_read;
	ret = FSFILE_Read(file, &bytes_read, 0, encryptedData.data(), file_size);

	printf("Decrypting data...\n");	
	std::vector<uint8_t> decryptedData = yw_proc(encryptedData, false);

	//do stuff

	std::vector<struct1::Yokai> yokailist;
	int offset = 7432;
	for (int i = 0; i < 240; i++) {

		if (decryptedData[offset+2] == 0) {
			break;
		}

		yokailist.push_back(struct1::Yokai(decryptedData, offset));
		offset += 92;
	}
	draw("romfs:/pandle.rgba", 128, 128, 20., 20.);
	gfxInitDefault();
	consoleInit(GFX_TOP, NULL);

	edit1::edit_yokai(yokailist);

	//okay that's enough stuff

	printf("Encrypting data...\n");
	std::vector<uint8_t> buffer = yw_proc(decryptedData, true);

	printf("Writing data...\n");
	u32 bytes_written;
	ret = FSFILE_Write(file, &bytes_written, 0, buffer.data(), file_size, FS_WRITE_FLUSH | FS_WRITE_UPDATE_TIME);
	ret = FSFILE_Close(file);
	ret = FSUSER_ControlArchive(save_archive, ARCHIVE_ACTION_COMMIT_SAVE_DATA, NULL, 0, NULL, 0);
	ret = FSUSER_CloseArchive(save_archive);

	gfxExit();
	return 0;
}
