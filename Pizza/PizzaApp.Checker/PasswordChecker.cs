using System;

namespace PizzaApp.Checker
{
    public class PasswordChecker
    {
        private const int _NORMAL_PASSWORD_NUM = 6;
        HidePassword hide = new HidePassword();


        public bool IsntUpper(string str)
        {
            if (str.Equals(str.ToLower()))
                return true;
            return false;
        }

        public void Check(ref string _password, ref string _repeatPassword)
        {
            hide.Hide(ref _password);
            Console.WriteLine();

            while (string.IsNullOrEmpty(_password) || _password.Length < _NORMAL_PASSWORD_NUM || IsntUpper(_password))
            {

                Console.Write("Sorry, your password is not safety! at less |1 number | 1 high letter\n ");
                Console.Write("Password: ");
                //_password = ReadLine();
                hide.Hide(ref _password);
                Console.WriteLine();
            }

            Console.Write("Repeat your password: ");
            hide.Hide(ref _repeatPassword);
            Console.WriteLine();

            while (_repeatPassword != _password)
            {
                Console.Write("Sorry, your password is not equal, please, try again!\n");
                Console.Write("Repeat your password: ");

                hide.Hide(ref _repeatPassword);
                Console.WriteLine();
            }

        }


    }
}