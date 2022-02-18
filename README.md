
# Installation

Download the application. Run the application you downloaded and click the Install button in the upper right corner. My application will be opened as an administrator again. Install the application by pressing the Install button again.

When the application is installed, it will take over the **ftplinker://** protocol and the **ftplinker** command.

There are several editable information fields in the interface of the application.

These are for specifying a manual directory. If we talk over WinSCP: the application will try to find WinSCP by itself. If it cannot find it (WinSCP may be installed in a different directory or disk), you can specify a directory manually.

***The fields you can see there:***  
WinSCP Path: _The path to the directory where WinSCP is installed._  
FileZilla Path: _The path to the directory where FileZilla is installed._  
VSCode Path: _The path to the directory where VSCode is installed._  
VSCode Workspace Path: _The path to the directory where the workspace is stored._

Need [SFTP Extension](https://marketplace.visualstudio.com/items?itemName=liximomo.sftp) for VSCode.

# Usage
> 1. CLIENT PROTOCOL DOMAIN USER PASS HOST PORT PATH
> 2. Base64 encoded string
> 3. ftplinker://...base64 encoded string...

Raw Data: 
```
VSCODE FTP testing.com testuser 96V*}p|307B^ 192.168.1.34 21 /public_html/
```

Base64 Encoded:
```
VlNDT0RFIEZUUCB0ZXN0aW5nLmNvbSB0ZXN0dXNlciA5NlYqfXB8MzA3Ql4gMTkyLjE2OC4xLjM0IDIxIC9wdWJsaWNfaHRtbC8=
```

As Link:
[ftplinker://VlNDT0RFIEZUUCB0ZXN0aW5nLmNvbSB0ZXN0dXNlciA5NlYqfXB8MzA3Ql4gMTkyLjE2OC4xLjM0IDIxIC9wdWJsaWNfaHRtbC8=](ftplinker://VlNDT0RFIEZUUCB0ZXN0aW5nLmNvbSB0ZXN0dXNlciA5NlYqfXB8MzA3Ql4gMTkyLjE2OC4xLjM0IDIxIC9wdWJsaWNfaHRtbC8=)
 
# Informations

## CLIENT
- [WinSCP](https://winscp.net/eng/download.php)
- [FileZilla Client](https://filezilla-project.org/download.php?platform=win64) 
- Explorer (Windows file explorer)
- [Visual Studio Code](https://code.visualstudio.com/download) 

Markdown is a lightweight markup language based on the formatting conventions
that people naturally use in email.

## PROTOCOL
- FTP
- SFTP  (Secure FTP)
Required

## DOMAIN
Markdown is a lightweight markup language. Required.

## USER
Username of the FTP server. Required.

## PASS 
Password of the FTP server. Required.

## HOST 
Hostname of the FTP server. Domain or IP address. Required.

## PORT
Port of the FTP server. Required.

## PATH
Path of the FTP server. It's not required. 


# How is it working?
Because it follows the ftplinker protocol, it handles the link when a link is called from that protocol.  
The link is base64 encrypted. Similar to torrent magnet url  
Makes base64-encrypted text readable.  
Data similar to "VSCODE FTP testing.com testuser 96V*}p|307B^ 192.168.1.34 21 /public_html/" appears.  
Runs WinSCP or FileZilla Client. It also adds connection information as a parameter while running.  
> winscp.exe sftp://user:password@example.com/  
> filezilla.exe sftp://user:password@example.com/

Explorer is already opens the directory.  

As for VSCode: it needs the workspace directory.  
`C:\Users\Amiral\Desktop\workspace`  
We gave testing.com as the domain.  
`C:\Users\Amiral\Desktop\workspace\testing.com`  
create a ".vscode" folder if it doesn't exist.
`C:\Users\Amiral\Desktop\workspace\testing.com\.vscode`  
create a `sftp.json` file in this directory if it doesn't exist.
`C:\Users\Amiral\Desktop\workspace\testing.com\.vscode\sftp.json`  
and start VSCode.

