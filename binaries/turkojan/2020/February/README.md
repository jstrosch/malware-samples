# Turkojan

MD5: 53aa23b5ca5a46a7af7d15404fb80170  
PCAP: 53aa23b5ca5a46a7af7d15404fb80170.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 02/12/2020  

This sample highlights Turkojan activity along with client side network traffic. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/74487535-557b9200-4e85-11ea-8a18-d785b83b6608.png)

Process activity from the Turkojan binary.

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/74487549-5b717300-4e85-11ea-966e-a6d631d91653.png)  
Traffic over port 8080 for C2 check-in, note that this sample does not use HTTP.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/74487573-6a582580-4e85-11ea-8d51-271e3961d15d.png)  
Suricata alerts using Emerging Threats Open and Abuse.ch rulesets