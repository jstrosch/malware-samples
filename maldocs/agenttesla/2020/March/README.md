# Excel drops AgentTesla

Excel: 02f3b89c7ad90fed3e057b6243a7293f.xls.bin  
PCAP: 02f3b89c7ad90fed3e057b6243a7293f.pcap  
Dropped EXE (AgentTesla - MSI): 02f3b89c7ad90fed3e057b6243a7293f.bin

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Maldoc - [Any.Run](https://app.any.run/tasks/078c98b9-b1e1-40d2-81b1-bbacaad1204d/)  
EXE - [Any.Run](https://app.any.run/tasks/9c836868-d7da-4850-82f3-e89408e3d57b/)
Date: 03/26/2020  

Excel document that drops AgentTesla.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/77720901-41b06900-6fb7-11ea-8ce2-b5e134f801e9.png)

Process activity from the Excel document, which downloads an MSI and executes through MSIEXEC.

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/77720903-42e19600-6fb7-11ea-803f-c59225bf01a7.png)

HTTP request to download the trojan

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/77720905-44ab5980-6fb7-11ea-89b9-49674e88c164.png)  

IDA alerts from Any.Run