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