# Java Network Launch Protocol (jnlp) / JAR, Downloads Gozi DLL

Java Network Launch Protocol: presentation.jnlp (MD5: 577564c622b9f8b32ba14b50dd0954c4)   
JAR File: presentation.jar (MD5: eed96d06c6abb27f5706cdaf74b23466)   
Dropped DLL - Gozi/Ursnif: presentation.dll (MD5: 71a3aab464b4d1851a60b750a24896aa)
PCAP: da777f23-2309-4c0f-8354-ef5a1bc9d8bd.pcap  

Analysis source: manual  
Date: 04/21/2021  
Additional Information: [Any.Run](https://app.any.run/tasks/da777f23-2309-4c0f-8354-ef5a1bc9d8bd)  
Discovered through an open directory, originally reported: [https://twitter.com/jstrosch/status/1385079891444387852](https://twitter.com/jstrosch/status/1385079891444387852)  

## JNLP File

![template](https://user-images.githubusercontent.com/1920756/116187561-61025400-a6eb-11eb-9439-5f86231df7b1.png)

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/116187701-96a73d00-a6eb-11eb-8791-b984d07c6766.png)

Process activity from the JNLP file and DLL execution.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/116188004-39f85200-a6ec-11eb-9dee-b610221b100f.png)

HTTP request to download the trojan as a DLL file.    

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/116187200-b25e1380-a6ea-11eb-8eb2-5df8c10ed7d0.png) 