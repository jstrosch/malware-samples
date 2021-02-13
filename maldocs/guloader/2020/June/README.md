# Excel Document Drops GuLoader

XLS MD5: af8ac4ce4e513e74c96d16536848fbc1.bin  
GuLoader MD5: a3b3caafdd3ef07f6a844956060bbde8.bin
PCAP: af8ac4ce4e513e74c96d16536848fbc1.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 06/01/2020  
Additional Resources: [Abuse.ch](https://urlhaus.abuse.ch/browse.php?search=cocomexdelbajio.com)  

This sample highlights an Excel document that downloads GuLoader, no follow-on behavior was observed.   

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/83925313-745fa600-a74c-11ea-899b-9926c8e462fe.png)

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/83925316-7590d300-a74c-11ea-985c-673f76bb6990.png) 

HTTP request for Guloader binary.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/83925317-76c20000-a74c-11ea-86d7-b3861a7c16b7.png)  
![Any.Run](https://user-images.githubusercontent.com/1920756/83925474-df10e180-a74c-11ea-9f23-6ce0899540ff.png)
Subset of Suricata alerts using Emerging Threats Open and Abuse.ch rulesets