

using nedomagazik;
using static nedomagazik.Admin;

namespace nedomagazik;
internal static class Aut
{
    const string logineror = "Неверный логин";
    const string passworderor = "Неверный пароль";
    private static int lastconter = 0;
    private static string login = null, password = null;
    public static uint role;
    public static string username;
    public static int useramount;
    public static bool Read(int longe)
    {
        username = null;
        bool iflogineror = true;
        bool ifpassworderor = true;
        List<AutObject> checusers = Sterealizer.desteruser<List<AutObject>>(Startname.Users);
        useramount = checusers.Count;
        Console.SetCursorPosition(MainClass.autcontent.Split("\n")[Control.YCursorPos - 2].Length, Control.YCursorPos);
        switch (Control.YCursorPos - 1)
        {
            case 1:
                login = Console.ReadLine();
                Console.SetCursorPosition(0, Control.YCursorPos);
                break;
            case 2:
                password = ReadPasword();
                Console.SetCursorPosition(0, Control.YCursorPos);
                break;
            case 3:
                if (login == null || password == null)
                    return true;
                foreach (AutObject checuser in checusers)
                {
                    if (checuser.login == login)
                        iflogineror = false;
                    if (checuser.password == password)
                        ifpassworderor = false;
                    if (username == null)
                        username = checuser.login;
                }

                Console.SetCursorPosition(0, longe + 2);
                for (int i = 0; i < Console.WindowWidth; i++)
                    Console.Write(" ");
                Console.SetCursorPosition(0, longe + 2);
                if (iflogineror)
                    Console.Write(logineror + " ");
                if (ifpassworderor)
                    Console.Write(passworderor);
                break;
        }
        return true;
    }
    private static string ReadPasword()
    {
        string pass = "";
        Console.SetCursorPosition(MainClass.autcontent.Split("\n")[Control.YCursorPos - 2].Length, Control.YCursorPos);
        for (int i = 0; i < lastconter; i++)
            Console.Write(" ");
        Console.SetCursorPosition(MainClass.autcontent.Split("\n")[Control.YCursorPos - 2].Length, Control.YCursorPos);
        int conter = 0;
        do
        {
            conter++;
            Control.key = Console.ReadKey(true);
            if (!Char.IsControl(Control.key.KeyChar))
            {
                pass += Control.key.KeyChar;
                Console.Write("*");
            }
            else if (Control.key.Key == ConsoleKey.Backspace)
            {
                pass = "";
                Console.SetCursorPosition(MainClass.autcontent.Split("\n")[Control.YCursorPos - 2].Length, Control.YCursorPos);
                for (int i = 0; i < conter; i++)
                    Console.Write(" ");
                Console.SetCursorPosition(MainClass.autcontent.Split("\n")[Control.YCursorPos - 2].Length, Control.YCursorPos);
            }
        }
        while (Control.key.Key != ConsoleKey.Enter);
        Console.SetCursorPosition(0, 2 + Control.YCursorPos - 1);
        lastconter = conter;
        return pass;
    }
}