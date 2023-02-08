using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nedomagazik;
internal class Control
{
    public static int YCursorPos = 2;
    public static ConsoleKeyInfo key;

    public static void ReadKey(int longe)
    {
        key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (YCursorPos > 2)
                    YCursorPos--;
                break;
            case ConsoleKey.DownArrow:
                if (YCursorPos < 1 + longe)
                    YCursorPos++;
                break;
        }
    }
    public static void MenuArrow(int longe)
    {
        if (YCursorPos != 2)
        {
            Console.SetCursorPosition(0, YCursorPos - 1);
            Console.WriteLine("  ");
        }
        if (YCursorPos != longe + 1)
        {
            Console.SetCursorPosition(0, YCursorPos + 1);
            Console.WriteLine("  ");
        }
        Console.SetCursorPosition(0, YCursorPos);
        Console.WriteLine("  ");
        Console.SetCursorPosition(0, YCursorPos);
        Console.WriteLine("=>");
        Console.SetCursorPosition(0, YCursorPos);
    }
}