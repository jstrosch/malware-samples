# Blue BotNet

MD5: 64a1d0dfdbd8cf4ff63682bfc748b1c2  
PCAP: 64a1d0dfdbd8cf4ff63682bfc748b1c2.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 03/23/2020

This sample highlights Blue Botnet activity. 

## Process Activity

Executes as a single process. This is a .NET binary and can be decompiled.


## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/77499579-81911800-6e20-11ea-9d48-2e78b50bd323.png)  

Highlights trojan checking in with c2 network to retrieve commands, targets, proxies, etc. All observed traffic was over HTTP.  

![C2](https://user-images.githubusercontent.com/1920756/77499714-d5036600-6e20-11ea-8500-3b3329ddefa8.png)

C2 information is stored at the end of the PE file. During startup, the EXE reads itself and then parses this content from them end.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/77499731-e0569180-6e20-11ea-9c02-2c9b5a1d7f1b.png)  

Suricata alerts using Emerging Threats Open