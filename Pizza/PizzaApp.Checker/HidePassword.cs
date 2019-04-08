using System;

namespace PizzaApp.Checker
{
    public class HidePassword
    {
        public string Hide(ref string password)
        {
            ConsoleKeyInfo key;
            string code = "";
            do
            {
                key = Console.ReadKey(true);

                if (Char.IsNumber(key.KeyChar) || Char.IsLetter(key.KeyChar))//||Char.IsControl(key.KeyChar))
                {
                    Console.Write("*");
                }
                code += key.KeyChar;
            } while (key.Key != ConsoleKey.Enter);
            password = code;
            return code;
        }
    }
}
