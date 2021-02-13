# Word drops Trickbot with payloads

Word: a0f6dcf7380cd5475a134344d281fdd1.doc.bin  
PCAP: a0f6dcf7380cd5475a134344d281fdd1.pcap  
Dropped EXE: andrew.med (tmp038.exe)   
WINYS folder: Contains encrypted payloads/modules along with configuration information  
Decoded folder: decoced configs and payloads/modules  
Decoding scripts available at: [https://github.com/hasherezade/malware_analysis/tree/master/trickbot](https://github.com/hasherezade/malware_analysis/tree/master/trickbot)

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Manual  
Date: 11/11/2018

Word document that drops Trickbot, includes several payloads/modules

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/78928809-e1193580-7a66-11ea-83db-4437b81c502a.png)  

Process activity from the Word document, which drops Trickbot. Trojan attempts to disable real-time protection and stop/delete windows defender service.

## Decoded Config

![Settings.ini](https://user-images.githubusercontent.com/1920756/78929027-42410900-7a67-11ea-939a-62c8b62546a6.png)  

Settings.ini

![Payloads](https://user-images.githubusercontent.com/1920756/78929078-5dac1400-7a67-11ea-8a6a-6cd650e24769.png)  

Payloads (DLLs)