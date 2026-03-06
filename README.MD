Nicolai H. Madsen

Systemet bruger SqLite. 
Begrundelse: Det er lettere. 

Hvordan man kører programmet (trin-for-trin)
1. Unzip og udpak filer i en mappe du vil have solution skal ligge i (yea, I'm explaining how to unzip a file).
2. Åben Solution-filen; "Library.slnx".
3. Åben Dev PowerShell (brug genvej CTRL + Æ)

(Bear with me, this is gonna get a little stupid)

4. I PowerShell brug kommandoen: cd Infrastructure
5. Brug kommandoen: dotnet ef database update
6. Brug kommandoen: cd ../
7. Brug kommandoen: cd Application
8. Brug kommandoen: dotnet run


Udfordringer og generelle tanker:
At holde mig til scopet af opgaven. 
Intellisense forslår kode som "async Task", jeg tænker "det ser spændende ud" and now here we are.

Opsætning af queries. 
Jeg stoppede hvor jeg gjorde, pga. mængden af input jeg fik brug for fra Claude begyndte, at blive for højt (jeg kunne ikke selv) til. 
Og da meningen var at du skulle se hvor vores niveau var henne af, tænkte jeg at det var bedre at stoppe der, end at 'power' gennem det. Det kan jeg gøre, når den er afleveret. 