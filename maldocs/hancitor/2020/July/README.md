# Word doc drops Hancitor loader

Word MD5: e57d44fd470e7364a235353ded942f0f.bin  
Trojan MD5 (extracted from network traffic): a2d54f9489071632ea8f69cc339c1975_6.pif.exe   
PCAP (Any.Run): e57d44fd470e7364a235353ded942f0f.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7
Date: 07/13/2020

This sample highlights an Word document with Hancitor loader embedded in the document. Check-in is performed but no further download instructions were received. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/87899835-18a95d80-ca18-11ea-82bd-73c0e55e16c9.png)

Process activity from the maldoc - 6.pif is an embedded EXE that is written to the file system and executed.

## Network Activity

![HTTP Traffic](https://user-images.githubusercontent.com/1920756/87899837-1a732100-ca18-11ea-9678-05c4e3bfadcb.png)  

IP check followed by C2 check-in

![Check-In](https://user-images.githubusercontent.com/1920756/87899838-1c3ce480-ca18-11ea-9fd4-cf32bfabfa55.png)

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/87899842-1d6e1180-ca18-11ea-9d68-36c7c0c48468.png)  
Subset of Suricata alerts using Emerging Threats Open and Abuse.ch rulesets
