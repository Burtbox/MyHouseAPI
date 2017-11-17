param(
    # The path (relative or absolute) of the output file
    [string]$output = "C:\WebProjects\MyHouseAPI\BuildScripts\MyHouseDB.sql", 
    
    # The path (relative or absolute) of the source file or files
    [string]$source = "C:\WebProjects\MyHouseAPI\Database", 
    
    # The filter to be applied to the source when retrieving files 
    [string]$filter = "*.sql"
    
)

# Check the path of the source files
if (!(Test-Path -path $source)) {
    Write-Host "ERROR: Path ""$source"" is invalid"
    break
}

Write-Host "Setting up output file:" $output

# Setup new file if not appending or if appending and it does not already exist
if ((Test-Path -path $output)) {
    Write-Host "Removing old output file:" $output
    Remove-Item -Path $output -Force
}
New-Item -ItemType file $output -force | Out-Null

# Get the files from the path, recursively if required
$files = Get-ChildItem $source -filter $filter -recurse

# Exclude folder objects
$files = $files | Where-Object { $_.PSIsContainer -ne $true }
# Exclude the output file
$files = $files | Where-Object { $_.Name -ne $output }

Write-Host "Compiling files:"
# Add the content of each file to the output file
foreach ($fileInfo in $files) {
    if($fileInfo) {
        Write-Host $fileInfo.FullName
        
        # Add a file path separator to the file
        Add-Content $output "/*"
        Add-Content $output "-- File Name: $($fileInfo.Name.ToString()) "
        Add-Content $output "-- First Created: $($fileInfo.CreationTime.ToString())"
        Add-Content $output "-- Last Modified: $($fileInfo.LastWriteTime.ToString())"
        Add-Content $output "*/"
        
        # Add the file content of the output file
        Add-Content $output (Get-Content $fileInfo.FullName)
        
        # Add a go and line break to the end
        Add-Content $output " -- Ending current file --"
        Add-Content $output "`n GO`n"
        Add-Content $output " -- Beginning next file --"


    }
}

Write-Host "`n"