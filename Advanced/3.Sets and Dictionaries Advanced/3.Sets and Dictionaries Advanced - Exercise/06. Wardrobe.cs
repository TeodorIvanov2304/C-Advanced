using System;
using System.Reflection;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = 
                                                   new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] colorsAndClothes = Console.ReadLine().Split(" -> ").ToArray();
                string color = colorsAndClothes[0];

                string[] clothes = colorsAndClothes[1].Split(",").ToArray();
                FillWardrobe(wardrobe, color, clothes);
            }

            string[] findItem = Console.ReadLine().Split();
            string searchColor = findItem[0];
            string searchItem = findItem[1];

            //Пускаме foreach за всички цветове в гардероба
            foreach (var item in wardrobe)
            {
                //Изпечатваме цвета
                Console.WriteLine($"{item.Key} clothes:");

                //Пускаме foreach за всички видове дрехи в съответния цвят(item.Value)
                foreach (var model in item.Value)
                {
                    string found = "(found!)";
                    //Ако моделът е търсеният(searchItem) и цветът е търсеният(searchColor)
                    // изпечатваме и (found!)"
                    if (model.Key == searchItem && item.Key == searchColor)
                    {
                        Console.WriteLine($"* {model.Key} - {model.Value} {found}");
                    }
                    else
                    {
                        Console.WriteLine($"* {model.Key} - {model.Value}");
                    }
                }
                
            }


        }
        //wardrobe.ContainsKey(searchColor) && wardrobe[searchColor].ContainsKey(searchItem)
        private static void FillWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string color, string[] clothes)
        {
            foreach (string item in clothes)
            {
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    wardrobe[color].Add(item, 1);
                }
                else
                {
                    if (wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] += 1;
                    }
                    else
                    {
                        wardrobe[color].Add(item, 1);
                    }

                }
            }
        }
    }
}