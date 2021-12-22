# Word Document uses Packager Shell Object to Execute VBScript, Run Powershell to Download AgentTesla

Word: 6e5a16bcb17ee13ad0f3cfef446e2904.doc.bin  
PCAP: 6e5a16bcb17ee13ad0f3cfef446e2904.pcap  
VBScript: abdtfhghgeghdpž.sct  
Dropped EXE (AgentTesla): 6458c0c295222a88f4a745200b331587e0f8acb3daafa22a9d830731769822d2_6458c0c295222a88_cb8.exe.bin  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 11/13/2021  

Word Document uses Packager Shell Object to Execute VBScript, Run Powershell to Download AgentTesla from dotted-quad.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/143422033-d50a8c56-c111-4cd9-9c13-c03497a88930.png)

Process activity highlights Powershell execution from the VB script, which is activated via a packager shell object.

![Packager Shell Object](https://user-images.githubusercontent.com/1920756/143422203-16fdfb85-34ee-4f19-b50e-6e9c9bbc23f8.png)

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/143422329-12298ca9-0b72-4314-b8b7-150813919992.png)

HTTP request to download AgentTesla from dotted-quad.

## Config

![Malware config](https://user-images.githubusercontent.com/1920756/143422622-4efd5c49-c150-49e0-a2b9-aa7be55f50b7.png)

AgentTesla commonly uses SMTP for data exfil, this information has been extracted via [Triage](https://tria.ge/211125-la41faegcm).

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/143422437-c7c73213-57aa-4a53-b69a-570fc8fbdf40.png)  

Multiple alerts where generated around the download of the PE file.