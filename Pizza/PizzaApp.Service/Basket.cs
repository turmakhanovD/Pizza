using PizzaApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.Service
{
    public class Basket
    {
        private List<Pizza> pizzas = new List<Pizza>();

        public void AddToBasket(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void OpenBasket()
        {
            Console.Clear();
            int sum = 0;
            foreach (var pizza in pizzas)
            {
                sum += pizza.Price;

            }
            Console.WriteLine("\t\t\tКорзина");
            foreach (var pizza in pizzas.Distinct())
            {
                
                Console.WriteLine(pizza.Name + " x " + pizzas.Where(x => x == pizza).Count() );
            }

            Console.WriteLine($"С ваc { sum } тг\n");/*Как вы хотите оплатить счет?\n1.Наличными\n2.PayPal*/

                Console.WriteLine("Введите свой адрес: ");
            Console.ReadLine();
            Console.WriteLine("Ожидайте заказ!");

        }
    }
}
