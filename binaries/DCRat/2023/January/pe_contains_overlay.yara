import "pe"

rule pe_contains_overlay {
    meta:
        description = "Rule to detect overlay in a PE file."
        author = "@jstrosch"
        date = "2023-01-02"
    condition:
       uint16(0) == 0x5a4d and pe.overlay.size > 0
}