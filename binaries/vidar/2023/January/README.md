# YouTube Video Series: Getting Started with Detect-It-Easy, Identifying Signs of Packing, Unpacking Vidar Stealer with Time-Travel Debugging 

[YouTube - Getting Started with Detect-It-Easy (DIE): Investigating a Stealer](https://youtu.be/FB_e1mIhykk)  
[YouTube - Identifying Signs of Packing in VIDAR Stealer with IDA Pro](https://youtu.be/pEjcmJRa7T8)  
[YouTube - Unpacking VIDAR using Time-Travel Debugging (TTD) in WinDbg Preview](https://youtu.be/HcyCZPNO3qI)  

Sample (2cc0be582a350f1eafb6d3c6cc713393098a6936346a9070ba55abd346dfb090): vidar.exe  
Unpacked Sample (fb1133fa33ab62f49babfa38db37d07927a05ff7f8f7b50accdc2b75fb99aa25): vidar_unpacked.exe
WinDbg TTD Trace: vidar01.idx, vidar01.out, vidar01.run  
Yara rule for detecting unpacked sample: vidar_unpacked.yara  
   
* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: [Malware Bazaar](https://bazaar.abuse.ch/browse.php?search=sha256%3A2cc0be582a350f1eafb6d3c6cc713393098a6936346a9070ba55abd346dfb090)  
Recording date: 2022-12 to 2023-01  
Tools covered: Detect-It-Easy, PEStudio, IDA Pro, WinDbg Time-Travel Debugging, Yara  

These videos cover several tools using a Vidar Stealer sample. The focus in on getting comfortable using these tools while looking for signs of packing. Time-Travel Debugging (TTD) is also introduced and the corresponding trace files added here. Finally, there is a Yara rule designed to detect the unpacked stealer.

## YARA Rule for Detecting Overlays
    rule vidar_stealer_unpacked {
        meta:
            description = "Detects the unpacked Vidar binary."        
            author = "@jstrosch"
            date = "2023-01-07"
            reference_md5 = "7b419724d28a464fa3ccead029201e05"

        strings:
            /*
                83 E4 F8                and     esp, 0FFFFFFF8h
                E8 75 43 FF FF          call    sub_40107B
                E8 70 43 FF FF          call    sub_40107B
                E8 6B 43 FF FF          call    sub_40107B
                E8 D1 43 FF FF          call    sub_4010E6
                E8 BF D8 00 00          call    sub_41A5D9
                E8 E1 42 FF FF          call    sub_401000
                E8 A3 FF FF FF          call    sub_40CCC7
                E8 9E FF FF FF          call    sub_40CCC7
                E8 99 FF FF FF          call    sub_40CCC7
                E8 3D F9 FF FF          call    sub_40C670
                33 C0                   xor     eax, eax
            */

            $c1 = {
                83 E4 F8
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                E8 [4]
                33
            }

        condition:
            uint16(0) == 0x5a4d and $c1
    } 