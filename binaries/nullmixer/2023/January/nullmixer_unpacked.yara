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