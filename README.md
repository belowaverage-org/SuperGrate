<h1 align="center">
  <img height="25" src="https://raw.githubusercontent.com/belowaverage-org/SuperGrate/master/SuperGrate/Images/supergrate.ico">
  Super Grate
</h1>
<p align="center">
  <br>
  <img height="74" src="https://raw.githubusercontent.com/krisdb2009/documentation/master/images/supersweet.png">
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <img height="80" src="https://raw.githubusercontent.com/belowaverage-org/SuperGrate/master/SuperGrate/Images/supergrate.ico">
  <br><br>
  <img src="https://raw.githubusercontent.com/krisdb2009/documentation/master/images/supergrate.png">
  <h2>Features</h2>
  <ul>
    <li>Simple GUI</li>
    <li>Configurable</li>
    <li>Works on Domain Joined and Non-Joined PCs</li>
    <li>Unified Backup Store</li>
    <li>Works remotely over a network</li>
  </ul>
  <h2>Configuration</h2>
  
```xml
<?xml version="1.0" encoding="utf-8"?>
<SuperGrate>
  <!--The UNC or Direct path to the USMT Migration Store E.g: \\ba-share\s$ or .\STORE.-->
  <MigrationStorePath>.\STORE</MigrationStorePath>
  <!--ScanState.exe & LoadState.exe CLI Parameters: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax -->
  <ScanStateParameters>/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3 /o</ScanStateParameters>
  <LoadStateParameters>/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3</LoadStateParameters>
</SuperGrate>
```

</p>
