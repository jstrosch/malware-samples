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