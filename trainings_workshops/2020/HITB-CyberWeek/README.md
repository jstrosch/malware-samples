# Hack-in-the-Box CyberWeek - November 19th, 2020 - Workshop: Analyzing Malicious Word and Excel Documents

Workshop available on YouTube: [https://youtu.be/_rlEpPwSIoc](https://youtu.be/_rlEpPwSIoc)

## Overview

Malicious office documents continue to be an effective tool for threat actors to compromise their victims and gain access to an organization’s network. While these documents have been around for a while, malware authors continue to find effective ways of abusing functionality to minimize their detection. This year alone we have seen a resurgence of such techniques through the use of Excel 4 Macros and other creative ways to bypass detection. In this workshop, we will get hands-on with the latest Office-based threats to understand how they work, how to detect them and identify indicators of compromise. You will learn the tools and techniques to extract macros, tackle obfuscation and debug the code. This workshop will take you deep into malicious office documents and the tools required to analyze them so that you can better defend your organization and it’s users.

## Key Learning Objectives

* Learn the tools and skills needed to perform analysis on malicious office documents, such as the Office IDE, oledump, olevba, xlmdeobfuscator, sandboxes and more
* Leverage static and dynamic tools to develop a hybrid approach for effectively analyzing malware, defeating obfuscation and identifying important indicators of compromise
* Learn how to leverage network traffic to gain a deeper understanding of malware behavior

## Topics Covered

Hour 1:

* Introduction to Lab VMs
* Discuss Office Documents
* Introduce tools and workflow
* Lab: Analyzing an Emotet Dropper

Hour 2:

* Identifying obfuscation patterns
* Using the Office IDE for debugging
* Lab: Dynamic Analysis

Hour 3:

* Dissecting Excel documents
* Working with Excel 4 macros
* Identifying other methods of executing content
* Lab: Reversing Excel-based Malware

Hour 4:

* Process hollowing
* Other advanced techniques
* Lab: Tracing Windows API and Extracting Shellcode