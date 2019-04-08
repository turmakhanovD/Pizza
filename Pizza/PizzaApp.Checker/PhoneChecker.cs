using System;

namespace PizzaApp.Checker
{
    public class PhoneChecker
    {
        private const int PHONE_SYM_NUMBER = 12;
        public void Check(ref string _phoneNumber)
        {
            _phoneNumber = Console.ReadLine();
            Console.WriteLine();
            while (_phoneNumber.Length < PHONE_SYM_NUMBER)
            {
                Console.Write("Sorry, write your phone correctly \n");
                Console.Write("Phone number: ");
                _phoneNumber = Console.ReadLine();

            }
        }
    }
}
