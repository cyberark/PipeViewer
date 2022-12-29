[![GitHub release][release-img]][release]
[![License][license-img]][license]
![Downloads][download]


<img src="https://github.com/cyberark/PipeViewer/blob/assets/pipeviewer_logo.png" width="260">   
A GUI tool for viewing Windows Named Pipes and searching for insecure permissions.  

## Overview
PipeViewer is a GUI tool that allows users to view details about Windows Named pipes and their permissions. It is designed to be useful for security researchers who are interested in searching for named pipes with weak permissions or testing the security of named pipes. With PipeViewer, users can easily view and analyze information about named pipes on their systems, helping them to identify potential security vulnerabilities and take appropriate steps to secure their systems.

## Usage

Double click the EXE binary and you will get the list of all named pipes.   

## Features
* A detailed overview of named pipes.
* Filter\highlight rows based on cells.
* Bold specific rows.
* Export\Import to\from JSON

## Upcoming Features
* Executer - allows send\receive data to one or more named pipes
* Properties window for each named pipe by right click


## Demo  
https://user-images.githubusercontent.com/11998736/209839897-416c3cfa-2ea4-4181-b51d-db8288b31485.mp4



## Credit
We want to thank James Forshaw ([@tyranid](https://github.com/tyranid)) for creating the open source [NtApiDotNet](https://github.com/googleprojectzero/sandbox-attacksurface-analysis-tools/tree/main/NtApiDotNet) which allowed us to get information about named pipes.  

## License
Copyright (c) 2022 CyberArk Software Ltd. All rights reserved  
This repository is licensed under  Apache-2.0 License - see [`LICENSE`](LICENSE) for more details.


## References:
For more comments, suggestions or questions, you can contact Eviatar Gerzi ([@g3rzi](https://twitter.com/g3rzi)) and CyberArk Labs.

[release-img]: https://img.shields.io/github/release/cyberark/PipeViewer.svg
[release]: https://github.com/cyberark/PipeViewer/releases

[license-img]: https://img.shields.io/github/license/cyberark/PipeViewer.svg
[license]: https://github.com/cyberark/PipeViewer/blob/master/LICENSE

[download]: https://img.shields.io/github/downloads/cyberark/PipeViewer/total?logo=github
