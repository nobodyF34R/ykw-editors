from Crypto.Cipher import AES
import base64

message = b"hETucL1nC6rKOQjSNXtdtg=="
message = base64.b64decode(message)

print (len(message))
for b in message:
    print(b)

key = "qwertyuiopasdfgh"

iv = "zxcvbnmlkjhgfdsa"

aes = AES.new(key, AES.MODE_CBC, iv)
decd = aes.decrypt(message)

print(decd)
