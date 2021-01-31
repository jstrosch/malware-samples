# Excel drops Qakbot (qbot) DLL

Excel: 0d66b622f28d032a6feddaf55b083198.bin  
PCAP: 0d66b622f28d032a6feddaf55b083198.pcap  
Dropped DLL (qbot): c4ca3b0c24456e0be9aab78ac633ba5e-copr-rsgs-dll.bin  

Analysis source: Cuckoo 2.0.7  
Date: 01/15/2021    

Excel document that drops Qakbot, executes via *rundll32.exe*.

## Maldoc template

![template](https://user-images.githubusercontent.com/1920756/106374451-4406f080-6349-11eb-894b-c4c11e32a183.jpg)

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/106374416-0a35ea00-6349-11eb-9775-ed125b6c6c27.png)

Process activity from the Excel document.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/106374419-0b671700-6349-11eb-9c1e-41845fc39ed4.png)

HTTP request to download the trojan as a JPG file.  

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/106374430-2afe3f80-6349-11eb-823e-9ff2834d6b95.png) 

Alerts indicating suspicious activity around the download of an PE file.