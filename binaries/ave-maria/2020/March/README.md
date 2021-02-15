# Ave Maria / Warzone RAT

MD5: 34e1bab2aedc629c1fa4289aa1dbcbef  
PCAP: 34e1bab2aedc629c1fa4289aa1dbcbef.pcap    

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 03/24/2020

This sample highlights Ave Maria process activity along with a successful check-in to it's panel. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/78467180-774c0500-76cf-11ea-9036-7dc9c909c5d2.png)

Process activity from the RAT, CNC activity comes from injected code into explorer.exe. 

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/78467181-7915c880-76cf-11ea-8155-7e1b1bbde142.png)  
Encrypted payloads between victim and C2 server.