C:\Windows\Microsoft.NET\Framework\v4.0.30319\installutil.exe WindowsService1.exe
Net Start "Telnet Service""
sc config "Telnet Service" start= auto