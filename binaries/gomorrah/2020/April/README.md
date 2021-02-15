# Gomorrah stealer (.NET binary)

MD5:  2fd45662e3d0ec0077ea2fa66b6378f0.bin  
PCAP: 2fd45662e3d0ec0077ea2fa66b6378f0.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 04/22/2020

This sample highlights Gomorrah activity along with successful C2 check-in and data-exfil. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/80334744-b7f2f600-8817-11ea-9236-7ec74a8f700e.png)

Process activity, anti-analysis was observed  

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/80334441-dad0da80-8816-11ea-89a2-cc3f83f86c10.png) 

HTTP traffic with data-exfil

## Suricata Alerts

![IDS Alerts](https://user-images.githubusercontent.com/1920756/80334601-4e72e780-8817-11ea-989b-c39d6e299f55.png)  
Suricata alerts via Any.Run

## Decompiler Output

![Gomorrah stealer](https://user-images.githubusercontent.com/1920756/80334469-f63be580-8816-11ea-8490-12f724b3bd41.png)

Sample of primary program structure

![CC Stealer](https://user-images.githubusercontent.com/1920756/80334470-f9cf6c80-8816-11ea-9571-2b162db04e63.png)

Sample of credit cards targeted  

