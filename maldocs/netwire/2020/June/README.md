# Excel drops Netwire - Sample 1

Excel MD5: a17e5c6d0278bc25eb69a5b39a902372.bin  
Trojan MD5 (extracted from network traffic): 9b0542b9f5f4f3410ed6013415091631.bin    
PCAP (Any.Run): a50361932dafc87f21afd7b985f20bcb.pcap  
Analysis on [Any.Run](https://app.any.run/tasks/dc578a10-b87a-4154-9b44-dee6627da3fd/)  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Any.Run 
Date: 06/26/2020 

This sample highlights an Excel document that downloads a PowerShell script and then an obfuscated PE file (netwire trojan).  

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/86078364-90a4e900-ba53-11ea-8089-ecd7a33d2c66.png)

Process activity from the maldoc.

## Network Activity

![PowerShell Download](https://user-images.githubusercontent.com/1920756/86078367-91d61600-ba53-11ea-93f6-063940432c52.png)

PowerShell script download, responsible for retrieving the encoded/obfuscated PE file.  

![PE Download](https://user-images.githubusercontent.com/1920756/86079590-702a5e00-ba56-11ea-99ab-73e5fcddd417.png)  

PE file was hex-encoded with arbitrary characters for obfuscation.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/86078369-939fd980-ba53-11ea-9bc0-c986290eeadc.png)  
Subset of Suricata alerts using Emerging Threats Open and Abuse.ch rulesets

# Excel drops Netwire w/ C2 check-in - Sample 2

Excel MD5: 3270afb6349ded4b3adeb82aab1a2fa6.bin  
Trojan MD5 (extracted from network traffic): ef86e680b9b0f9d2b678c2bac63ee78a.bin    
PCAP (Any.Run): 69af1f8a78a329fd50a3fc444322532b.pcap  

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/86079855-1aa28100-ba57-11ea-80d1-075ae4720540.png)

## Network Activity

![HTTP Requests](https://user-images.githubusercontent.com/1920756/86079859-1c6c4480-ba57-11ea-858b-267a937d7ba3.png)  

HTTP requests for PowerShell scripts along with a hex-encoded PE file  

![C2](https://user-images.githubusercontent.com/1920756/86079862-1d9d7180-ba57-11ea-83f8-27c36227781c.png)

Beaconing activity

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/86079865-1ece9e80-ba57-11ea-9d56-b89f15c306b1.png)  
Suricata alerts using Emerging Threats Open, TGI Hunt and Abuse.ch rulesets