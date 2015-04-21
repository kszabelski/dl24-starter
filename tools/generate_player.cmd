:: Compile and run code from generate_player.cs
@powershell -Command ^& { [environment]::CurrentDirectory = \"%~dp0\\" ; (Add-Type -Path \"%~dpn0.cs\" -PassThru -IgnoreWarnings ^| where {$_.IsPublic})::Main() }
