# Excel drops Qakbot (qbot) DLL

Excel: d0313772c1e64397f258f4d2858b6887.bin  
PCAP: d0313772c1e64397f258f4d2858b6887.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Tria.ge - [https://tria.ge/201128-edgayhq81j](https://tria.ge/201128-edgayhq81j)  
Extraced C2 (PasteBin) - [https://pastebin.com/J810eRiy](https://pastebin.com/J810eRiy)  
Further Information: [https://twitter.com/jstrosch/status/1332576642493984769](https://twitter.com/jstrosch/status/1332576642493984769)
Sample is signed: "Školab s.r.o."
Date: 11/27/2020    

Excel document that drops Qakbot, executes via *regsvr32.exe*.

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/100495807-ac9cdb80-3114-11eb-87cb-1264613a65df.png)

Process activity from the Excel document.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/100495813-b7f00700-3114-11eb-92a9-1242bb87bf31.png)

HTTP request to download the trojan as a JPG file.  

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/100495841-f71e5800-3114-11eb-8135-4c80c0ffe555.png) 

Alerts indicating suspicious activity around the download of an PE file.