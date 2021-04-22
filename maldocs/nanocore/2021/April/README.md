# Word Document Uses Template Injection that downloads an RTF Document, Exploits CVE-2017-11882 to Drop Nanocore

Word (macroless document) - c16b38ae42a9c32ba01ccd93bd90efceb4df05adb997b179758844e2d7d9b8c1_nd.docx (MD5: )0fa0fc8e801d4228a50ec62e2f4d7396:  
PCAP: 9ea200759d2de125d337723455fb84682c1be5b7399c9719624c45f9533f1e5d_dump.pcap  
RTF Document: nt.dot (MD5: 8bf656a930d62170864950522b5cd0c0)  
Nanocore Trojan: nd.exe (MD5: )  bd0d18125966f176e6ade8488bf1972d 

Analysis source: Cuckoo 2.0.7  
Date: 04/20/2021    

Word document uses template injection to download an RTF document to utilize CVE-2017-11882 to drop Nanocore.  

## Maldoc template Injection

![template](https://user-images.githubusercontent.com/1920756/115650894-bb687280-a2ef-11eb-82f5-429b40c20693.png)  

The target attribute is set to *hxxp://doctor.hopto[.]org/torotoro/nd.dot*, which downloads the RTF document when the original maldoc is opened. The URL is found in *webSettings.xml.rel* in *word/_rels/*.

## Network Activity

![Malware Download](https://user-images.githubusercontent.com/1920756/115650857-ab509300-a2ef-11eb-98b8-49af987b471b.png)  

Network activity to download the template file, followed by a download of the trojan (nd.exe).  

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/115650861-ac81c000-a2ef-11eb-8e51-0bd5a6593d34.png) 

Alerts indicating suspicious activity around the download of an PE file.