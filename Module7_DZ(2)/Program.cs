using System;
namespace TemplateMethodDemo
{
    abstract class Beverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments()) AddCondiments();
        }
        protected void BoilWater() => Console.WriteLine("Кипятим воду...");
        protected abstract void Brew();
        protected void PourInCup() => Console.WriteLine("Наливаем напиток в чашку...");
        protected abstract void AddCondiments();
        protected virtual bool CustomerWantsCondiments()
        {
            Console.Write("Добавить лимон? (да/нет): ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return false;
            input = input.Trim().ToLower();
            if (input == "да" || input == "д") return true;
            if (input == "нет" || input == "н") return false;
            Console.WriteLine("Некорректный ответ, считаем, что без добавок.");
            return false;
        }
    }
    class Tea : Beverage
    {
        protected override void Brew() => Console.WriteLine("Завариваем чай...");
        protected override void AddCondiments() => Console.WriteLine("Добавляем лимон...");
    }
    class Coffee : Beverage
    {
        protected override void Brew() => Console.WriteLine("Готовим кофе...");
        protected override void AddCondiments() => Console.WriteLine("Добавляем сахар и молоко...");

        protected override bool CustomerWantsCondiments()
        {
            Console.Write("Добавить сахар и молоко? (да/нет): ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return false;
            input = input.Trim().ToLower();
            if (input == "да" || input == "д") return true;
            if (input == "нет" || input == "н") return false;
            Console.WriteLine("Некорректный ответ, считаем, что без добавок.");
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приготовим чай:");
            var tea = new Tea();
            tea.PrepareRecipe();

            Console.WriteLine("\nПриготовим кофе:");
            var coffee = new Coffee();
            coffee.PrepareRecipe();
        }
    }
}
