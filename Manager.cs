using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Manager
    {
        private Dictionary<string, string> _passwords = new();
        private string _FilePath = "C:\\Users\\mohamed elsayed\\source\\repos\\c#_training\\PasswordManager\\WORDS.txt";
        internal Manager()
        {
            if (File.Exists(_FilePath))
            {
                LoadPasswordsFromFile(_FilePath);
            }
            else
            {
                Console.WriteLine("No password file found. Starting with an empty password manager.");
            }
        }
        public void View_Passwords()
        {
            foreach (object KeyValuePair in _passwords)
            {
                Console.WriteLine(KeyValuePair);
            }
        }

        internal bool AddPassword(string site, string? pass)
        {
            bool isadded = _passwords.TryAdd(site, pass);
            if (isadded)
            {
                Console.WriteLine("Password added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add password. It may already exist.");
            }
            return isadded;
        }

        internal bool RemovePassword(string site)
        {
            if (_passwords.Remove(site))
            {
                Console.WriteLine("Password removed successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to remove password. It may not exist.");
                return false;
            }
        }

        internal void SaveChanges()
        {
            if (File.Exists(_FilePath))
            {
                SavePasswordstoFile(_FilePath);
            }
            else
            {
                File.Create(_FilePath).Close();
                SavePasswordstoFile(_FilePath);
            }
        }

        internal void UpdatePassword(string site, string? pass)
        {
            if (_passwords.ContainsKey(site))
            {
                _passwords[site] = pass;
                Console.WriteLine("Password updated successfully.");    
            }
            else
            {
                _passwords.Add(site, pass);
                Console.WriteLine("Site was not found, but we added it for you as new enty.");
            }
        }
        private void LoadPasswordsFromFile(string FileName)
        {
            StringBuilder site = new();
            StringBuilder pass = new();
            StringBuilder[] lineArray = new StringBuilder[2];
            foreach (string line in File.ReadLines(FileName))
            {
                lineArray = line.Split(",").Select(s => new StringBuilder(s)).ToArray();
                if (lineArray.Length == 2)
                {
                    site = lineArray[0];
                    pass = lineArray[1];
                    _passwords.Add(site.ToString(), pass.ToString());
                }
            }
        }

        private void SavePasswordstoFile(string FileName)
        {
            // Prepare all lines first
            var lines = _passwords.Select(kvp => $"{kvp.Key},{kvp.Value}");

            // Write all at once (atomic operation)
            File.WriteAllLines(FileName, lines);

            Console.WriteLine("Your data was saved successfully.");

        }
    }
}   
