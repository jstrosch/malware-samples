# Excel drops IcedId - Uses VBA macros to execute Excel 4 macros in hidden sheet/hidden columns

Excel (SHA256): 742797290-04012021 2.xlsm (0b9ef9ef48bdb672f1a80ef444521d60d13eb299d0d873f473980492f53b50a6)  
PCAP file: f4f7444f-dd16-4352-816d-b0528edef6aa.pcap  
Dropped EXE - IcedID (SHA256): 44285_5327891204.dat (b560e2d47ad2c84f16667b570010078a3df3ef70e788fab00381771f2a0bb336)  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Additional analysis: [Any.Run](https://app.any.run/tasks/f4f7444f-dd16-4352-816d-b0528edef6aa)  
Date: 04/01/2021  

Excel document that drops IcedId.

## Excel Document

![Template](https://user-images.githubusercontent.com/1920756/113426249-d141e200-9398-11eb-838d-ae644f1f82d4.png)

Maldoc lure, abusing Microsoft Excel logo.  

![VBA Macros](https://user-images.githubusercontent.com/1920756/113426258-d4d56900-9398-11eb-8c2a-9a17e2656535.png)

VBA macros extracted with OLEDUMP. Auto_open is used to execute Excel 4 macros in hidden sheet *Brisk*. Column *CD* is also hidden in the sheet.

![Excel 4 Macros](https://user-images.githubusercontent.com/1920756/113426399-0817f800-9399-11eb-8efc-3ab270197426.png)

Excel 4 macro content can be seen using *UrlDownloadToFileA* to download DLL from three hosts and then executed using *rundll32*. The entry-point for each DLL is *PluginInit*.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/113426556-3f86a480-9399-11eb-9538-e439bdf6cc15.png)

Process activity from the Excel document, which uses *rundll32* to execute all three instances of the downloaded DLL.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/113426607-5200de00-9399-11eb-8785-15e63e04bb33.png)

HTTP requests to dotted-quads to download unobfuscated PE file. 

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/113426666-68a73500-9399-11eb-97fe-3f6eeb61a108.png)  

Numeruous IDS alerts around the three PE file downloads and the way in which it was downloaded.