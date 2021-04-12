# Excel drops Campo Loader

Excel MD5: f23acd80b83b3bc1ea1503e94e1831f8.bin 
PCAP: f23acd80b83b3bc1ea1503e94e1831f8.pcap  
Dropped DLL (b4164149ffc43c2bf55cb66922e738b0): 238.dll  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Any.Run: [https://app.any.run/tasks/8823560f-d44a-45bc-9706-aac3ac7dd30c/](https://app.any.run/tasks/8823560f-d44a-45bc-9706-aac3ac7dd30c/)  

Additional analysis availabe on YouTube: [https://youtu.be/un8I6dfuDVQ](https://youtu.be/un8I6dfuDVQ)  
IDA Python Script to Decode XOR-Encoded Strings: [https://github.com/jstrosch/XOR-Decode-Strings-IDA-Plugin](https://github.com/jstrosch/XOR-Decode-Strings-IDA-Plugin)  

Excel document that drops unknown DLL through the use of Certutil *-decode* and *-decodehex*

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/102286975-02d49180-3eff-11eb-98a4-67be23c7c42b.png)

Macros use certutil to first base64 decode the DLL (-decode), then uses certutil to convert from hex using -decodehex. RUNDLL32 is used to execute the DLL, the entry point is the function *D*

## Network Activity

![Attempted Download](https://user-images.githubusercontent.com/1920756/102286977-0405be80-3eff-11eb-8067-ec396cc2ef72.png)

Attempt was made to download a payload from *hxxp://207.154.235.218/campo/z/z*. Unfortunately the host did not respond at the time of analysis.

## Suricata Alerts

No alerts were generated during execution.