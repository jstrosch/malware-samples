# YouTube Video: OneNote Malware Trends - Investigating Script Execution that Leads to QuakBot 

[YouTube - OneNote Malware Trends - Investigating Script Execution that Leads to QuakBot](https://youtu.be/POlBtcMdau8)   

Sample (ec674e92a9d108d67d2cc0f1f2d20579a8ca8ba6e32af1fe0ed8a1067a426586): qbot.one  
Powershell script: script.ps1  
Qbot payload DLL (476e834197ac6cd3080059d86a8a2a49e31212ed75e0d68e4e21fcc3bc6b1d8b): 187737.dat    
   
* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: [Malware Bazaar](https://bazaar.abuse.ch/sample/15212428deeeabcd5b11a1b8383c654476a3ea1b19b804e4aca606fac285387f/)  
Recording date: 2023-02-17  
Tools covered: onedump.py, OneNote, batch files, CyberChef, Yara, Powershell, Process Monitor     

As OneNote documents continue to plague organizations, I decided to take a look at yet another document, this one leads to a qbot (quakbot) infection. In this video, we'll use ProcMon and Process Hacker 2 to learn more about the process activity around OneNote documents. We'll then use Onedump to extract the script and decode it. Finally, we'll talk briefly about the DLL that is downloaded that leads to the qbot infection.