# Word doc w/ embedded Hancitor loader, IP check and C2 activity

Word MD5: e688ebdab6916fc89610c89ccb94ce16.bin    
PCAP (Any.Run): e57d44fd470e7364a235353ded942f0f.pcap  

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7
Date: 01/15/2021  

This sample highlights an Word document with embedded Hancitor loader. Check-in is performed but no further download instructions were received. 

## Maldoc Template

![Image](https://user-images.githubusercontent.com/1920756/106373744-3dc14600-6342-11eb-9a33-8c175857d3c4.jpg)

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/106373693-c4295800-6341-11eb-8bab-1fad36fd712b.png)

Process activity from the maldoc - 6.pif is an embedded EXE that is written to the file system and executed.

## Network Activity

![HTTP Traffic](https://user-images.githubusercontent.com/1920756/106373695-c55a8500-6341-11eb-9a1d-e08ab840acd4.png)  

IP check followed by C2 check-in

