﻿# Set execution policy
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Force

# Enable logging
$LogFile = "C:\InstallLog.txt"
Function Log ($Message) {
    $TimeStamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
    Add-Content -Path $LogFile -Value "$TimeStamp - $Message"
}

# Update Windows
Log "Starting Windows Update..."
Install-WindowsUpdate -AcceptAll -AutoReboot
Log "Windows Update completed."

# Install Chocolatey (if not installed)
Log "Checking Chocolatey installation..."
if (!(Test-Path "C:\ProgramData\chocolatey")) {
    Log "Installing Chocolatey..."
    Set-ExecutionPolicy Bypass -Scope Process -Force
    [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072
    Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
    $env:Path += ";C:\ProgramData\chocolatey\bin"
    Log "Chocolatey installed."
} else {
    Log "Chocolatey already installed."
}

# Refresh Environment Variables
refreshenv

# Install Terraform
Log "Installing Terraform..."
choco install terraform -y
Log "Terraform installed."

# Install Visual Studio Code
Log "Installing Visual Studio Code..."
choco install vscode -y
Log "Visual Studio Code installed."

# Install Git
Log "Installing Git..."
choco install git -y
Log "Git installed."

# Install Azure CLI
Log "Installing Azure CLI..."
choco install azure-cli -y
Log "Azure CLI installed."

# Verify Installations
$Tools = @("terraform", "code", "git", "az")
foreach ($tool in $Tools) {
    if (Get-Command $tool -ErrorAction SilentlyContinue) {
        Log "$tool installed successfully."
    } else {
        Log "Error: $tool installation failed."
    }
}

Log "Installation script completed."
