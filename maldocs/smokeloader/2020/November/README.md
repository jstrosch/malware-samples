# Word document drops Smokeloader

Word: f3495691c23e2c4eaacfc5e412130457.bin  
PCAP: f3495691c23e2c4eaacfc5e412130457.pcap  
Dropped EXE (Smokeloader): vgzrlzo.rar_870d23e188eccfe11eab8d561c95c08b.bin  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 11/24/2020 

Word document that drops Smokeloader EXE from *sbm.balajihandheld[.]in* with a *.rar* extension.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/100495252-321d8d00-310f-11eb-93d9-b52e34cbbe09.png)

Macros are used to execute several processes - one is an instance of cmd.exe to show a message box indicating an error has occurred trying to open the document. Powershell is then used to decode a base64 encooded script to download the EXE.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/100495253-334eba00-310f-11eb-8f2a-e5479e35043d.png)

HTTP request to download the trojan - the file requested was purpotedly a RAR (note the file extension) but a PE file was returned.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/100495255-347fe700-310f-11eb-8bc1-21ac5337754e.png)  

Several IDS alerts were generated around the download of the PE file, along with TLS and JA3 alerts. 