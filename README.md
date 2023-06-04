[![GitHub release][release-img]][release]
[![License][license-img]][license]
![Downloads][download]


<img src="https://github.com/cyberark/PipeViewer/blob/assets/pipeviewer_logo.png" width="260">   
A GUI tool for viewing Windows Named Pipes and searching for insecure permissions.  

The tool was published as part of a research about Docker named pipes:   
["Breaking Docker Named Pipes SYSTEMatically: Docker Desktop Privilege Escalation – Part 1"](https://www.cyberark.com/resources/threat-research-blog/breaking-docker-named-pipes-systematically-docker-desktop-privilege-escalation-part-1)   
["Breaking Docker Named Pipes SYSTEMatically: Docker Desktop Privilege Escalation – Part 2"](https://www.cyberark.com/resources/threat-research-blog/breaking-docker-named-pipes-systematically-docker-desktop-privilege-escalation-part-2)   

## Overview
PipeViewer is a GUI tool that allows users to view details about Windows Named pipes and their permissions. It is designed to be useful for security researchers who are interested in searching for named pipes with weak permissions or testing the security of named pipes. With PipeViewer, users can easily view and analyze information about named pipes on their systems, helping them to identify potential security vulnerabilities and take appropriate steps to secure their systems.

## Usage

Double click the EXE binary and you will get the list of all named pipes.   

## Warning  
We built the project and uploaded it so you can find it in the releases.  
One problem is that the binary will trigger alerts from Windows Defender because it uses the NtObjerManager package which is flagged as virus.  
Note that James Forshaw talked about it [here](https://youtu.be/At-SWQyp-DY?t=1652).  
We can't change it because we are depend on third party DLL.  

## Features
* A detailed overview of named pipes.
* Filter\highlight rows based on cells.
* Bold specific rows.
* Export\Import to\from JSON

## Upcoming Features
* Mark the pipes the you can access
* Executer - allows send\receive data to one or more named pipes
* Properties window for each named pipe by right click


## Demo  
https://user-images.githubusercontent.com/11998736/215425682-c5219395-16ea-42e9-8d1e-a636771b5ba2.mp4



## Credit
We want to thank James Forshaw ([@tyranid](https://github.com/tyranid)) for creating the open source [NtApiDotNet](https://github.com/googleprojectzero/sandbox-attacksurface-analysis-tools/tree/main/NtApiDotNet) which allowed us to get information about named pipes.  

## License
Copyright (c) 2023 CyberArk Software Ltd. All rights reserved  
This repository is licensed under  Apache-2.0 License - see [`LICENSE`](LICENSE) for more details.


## References:
For more comments, suggestions or questions, you can contact Eviatar Gerzi ([@g3rzi](https://twitter.com/g3rzi)) and CyberArk Labs.

[release-img]: https://img.shields.io/github/release/cyberark/PipeViewer.svg
[release]: https://github.com/cyberark/PipeViewer/releases

[license-img]: https://img.shields.io/github/license/cyberark/PipeViewer.svg
[license]: https://github.com/cyberark/PipeViewer/blob/master/LICENSE

[download]: https://img.shields.io/github/downloads/cyberark/PipeViewer/total?logo=github
