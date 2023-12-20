using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023
{
    internal class Day02
    {
        public void A()
        {
            var text = File.ReadAllLines("day02.in");
            int sum = 0;
            foreach (var line in text)
            {
                var game = int.Parse(line.Split(":")[0].Split()[1]);
                var sets = line.Split(": ")[1].Split("; ").Select(sets => sets.Split(", ")).ToArray();
                Dictionary<string, int> maxes = new Dictionary<string, int>();
                maxes["green"] = 0;
                maxes["red"] = 0;
                maxes["blue"] = 0;
                foreach (var set in sets)
                {
                    foreach (var color in set)
                    {
                        var c = color.Split()[1];
                        var amt = int.Parse(color.Split()[0]);
                        maxes[c] = Math.Max(maxes[c], amt);
                    }
                }

                if (maxes["red"] <= 12 && maxes["green"] <= 13 && maxes["blue"] <= 14)
                {
                    sum += game;
                }
            }

            Console.WriteLine(sum);
        }
        public void B()
        {
            var text = File.ReadAllLines("day02.in");
            int sum = 0;
            foreach (var line in text)
            {
                var game = int.Parse(line.Split(":")[0].Split()[1]);
                var sets = line.Split(": ")[1].Split("; ").Select(sets => sets.Split(", ")).ToArray();
                Dictionary<string, int> maxes = new Dictionary<string, int>();
                maxes["green"] = 0;
                maxes["red"] = 0;
                maxes["blue"] = 0;
                foreach (var set in sets)
                {
                    foreach (var color in set)
                    {
                        var c = color.Split()[1];
                        var amt = int.Parse(color.Split()[0]);
                        maxes[c] = Math.Max(maxes[c], amt);
                    }
                }

                sum += maxes["red"] * maxes["green"] * maxes["blue"];
            }

            Console.WriteLine(sum);
        }
    }
}
