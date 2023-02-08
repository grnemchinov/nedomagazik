using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nedomagazik
{
    internal class Startname
    {
        public const string Users = "\\source\\repos\\shop10\\users.json";
        public static List<AutObject> startname()
        {
            AutObject user1 = new AutObject();
            user1.id = 121;
            user1.login = "admin";
            user1.password = " ";
            user1.role = 1;
            AutObject user2 = new AutObject();
            user2.id = 11;
            user2.login = "user1";
            user2.password = " ";
            user2.role = 2;
            AutObject user3 = new AutObject();
            user3.id = 12;
            user3.login = "user2";
            user3.password = " ";
            user3.role = 3;
            AutObject user4 = new AutObject();
            user4.id = 21;
            user4.login = "user3";
            user4.password = " ";
            user4.role = 4;
            AutObject user5 = new AutObject();
            user5.id = 22;
            user5.login = "user4";
            user5.password = " ";
            user5.role = 5;
            List<AutObject> listuser = new List<AutObject>();
            listuser.Add(user1);
            listuser.Add(user2);
            listuser.Add(user3);
            listuser.Add(user4);
            listuser.Add(user5);
            return listuser;
        }
    }
}
