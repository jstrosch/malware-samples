# Excel downloads AsyncRAT

MD5 (ee6d2f06ce4476370cb830acb3890dca.xls.bin) = ee6d2f06ce4476370cb830acb3890dca  
MD5 (4a6bfc263ed646d3a225194d54f96a73abb7c17c8e1113e2d4b5aa7606f79f4f_dump.pcap) = dd740ca117e803992607341254ff7ee4  

Analysis source: Cuckoo 2.0.7  
Date: 06/09/2021    

Excel downloads AsyncRAT.  

## Maldoc template

![template](https://user-images.githubusercontent.com/1920756/121822930-8b8e7900-cc67-11eb-84cc-d65e72f2cbae.jpg)  

Social engineering abusing Excel.  

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/121822933-8cbfa600-cc67-11eb-9035-618275b9ad91.png)  

Process activity from the Excel, uses PowerShell script to download/execute trojan.  

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/121822934-8e896980-cc67-11eb-9f8e-4988755adcfd.png)

PE file download over HTTP.  

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/121822936-8fba9680-cc67-11eb-9af8-8b2f8a29495f.png) 

IDS alerts generated around PE file download activity.  