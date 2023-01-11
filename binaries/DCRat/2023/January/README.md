# YouTube Video: The Basics of Overlays in PE Files

[YouTube - The Basics of Overlays in PE Files](https://youtu.be/pUjBJ4m7tUI)

Sample (SHA256): 294a15b8d5df132b50a68c5ac19a6c7aafc8b051983a28e7bf182bff6aa2ef15.exe.bin  
Extracted Overlay: overlay.bin  
Python script to decompress zlib: zlib_decompress.py  
YARA rule for overaly detection: pe_contains_overlay.yara  
   
* See the [README](https://github.com/jstrosch/malware-samples) for information about the archive password.  

Analysis source: [Malware Bazaar](https://bazaar.abuse.ch/browse.php?search=sha256%3A294a15b8d5df132b50a68c5ac19a6c7aafc8b051983a28e7bf182bff6aa2ef15)  
Recording date: 2023-01-02  

This sample highlights overlays in PE files. In this video, I'll cover the basics of overlays, how to detect them using Detect-It-Easy and PEStudio, and create a very simple Yara rule. The sample is DCRat and the overaly contains a RAR file.

## YARA Rule for Detecting Overlays
    import "pe"

    rule pe_contains_overlay {
        meta:
            description = "Rule to detect overlay in a PE file."
            author = "@jstrosch"
            date = "2023-01-02"
        condition:
            uint16(0) == 0x5a4d and pe.overlay.size > 0
    }