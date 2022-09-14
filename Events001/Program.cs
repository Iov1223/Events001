using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;

namespace Events001
{
    delegate void myDelegate(string str);
    class someclass
    {
        private string hello = "Hello, {0}!",
            hi = "Hi, {0}!", rus_hello = "Здравствуйте, {0}!",
            rus_hi = "Привет, {0}!";
        public string userName, _output = "output.txt";
        public int userAge;
        public event myDelegate _notify;
        public someclass()
        {
            Console.WriteLine("Как вас зовут?");
            userName = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            userAge = int.Parse(Console.ReadLine());
            if (userAge < 18)
            {
                _notify = teenHi;
                _notify += teenWrite;
            }
            else
            {
                _notify = adultHi;
                _notify += adultWrite;
            }

        }
        public void teenHi(string _name)
        {
            Console.WriteLine(rus_hi, _name);
        }
        public void adultHi(string _name)
        {
            Console.WriteLine(rus_hello, _name);
        }
        public void teenWrite(string _name)
        {
            try
            {
                var _file = new StreamWriter(_output, true);
                _file.WriteLine(rus_hi, _name);
                _file.Close();
            }
            catch
            {
                Console.WriteLine("Не получилось записать в файл...");
            }
        }
        public void adultWrite(string _name)
        {
            try
            {
                var _file = new StreamWriter(_output, true);
                _file.WriteLine(rus_hello, _name);
                _file.Close();
            }
            catch
            {
                Console.WriteLine("Не получилось записать в файл...");
            }
        }

        public void Hello()
        {
            _notify(this.userName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var NewUser = new someclass();
            NewUser.Hello();
        }
    }
}
