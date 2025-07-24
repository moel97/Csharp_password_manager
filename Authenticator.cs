using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Authenticator
    {
        private static string _password = "0000";
        internal static bool start_Authentication() {
            string input = null;
            for (int i = 0; i <3; i++)
            {
                Console.WriteLine("Please enter your password:");
                input = Console.ReadLine();
                if (input == _password) 
                {
                    Console.WriteLine("Please enter an option:");
                    Console.WriteLine("[Add] for adding a new password");
                    Console.WriteLine("[View] for displaying existing passwords");
                    Console.WriteLine("[Remove] for removing an existing password");
                    Console.WriteLine("[Update] to update a password");
                    Console.WriteLine("[Save] to save the changes ");
                    Console.WriteLine("[Exit] to Exit");
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect password, please try again."); 
                }
            }
            Console.WriteLine("Too many attempts, access denied.");
            return false;

            
        }
    }
}
