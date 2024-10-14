using System;
using System.Linq;

namespace ConsoleTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Task: 
                User class

                - Username
                - Age
                - Password

                Username, password property-ləri olmadan user obyekti yaratmaq olmaz.

                Age propery-i mənfi ola bilməz.

                Password property-i bu şərtləri ödəməlidir:

                1. Boş ola bilməz
                2. Uzunluğu 8-dən kiçik ola bilməz
                3. İçində ən az bir böyük hərf olmalıdır
                4. İçində ən az bir rəqəm olmalıdır

                Üçüncü və dördüncü şərti ayrı bir private methodda yazıb gəlib propertyinin 
                setində istifadə etmək lazımdır.
             */

            var newUserObject = new User("Fuad", "Sebas157469832");
            var newUserObject1 = new User("Fuad", "sebas");



            Console.WriteLine($"{newUserObject.Name}\n{newUserObject.Password}\n{newUserObject.Age}");
            Console.WriteLine($"{newUserObject1.Name}\n{newUserObject1.Password}\n{newUserObject1.Age}");
        }
        public class User
        {
            private string _password;
            public string Name { get; set; }
            public string Password
            {
                get
                {
                    return _password;
                }
                set
                {
                    _password = CheckPassword(value);
                }
            }
            public int? Age { get; set; }
            public User(string name, string password, int? age = null)
            {
                if (name == null) throw new ArgumentNullException("name doesnt exist");
                Name = name;
                Password = password;
                Age = age;
            }
        }

        private static string CheckPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password doesnt exist");
            }
            password.Trim();

            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter.");
            }

            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }

            return password;
        }
    }
}
