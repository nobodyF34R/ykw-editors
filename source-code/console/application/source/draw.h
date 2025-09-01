#ifndef DRAW_H
#define DRAW_H

/** Example to load a RGBA image and display it with C2D */

#include <3ds.h>
#include <3ds/romfs.h>
#include <3ds/svc.h>
#include <citro2d.h>

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define CLEAR_COLOR C2D_Color32(0x0, 0x0, 0x0, 0x0)

const u32 next_pow2(u32 n) {
  n--;
  n |= n >> 1;
  n |= n >> 2;
  n |= n >> 4;
  n |= n >> 8;
  n |= n >> 16;
  n++;
  return n;
}
const u32 clamp(u32 n, u32 lower, u32 upper) {
  if (n < lower)
    return lower;
  if (n > upper)
    return upper;
  return n;
}
const u32 rgba_to_abgr(u32 px) {
  u8 r = (px & 0xff000000) >> 24;
  u8 g = (px & 0x00ff0000) >> 16;
  u8 b = (px & 0x0000ff00) >> 8;
  u8 a = px & 0x000000ff;
  return (a << 24) | (b << 16) | (g << 8) | r;
}

/** Read an RGBA image from `path` with dimensions `image_width`x`image_height`
 * and return a `C2D_Image` object.
 * Assumes image data is stored left->right, top->bottom.
 * Dimensions must be within 64x64 and 1024x1024.
 * svcBreak's if the file can't be opened. */
C2D_Image get_image(const char *path, u32 image_width, u32 image_height) {
  // Open file
  FILE *file = fopen(path, "rb");
  if (file == NULL) {
    fprintf(stderr, "failed to open `%s'", path);
    svcBreak(USERBREAK_PANIC);
  }
  u32 px_count = image_width * image_height;
  u32 *rgba_raw = (u32 *)malloc(px_count * sizeof(u32));
  fread((char *)rgba_raw, sizeof(u32), px_count, file);

  // Image data
  C2D_Image image;

  // Base texture
  C3D_Tex *tex = (C3D_Tex *)malloc(sizeof(C3D_Tex));
  image.tex = tex;
  // Texture dimensions must be square powers of two between 64x64 and 1024x1024
  tex->width = clamp(next_pow2(image_width), 64, 1024);
  tex->height = clamp(next_pow2(image_height), 64, 1024);

  // Subtexture
  Tex3DS_SubTexture *subtex = (Tex3DS_SubTexture *)malloc(sizeof(Tex3DS_SubTexture));
  image.subtex = subtex;
  subtex->width = image_width;
  subtex->height = image_height;
  // (U, V) coordinates
  subtex->left = 0.0f;
  subtex->top = 1.0f;
  subtex->right = (float)image_width / (float)tex->width;
  subtex->bottom = 1.0 - ((float)image_height / (float)tex->height);

  C3D_TexInit(tex, tex->width, tex->height, GPU_RGBA8);
  C3D_TexSetFilter(tex, GPU_LINEAR, GPU_NEAREST);

  memset(tex->data, 0, px_count * 4);
  for (u8 i = 0; i < image_width; i++) {
    for (u8 j = 0; j < image_height; j++) {
      u32 src_idx = (j * image_width) + i;
      u32 rgba_px = rgba_raw[src_idx];
      u32 abgr_px = rgba_to_abgr(rgba_px);

      // Swizzle magic to convert into a t3x format, c.f.:
      // https://github.com/pyroticinsanity/3dsdod/blob/fe8d357bd918008831af351b793efad6cb48c8b0/source/3ds/ctr_utils.cpp#L139
      // https://github.com/astronautlevel2/Anemone3DS/blob/ba08ab9108cec81a4fcb31d12a2af09bab589b82/source/loading.c#L338
      // https://github.com/devkitPro/tex3ds/blob/master/source/swizzle.cpp
      u32 dst_ptr_offset = ((((j >> 3) * (tex->width >> 3) + (i >> 3)) << 6) +
                            ((i & 1) | ((j & 1) << 1) | ((i & 2) << 1) |
                             ((j & 2) << 2) | ((i & 4) << 2) | ((j & 4) << 3)));
      ((u32 *)tex->data)[dst_ptr_offset] = abgr_px;
    }
  }

  // free(rgba_raw);

  return image;
}

#endif // DRAW_H