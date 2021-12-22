# Excel document uses XLM macros to execute cmd.exe to download/run MSHTA script -> Downloads Powershell script -> Downloads Emotet DLL

Excel: d67193e7b4806640105a117a020ab6b0.xlsm.bin  
PCAP: d67193e7b4806640105a117a020ab6b0.pcap  
MSHTA script downloaded from hxxp://87.251.85[.]100/PP/pp.html: 4b417a733f9da87991d2a4052cdb0617_pp.html  
Powershell script downloaded from hxxp://87.251.85[.]100/PP/PP.PNG :0ebc06f7dd4f041ec57209530a15fbb0_PP.PNG  
Dropped EXE (Emotet): 3537ad7979bdcd294c534ed3fa174b34_Uwp2XxU2yzt21weDcM2.bin  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 12/16/2021  

Excel document uses XLM macros to execute cmd.exe to download/run MSHTA script -> Downloads Powershell script -> Downloads Emotet DLL

## Process Activity

![Process Activity](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/emotet/2021/December/process.png?raw=true)

Process activity highlights the execution of XLM macros to run MSHTA, which downloads and executes a Powershell script before downloading and running the Emotet DLL.

![XLM Macros](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/emotet/2021/December/xlmmacros.png?raw=true)

## Network Activity

![Malware Download](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/emotet/2021/December/network.png?raw=true)

HTTP requests to download intermediary scripts before the Emotet malware.

## Suricata Alerts

![Suricata Alerts](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/emotet/2021/December/suri.png?raw=true)  

Multiple alerts where generated around the download of the PE file and TLS activity.