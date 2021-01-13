<#
    Exports Super Grate Store to a CSV document.
#>
$settings = Select-Xml -Path ".\SuperGrate.xml" -XPath "SuperGrate"
class UserRow {
    $Tag = ""
    $SID = ""
    $NTAccount = ""
    $SourceComputer = ""
    $DestinationComputer = ""
    $ImportedBy = ""
    $ImportedOn = ""
    $ExportedBy = ""
    $ExportedOn = ""
    $Size = 0
}
function Get-SGAttrib($Name, $Date = $false) {
    $result = Get-Content -Path $(Join-Path -Path $user.FullName -ChildPath $name) -ErrorAction SilentlyContinue
    if($Date -and -not ($result -eq $null)) {
        $result = [System.DateTime]::FromFileTime($result)
    }
    return $result
}
Remove-Item -Path ".\StoreExport.csv" -Force -ErrorAction SilentlyContinue
foreach($user in $(Get-ChildItem -Path $settings.Node.MigrationStorePath)) {
    $row = [UserRow]::new()
    $row.Tag =                 $user.Name
    $row.SID =                 Get-SGAttrib -Name "SID"
    $row.NTAccount =           Get-SGAttrib -Name "NTACCOUNT"
    $row.SourceComputer =      Get-SGAttrib -Name "SOURCE"
    $row.DestinationComputer = Get-SGAttrib -Name "DESTINATION"
    $row.ImportedBy =          Get-SGAttrib -Name "IMPORTEDBY"
    $row.ImportedOn =          Get-SGAttrib -Name "IMPORTEDON" -Date $true
    $row.ExportedBy =          Get-SGAttrib -Name "EXPORTEDBY"
    $row.ExportedOn =          Get-SGAttrib -Name "EXPORTEDON" -Date $true
    $row.Size =                "$([System.Math]::Round($(Get-Item -Path $(Join-Path -Path $user.FullName -ChildPath "DATA")).Length / 1024 / 1024)) MB"
    Export-Csv -InputObject $row -Path "StoreExport.csv" -Force -NoTypeInformation -Append
}