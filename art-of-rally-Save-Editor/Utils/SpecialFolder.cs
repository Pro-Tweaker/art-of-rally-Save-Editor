﻿using System;
using System.Runtime.InteropServices;

namespace art_of_rally_Save_Editor.Utils
{
    public static class SpecialFolder
    {
        [DllImport("shell32.dll")]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        public static string GetPath(Guid knownFolderId)
        {
            IntPtr pszPath = IntPtr.Zero;
            try
            {
                int hResult = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);

                if (hResult >= 0)
                {
                    return Marshal.PtrToStringAuto(pszPath);
                }

                throw Marshal.GetExceptionForHR(hResult);
            }
            finally
            {
                if (pszPath != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pszPath);
                }
            }
        }

        public static class KnownFolder
        {
            // Synchronized with Windows SDK 10.0.16299.0 KnownFolders.h
            public static readonly Guid NetworkFolder = Guid.Parse("D20BEEC4-5CA8-4905-AE3B-BF251EA09B53");
            public static readonly Guid ComputerFolder = Guid.Parse("0AC0837C-BBF8-452A-850D-79D08E667CA7");
            public static readonly Guid InternetFolder = Guid.Parse("4D9F7874-4E0C-4904-967B-40B0D20C3E4B");
            public static readonly Guid ControlPanelFolder = Guid.Parse("82A74AEB-AEB4-465C-A014-D097EE346D63");
            public static readonly Guid PrintersFolder = Guid.Parse("76FC4E2D-D6AD-4519-A663-37BD56068185");
            public static readonly Guid SyncManagerFolder = Guid.Parse("43668BF8-C14E-49B2-97C9-747784D784B7");
            public static readonly Guid SyncSetupFolder = Guid.Parse("0F214138-B1D3-4A90-BBA9-27CBC0C5389A");
            public static readonly Guid ConflictFolder = Guid.Parse("4BFEFB45-347D-4006-A5BE-AC0CB0567192");
            public static readonly Guid SyncResultsFolder = Guid.Parse("289A9A43-BE44-4057-A41B-587A76D7E7F9");
            public static readonly Guid RecycleBinFolder = Guid.Parse("B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC");
            public static readonly Guid ConnectionsFolder = Guid.Parse("6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD");
            public static readonly Guid Fonts = Guid.Parse("FD228CB7-AE11-4AE3-864C-16F3910AB8FE");
            public static readonly Guid Desktop = Guid.Parse("B4BFCC3A-DB2C-424C-B029-7FE99A87C641");
            public static readonly Guid Startup = Guid.Parse("B97D20BB-F46A-4C97-BA10-5E3608430854");
            public static readonly Guid Programs = Guid.Parse("A77F5D77-2E2B-44C3-A6A2-ABA601054A51");
            public static readonly Guid StartMenu = Guid.Parse("625B53C3-AB48-4EC1-BA1F-A1EF4146FC19");
            public static readonly Guid Recent = Guid.Parse("AE50C081-EBD2-438A-8655-8A092E34987A");
            public static readonly Guid SendTo = Guid.Parse("8983036C-27C0-404B-8F08-102D10DCFD74");
            public static readonly Guid Documents = Guid.Parse("FDD39AD0-238F-46AF-ADB4-6C85480369C7");
            public static readonly Guid Favorites = Guid.Parse("1777F761-68AD-4D8A-87BD-30B759FA33DD");
            public static readonly Guid NetHood = Guid.Parse("C5ABBF53-E17F-4121-8900-86626FC2C973");
            public static readonly Guid PrintHood = Guid.Parse("9274BD8D-CFD1-41C3-B35E-B13F55A758F4");
            public static readonly Guid Templates = Guid.Parse("A63293E8-664E-48DB-A079-DF759E0509F7");
            public static readonly Guid CommonStartup = Guid.Parse("82A5EA35-D9CD-47C5-9629-E15D2F714E6E");
            public static readonly Guid CommonPrograms = Guid.Parse("0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8");
            public static readonly Guid CommonStartMenu = Guid.Parse("A4115719-D62E-491D-AA7C-E74B8BE3B067");
            public static readonly Guid PublicDesktop = Guid.Parse("C4AA340D-F20F-4863-AFEF-F87EF2E6BA25");
            public static readonly Guid ProgramData = Guid.Parse("62AB5D82-FDC1-4DC3-A9DD-070D1D495D97");
            public static readonly Guid CommonTemplates = Guid.Parse("B94237E7-57AC-4347-9151-B08C6C32D1F7");
            public static readonly Guid PublicDocuments = Guid.Parse("ED4824AF-DCE4-45A8-81E2-FC7965083634");
            public static readonly Guid RoamingAppData = Guid.Parse("3EB685DB-65F9-4CF6-A03A-E3EF65729F3D");
            public static readonly Guid LocalAppData = Guid.Parse("F1B32785-6FBA-4FCF-9D55-7B8E7F157091");
            public static readonly Guid LocalAppDataLow = Guid.Parse("A520A1A4-1780-4FF6-BD18-167343C5AF16");
            public static readonly Guid InternetCache = Guid.Parse("352481E8-33BE-4251-BA85-6007CAEDCF9D");
            public static readonly Guid Cookies = Guid.Parse("2B0F765D-C0E9-4171-908E-08A611B84FF6");
            public static readonly Guid History = Guid.Parse("D9DC8A3B-B784-432E-A781-5A1130A75963");
            public static readonly Guid System = Guid.Parse("1AC14E77-02E7-4E5D-B744-2EB1AE5198B7");
            public static readonly Guid SystemX86 = Guid.Parse("D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27");
            public static readonly Guid Windows = Guid.Parse("F38BF404-1D43-42F2-9305-67DE0B28FC23");
            public static readonly Guid Profile = Guid.Parse("5E6C858F-0E22-4760-9AFE-EA3317B67173");
            public static readonly Guid Pictures = Guid.Parse("33E28130-4E1E-4676-835A-98395C3BC3BB");
            public static readonly Guid ProgramFilesX86 = Guid.Parse("7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E");
            public static readonly Guid ProgramFilesCommonX86 = Guid.Parse("DE974D24-D9C6-4D3E-BF91-F4455120B917");
            public static readonly Guid ProgramFilesX64 = Guid.Parse("6D809377-6AF0-444B-8957-A3773F02200E");
            public static readonly Guid ProgramFilesCommonX64 = Guid.Parse("6365D5A7-0F0D-45E5-87F6-0DA56B6A4F7D");
            public static readonly Guid ProgramFiles = Guid.Parse("905E63B6-C1BF-494E-B29C-65B732D3D21A");
            public static readonly Guid ProgramFilesCommon = Guid.Parse("F7F1ED05-9F6D-47A2-AAAE-29D317C6F066");
            public static readonly Guid UserProgramFiles = Guid.Parse("5CD7AEE2-2219-4A67-B85D-6C9CE15660CB");
            public static readonly Guid UserProgramFilesCommon = Guid.Parse("BCBD3057-CA5C-4622-B42D-BC56DB0AE516");
            public static readonly Guid AdminTools = Guid.Parse("724EF170-A42D-4FEF-9F26-B60E846FBA4F");
            public static readonly Guid CommonAdminTools = Guid.Parse("D0384E7D-BAC3-4797-8F14-CBA229B392B5");
            public static readonly Guid Music = Guid.Parse("4BD8D571-6D19-48D3-BE97-422220080E43");
            public static readonly Guid Videos = Guid.Parse("18989B1D-99B5-455B-841C-AB7C74E4DDFC");
            public static readonly Guid Ringtones = Guid.Parse("C870044B-F49E-4126-A9C3-B52A1FF411E8");
            public static readonly Guid PublicPictures = Guid.Parse("B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5");
            public static readonly Guid PublicMusic = Guid.Parse("3214FAB5-9757-4298-BB61-92A9DEAA44FF");
            public static readonly Guid PublicVideos = Guid.Parse("2400183A-6185-49FB-A2D8-4A392A602BA3");
            public static readonly Guid PublicRingtones = Guid.Parse("E555AB60-153B-4D17-9F04-A5FE99FC15EC");
            public static readonly Guid ResourceDir = Guid.Parse("8AD10C31-2ADB-4296-A8F7-E4701232C972");
            public static readonly Guid LocalizedResourcesDir = Guid.Parse("2A00375E-224C-49DE-B8D1-440DF7EF3DDC");
            public static readonly Guid CommonOEMLinks = Guid.Parse("C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D");
            public static readonly Guid CDBurning = Guid.Parse("9E52AB10-F80D-49DF-ACB8-4330F5687855");
            public static readonly Guid UserProfiles = Guid.Parse("0762D272-C50A-4BB0-A382-697DCD729B80");
            public static readonly Guid Playlists = Guid.Parse("DE92C1C7-837F-4F69-A3BB-86E631204A23");
            public static readonly Guid SamplePlaylists = Guid.Parse("15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5");
            public static readonly Guid SampleMusic = Guid.Parse("B250C668-F57D-4EE1-A63C-290EE7D1AA1F");
            public static readonly Guid SamplePictures = Guid.Parse("C4900540-2379-4C75-844B-64E6FAF8716B");
            public static readonly Guid SampleVideos = Guid.Parse("859EAD94-2E85-48AD-A71A-0969CB56A6CD");
            public static readonly Guid PhotoAlbums = Guid.Parse("69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C");
            public static readonly Guid Public = Guid.Parse("DFDF76A2-C82A-4D63-906A-5644AC457385");
            public static readonly Guid ChangeRemovePrograms = Guid.Parse("DF7266AC-9274-4867-8D55-3BD661DE872D");
            public static readonly Guid AppUpdates = Guid.Parse("A305CE99-F527-492B-8B1A-7E76FA98D6E4");
            public static readonly Guid AddNewPrograms = Guid.Parse("DE61D971-5EBC-4F02-A3A9-6C82895E5C04");
            public static readonly Guid Downloads = Guid.Parse("374DE290-123F-4565-9164-39C4925E467B");
            public static readonly Guid PublicDownloads = Guid.Parse("3D644C9B-1FB8-4F30-9B45-F670235F79C0");
            public static readonly Guid SavedSearches = Guid.Parse("7D1D3A04-DEBB-4115-95CF-2F29DA2920DA");
            public static readonly Guid QuickLaunch = Guid.Parse("52A4F021-7B75-48A9-9F6B-4B87A210BC8F");
            public static readonly Guid Contacts = Guid.Parse("56784854-C6CB-462B-8169-88E350ACB882");
            public static readonly Guid SidebarParts = Guid.Parse("A75D362E-50FC-4FB7-AC2C-A8BEAA314493");
            public static readonly Guid SidebarDefaultParts = Guid.Parse("7B396E54-9EC5-4300-BE0A-2482EBAE1A26");
            public static readonly Guid PublicGameTasks = Guid.Parse("DEBF2536-E1A8-4C59-B6A2-414586476AEA");
            public static readonly Guid GameTasks = Guid.Parse("054FAE61-4DD8-4787-80B6-090220C4B700");
            public static readonly Guid SavedGames = Guid.Parse("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4");
            public static readonly Guid Games = Guid.Parse("CAC52C1A-B53D-4EDC-92D7-6B2E8AC19434");
            public static readonly Guid SEARCH_MAPI = Guid.Parse("98EC0E18-2098-4D44-8644-66979315A281");
            public static readonly Guid SEARCH_CSC = Guid.Parse("EE32E446-31CA-4ABA-814F-A5EBD2FD6D5E");
            public static readonly Guid Links = Guid.Parse("BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968");
            public static readonly Guid UsersFiles = Guid.Parse("F3CE0F7C-4901-4ACC-8648-D5D44B04EF8F");
            public static readonly Guid UsersLibraries = Guid.Parse("A302545D-DEFF-464B-ABE8-61C8648D939B");
            public static readonly Guid SearchHome = Guid.Parse("190337D1-B8CA-4121-A639-6D472D16972A");
            public static readonly Guid OriginalImages = Guid.Parse("2C36C0AA-5812-4B87-BFD0-4CD0DFB19B39");
            public static readonly Guid DocumentsLibrary = Guid.Parse("7B0DB17D-9CD2-4A93-9733-46CC89022E7C");
            public static readonly Guid MusicLibrary = Guid.Parse("2112AB0A-C86A-4FFE-A368-0DE96E47012E");
            public static readonly Guid PicturesLibrary = Guid.Parse("A990AE9F-A03B-4E80-94BC-9912D7504104");
            public static readonly Guid VideosLibrary = Guid.Parse("491E922F-5643-4AF4-A7EB-4E7A138D8174");
            public static readonly Guid RecordedTVLibrary = Guid.Parse("1A6FDBA2-F42D-4358-A798-B74D745926C5");
            public static readonly Guid HomeGroup = Guid.Parse("52528A6B-B9E3-4ADD-B60D-588C2DBA842D");
            public static readonly Guid HomeGroupCurrentUser = Guid.Parse("9B74B6A3-0DFD-4f11-9E78-5F7800F2E772");
            public static readonly Guid DeviceMetadataStore = Guid.Parse("5CE4A5E9-E4EB-479D-B89F-130C02886155");
            public static readonly Guid Libraries = Guid.Parse("1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE");
            public static readonly Guid PublicLibraries = Guid.Parse("48DAF80B-E6CF-4F4E-B800-0E69D84EE384");
            public static readonly Guid UserPinned = Guid.Parse("9E3995AB-1F9C-4F13-B827-48B24B6C7174");
            public static readonly Guid ImplicitAppShortcuts = Guid.Parse("BCB5256F-79F6-4CEE-B725-DC34E402FD46");
            public static readonly Guid AccountPictures = Guid.Parse("008CA0B1-55B4-4C56-B8A8-4DE4B299D3BE");
            public static readonly Guid PublicUserTiles = Guid.Parse("0482AF6C-08F1-4C34-8C90-E17EC98B1E17");
            public static readonly Guid AppsFolder = Guid.Parse("1E87508D-89C2-42F0-8A7E-645A0F50CA58");
            public static readonly Guid StartMenuAllPrograms = Guid.Parse("F26305EF-6948-40B9-B255-81453D09C785");
            public static readonly Guid CommonStartMenuPlaces = Guid.Parse("A440879F-87A0-4F7D-B700-0207B966194A");
            public static readonly Guid ApplicationShortcuts = Guid.Parse("A3918781-E5F2-4890-B3D9-A7E54332328C");
            public static readonly Guid RoamingTiles = Guid.Parse("00BCFC5A-ED94-4e48-96A1-3F6217F21990");
            public static readonly Guid RoamedTileImages = Guid.Parse("AAA8D5A5-F1D6-4259-BAA8-78E7EF60835E");
            public static readonly Guid Screenshots = Guid.Parse("B7BEDE81-DF94-4682-A7D8-57A52620B86F");
            public static readonly Guid CameraRoll = Guid.Parse("AB5FB87B-7CE2-4F83-915D-550846C9537B");
            public static readonly Guid SkyDrive = Guid.Parse("A52BBA46-E9E1-435F-B3D9-28DAA648C0F6");
            public static readonly Guid OneDrive = Guid.Parse("A52BBA46-E9E1-435F-B3D9-28DAA648C0F6");
            public static readonly Guid SkyDriveDocuments = Guid.Parse("24D89E24-2F19-4534-9DDE-6A6671FBB8FE");
            public static readonly Guid SkyDrivePictures = Guid.Parse("339719B5-8C47-4894-94C2-D8F77ADD44A6");
            public static readonly Guid SkyDriveMusic = Guid.Parse("C3F2459E-80D6-45DC-BFEF-1F769F2BE730");
            public static readonly Guid SkyDriveCameraRoll = Guid.Parse("767E6811-49CB-4273-87C2-20F355E1085B");
            public static readonly Guid SearchHistory = Guid.Parse("0D4C3DB6-03A3-462F-A0E6-08924C41B5D4");
            public static readonly Guid SearchTemplates = Guid.Parse("7E636BFE-DFA9-4D5E-B456-D7B39851D8A9");
            public static readonly Guid CameraRollLibrary = Guid.Parse("2B20DF75-1EDA-4039-8097-38798227D5B7");
            public static readonly Guid SavedPictures = Guid.Parse("3B193882-D3AD-4EAB-965A-69829D1FB59F");
            public static readonly Guid SavedPicturesLibrary = Guid.Parse("E25B5812-BE88-4BD9-94B0-29233477B6C3");
            public static readonly Guid RetailDemo = Guid.Parse("12D4C69E-24AD-4923-BE19-31321C43A767");
            public static readonly Guid Device = Guid.Parse("1C2AC1DC-4358-4B6C-9733-AF21156576F0");
            public static readonly Guid DevelopmentFiles = Guid.Parse("DBE8E08E-3053-4BBC-B183-2A7B2B191E59");
            public static readonly Guid Objects3D = Guid.Parse("31C0DD25-9439-4F12-BF41-7FF4EDA38722");
            public static readonly Guid AppCaptures = Guid.Parse("EDC0FE71-98D8-4F4A-B920-C8DC133CB165");
            public static readonly Guid LocalDocuments = Guid.Parse("F42EE2D3-909F-4907-8871-4C22FC0BF756");
            public static readonly Guid LocalPictures = Guid.Parse("0DDD015D-B06C-45D5-8C4C-F59713854639");
            public static readonly Guid LocalVideos = Guid.Parse("35286A68-3C57-41A1-BBB1-0EAE73D76C95");
            public static readonly Guid LocalMusic = Guid.Parse("A0C69A99-21C8-4671-8703-7934162FCF1D");
            public static readonly Guid LocalDownloads = Guid.Parse("7D83EE9B-2244-4E70-B1F5-5393042AF1E4");
            public static readonly Guid RecordedCalls = Guid.Parse("2F8B40C2-83ED-48EE-B383-A1F157EC6F9A");
            public static readonly Guid AllAppMods = Guid.Parse("7AD67899-66AF-43BA-9156-6AAD42E6C596");
            public static readonly Guid CurrentAppMods = Guid.Parse("3DB40B20-2A30-4DBE-917E-771DD21DD099");
            public static readonly Guid AppDataDesktop = Guid.Parse("B2C5E279-7ADD-439F-B28C-C41FE1BBF672");
            public static readonly Guid AppDataDocuments = Guid.Parse("7BE16610-1F7F-44AC-BFF0-83E15F2FFCA1");
            public static readonly Guid AppDataFavorites = Guid.Parse("7CFBEFBC-DE1F-45AA-B843-A542AC536CC9");
            public static readonly Guid AppDataProgramData = Guid.Parse("559D40A3-A036-40FA-AF61-84CB430A4D34");
        }
    }
}
