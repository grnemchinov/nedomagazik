using nedomagazik;
using System.Security.Cryptography.X509Certificates;

namespace nedomagazik;

internal class Admin : CRUD
{
    const string readmenutext = "Админ Read";
    const string createmenutext = "Админ Create";
    const string updatemenutext = "Админ Update";
    public static AutObject ChoseUser = null;
    private static int ChoseUserpos;
    private static int ChoseUserposDelit = -1;
    private const string hadtabulate = "ID Login Password Role";

    public static bool CRUDe()
    {
        if (Control.key.Key == (ConsoleKey)MainClass.keybinds.Enter)
            switch (Control.YCursorPos - 1)
            {
                case 1:
                    Create();
                    Control.YCursorPos = 2;
                    return true;
                case 2:
                    if (ChoseUser != null)
                        Dlete();
                    return true;
                case 3:
                    Read();
                    Control.YCursorPos = 2;
                    return true;
                case 4:
                    if (ChoseUser != null)
                        Update();
                    Control.YCursorPos = 2;
                    return true;
            }
        return false;
    }
    private static void Create()
    {
        Console.Clear();
        Menu.Meni(createmenutext + ": " + Aut.username, MainClass.CUAcontent);
        AutObject newe = new AutObject();
        while (Control.key.Key != (ConsoleKey)MainClass.keybinds.Escape)
        {
            ChoseUserpos = Menu.MenuCUA(newe, ChoseUserpos, false);//false Create
        }
        Console.Clear();
        Menu.Meni(MainClass.adminmenutext + ": " + Aut.username, MainClass.CRUDcontent);
    }
    private static void Dlete()
    {

        if (Control.key.Key == (ConsoleKey)MainClass.keybinds.Enter && ChoseUserposDelit != ChoseUserpos)
        {
            List<AutObject> checusers = Sterealizer.desteruser<List<AutObject>>(Startname.Users);
            checusers.RemoveAt(ChoseUserpos);
            ChoseUserposDelit = ChoseUserpos;
            Sterealizer.steruser(checusers, Startname.Users);
        }
    }
    private static void Read()
    {
        string find = null;
        string findteg = null;
        string text = null;
        Console.Clear();
        Menu.Meni(readmenutext + ": " + Aut.username, TabulatAdmin.ListUsers(find, findteg, hadtabulate));
        while (Control.key.Key != (ConsoleKey)MainClass.keybinds.Escape)
        {
            Control.ReadKey(TabulatAdmin.Finde.Count + 1);
            Control.MenuArrow(TabulatAdmin.Finde.Count + 1);
            if (Control.key.Key == (ConsoleKey)MainClass.keybinds.Enter && Control.YCursorPos - 2 != 0)
            {
                ChoseUser = TabulatAdmin.Finde[Control.YCursorPos - 3];
                ChoseUserpos = Control.YCursorPos - 3;
            }
            else if (Control.key.Key == (ConsoleKey)MainClass.keybinds.Enter && Control.YCursorPos - 2 == 0)
            {
                Console.SetCursorPosition(9, Control.YCursorPos);
                text = Console.ReadLine();
                findteg = text.Split(": ")[0];
                if (text.Split(": ").Length == 2)
                    find = text.Split(": ")[1];
                Console.Clear();
                Menu.Meni(readmenutext + ": " + Aut.username, TabulatAdmin.ListUsers(find, findteg, hadtabulate));
            }
        }
        Console.Clear();
        Menu.Meni(MainClass.adminmenutext + ": " + Aut.username, MainClass.CRUDcontent);
    }
    private static void Update()
    {

        Console.Clear();
        Menu.Meni(updatemenutext + ": " + Aut.username, MainClass.CUAcontent);
        AutObject newe = new AutObject();
        while (Control.key.Key != (ConsoleKey)MainClass.keybinds.Escape)
        {
            ChoseUserpos = Menu.MenuCUA(newe, ChoseUserpos, true);//true Update
        }
        Console.Clear();
        Menu.Meni(MainClass.adminmenutext + ": " + Aut.username, MainClass.CRUDcontent);
    }
    class TabulatAdmin
    {
        private static int tabulate;
        public static List<AutObject> Finde;
        public static string ListUsers(string find, string findteg, string had)
        {
            List<AutObject> checusers = Sterealizer.desteruser<List<AutObject>>(Startname.Users);
            Finde = new List<AutObject>();
            string listusers = "  Поиск: ";
            tabulate = listusers.Length;
            listusers = Format(listusers, had.Split(" ")[0], had);
            listusers = Format(listusers, had.Split(" ")[1], had);
            listusers = Format(listusers, had.Split(" ")[2], had);
            listusers = Format(listusers, had.Split(" ")[3], had);
            listusers = listusers + "\n";
            tabulate = 0;
            foreach (AutObject checuser in checusers)
            {
                switch (findteg)
                {
                    case "ID":
                        if (find == checuser.id.ToString())
                            listusers = Formats(listusers, checuser, had);
                        break;
                    case "Login":
                        if (find == checuser.login)
                            listusers = Formats(listusers, checuser, had);
                        break;
                    case "Password":
                        if (find == checuser.password)
                            listusers = Formats(listusers, checuser, had);
                        break;
                    case "Role":
                        if (find == checuser.role.ToString())
                            listusers = Formats(listusers, checuser, had);
                        break;
                    case null:
                        listusers = Formats(listusers, checuser, had);
                        break;
                    default:
                        if (findteg == checuser.id.ToString() || findteg == checuser.login || findteg == checuser.password || findteg == checuser.role.ToString())
                            listusers = Formats(listusers, checuser, had);
                        break;
                }
            }
            return listusers;
        }
        private static string Formats(string listusers, AutObject checuser, string had)
        {
            Finde.Add(checuser);
            listusers = Format(listusers, checuser.id.ToString(), had);
            listusers = Format(listusers, checuser.login, had);
            listusers = Format(listusers, checuser.password, had);
            listusers = Format(listusers, checuser.role.ToString(), had);
            listusers = listusers + "\n";
            tabulate = 0;
            return listusers;
        }
        private static string Format(string speaker, string table, string had)
        {
            for (int i = 0; i < Console.WindowWidth / (had.Split(" ").Length + 1) - tabulate; i++)
                speaker = speaker + " ";
            speaker = speaker + table;
            tabulate = table.Length;
            return speaker;
        }
    }
   
}