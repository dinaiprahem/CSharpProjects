

using System.Text;

namespace passwordManager
{
    internal class Program
    {
        private static readonly Dictionary<string, string> _websitePasswords = new();
        static void Main(string[] args)
        {
            readPasswords();
            while(true)
            {
                Console.WriteLine("please select option");
                Console.WriteLine("1. list all passwords");
                Console.WriteLine("2. add / change password");
                Console.WriteLine("3. get password");
                Console.WriteLine("4. delete password");
                var option = Console.ReadLine();
                if (option == "1")
                {
                    listAllPasswords();
                }
                else if (option == "2")
                {
                    addOrChangePassword();
                }
                else if (option == "3")
                {
                    getPassword();
                }
                else if (option == "4")
                {
                    deletePassword();
                }
                Console.WriteLine("\n-------------------------------------------\n");
            }
        }

        private static void readPasswords()
        {
            if(File.Exists("passwords.txt"))
            {
                var read = File.ReadAllText("passwords.txt");
                foreach (var item in read.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(item))
                      {
                        // to split pass and name of site
                        var index = item.IndexOf("=");
                        var name = item.Substring(0, index);
                        var pass = item.Substring(index + 1);
                        //make decryption before reading from file and adding to dictionary
                        _websitePasswords.Add(name,EncryptionUtilities.decrypt(pass));
                      }
                }
            }
           
        }
        private static void savePasswords()
        {
            var sb = new StringBuilder();
            foreach (var item in _websitePasswords)
            { // make encryption before adding to the file
                sb.AppendLine($"{item.Key} = {EncryptionUtilities.encrypt( item.Value) }");
            }
            File.WriteAllText("passwords.txt", sb.ToString());

        }
        private static void deletePassword()
        {
            Console.Write("enter the name of website :");
            var name = Console.ReadLine();
            if (_websitePasswords.ContainsKey(name))
            {
                _websitePasswords.Remove(name);
                Console.WriteLine($"password removed");
                savePasswords();
            }
            else
            {
                Console.WriteLine("password not found");
            }
        }

        private static void getPassword()
        {
            Console.Write("enter the name of website :");
            var name = Console.ReadLine();
            if (_websitePasswords.ContainsKey(name)) {
                Console.WriteLine($"password of {name} is {_websitePasswords[name]} ");
            }else
            {
                Console.WriteLine("password not found");
            }
        }

        private static void addOrChangePassword()
        {
            Console.Write("please enter the name of website :");
            var name = Console.ReadLine();
            Console.Write("enter the password :");
            var pass = Console.ReadLine();
            if (_websitePasswords.ContainsKey(name))
            {
                _websitePasswords[name] = pass;
                Console.WriteLine($"password of {name } changed.");
            }
            else
            {
                _websitePasswords.Add(name, pass);
                Console.WriteLine($"password added successfully.");
            }
            savePasswords();
        }

        private static void listAllPasswords()
        {
            foreach (var item in _websitePasswords)
            {
                Console.WriteLine($" {item.Key} = {item.Value}");
            }
        }
    }
}
