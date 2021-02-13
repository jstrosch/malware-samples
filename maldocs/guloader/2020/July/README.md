# Excel Document Drops GuLoader

XLS MD5: 488543905f161a9a35434299ad6474c6.bin  
GuLoader MD5: 60a9b70b70e03fd55c455fb5481cd7ff_far.msi.bin
Additional Artifact MD5: ac1700c1ae89dfa43f6b160866be50b8_Host_doxJdsggH87.bin  
PCAP: af8ac4ce4e513e74c96d16536848fbc1.pcap   

* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: Cuckoo 2.0.7  
Date: 06/07/2020  
Additional Resources: [Any.Run](https://app.any.run/tasks/4d87db9b-ffc3-4fca-9314-6b3106f3dbcc)  

This sample highlights an Excel document that drops GuLoader with follow-up C2.   

## Process Activity

![Process Activity](https://user-images.githubusercontent.com/1920756/87897862-3bd10e80-ca12-11ea-81d3-c8c4504c6ba6.png)  
Process activity from maldoc (xls)

![Process Activity](https://user-images.githubusercontent.com/1920756/87897866-3d023b80-ca12-11ea-9d78-07856df92c78.png)  
Process activity from a later date from far.msi (19 July 2020) - originally downloaded from far1.[ru]

## Network Activity

![Malware Check-In](https://user-images.githubusercontent.com/1920756/87897945-733fbb00-ca12-11ea-864c-9666d19edb32.png) 

HTTP request to download Guloader and follow-on C2 to weneedthisbar.[us]

## Suricata Alerts

![Suricata Alerts](https://user-images.githubusercontent.com/1920756/87897948-7470e800-ca12-11ea-8a63-0c2b0d2d9d0b.png)  
Alerts from July 19 run  