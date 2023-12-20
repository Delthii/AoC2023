using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023
{
    internal class Day01
    {
        string[] numbers = {"zero","one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public void A()
        {
            var text = File.ReadAllLines("day01.in");
            int sum = 0;
            foreach (var line in text)
            {
                int left = 0, right = line.Length - 1;
                while (!char.IsAsciiDigit(line[left]))
                {
                    left++;
                }
                while (!char.IsAsciiDigit(line[right]))
                {
                    right--;
                }
                sum += int.Parse(line[left] + "" + line[right]);


            }

            Console.WriteLine(sum);
        }

        public void B()
        {
            var text = File.ReadAllLines("day01.in");
            int sum = 0;
            foreach (var line in text)
            {
                int left = 0, right = line.Length - 1;
                int leftNum = 0;
                while (!char.IsAsciiDigit(line[left]) && leftNum == 0)
                {
                    left++;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        string num = numbers[i];
                        if (line.Substring(0, left).Contains(num))
                        {
                            leftNum = i;
                            break;
                        }
                    }
                }

                int rightNum = 0;
                while (!char.IsAsciiDigit(line[right]) && rightNum == 0)
                {
                    right--;
                    for (int i = numbers.Length - 1; i >= 0; i--)
                    {
                        string num = numbers[i];
                        if (line.Substring(right, Math.Min(line.Length - right, 5)).Contains(num))
                        {
                            rightNum = i;
                            break;
                        }
                    }
                }
                sum += int.Parse((leftNum > 0 ? leftNum : line[left] - '0') + "" + (rightNum > 0 ? rightNum : line[right] - '0'));
            }

            Console.WriteLine(sum);
        }
    }
}
