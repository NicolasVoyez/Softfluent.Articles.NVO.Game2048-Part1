using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softfluent.Articles.NVO.Game2048.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game2048 game = new Game2048();

            bool isFinished = false;
            while (!isFinished)
            {
                ShowGrid(game);

                var key = Console.ReadKey();
                GameResult result = GameResult.Continue;
                if (key.Key == ConsoleKey.UpArrow)
                    result = game.DoAction(Direction.Top);
                else if (key.Key == ConsoleKey.DownArrow)
                    result = game.DoAction(Direction.Bottom);
                else if (key.Key == ConsoleKey.RightArrow)
                    result = game.DoAction(Direction.Right);
                else if (key.Key == ConsoleKey.LeftArrow)
                    result = game.DoAction(Direction.Left);



                if (result == GameResult.Loss)
                {
                    isFinished = true;
                    ShowGrid(game);
                    Console.WriteLine();
                    Console.WriteLine("You loose, that's kind of tragic !");
                    Console.WriteLine();
                    Console.ReadKey();
                }
                else if (result == GameResult.Win)
                {
                    isFinished = true;
                    ShowGrid(game);
                    Console.WriteLine();
                    Console.WriteLine("Congratulations, you won !");
                    Console.WriteLine();
                }

            }

            Console.WriteLine("Press Escape to leave !");
            var nowKey = ConsoleKey.M;
            while (nowKey != ConsoleKey.Escape)
                nowKey = Console.ReadKey().Key;
        }

        private static void ShowGrid(Game2048 game)
        {
            Welcome();

            for (int i = 0; i < Game2048.SIZE; i++)
                Console.Write("-------");
            Console.WriteLine("-");
            for (int x = 0; x < Game2048.SIZE; x++)
            {
                Console.Write("|");
                for (int y = 0; y < Game2048.SIZE; y++)
                {
                    var current = game.ShowBoard[x, y].ToString();
                    Console.ForegroundColor = GetColor(current);
                    for (int i = current.Length; i < 6; i++)
                    {
                        current = ((i % 2 == 0) ? " " : "") + current + ((i % 2 == 1) ? " " : "");
                    }

                    Console.Write(current);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
                Console.WriteLine();
                for (int i = 0; i < Game2048.SIZE; i++)
                    Console.Write("-------");
                Console.WriteLine("-");
            }
        }

        private static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to 2048. Play with arrows.");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static ConsoleColor GetColor(string current)
        {
            switch (current)
            {
                case "0":
                    return ConsoleColor.Black;
                case "8":
                    return ConsoleColor.Cyan;
                case "16":
                    return ConsoleColor.Blue;
                case "32":
                    return ConsoleColor.DarkBlue;
                case "64":
                    return ConsoleColor.DarkGreen;
                case "128":
                    return ConsoleColor.Green;
                case "256":
                    return ConsoleColor.Yellow;
                case "512":
                    return ConsoleColor.Red;
                case "1024":
                    return ConsoleColor.DarkRed;
                case "2048":
                    return ConsoleColor.DarkMagenta;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}
