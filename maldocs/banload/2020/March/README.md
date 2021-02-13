# Word drops Banload Banking Trojan

Excel: a46aff762755cfa81c2095d1e6c24176.doc.bin  
PCAP: a46aff762755cfa81c2095d1e6c24176.pcap  
Dropped EXE (Banload): a46aff762755cfa81c2095d1e6c24176.bin

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Maldoc/Exe - [Any.Run](https://app.any.run/tasks/8226cbc4-eae4-41c2-8318-65cb7c86d000)  
Date: 03/26/2020  

Excel document that drops Banload.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/77722194-0b74e880-6fbb-11ea-9013-195122cebd2f.png)

Process activity from the Word document, which drops Banload via a Zip file.

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/77722195-0ca61580-6fbb-11ea-855d-7d05dc0e375f.png)

HTTP request to download the trojan with post-infection traffic

![Malware Check-in](https://user-images.githubusercontent.com/1920756/77722323-72929d00-6fbb-11ea-8b0a-0addf82f7871.png)  

Check-in includes the use of HTTP 1.0 and a non-standard user-agent

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/77722196-0dd74280-6fbb-11ea-8f7f-da7538a288b4.png)  

IDA alerts from Any.Run