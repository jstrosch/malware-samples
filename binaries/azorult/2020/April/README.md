# Azorult drops Blackout Ransomware

Azorult: 32729bc1f7efd35547b28f2367834827.bin  
PCAP:  32729bc1f7efd35547b28f2367834827.pcap  
Blackout Ransomware: 4ada86ccdf981494d4142eec6b9ccf04.bin  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Any.Run: [Any.Run](https://app.any.run/tasks/c58ae060-8cf2-4535-a16c-0715809fdd03)  
Date: 04/13/20 

This sample highlights Azorult process activity along with a successful check-in to it's panel and dropping of Blackout ransomware. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/79133793-3b214000-7d72-11ea-99a4-95dd899a440a.png)

Process activity from the Azorult binary, which launches Blackout ransomware (US-2020-20-03-16-18-40-0569324B-9414737A-3C853917-C61460EF-C4978359.com).

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/79133881-60ae4980-7d72-11ea-9578-d687e616915d.png)  
POST requests for check-in followed by GET request for Blackout

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/79134035-a8cd6c00-7d72-11ea-995d-c203acf723ab.png)  
Suricata alerts using Emerging Threats Open and Abuse.ch rulesets

## Ransom Payment Page

![Blackout](https://user-images.githubusercontent.com/1920756/79134069-b71b8800-7d72-11ea-9f68-4b0615d24364.png)