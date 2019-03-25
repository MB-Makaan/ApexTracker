using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to View Data, or Press 2 to Enter Data");
            var input = Console.ReadLine();
            do
            {
                if (input == "1")
                {
                    foreach (var w in File.ReadAllLines("ApexStats.csv")                                           
                                           .Select(v => Legend.FromCsv(v))
                                           .ToList())
                    {
                        Console.WriteLine(w.character);
                        Console.WriteLine(w.kills);
                        Console.WriteLine(w.damageDone);
                        Console.WriteLine(w.killsAsKillLeader);
                        Console.WriteLine(w.winningKills);
                        Console.WriteLine(w.headshots);
                        Console.WriteLine(w.finishers);
                        Console.WriteLine(w.revives);
                        Console.WriteLine(w.gamesPlayed);
                        Console.WriteLine(w.winsWithFullSquad);
                        Console.WriteLine(w.timesPlacedTopThree);
                    }



                }

                else if (input == "2")
                {
                    string[,] table = ReadFileToTable();

                    AskUserQuestions(table);

                    WriteToFile(table);
                }

                Console.Write("Press 1 to View Data, or Press 2 to Enter Data or type \"quit\" to exit: ");
                input = Console.ReadLine();
            } while (input != "quit");
        }

        private static void WriteToFile(string[,] table)
        {
            using (TextWriter tw = new StreamWriter("ApexStats.csv"))
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    List<string> rowValues = new List<string>();
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        rowValues.Add(table[i, j]);
                    }

                    tw.WriteLine(string.Join(",", rowValues));
                }
            }
        }

        private static void AskUserQuestions(string[,] table)
        {
            Console.WriteLine("What row would you like to modify?");
            int rowToModify = int.Parse(Console.ReadLine());
            Console.WriteLine("What column would you like to modify?");
            int columnToModify = int.Parse(Console.ReadLine());
            Console.WriteLine("What would you like to set the value to?");
            string valueToModify = Console.ReadLine();
            table[rowToModify, columnToModify] = valueToModify;
        }

        private static string[,] ReadFileToTable()
        {
            string rawFile = File.ReadAllText("ApexStats.csv");
            string[] lines = rawFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string[] fields = lines[0].Split(',');

            string[,] table = new string[lines.Length, fields.Length];

            for (int row = 0; row < lines.Length; row++)
            {
                fields = lines[row].Split(',');
                for (int column = 0; column < fields.Length; column++)
                {
                    table[row, column] = fields[column];
                }
            }

            return table;
        }
    }
}
