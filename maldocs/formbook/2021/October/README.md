# Excel drops Qakbot (qbot) DLL

Word: 5949085c9f589beb144d3754ac2e31a0.bin  
PCAP: 0d66b622f28d032a6feddaf55b083198.pcap  
Dropped EXE (formbook): 9c9a99423087bdfd23df04a29984273ba056021ee54e815d2cd85103a9548eff_9c9a99423087bdfd_audio  

Analysis source: Cuckoo 2.0.7  
Date: 10/15/2021    

Word document that downloads Formbook and executes via *powershell*.

## Maldoc template

![template](https://user-images.githubusercontent.com/1920756/139555119-e5e741a8-fbf0-448e-88bc-562cbd20b11e.jpg)

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/139555140-7e9eff9d-816d-4d75-8b27-a3a8da6bba65.png)

Process activity from the Word document, powershell is used to download and execute the payload.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/139555171-b1268724-949e-4d3d-87d3-5790de299081.png)

HTTP request to download the trojan as an EXE file.  

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/139555178-52dffe94-2115-4bb5-886a-3091e60cd152.png) 

Alerts indicating suspicious activity around the download of an PE file.