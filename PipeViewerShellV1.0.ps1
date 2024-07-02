# Installing the Module - Do it before your first run.
#Install-Module -Name NtObjectManager -RequiredVersion 1.1.32

# To allow the execution of local scripts and scripts signed by a trusted publisher.
#Set-ExecutionPolicy RemoteSigned

function Invoke-PipeViewer {
<#
.SYNOPSIS
    A PowerShell script to gather detailed information about named pipes on the system and export it to JSON format.
.DESCRIPTION
    This script uses the NtObjectManager module to create a JSON file that can be imported into the PipeViewer, a CyberArk open source tool,
    to display detailed information about named pipes.
.AUTHOR
    Noam Regev
.COMPANY
    CyberArk Software Ltd.
    https://github.com/cyberark/pipeviewer
#>

    param (
        [switch]$Print,  # Switch to control output display
        [switch]$Export,  # Switch to control exporting to JSON
        [string]$fileName = "NamedPipes.json", # Optional filename, default name - NamedPipes.json
        [switch]$Help     # Switch to display help information
    )

    # Check if no switches are provided
    if ($PSBoundParameters.Count -eq 0) {
        $Help = $true
    }

    # Display usage information if -Help switch is used
    if ($Help) {
        $helpText = @"
  _____ _         __      ___                        
 |  __ (_)        \ \    / (_)                       
 | |__) | _ __   __\ \  / / _  _____      _____ _ __ 
 |  ___/ | '_ \ / _ \ \/ / | |/ _ \ \ /\ / / _ \ '__|
 | |   | | |_) |  __/\  /  | |  __/\ V  V /  __/ |   
 |_|   |_| .__/_\___| \/   |_|\___| \_/\_/ \___|_|   
         | | / ____| |        | | |                  
         |_|| (___ | |__   ___| | |                  
             \___ \| '_ \ / _ \ | |                  
             ____) | | | |  __/ | |                  
            |_____/|_| |_|\___|_|_| v1.0               
                                                     
Author: Noam Regev
Version: 1.0
Company: CyberArk Software Ltd.
Contributors: Eviatar Gerzi

  vvv PipeViewer GUI Version GitHub Link vvv
GitHub: https://github.com/cyberark/pipeviewer
                                
Usage:
    Invoke-PipeViewer -Help
        Display this help information.
    Invoke-PipeViewer -Print
        Print the output to the console.
    Invoke-PipeViewer -Export [FileName]
        Export the output to JSON file with the specified name or 'NamedPipes.json' by default,
        the json file can be imported by the PipeViewer non-shell version.

Examples:
    # Print the named pipes details to the console.
    Invoke-PipeViewer -Print
   
    # Export the named pipes details to the given path with the name provided as a JSON file.
    Invoke-PipeViewer -Export "C:\Path\To\CustomName2.json"

    # Print the named pipes and export it to current directory.
    Invoke-PipeViewer -Print -Export "CustomName1.json"
