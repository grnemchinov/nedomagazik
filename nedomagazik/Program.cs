using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace nedomagazik;
class MainClass
{
    const string autmenutext = "Дпвм";
    public const string autcontent = "  Логин: \n  Пароль: \n  Авторизоваться";
    public const string adminmenutext = "Админ CRUD";
    public const string warehousemanegertext = "Склад Менеджер CRUD";
    public const string CRUDcontent = "  Create\n  Dlete Нажмите Enter для удаления\n  Read\n  Update";
    public const string CUAcontent = "  ID: \n  Login: \n  Password: \n  roole: \n  Создать\n1-admin\n2-personnelmanager\n3-\n4-\n5-";
    public const string CUPMcontent = "  ID: \n  Surname: \n  Name: \n  Patronymic: \n  Born: \n  Serialnumber: \n  Status: \n  Iduser: \n  Создать";
    public const string CUWMcontent = "  ID: \n  Name: \n  Cost: \n  Count: \n  Создать";
    public const string CUBPcontent = "  ID: \n  Name: \n  Data: \n  Cost: \n  Pluss: \n  Создать";
    const int autlonge = 3;
    const int CRUDlonge = 4;
    public enum keybinds
    {
        Escape = ConsoleKey.Escape,
        Enter = ConsoleKey.Enter
    }
    public static void Main(string[] args)
    {

        Console.WindowHeight = Console.LargestWindowHeight;
        Console.WindowWidth = Console.LargestWindowWidth;

        bool keepRunning = true;
        Console.WriteLine("Нажмите CTRL+C для входа в магазин");
        Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            keepRunning = false;
        };
        while (keepRunning) { }
        while (true)
        {
            Auten();
            Control.YCursorPos = 2;
        }
    }
    static void Auten()
    {
        bool chec = true;
        Console.Clear();
        Menu.Meni(autmenutext, autcontent);
        while (chec)
        {
            Control.ReadKey(autlonge);
            Control.MenuArrow(autlonge);
            if (Control.key.Key == (ConsoleKey)keybinds.Enter)
                chec = Aut.Read(autlonge);
        }
    }
    static void Admine()
    {
        bool chec = true;
        Console.Clear();
        Menu.Meni(warehousemanegertext + ": " + Aut.username, CRUDcontent);
        while (Control.key.Key != (ConsoleKey)keybinds.Escape || chec)
        {
            Control.ReadKey(CRUDlonge);
            Control.MenuArrow(CRUDlonge);
            chec = Admin.CRUDe();
        }
    }
}