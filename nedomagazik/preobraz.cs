using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace nedomagazik;
internal class AutObject
{
    public uint id { get; set; }
    public string login { get; set; }
    public string password { get; set; }
    public uint role { get; set; }
}
internal class EmployeObject
{
    public uint id { get; set; }
    public string surname { get; set; }
    public string name { get; set; }
    public string patronymic { get; set; }
    public DateTime born { get; set; }
    public int serialnumber { get; set; }
    public string status { get; set; }
    public uint pay { get; set; }
    public uint iduser { get; set; }
}
internal class GoodGodObject
{
    public uint id { get; set; }
    public string name { get; set; }
    public uint cost { get; set; }
    public uint count { get; set; }
}
internal class BookeepingentryObject
{
    public uint id { get; set; }
    public string name { get; set; }
    public DateTime data { get; set; }
    public uint cost { get; set; }
    public bool plus { get; set; }
}
internal class BuyObject
{
    public uint id { get; set; }
    public List<GoodGodObject> check { get; set; }
}
internal static class Sterealizer
{
    public static void steruser<T>(T listdata, string paff)
    {
        string paf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string json = JsonSerializer.Serialize(listdata);
        File.WriteAllText(paf + paff, json);
    }
    public static T desteruser<T>(string paff)
    {
        string paf = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string jsontext = File.ReadAllText(paf + paff);
        T list = JsonSerializer.Deserialize<T>(jsontext);
        return list;
    }
}