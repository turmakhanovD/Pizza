using PizzaApp.Checker;
using PizzaApp.Service;
using RegistrationSystem;
using System;

namespace PizzaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu main = new MainMenu();
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            LoginSystem loginSystem = new LoginSystem();
            HidePassword hide = new HidePassword();
            string login, password = "";

            Console.WriteLine("\t\t\t\tPizzaHUB" + "\nChoose action:" + "\n1.Login" + "\n2.Register");
            
            int choose = 0;
            while (choose != 1 && choose != 2)
            {
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\t\tLogin\nLogin:");
                            login = Console.ReadLine();
                            Console.WriteLine("Password:");
                            hide.Hide(ref password);
                            loginSystem.LogIn(login, password);
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Clear();
                            Registration registration = new Registration();
                            registration.StartRegistration();
                            main.OpenPizzaMenu();
                            break;
                        default:
                            break;
                    }
                }
                else if(choose > 2) Console.WriteLine("Введите адекватное число!");
                else Console.WriteLine("Введите адекватное число!");
                
              
            }
            Console.ReadLine();
        }
    }
}
