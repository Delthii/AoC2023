using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023
{
    internal class Day03
    {
        public void A()
        {
            var text = File.ReadAllLines("day03.in");
            int sum = 0;
            List<(int Row, int Start, int Length)> numbers = new();
            for (int row = 0; row < text.Length; row++)
            {
                string line = text[row];
                for(int col = 0; col < line.Length; col++)
                {
                    if (char.IsDigit(line[col]))
                    {
                        int start = col;
                        while (col < line.Length && char.IsDigit(line[col])) { col++; }
                        numbers.Add((row, start, col - start));
                        //Console.WriteLine(text[row].Substring(start, col - start));
                    }
                }
            }

            foreach(var (row, start, length) in numbers)
            {
                int val = int.Parse(text[row].Substring(start, length));
                bool legit = false;
                for(int i = start - 1; i < start + length + 1 && !legit; i++)
                {
                    if (i < 0 || i >= text[0].Length) continue;
                    for(int y = -1; y < 2 && !legit; y++)
                    {
                        if(row + y < 0 || row + y >= text.Length) continue;
                        var c = text[row + y][i];
                        if(!char.IsDigit(c) && c != '.')
                        {
                            legit = true;
                            break;
                        }
                    }
                }
                if( legit)
                {
                    sum += val;
                }
            }
                    Console.WriteLine(sum);
        }

        public void B()
        {
            var text = File.ReadAllLines("day03.in");
            int sum = 0;
            List<(int Row, int Start, int Length)> numbers = new();
            for (int row = 0; row < text.Length; row++)
            {
                string line = text[row];
                for (int col = 0; col < line.Length; col++)
                {
                    if (char.IsDigit(line[col]))
                    {
                        int start = col;
                        while (col < line.Length && char.IsDigit(line[col])) { col++; }
                        numbers.Add((row, start, col - start));
                    }
                }
            }

            Dictionary<int, List<(int Row, int Start, int Length)>> gears = new();

            foreach (var (row, start, length) in numbers)
            {
                int val = int.Parse(text[row].Substring(start, length));
                bool legit = false;
                for (int i = start - 1; i < start + length + 1 && !legit; i++)
                {
                    if (i < 0 || i >= text[0].Length) continue;
                    for (int y = -1; y < 2 && !legit; y++)
                    {
                        if (row + y < 0 || row + y >= text.Length) continue;
                        var c = text[row + y][i];
                        if (c == '*')
                        {
                            int hash = row + y + i * 2048;
                            if (!gears.ContainsKey(hash))
                            {
                                gears[hash] = new();
                            }

                            gears[hash].Add((row, start, length));
                            legit = true;
                            break;
                        }
                    }
                }
            }

            var ans = gears.Values.Where(l => l.Count == 2).Select(t => int.Parse(text[t[0].Row].Substring(t[0].Start, t[0].Length)) * int.Parse(text[t[1].Row].Substring(t[1].Start, t[1].Length))).Sum();
            Console.WriteLine(ans.ToString());
        }
    }
}
