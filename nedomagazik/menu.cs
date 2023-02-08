using nedomagazik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace nedomagazik;

internal static class Menu
{
    public static void Meni(string menitext, string content)
    {
        MeniUp(menitext);
        MeniContent(content);
    }
    private static void MeniUp(string menitext)
    {
        Console.SetCursorPosition((Console.WindowWidth - menitext.Length) / 2, 0);
        Console.WriteLine(menitext);
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write("-");
    }
    public static void MeniContent(string content)
    {
        Console.SetCursorPosition(0, 2);
        Console.WriteLine(content);
    }
    public static int MenuCUA(AutObject newe, int ChoseUserpos, bool CorU)
    {

        Control.ReadKey(MainClass.CUAcontent.Split("\n").Length - 5);
        Control.MenuArrow(MainClass.CUAcontent.Split("\n").Length - 5);
        if (Control.key.Key == ConsoleKey.Enter)
        {
            Console.SetCursorPosition(MainClass.CUAcontent.Split("\n")[Control.YCursorPos - 2].Length, Control.YCursorPos);
            string text = null;
            if (Control.YCursorPos - 2 != 5)
                text = Console.ReadLine();
            switch (Control.YCursorPos - 2)
            {
                case 0:
                    try { newe.id = UInt32.Parse(text); }
                    catch
                    {
                        Console.SetCursorPosition(0, MainClass.CUAcontent.Split("\n").Length + 2);
                        Console.WriteLine("Вводите число в ID и roole");
                    }
                    break;
                case 1:
                    newe.login = text;
                    break;
                case 2:
                    newe.password = text;
                    break;
                case 3:
                    try { newe.role = UInt32.Parse(text); }
                    catch
                    {
                        Console.SetCursorPosition(0, MainClass.CUAcontent.Split("\n").Length + 2);
                        Console.WriteLine("Вводите число в ID и roole");
                    }
                    break;
                case 4:
                    Console.SetCursorPosition(0, MainClass.CUAcontent.Split("\n").Length + 2);
                    Console.WriteLine("                          ");
                    if (newe.login != null && newe.password != null)
                    {
                        List<AutObject> checusers = Sterealizer.desteruser<List<AutObject>>(Startname.Users);
                        if (CorU)
                        {
                            checusers.RemoveAt(ChoseUserpos);
                        }
                        checusers.Add(newe);
                        Sterealizer.steruser(checusers, Startname.Users);
                    }
                    else
                    {
                        Console.SetCursorPosition(0, MainClass.CUAcontent.Split("\n").Length + 2);
                        Console.WriteLine("Заполните все поля");
                    }
                    break;
            }

        }
        return ChoseUserpos;
    }
}