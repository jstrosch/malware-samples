# Excel drops Qakbot (qbot) EXE

Excel: 50b8112ccc4c63a1e73f65a16868f610.xls.bin  
PCAP: 50b8112ccc4c63a1e73f65a16868f610.pcap    

Analysis source: Cuckoo 2.0.7  
Date: 09/27/2021    

Excel document that drops Qakbot, executes via *regsvr32.exe*.

## Maldoc template

![template](https://user-images.githubusercontent.com/1920756/134993106-3ab76d89-3776-467b-b449-257adbb557c5.jpg)

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/134993149-8cf34c6c-edf6-4df0-b9a8-efe59aecb8ec.png)

Process activity from the Excel document and follow-on payloads.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/134993205-6bf0885d-8c33-4591-8ae7-63c63fc9169c.png)

HTTP request to download the trojan as a DAT file.  

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/134993246-0685a9b8-8a42-478c-9214-f3b8dfa73536.png) 

Alerts indicating suspicious activity around the download of an PE file.