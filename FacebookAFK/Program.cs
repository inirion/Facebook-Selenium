using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAFK
{
    class Program
    {
        static void Main(string[] args)
        {
            string Login = "";
            string Password = "";
            string Person = "";
            FrontPage loginPage = new FrontPage();
            HomePage facebookHomePage = loginPage.Login(Login, Password);
            facebookHomePage.SendMessage(Person, "To jest bot");
            facebookHomePage.SendMessage(Person, "Bot jest fajny");
            facebookHomePage.SendMessage(Person, "Tralala");
        }
    }
}
