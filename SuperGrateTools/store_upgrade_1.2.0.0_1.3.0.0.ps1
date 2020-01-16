Get-ChildItem -Depth 1 -File -Filter "*.MIG" -Force -Path ".\STORE" -Recurse | Rename-Item -NewName "data"
foreach($item in Get-ChildItem -Directory -Force -Path ".\STORE") {
    if($item.Name.StartsWith("S-") -and $item.Name.Split('-').Length -eq 8) {
        Set-Content -NoNewline -Path $(Join-Path -Path $item.FullName -ChildPath "sid") -Value $item.Name
        $item | Rename-Item -NewName $(New-Guid).Guid
    }
}
