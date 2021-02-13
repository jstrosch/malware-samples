# Word document drops Dridex DLL w/ Check-In

Word: 47e15fb96cffb8180f686aa4c824cfdd.bin  
PCAP: 47e15fb96cffb8180f686aa4c824cfdd.pcap  
Dropped DLL (Dridex): t6yswb.pdf_770df303f86ac191c177035c214589ee.bin  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Additional analysis on Any.Run: [https://app.any.run/tasks/2e4fad01-06ca-4e75-b857-bdc62dff5bc4/](https://app.any.run/tasks/2e4fad01-06ca-4e75-b857-bdc62dff5bc4/)
Date: 11/24/2020 

Word document that drops Dridex dll from *rasadbar[.]ir* with a *.pdf* extension. DLL payload is returned unobfuscated. 

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/100494846-58d9c480-310b-11eb-84f1-57d2bb1cf9ff.png)

Macros are used to execute several processes - one is an instance of cmd.exe to show a message box indicating an error has occurred trying to open the document. Powershell is then used to decode a base64 encooded script to download the DLL and execute via an instance of rundll32.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/100494881-cab20e00-310b-11eb-9c72-2594febfa5f3.png)

HTTP request to download the trojan - the file requested was purpotedly a PDF (note the file extension) but a PE file was returned.

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/100494900-f7662580-310b-11eb-833d-c10e750f8108.png)  

Several IDS alerts were generated around the download of the PE file, along with TLS and JA3 alerts. 

![Chech-In](https://user-images.githubusercontent.com/1920756/100494931-37c5a380-310c-11eb-9419-dc96b60baccd.png)

JA3 hash alerted on potential check-in traffic to 162.241.44.26 over port 9443 and 192.232.229.53 over port 4443.

![Suspicious Certs](https://user-images.githubusercontent.com/1920756/100495018-dc47e580-310c-11eb-8e68-cd2000b6f744.png)

![Suspicious Certs](https://user-images.githubusercontent.com/1920756/100495005-c9351580-310c-11eb-8db2-f3daf04ce475.png)