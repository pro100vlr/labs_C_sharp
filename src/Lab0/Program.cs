using System;
using System.Collections.Generic;

namespace VendingMachineApp
{
    class Program
    {
        class Product
        {
            public string Name {get; set;}
            public int Price {get; set;}
            public int Count {get; set;}

            public Product(string name, int price, int count)
            {
                Name = name;
                Price = price;
                Count = count;
            }
        }

        static List<Product> products = new List<Product>()
        {
            new Product("Сникерс", 50, 5),
            new Product("Кола", 70, 3),
            new Product("Чипсы", 40, 4),
            new Product("Вода", 30, 6)
        };

        static int userMoney = 0;
        static int machineMoney = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Вендинговый автомат\n");

            while (true)
            {
                Console.WriteLine("1. Показать товары");
                Console.WriteLine("2. Внести монеты");
                Console.WriteLine("3. Купить товар");
                Console.WriteLine("4. Вернуть деньги");
                Console.WriteLine("5. Админ-режим");
                Console.WriteLine("0. Выход");

                Console.Write("\nВыберите пункт меню: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        InsertCoins();
                        break;
                    case "3":
                        BuyProduct();
                        break;
                    case "4":
                        ReturnMoney();
                        break;
                    case "5":
                        AdminMode();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный пункт меню.\n");
                        break;
                }
            }
        }

        static void ShowProducts()
        {
            Console.WriteLine("Список товаров:");
            for (int i = 0; i < products.Count; i++)
            {
                Product p = products[i];
                Console.WriteLine($"{i+1}. {p.Name} - {p.Price} руб. (осталось {p.Count})");
            }
            Console.WriteLine();
        }

        static void InsertCoins()
        {
            Console.Write("Введите сумму монет (10, 50, 100): ");
            string input = Console.ReadLine();
            int sum;
            if (int.TryParse(input, out sum))
            {
                if (sum == 10 || sum == 50 || sum == 100)
                {
                    userMoney += sum;
                    Console.WriteLine($"Вы внесли {sum} руб. Всего внесено: {userMoney} руб.\n");
                }
                else
                {
                    Console.WriteLine("Автомат принимает только 10, 50 или 100 руб.\n");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода.\n");
            }
        }

        static void BuyProduct()
        {
            ShowProducts();
            Console.Write("Введите номер товара: ");
            string input = Console.ReadLine();
            int num;
            if (int.TryParse(input, out num) && num >= 1 && num <= products.Count)
            {
                Product chosen = products[num - 1];
                if (chosen.Count <= 0)
                {
                    Console.WriteLine("Товара нет в наличии.\n");
                }
                else if (userMoney >= chosen.Price)
                {
                    userMoney -= chosen.Price;
                    machineMoney += chosen.Price;
                    chosen.Count--;
                    Console.WriteLine($"Вы купили {chosen.Name}. Остаток средств: {userMoney} руб.\n");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств!\n");
                }
            }
            else
            {
                Console.WriteLine("Неверный номер товара.\n");
            }
        }

        static void ReturnMoney()
        {
            if (userMoney > 0)
            {
                Console.WriteLine($"Вам возвращено {userMoney} руб.\n");
                userMoney = 0;
            }
            else
            {
                Console.WriteLine("Нет внесённых денег.\n");
            }
        }

        static void AdminMode()
        {
            Console.Write("Введите пароль: ");
            string pass = Console.ReadLine();
            if (pass == "1234") // условный пароль
            {
                Console.WriteLine("Админ-режим:");
                Console.WriteLine($"В автомате денег: {machineMoney} руб.");

                Console.Write("Собрать выручку? (да/нет): ");
                string collect = Console.ReadLine();
                if (collect.ToLower() == "да")
                {
                    Console.WriteLine($"Вы забрали {machineMoney} руб.");
                    machineMoney = 0;
                }

                Console.WriteLine("Хотите пополнить товары? (да/нет): ");
                string ans = Console.ReadLine();
                if (ans.ToLower() == "да")
                {
                    ShowProducts();
                    Console.Write("Введите номер товара для пополнения: ");
                    string input = Console.ReadLine();
                    int num;
                    if (int.TryParse(input, out num) && num >= 1 && num <= products.Count)
                    {
                        Console.Write("Введите количество для добавления: ");
                        string countStr = Console.ReadLine();
                        int addCount;
                        if (int.TryParse(countStr, out addCount))
                        {
                            products[num - 1].Count += addCount;
                            Console.WriteLine("Товар пополнен.\n");
                        }
                    }
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Неверный пароль.\n");
            }
        }
    }
}

