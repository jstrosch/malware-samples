# Excel document drops Raccoon 

Excel: f81192d7fb07ca8b5179a607b5a57a97.bin  
PCAP: f81192d7fb07ca8b5179a607b5a57a97.pcap  
PCAP (AnyRun): aed29c48-3a27-487f-ac21-6399f7037470.pcap  
Dropped EXE (Raccoon): c6f6ed1f84712740a7ee2faa2e1fff9b.bin 

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
XLS document and EXE hosted on same server with open directory: [https://twitter.com/jstrosch/status/1347225282290319361](https://twitter.com/jstrosch/status/1347225282290319361)  
Additional analysis on AnyRun: [https://app.any.run/tasks/aed29c48-3a27-487f-ac21-6399f7037470/#](https://app.any.run/tasks/aed29c48-3a27-487f-ac21-6399f7037470/#)  
Date: 01/07/2021  

Excel document drops Raccoon EXE from *hxxp://file.discountmonumentcenter[.]com/doc/sek750_2021.exe*, after a redirect through *hxxps://cutt[.]ly/WjszILu*.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/104872241-eae39980-5912-11eb-94b4-49727f8db4a1.png)

Raccoon EXE was downloaded from *cut.ly* URL shortener service. EXE was written to the file system with *.bat* extension and executed via PowerShell.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/104872582-db188500-5913-11eb-8b43-f43f0f3fa7cd.png)

Malware download.

![Open directory](https://user-images.githubusercontent.com/1920756/104872613-f1264580-5913-11eb-9834-dac7563edac2.png)

Open directory

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/104872647-08fdc980-5914-11eb-8067-5ef86e4ae344.png)  

Several IDS alerts were generated around the download of the PE file (AnyRun)
