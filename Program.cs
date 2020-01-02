using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        // 01.Ages
        public static void Ages(int input)
        {
            if (input >= 0 && input <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (input >= 3 && input <= 13)
            {
                Console.WriteLine("child");
            }
            else if (input >= 14 && input <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (input >= 20 && input <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (input >= 66)
            {
                Console.WriteLine("elder");
            }
        }

        //02.Division
        public static void Division(int input)
        {

            if (input % 10 == 0)
            {
                Console.WriteLine("The number is divisible by 10");
                return;
            }
            else if (input % 7 == 0)
            {
                Console.WriteLine("The number is divisible by 7");
                return;
            }
            else if (input % 6 == 0)
            {
                Console.WriteLine("The number is divisible by 6");
                return;
            }
            else if (input % 3 == 0)
            {
                Console.WriteLine("The number is divisible by 3");
                return;
            }
            else if (input % 2 == 0)
            {
                Console.WriteLine("The number is divisible by 2");
                return;
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }

        //03.Vacation
        public static void Vacation(int people, string peopleType, string weekDay)
        {        

            peopleType.ToLower();

            weekDay.ToLower();

            decimal price = default;

            decimal percentage = default;

            if (peopleType == "students")
            {
                if (weekDay == "friday")
                {
                    price = people * 8.45m;

                    if (people >= 30)
                    {
                        percentage = 1.5m * (price / 10);
                        price -= percentage;
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
                else if (weekDay == "saturday")
                {
                    price = people * 9.80m;

                    if (people >= 30)
                    {
                        percentage = 1.5m * (price / 10);
                        price -= percentage;
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
                else if (weekDay == "sunday")
                {
                    price = people * 10.46m;

                    if (people >= 30)
                    {
                        percentage = 1.5m * (price / 10);
                        price -= percentage;
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
            }
            else if (peopleType == "business")
            {
                if (weekDay == "friday")
                {
                    price = people * 10.90m;

                    if (people >= 100)
                    {

                        price -= (10.90m * 10);
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
                else if (weekDay == "saturday")
                {
                    price = people * 15.60m;

                    if (people >= 100)
                    {

                        price -= (10.90m * 10);
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
                else if (weekDay == "sunday")
                {
                    price = people * 16m;

                    if (people >= 100)
                    {

                        price -= (10.90m * 10);
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
            }
            else if (peopleType == "regular")
            {
                if (weekDay == "friday")
                {
                    price = people * 15m;

                    if (people >= 10 && people <= 20)
                    {
                        percentage = 0.5m * (price / 10);
                        price -= percentage;
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
                else if (weekDay == "saturday")
                {
                    price = people * 20m;

                    if (people >= 10 && people <= 20)
                    {
                        percentage = 0.5m * (price / 10);
                        price -= percentage;
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
                else if (weekDay == "sunday")
                {
                    price = people * 22.50m;

                    if (people >= 10 && people <= 20)
                    {
                        percentage = 0.5m * (price / 10);
                        price -= percentage;
                    }

                    Console.WriteLine($"Total price: {price:F2}");
                    return;
                }
            }
        }

        //04.PrintAndSum
        public static void PrintAndSum(int start, int end)
        {
            int sum = default;

            var numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);

                sum += i;
            }

            Console.Write(String.Join(' ', numbers));
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }

        //05.Login
        public static void Login(string username)
        {
            char[] passwordProcessing = username.ToArray();

            Array.Reverse(passwordProcessing);

            string password = new string(passwordProcessing);

            var input = Console.ReadLine();

            for (int i = 0; i < 3; i++)
            {
                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                input = Console.ReadLine();
            }


            Console.WriteLine($"User {username} blocked!");
        }

        //06.Strong Numbers
        public static void StrongNumbers(int insert)
        {
            int number = insert;
            int factoriel;

            int sum = default;

            while (number != 0)
            {
                int currentNumber = number % 10;
                number /= 10;
                factoriel = 1;

                for (int i = 1; i <= currentNumber; i++)
                {
                    factoriel *= i;
                }

                sum += factoriel;
            }

            if (sum == insert)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        //07.Vending Machine
        public static void VendingMachine(string input)
        {
         
            decimal sum = default;

            while (input != "Start")
            {
                var money = decimal.Parse(input);

                if (money == 0.1m || money == 0.2m || money == 0.5m || money == 1m || money == 2m)
                {
                    sum += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {

                if (input == "Nuts")
                {

                    if (sum - 2.0m < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 2.0m;

                        Console.WriteLine("Purchased nuts");
                    }

                }
                else if (input == "Water")
                {

                    if (sum - 0.7m < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 0.7m;

                        Console.WriteLine("Purchased water");
                    }
                }
                else if (input == "Crisps")
                {


                    if (sum - 1.5m < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 1.5m;

                        Console.WriteLine("Purchased crisps");
                    }
                }
                else if (input == "Soda")
                {

                    if (sum - 0.8m < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        sum -= 0.8m;

                        Console.WriteLine("Purchased soda");

                    }
                }
                else if (input == "Coke")
                {
                    sum -= 1.0m;

                    if (sum < 0)
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine("Purchased coke");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:F2}");
        }

        //08.Triangle Of Numbers
        public static void TriangleOFNumbers(int insert)
        {
            List<int> numbers = new List<int>();

            for (int column = 1; column <= insert; column++)
            {
                numbers.Clear();

                for (int row = 1; row <= column; row++)
                {
                    numbers.Add(column);
                }
                Console.Write(String.Join(' ', numbers));

                Console.WriteLine();
            }
        }

        //09.Padawan Equipment
        public static void PadawanEquipment(double moneyAmount, int studentsCount, double lightsabersPrice,
                                            double robesPrice, double beltPrice)
        {
            double percentage = Math.Ceiling(((double)studentsCount * 10) / 100);

            if (percentage < 1)
            {
                percentage = 1;
            }

            double freeBelts = studentsCount / 6;

            double saberSum = lightsabersPrice * (studentsCount + percentage);
            double robesSum = robesPrice * studentsCount;
            double beltsSum = beltPrice * (studentsCount - freeBelts);

            double equipmentPrice = saberSum + robesSum + beltsSum;

            if (moneyAmount >= equipmentPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentPrice:F2}lv.");
            }
            else
            {
                double need = equipmentPrice - moneyAmount;
                Console.WriteLine($"Ivan Cho will need {need:F2}lv more.");
            }
        }

        //10.Rage Expenses
        public static void RageExpenses(int lostGames, 
                                        double headsetPrice,
                                        double mousePrice,
                                        double keyboardPrice,
                                        double displayPrice)
        {           

            double headsetSum = 0;

            double mouseSum = 0;

            double keyboardSum = 0;

            double displaySum = 0;

            double total;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headsetSum += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    mouseSum += mousePrice;
                }
                if (i % 6 == 0)
                {
                    keyboardSum += keyboardPrice;
                }
                if (i % 12 == 0)
                {
                    displaySum += displayPrice;
                }
            }

            total = headsetSum + mouseSum + keyboardSum + displaySum;

            Console.WriteLine($"Rage expenses: {total:F2} lv.");
        }
    }

}
