# IcedID with Stego Image

MD5: 5009b8bcf024704c8b23e42c492f118c.bin   
PCAP: 5009b8bcf024704c8b23e42c492f118c.pcap  
background.png MD5: 4804ce83d53805f0702edfc8cb5ebf93  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 06/01/2020  
Additional Reference: [https://twitter.com/James_inthe_box/status/1267547638456442882](https://twitter.com/James_inthe_box/status/1267547638456442882)  

This sample highlights IcedID activity along with an image used for steganography (background.png). The request for the background image was made over an HTTPS connection and therefore not visible in the PCAP. I've added the image to the repository though. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/83924424-44170800-a74a-11ea-8011-c78df9960e23.png)

Limited process activity from the main IcedID binary.

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/83924475-64df5d80-a74a-11ea-93dd-89832f4540c2.png) 

HTTP GET request to hxxp://gegemony4you.top, which includes additional HTTP request to same domain for background.png.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/83924482-66108a80-a74a-11ea-9355-8103651d630f.png)  
Subset of Suricata alerts using Emerging Threats Open and Abuse.ch rulesets