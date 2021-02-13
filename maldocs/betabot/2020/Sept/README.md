# Word doc drops Betabot (Uses CVE-2017-11882)

Word: 5f2cbc4f89826b9fcb345fa947ea1957.doc.bin  
PCAP: 5f2cbc4f89826b9fcb345fa947ea1957.pcap  
Dropped EXE (betabot): 79afa994e75a30118512e2a079c859b1_div.exe.bin

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Maldoc - [Any.Run](https://app.any.run/tasks/cc2fd9b0-647a-4fb7-a543-c3f3f0cee634)  
Betabot (div.exe) - [Any.Run](https://app.any.run/tasks/feed5ffa-7d48-400e-bba0-e5a7906a5a55/)    
Date: 09/17/2020  

Word document drops betabot via CVE-2017-11882

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/97782617-89f0c480-1b60-11eb-9b1f-df143ec70afd.png)

Process activity from the Word document, highlights CVE exploitation.

## Network Activity

![Payload download](https://user-images.githubusercontent.com/1920756/97782626-97a64a00-1b60-11eb-9f0e-7375a1cd23dd.png)

HTTP request to download the trojan - div.exe. Download is over HTTP.  

## Suricata Alerts

![Suricata alerts](https://user-images.githubusercontent.com/1920756/97782642-aee53780-1b60-11eb-80cb-09cfccfaf9c2.png)

No IDS alerts were generated.  