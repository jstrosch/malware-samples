# Excel drops Qakbot (qbot)

Excel: 81d0041ad1915cb72440b47e512fffb0.xls.bin  
PCAP: 81d0041ad1915cb72440b47e512fffb0.pcap  
Dropped EXE (qbot): 336aaae4fa380c66834c8665172cf179.bin  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Maldoc - [Any.Run](https://app.any.run/tasks/cc2fd9b0-647a-4fb7-a543-c3f3f0cee634)  
Date: 10/29/2020    

Excel document that drops Qakbot

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/97782237-66c51580-1b5e-11eb-8419-b1b8f220ec83.png)

Process activity from the Excel document.

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/97782243-6f1d5080-1b5e-11eb-882d-bf51495c6680.png)

HTTP request to download the trojan, obstensibly as a GIF file. The connection was over TLS, the payload will be encrypted in the PCAP.  

## Maldoc Template

![Maldoc Template](https://user-images.githubusercontent.com/1920756/97782293-b4da1900-1b5e-11eb-8f5f-b9595206ce82.jpg)

Maldoc template does not use an image but instead relies on text.

## Suricata Alerts

No IDS alerts were generated.  