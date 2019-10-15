using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pick_Ball_Game_14_10_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] game = new int[] { 0, 3, 4, 6 };
            PrintGame(game);
            while(true)
            {
                HumanMove(game);
                PrintGame(game);
                if (HasNoBall(game))
                {
                    Console.WriteLine("\nYou Lose");
                    break;
                }
                Console.WriteLine("\nConputer Is Thinking...............");

                ComputerMove(game);
                PrintGame(game);
                if (HasNoBall(game))
                {
                    Console.WriteLine("\nYou Win");
                    break;
                }
            }
        }

        public static void HumanMove(int[] game)
        {
            Console.WriteLine("\nwhich group do you choose? ");
            Console.Write("Answer: ");
            int group = int.Parse(Console.ReadLine());
            Console.WriteLine("\nHow many balls will you pick? ");
            Console.Write("Answer: ");
            int balls = int.Parse(Console.ReadLine());
            PickBalls(game, group, balls);
        }

        public static void ComputerMove(int[] game)
        {
            if (HasOneBall(game))
            {
                int g = 0;
                GetOneGroup(game, out g);
                if (game[g] > 1)
                    PickBalls(game, g, game[g] - 1);
                else
                    PickBalls(game, g, 1);
            }
            else if (HasTwoBalls(game))
            {
                int a = 0, b = 0;
                GetTwoGroup(game, out a, out b);
                if (game[a] == 1)
                    PickBalls(game, b, game[b]);
                else if (game[b] == 1)
                    PickBalls(game, a, game[a]);
                else if (game[a] > game[b])
                    PickBalls(game, a, game[a] - game[b]);
                else if (game[b] > game[a])
                    PickBalls(game, b, game[b] - game[a]);
                else
                    PickBalls(game, a, 1);
            }
            else
            {
                Random rand = new Random();
                int group = rand.Next(1, 3);
                int balls = rand.Next(1, game[group]);
                PickBalls(game, group, balls);
                Console.WriteLine("\nComputer picks group {0},{1} balls.", group, balls);
            }
        }

        static void PrintGame(int[] game)
        {
            Console.Write("Group 1: ");
            for (int i = 0; i < game[1]; i++)
            {
                Console.Write("O");
            }
            Console.WriteLine();

            Console.Write("Group 2: ");
            for (int i = 0; i < game[2]; i++)
            {
                Console.Write("O");
            }
            Console.WriteLine();

            Console.Write("Group 3: ");
            for (int i = 0; i < game[3]; i++)
            {
                Console.Write("O");
            }
            Console.WriteLine();
        }

        static void PickBalls(int[] game, int group, int balls)
        {
            game[group] -= balls;
        }

        static bool HasNoBall(int[] game)
        {
            return game[1] == 0 && game[2] == 0 && game[3] == 0;
        }

        static bool HasOneBall(int[] game)
        {
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
            {
                return true;
            }

            if (game[1] == 0 && game[2] > 0 && game[3] == 0 )
            {
                return true;
            }

            if (game[1] == 0 && game[2] == 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }

        static bool HasTwoBalls(int[] game)
        {
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
            {
                return true;
            }

            if (game[1] > 0 && game[2] == 0 && game[3] > 0)
            {
                return true;
            }

            if (game[1] == 0 && game[2] > 0 && game[3] > 0)
            {
                return true;
            }
            return false;
        }

        static void GetOneGroup(int[] game, out int g)
        {
            g = 0;
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
            {
                g = 1;
            }

            if (game[1] == 0 && game[2] > 0 && game[3] == 0)
            {
                g = 2;
            }

            if (game[1] == 0 && game[2] == 0 && game[3] > 0)
            {
                g = 3;
            }
        }

        static void GetTwoGroup(int[] game, out int a, out int b)
        {
            a = b = 0;
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
            {
                a = 1;
                b = 2;
            }

            if (game[1] > 0 && game[2] == 0 && game[3] > 0)
            {
                a = 1;
                b = 3;
            }

            if (game[1] == 0 && game[2] > 0 && game[3] > 0 )
            {
                a = 2;
                b = 3;
            }
        }

        static bool HasThreeGroup(int[] game)
        {
            return game[1] > 0 && game[2] > 0 && game[3] > 0;
        }
    }
}
