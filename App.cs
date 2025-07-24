using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class App
    {
        internal static void Start() 
        {
            Console.WriteLine( "Welcome to your password manager ^_-" );
            bool isAuthenticated = Authenticator.start_Authentication();
            if (isAuthenticated)
            {
                Manager pass_manager = new Manager();
                while (true)
                {
                    Console.WriteLine("\n\n ______________________");
                    Console.Write(">");
                                     
                    string input = Console.ReadLine().ToLower().Trim();

                    if (input == "exit")
                    {
                        Console.WriteLine("Exiting the application. Goodbye!");
                        break;
                    }
                    else if (input == "view")
                    {
                        pass_manager.View_Passwords();
                    }
                    else if (input == "add")
                    {
                        Console.WriteLine("Enter the site name:");
                        string site = Console.ReadLine().Trim();
                        Console.WriteLine("Enter the password:");
                        string pass = Console.ReadLine();
                        pass_manager.AddPassword(site, pass);
                    }
                    else if (input == "remove")
                    {
                        Console.WriteLine("Enter the site name to remove:");
                        string site = Console.ReadLine();
                        pass_manager.RemovePassword(site);
                    }
                    else if (input == "update")
                    {
                        Console.WriteLine("Enter the site name:");
                        string site = Console.ReadLine().Trim();
                        Console.WriteLine("Enter the new password:");
                        string pass = Console.ReadLine();
                        pass_manager.UpdatePassword(site, pass);
                    }
                    else if (input == "save")
                    {
                        pass_manager.SaveChanges();
                    }
                }
            }
        }
    }
}