"@
        Write-Host $helpText
        return
    }

    # Import the required module
    Import-Module NtObjectManager

    function ConvertAccessMaskToSimplePermissions {
        param (
            [Parameter(Mandatory=$true)]
            $AccessMask
        )

        switch ($AccessMask) {
            2032127 { return "Full" }     # 001F01FF
            1245631 { return "RWX" }      # 001301BF
            1180095 { return "RWX" }      # 001201BF
            1180063 { return "RW" }       # 0012019F
            1048854 { return "W" }        # 00100116
            1179817 { return "RX" }       # 001200A9
            1180059 { return "R" }        # 0012019B
            default { return "(special)" }
        }
    }

    function ConvertSidToName {
        param (
            [string]$sid
        )
        try {
            $account = New-Object System.Security.Principal.SecurityIdentifier($sid)
            $account.Translate([System.Security.Principal.NTAccount]).Value
        } catch {
            $sid # Return SID if translation fails
        }
    }

    $processPIDsDictionary = @{}

    function ProcessNameWithProcessPIDs {
        param (
            [NtApiDotNet.NtNamedPipeFileBase]$PipeObj
        )
        $processIds = $PipeObj.GetUsingProcessIds()
        $processNames = @()
        foreach ($curPid in $processIds) {
            if ($processPIDsDictionary.ContainsKey($curPid)) {
                $processNames += "$($processPIDsDictionary[$curPid]) ($curPid)"
            } else {
                try {
                    $process = [System.Diagnostics.Process]::GetProcessById($curPid)
                    $processPIDsDictionary[$curPid] = $process.ProcessName
                    $processNames += "$($process.ProcessName) ($curPid)"
                } catch {
                    $processPIDsDictionary[$curPid] = "<no_process>"
                    $processNames += "<no_process> ($curPid)"
                }
            }
        }
        return $processNames -join "; "
    }

    # Define the Get-NamedPipeDetails function
    function Get-NamedPipeDetails {
        param (
            [string]$PipeName
        )
        try {
            $pipeObj = Get-NtFile -Path $PipeName -Win32Path
            $owner = ConvertSidToName $pipeObj.SecurityDescriptor.Owner.Sid
            $integrityLevel = $pipeObj.SecurityDescriptor.MandatoryLabel.IntegrityLevel
            $clientPID = ProcessNameWithProcessPIDs -PipeObj $pipeObj
            $pipeType = $pipeObj.PipeType.ToString()
            $configuration = $pipeObj.Configuration.ToString()
            $readMode = $pipeObj.ReadMode.ToString()
            $numberOfLinks = $pipeObj.NumberOfLinks
            $directoryGrantedAccess = $pipeObj.DirectoryGrantedAccess.ToString()    #Getting More Information then We Get From the PipeViewer!
            $grantedAccessString = $pipeObj.GrantedAccess.ToString()    #Getting More Information then We Get in the PipeViewer!
            $grantedAccessGeneric = $pipeObj.GrantedAccessGeneric.ToString()    #Getting More Information then We Get in the PipeViewer!
            $endpointType = $pipeObj.EndPointType.ToString()
            $creationTime = $pipeObj.CreationTime.ToString("o")
            $handle = $pipeObj.Handle.ToString()

            # Format the permissions
            $permissionsFormatted = ($pipeObj.SecurityDescriptor.Dacl | ForEach-Object {
                $trusteeName = ConvertSidToName -sid $_.Sid
                $permissionString = ConvertAccessMaskToSimplePermissions -AccessMask $_.Mask
                "Allowed $permissionString $trusteeName"
            }) -join "; `n"

            $details = [PSCustomObject]@{
                Name                   = $PipeName
                IntegrityLevel         = $integrityLevel
                Permissions            = $permissionsFormatted
                ClientPID              = $clientPID
                PipeType               = $pipeType
                Configuration          = $configuration
                ReadMode               = $readMode
                NumberOfLinks          = $numberOfLinks
                DirectoryGrantedAccess = $directoryGrantedAccess
                GrantedAccess          = $grantedAccessString
                GrantedAccessGeneric   = $grantedAccessGeneric
                CreationTime           = $creationTime
                OwnerName              = $owner
                EndPointType           = $endpointType
                Handle                 = $handle
            }
            return $details
        } catch {
            # When there is no Access add the Pipe with null arguments.
            return [PSCustomObject]@{
                Name                   = $PipeName
                IntegrityLevel         = $null
                Permissions            = $null
                ClientPID              = $null
                PipeType               = $null
                Configuration          = $null
                ReadMode               = $null
                NumberOfLinks          = $null
                DirectoryGrantedAccess = $null
                GrantedAccess          = $null
                GrantedAccessGeneric   = $null
                CreationTime           = $null
                OwnerName              = $null
                EndPointType           = $null
                Handle                 = $null
            }
        }
    }

    function Get-NamedPipes {
        [System.IO.Directory]::GetFiles("\\.\pipe\")
    }

    # Main execution block
    $namedPipes = Get-NamedPipes
    $pipeDetailsList = @()
    foreach ($pipe in $namedPipes) {
        try {
            $pipeDetails = Get-NamedPipeDetails -PipeName $pipe
            if ($pipeDetails -ne $null) {
                $pipeDetailsList += $pipeDetails
            }
        } catch {
            Write-Error "Skipping pipe $pipe due to error: $_"
        }
    }

    if ($Print) {
        $pipeDetailsList | Format-List
    }

    if ($Export) {
        $fileName = if ($FileName -eq "NamedPipes.json" -and $Export -ne $true) { $Export } else { $FileName }
        $outputPath = if ($fileName.Contains("\") -or $fileName.Contains("/")) { $fileName } else { Join-Path -Path (Get-Location) -ChildPath $fileName }
        $pipeDetailsList | ConvertTo-Json | Out-File -FilePath $outputPath
        Write-Host "Details exported to '$outputPath'"
    }
}