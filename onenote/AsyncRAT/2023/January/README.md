# YouTube Video: OneNote Malware - Tips and Tricks for Investigating OneNote Malware Used to Deliver AsyncRAT 

[YouTube - OneNote Malware: Tips and Tricks for Investigating OneNote Malware Used to Deliver AsyncRAT](https://youtu.be/kK6Tsmr_wCY)   

Sample (15212428deeeabcd5b11a1b8383c654476a3ea1b19b804e4aca606fac285387f): 15212428deeeabcd5b11a1b8383c654476a3ea1b19b804e4aca606fac285387f.one  
batch file w/ AsyncRAT (d329a265d4005b2cb8902d6148ff5e4477f2203bc2e476e51e5895f9be99c53e): sky.bat    
Yara rule for detecting unpacked sample: malicious_onenote.yara  
   
* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: [Malware Bazaar](https://bazaar.abuse.ch/sample/15212428deeeabcd5b11a1b8383c654476a3ea1b19b804e4aca606fac285387f/)  
Recording date: 2023-01-23  
Tools covered: onedump.py, OneNote, batch files, CyberChef, Yara   

Threat actors and red teams alike are always looking for, and finding, creative ways to gain initial access. Such is the case with the recent surge in the use of Microsoft OneNote files. Similar in purpose to macro-enabled office documents, OneNote files allow the embedding of scripting technology to run arbitrary commands and gives the ability to drop or download malicious programs. In this video, we'll take a look at a recent OneNote file to investigate it's structure. We'll use some recent developed tools available on Github and discuss techniques for crafting a Yara rule. We'll then deobfuscate a batch file that contains the encrypted payload. By the end of this video you'll have a better understanding of how OneNote file are being abused, how to detect and investigate them, and pick up a few techniques for unraveling a BAT file!

## YARA Rule for Detecting Overlays
    rule malicious_onenote {
        meta:
            author = "@jstrosch"
            description = "Detects malicious onenote files"
            date = "2023-01-21"

        strings:
            $hta = "hta:application" nocase
            $hta_script = "type=\"text/vbscript\""
            $hta_open = "autoopen" nocase

        condition:
            uint32be(0x0) == 0xE4525C7B
            and 2 of them
    }