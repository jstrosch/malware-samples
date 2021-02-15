# Trickbot using Revocations.txt config - drops pwgrab64 and networkDll64

MD5: 81ee8c62fff641b99f3e5ac83c575526.bin  
PCAP: 81ee8c62fff641b99f3e5ac83c575526.pcap  
CmdValiate: Folder containing configs and modules, created under %AppData%/temp/    
revocations.txt: Original configuration file  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mcconf.txt: Decoded configuration file using []()  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data: Folder created to house dropped modules  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;networkDll64: module  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;networkDll64_configs: folder containing module config  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dpost: config  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pwgrab64: module  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pwgrab64_configs: folder containing module config  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dpost: config  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Manual 
Date: 004/14/20

This sample highlights Trickbot activity with an updated main configuration file.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/79505218-b0527680-7ff9-11ea-8d28-32d768dc6bf6.png)  

Process activity, this sample was run from an administrative command prompt. 

![PrivEsc](https://user-images.githubusercontent.com/1920756/79505337-d8da7080-7ff9-11ea-8cea-0490f94e1f63.png)  

Privilege escalation attempts were noted on Any.Run.

## Changes to main configuration file

![Main Config File](https://user-images.githubusercontent.com/1920756/79505451-00c9d400-7ffa-11ea-8029-c760903af449.png)  

The main configuration file was named revocations.txt, and contained large amounts of junk text with the encrypted commands burried within  

![Config](https://user-images.githubusercontent.com/1920756/79505581-32429f80-7ffa-11ea-86bf-802ce8767538.png)  

version 1000507 and gtag man6  


## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/79505498-1212e080-7ffa-11ea-807b-fb463b67b27b.png)  
Alerts genereated from Suricata  