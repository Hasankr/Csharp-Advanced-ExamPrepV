using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Queue<int> greys = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                {"Oven", 50}, 
                {"Sink", 40},
                {"Countertop", 60},
                {"Wall", 70},
                
            };
            Dictionary<string, int> possibleLocations = new Dictionary<string, int>()
            {
                {"Oven", 0},
                {"Sink", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor", 0},

            };
            while (whites.Count != 0 && greys.Count != 0)
            {
                int white = whites.Pop();
                int gray = greys.Dequeue();
                if (white == gray)
                {
                    int newTile = white + gray;
                    KeyValuePair<string, int> loc = locations.FirstOrDefault(x => x.Value == newTile);
                    if (loc.Key != null)
                    {
                        possibleLocations[loc.Key]++;
                    }
                    else
                    {
                        possibleLocations["Floor"]++;
                    }
                }
                else
                {
                    whites.Push(white / 2);
                    greys.Enqueue(gray);
                }
                //Console.WriteLine($"{white} + {gray} = {white + gray}");
                
            }
            string whitesLeft = whites.Count == 0 ? "none" : string.Join(", ", whites);
            string greysLeft = greys.Count == 0 ? "none" : string.Join(", ", greys);
            Console.WriteLine($"White tiles left: {whitesLeft}");
            Console.WriteLine($"Grey tiles left: {greysLeft}");
            possibleLocations = possibleLocations.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(l => l.Key, l => l.Value);
            foreach (var location in possibleLocations)
            {
                if (location.Value != 0)
                {
                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }

        }
    }
}
