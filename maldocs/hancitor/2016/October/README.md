# Hancitor Maldoc

MD5:  b107f3235057bb2b06283030be8f26e4   
PCAP:  b107f3235057bb2b06283030be8f26e4.shellcode   

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source (Tria.ge): https://tria.ge/reports/200317-pt9rcrh1l2/behavioral1  
Date: n/a  

This sample highlights Hancitor maldoc activity (string "starfall"). 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/76962513-5d4bad80-68ed-11ea-94c4-fe5427394b9f.png)

Process activity, which highlights the process hollowing technique.

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/76962551-6d638d00-68ed-11ea-9df8-540d9244ead1.png)  
Attempts to obtain host IP address using an IP look-up service.

![DNS](https://user-images.githubusercontent.com/1920756/76962611-8c621f00-68ed-11ea-8049-2b1ce1566332.png)

Attempts to resolve several domains, which are long since dead :)

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/76962652-9dab2b80-68ed-11ea-8568-a39cb0b51a27.png)  
Suricata alerts using Emerging Threats Open and Abuse.ch rulesets