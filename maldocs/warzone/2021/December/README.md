# Excel document uses VBA macros to execute cmd.exe to run Powershell script -> Downloads WarzoneRAT over HTTPS

Excel: c558218fab28a77dc596dad19e0851fd.xlsm  
PCAP: ee8cd64cf2236b902d11e9bed3f20bfb023eecfcc0e9b11f01a5f25f814cba1a_dump.pcap  
BAT script created via macros: bixkcozkkemqyslgmpvwuri.bat  
Dropped EXE (Warzone): ktaqftbffhqhoxzyblssi.exe  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 12/22/2021  

Excel document uses VBA macros to execute cmd.exe to run Powershell script -> Downloads WarzoneRAT over HTTPS

## Process Activity

![Process Activity](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/warzone/2021/December/process.png?raw=true)

Process activity highlights the execution of VBA macros to create BAT script. This, in turn, executes Powershell to download the malware.  

![VBA Macros](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/warzone/2021/December/vbamacros.png?raw=true)

## Network Activity

![Malware Download](https://raw.githubusercontent.com/jstrosch/malware-samples/master/maldocs/warzone/2021/December/network.png?raw=true)

HTTPS request to download malware.