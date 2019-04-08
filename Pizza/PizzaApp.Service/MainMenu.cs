using PizzaApp.Model;
using System;

namespace PizzaApp.Service
{
    public class MainMenu
    {
        public Pizza MargariteCombo = new Pizza { Id = 1, Name = "Итальянская маргарита", Price = 2000 };
        public Pizza PeperoniCombo = new Pizza { Id = 1, Name = "Пеперони острая", Price = 2800 };
        public Pizza ElitePizzaCombo = new Pizza { Id = 1, Name = "Фирменная пицца", Price = 7200 };
        private Basket basket = new Basket();

        public void OpenPizzaMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t\tPizzaHUB" + "\n1.Комбо \"Маргаритус\" (Итальянская маргарита + 2л кола) |2000тг"
                + "\n2.Комбо \"Пеперониус\" (Пеперони острая + 2л кола) |2800тг"
                + "\n3.Комбо \"Мажориус\" (Фирменная пицца + 2л кола) |7200тг"
                + "\n4.Корзина" +
                "\n5.Exit");
            int choose = 0;
            while (choose != 5 && choose != 4)
            {
                int.TryParse(Console.ReadLine(), out choose);
                switch (choose)
                {
                    case 1:
                        basket.AddToBasket(MargariteCombo);
                        Console.WriteLine("Вы успешно приобрели первое комбо!");                   
                        break;
                    case 2:
                        basket.AddToBasket(PeperoniCombo);
                        Console.WriteLine("Вы успешно приобрели второе комбо!");
                        break;
                    case 3:
                        basket.AddToBasket(ElitePizzaCombo);
                        Console.WriteLine("Вы успешно приобрели третье комбо!");
                        break;
                    case 4:
                        basket.OpenBasket();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Введите корректное число!");
                        break;
                }
            }
        }
    }
}
