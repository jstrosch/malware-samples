[![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/blackhacker)

<p align="center">
 <img src="https://e.top4top.io/p_1759cl1t61.png" alt="" />
</p>

<p align="center">
 <a href="#"><img align="center" src="https://img.shields.io/maintenance/no/2020" /></a>
 <a href="#"><img align="center" src="https://img.shields.io/github/license/FarisCode511/BlackNET" /></a>
 <a href="#"><img align="center" src="https://img.shields.io/github/languages/top/FarisCode511/BlackNET" /></a>
 <a href="#"><img align="center" src="https://badgen.net/badge/color/awesome/pink?icon=awesome&label" /></a>
 <a href="#"><img align="center" src="https://img.shields.io/github/v/release/FarisCode511/BlackNET" /></a>
 <a href="#"><img align="center" src="https://img.shields.io/github/repo-size/FarisCode511/BlackNET" /></a>
</p>

---

# BlackNET 😈
Free advanced and modern Windows botnet with a nice and secure PHP panel developed using VB.NET.

## About BlackNET 🤓
Free advanced and modern Windows botnet with a nice and secure PHP panel built using VB.NET.

this botnet controller comes with a lot of features and the most secure panel for free

Developed By: Black.Hacker

## What You Can Do 💪
 1. Upload File
    + From URL
    + From Disk
 2. DDOS Attack [ TCP,UDP,ARME,Slowloris, HTTPGet, POSTHttp, Bandwidth Flood ]
    + Start DDOS
    + Stop DDOS
 3. Open Webpage
    + Visible
    + Hidden
 4. Show MessageBox
 5. Take Screenshot
 6. Steal Firefox Cookies
 7. Steal Saved Passwords
    + Chrome
    + Firefox
    + NordVPN
    + FileZilla
    + Outlook
 8. Steal Chrome Cookies
 9. Steal Discord Token
 10. Steal Clipboard Data
 11. Execute Shell Commands
     + CMD (Command Prompt)
     + Powershell
 12. Send Spam Emails
 13. Run XMR Miner
 14. Seed a Torrent File
     + From Disk
     + From URL
 15. Keylogger
 16. Execute Scripts
 17. Execute Custom Plugins
 18. Computer Operations
     + Restart
     + Shutdown
     + Logout
 19. Bitcoin Wallet Stealer
 20. Uninstall Client
 21. Move Client
 22. Blacklist Client
 23. Update Client
 24. Close Client

## Requirements ⚡️
1. PHP >=  7.3
2. NET Framework
    + Stub >= 4.5
    + Builder >= 4.5

## How to Install 🤔
1. Pull the repo or Download the latest release
2. Compress BlackNET panel folder and upload it to your hosting
3. Create a database with any name you want
4. Change the database information in config/config.php
5. Change the "Panel URL" with your url in config/config.php
6. Change all files and folders permission to 777
7. Make Sure that all dependencies are included in "plugins" folder
   + FileSearcher.dll
   + PasswordStealer.dll
   + PluginExample.dll
   + xmrig.exe
8. Go to install.php fill-up the form and click install
9. Create a cron job for ping.php and remove.php

## Update notice 📌
If you have BlackNET installed you need

#### WARNING: BEFORE UPDATING PLEASE MAKE A COPY OF YOUR DATABASE OR YOU WILL LOSE YOUR CLIENTS

1. Make a copy of config.php
2. Upload the new files
3. Update the new config.php
4. Run update.php

## How to secure BlackNET 🔒
1. Remove install.php and update.php
2. Enable Captcha using Google reCaptcha v3
3. Enable 2FA on your account
4. Add a security question

## How to use the File Searcher Function 🔍
1. execute "Get file fom the system" command on the client
2. use this pattern ``` %Userprofile%|[Here write extension list] ```
3. Wait until the plugin finish the process and upload the files

Pattern Example:
```
%Userprofile%|[jpg,png,docx,pdf,logs,txt,pptx,psd,rtf]
```

## 000Webhost notice 🛑

Please use [Unzipper.php](https://github.com/ndeet/unzipper) to extract the panel files inside 000webhost filemanager

## Documentation 📖

If you want to develope or reuse the panel you can take a look at the code document to understand some of the functions and how to use them

### [Documentation](https://fariscode511.github.io/BlackNET/)

## Screenshots 🌌

![](https://d.top4top.io/p_1761hwi5l1.png)

![](https://i.imgur.com/3T4CRDk.gif)

![](https://j.top4top.io/p_1738jsi5f2.png)

![](https://j.top4top.io/p_1806nyr9c1.png)

## YouTube Tutorials 📹
[How to install BlackNET v3.7.0](https://youtu.be/0IU_64yfL80)

[How to obfuscate BlackNET](https://www.youtube.com/watch?v=hzC8_UYGor0)

[How to Setup BlackNET Cron Job System](https://www.youtube.com/watch?v=rHCYGRA1h54)

[How to Secure BlackNET Panel](https://www.youtube.com/watch?v=P6dBDr9iCD8)

## What's New 🆕

```
v3.7
  1. Added more Charts and Stats
  2. Updated the stub .NET Framework to 4.5
     + Fixed a lot of HTTP Socket Issues and Stabilty
     + More room for new features
  3. Fixed Discord Stealer
  4. Added PHPSpreadsheet
     + Export Logs to Excel file insted of CSV
  5. Fixed "Stop DDoS" Bug
  6. Fixed "Take Screenshot" Bug
  7. Fixed "Delete Files" Bug
  8. Fixed "Installed Softwares" Bug
  9. Fixed Self Destruction Bug
  10. Added Code Documentation for Developers
  11. Added GPU and CPU information
  12. Added RAM Size Information
  13. Added DropBox Spread
  14. Added OneDrive Spread
  15. Added Downloader with Multiple Links
  16. Added XMR Miner
  17. Added Export Passwords to Excel
  18. Added Client Files Backup Function
  19. Added Torrent Seeder
  20. Added Disable Windows Defender
  21. Added Protect with Critical Process
  22. Added Modules Support
  23. Keylogger Start On Run [Optional]
  24. Modified File Binder
      + Support Multiple Files
  25. Added "Client Information" Page
      + Export Client Informtion to Excel
  26. Fixed 000webhost issue [ Tested ]
  27. Updated BlackNET Builder to .NET 4.5
  28. Redesigned the Builder
  29. Modified the Password Stealer
      + Doesn't require Newtonsoft.Json.dll
  30. Modified the File Searcher
      + Doesn't require Ionic.zip.dll
  31. Modified the Icon Changer
  32. Modified "Schedule Task" Function
  33. Removed Chrome History Stealer
  34. Cleaner Code and File Structure
  35. Cleaner Database Structure
  36. Simple Template Engine to handle layouts
  37. The panel now depends on Composer
  38. Code Refactored with the standard PSR-12
  39. Updated PHPMailer to 6.2.0
  40. Updated BlackUpload to v1.5.2
  41. Secrity Enhancement
  42. Small UI changes
  43. Small Installation Changes
  44. Improved Connection Speed
  45. Bug Fixes
```

## Used Code 🔧
| Developer       | Used Code    | Used For      |
| :-------------: | :----------: | :-----------: |
| KFC Watermelon  | PlasmaRAT    | BlackNET DDoS |
| NYANxCAT        | LimeLogger   | Keylogger     |
| 0xfd            | Chrome Retriver| Chrome Stealer|
| LimerBoy        | JSONReader   | Firefox Stealer | 
| Amadeus         | XMR Miner    | XMR Miner       |

## Used Libraries 🤖
1. PHPMailer
2. Google reCaptcha
3. PHPSpreadsheet
4. Google Authenticator
5. GeoIP2

## LEGAL DISCLAIMER PLEASE READ! 🛑
##### I, the creator and all those associated with the development and production of this program are not responsible for any actions and or damages caused by this software. You bear the full responsibility of your actions and acknowledge that this software was created for educational purposes only. This software's intended purpose is NOT to be used maliciously, or on any system that you do not have own or have explicit permission to operate and use this program on. By using this software, you automatically agree to the above.

## License ⚖️
This project is licensed under the MIT License

## Copyright ©️
[![Open Source Love svg1](https://badges.frapsoft.com/os/v1/open-source.png?v=103)](https://github.com/ellerbrock/open-source-badges/) [![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FFarisCode511%2FBlackNET.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FFarisCode511%2FBlackNET?ref=badge_shield)

Copyright © Black.Hacker - 2021
