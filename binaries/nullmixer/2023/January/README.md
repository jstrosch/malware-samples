# YouTube Video Series: Investigating NullMixer -  Identifying Packing Techniques, Identifying and Unraveling ASPack, and Investigating Network Traffic with Suricata and Evebox.

[YouTube Video 01: Investigating NullMixer - Identifying Initial Packing Techniques ](https://youtu.be/92jKJ_G_6ho)  
[YouTube Video 02: Unpacking NullMixer - Identifying and Unraveling ASPack](https://youtu.be/yLQfDk3dVmA)  
[YouTube Video 03: Investigating NullMixer Network Traffic: Utilizing Suricata and Evebox](https://youtu.be/v_K_zoPGpdk)  
[YouTube Video 04: Detecting Nullmixer with Yara - Crafting a Custom Rule](https://youtu.be/zyyp4P5dGR8)  
[YouTube Video 04: NullMixer Network Detection - Crafting Custom IDS Rules with Suricata](https://youtu.be/M03AVdfFZsA)  

Initial sample (7a4df2fc82c0b553d0b703f51635fd62cf02553706f942c66d752c1d8fae207b): nullmixer.bin  
Packed NullMixer binary (168dbf26faebd7278b121d4f071003c31db12dfd51910d8f924b03bb43a9ca03): setup_install.exe  
Dumped NullMixer: setup_install_dump_SCY.exe  
PCAP from Triage: nullmixer_internet.pcapng  
Additional payloads and libriaries included.  
   
* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: [Malware Bazaar](https://bazaar.abuse.ch/sample/7a4df2fc82c0b553d0b703f51635fd62cf02553706f942c66d752c1d8fae207b/)  
Recording date: 2023-01
Tools covered: IDA Pro, x32dbg, Scylla, NSIS, 7z, Yara, Suricata, EveBox     

Video 01 will be the first of a multi-part series in which we take a look at unraveling the basics of how NullMixer works. In the first video, we'll explore the initial layers of how NullMixer is delivered, which includes NullSoft Self-Extracting installer and 7zip self-extracting archives. We'll use tools such as Detect-It-Easy and simply 7z commands to unravel the first stages. By the end of this video, we'll identify the main payloads and the binary responsible for executing them.

Video 02 will complete our first-look analysis of NullMixer by unpacking the main binary, which uses ASPack. We'll discuss some common unpacking patterns in the code using IDA Pro, then switch to x32dbg to perform the unpacking. 

Video 03 will cover the inspecting network traffic can often give you unique insight into the malware you are investigating. in this video, we'll take a look at network traffic from our NullMixer sample and use Suricata to generate IDS alerts. We'll also take advantage of the light weight UI called Evebox, which allows us to easily navigate through Suricata's output - which includes more than just the network alerts. 

## YARA Rule for Detecting Unpacked Binary

    rule nullmixer_unpacked {
        meta:
            description = "Detects unpacked Nullmixer"
            author = "@jstrosch"
            date = "2023-02-04"
            sample = ""

        strings:
            $s1 = "&oname[]="
            $s2 = "report_error.php?key="
            $s3 = "addInstall.php?key="
            $s4 = "addInstallImpression.php?key="
            $s5 = "No-Exes-Found-To-Run"
            $s6 = "_1.txt"

        condition:
            uint16(0) == 0x5a4d and 5 of them
    }

## Suricata Rule for Nullmixer Check-In

    alert http $HOME_NET any -> $EXTERNAL_NET any (msg:"Nullmixer Check-In"; \
    flow:established,to_server; \
    http.method; content:"GET"; \
    http.uri; content:"addInstall.php?key="; content:"&oname[]="; content:"&cnt="; content:!"Referer"; \
    classtype:command-and-control; sid:10000001; rev:1; metadata:affected_product Windows_XP_Vista_7_8_10_Server_32_64_Bit, attack_target Client_Endpoint, created_at 2023_02_06, deployment Perimeter, malware_family NullMixer, signature_severity Major;)

