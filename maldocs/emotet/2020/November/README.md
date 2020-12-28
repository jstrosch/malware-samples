# Emotet Maldoc (Word) - Embedded DLL and CertUtil for Base64 Decoding

Excel MD5: 7dbd8ecfada1d39a81a58c9468b91039.bin  
PCAP: 7dbd8ecfada1d39a81a58c9468b91039.pcap  
Base64 Encoded DLL (used by certutil): ca4b9652ed45507c4f08142b04f72866.b64  
Payload (Emotet Trojan): 706ea7f029e6bc4dbf845db3366f9a0e.dll.bin  

Analysis on YouTube: [https://youtu.be/NzzS9DqPPfw](https://youtu.be/NzzS9DqPPfw)  

Analysis source: Cuckoo 2.0.7  
Any.Run: [https://app.any.run/tasks/b1792f9f-d24c-4f42-8fd2-1850c2a6c779/#](https://app.any.run/tasks/b1792f9f-d24c-4f42-8fd2-1850c2a6c779/#)  

11/10/2020 - AnyRun posted an Emotet maldoc that utilized CertUtil to decode a DLL payload that was used for unpacking and running the Emotet trojan. This is a deviation from normal use of obfuscated base64 PowerShell command as well as embedding the DLL into the maldoc instead of retrieving from a compromised host. This video provides analysis of the document using both static and dynamic techniques, as well as a walk-through of the macro code.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/102800201-296c4f80-4379-11eb-8de0-0474a5e7a601.png)

Macros use certutil to base64 decode the DLL (-decode), then *RUNDLL32* is used to execute the DLL, the entry point is the function *In*

## Network Activity

![Emotet Check-In]("https://user-images.githubusercontent.com/1920756/102800209-2b361300-4379-11eb-8d25-cab048ebebe5.png)

Since the DLL was embedded in the document, there is no initial request for the trojan (EXE file). Emotet check-in traffic is observed after execution of the DLL, which is used for unpacking.

## Suricata Alerts

![Suricata IDS Alerts](https://user-images.githubusercontent.com/1920756/102800212-2cffd680-4379-11eb-9b68-177938a17887.png)