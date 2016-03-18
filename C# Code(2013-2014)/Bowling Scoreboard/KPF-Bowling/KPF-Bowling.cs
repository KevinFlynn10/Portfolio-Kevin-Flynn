/* 
 * File: KPF-Bowling
 * Author: Kevin Flynn
 * Purpose: Making a bowling game where the score is kept and has all the working concepts of an actual scoreboard. 
 * Each frame, the bowler has two chances to knock down all of the pins. If they are able to do so in one bowl
 * then it is a strike. If done in two bowls then it is a spare. There are a total of ten frames per game.
 * Good Luck!
 * */
using System;
class Bowling
{
    static void Main()
    {
        Boolean scoring = true;
        int[] Frames1, Frames2, Frames3, total;
        Frames1 = new int[12];
        Frames2 = new int[12];
        Frames3 = new int[12];
        total = new int[12];
        string strike = "X";
        string spare = "/";
        int j;
        int i;
        total[0] = 0;
        while (scoring == true) //Checks to make see if it should write the scoreboard or input scores
        {
            for (i = 1; i <= 11; i++) // Loop controlling inputs for scores
            {
                if (i <= 10)
                {
                    Console.WriteLine("Frame " + i);

                    Console.Write("Enter First Bowl: ");
                    Frames1[i] = Convert.ToInt32(Console.ReadLine());

                    if (i == 10 || Frames1[i] != 10)
                    {
                        Console.Write("Enter Second Bowl: ");
                        Frames2[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    if (i < 10 && Frames1[i] + Frames2[i] >= 11 || Frames1[i] + Frames2[i] < 0 || Frames3[i] > 10 || Frames3[i] < 0) // Checks for any type of invalid inputs
                    {
                        Console.WriteLine("Invalid Score. Please Enter Score Again");
                        i--;
                    }
                }

                else
                {
                    scoring = false; // Starts to draw Scoreboard
                }
            }
            for (i = 1; i <= 11; i++) // loop to check for strikes, spares, normal input, or third frame
            {
                if (i == 10 && Frames1[i] == 10)
                {
                    Console.Write("Enter Third Bowl: ");
                    Frames3[i] = Convert.ToInt32(Console.ReadLine());

                    total[i] = total[i - 1] + 10 + Frames2[i] + Frames3[i];
                }
                else if (i == 10 && Frames1[i] + Frames2[i] == 10)
                {
                    Console.Write("Enter Third Bowl: ");
                    Frames3[i] = Convert.ToInt32(Console.ReadLine());

                    total[i] = total[i - 1] + 10 + Frames3[i];
                }
                else if (i == 9 && Frames1[9] == 10 && Frames1[10] == 10)
                {
                    total[i] = total[i - 1] + 20 + Frames2[10];
                }
                else if (Frames1[i] == 10 && Frames1[i + 1] == 10)
                {
                    total[i] = total[i - 1] + 20 + Frames1[i + 2];
                }
                else if (Frames1[i] == 10)
                {
                    total[i] = total[i - 1] + 10 + Frames1[i + 1] + Frames2[i + 1];
                    Frames2[i] = 0;
                }
                else if (Frames1[i] + Frames2[i] == 10)
                {
                    total[i] = total[i - 1] + 10 + Frames1[i + 1];
                }
                else
                {
                    total[i] = total[i - 1] + Frames1[i] + Frames2[i];
                }
            }
            for (j = 1; j < 10; j++) // Start of multiple loops that create the scoreboard. Check to see if strikes or spares are present
            {
                Console.Write("------");
            }
            Console.WriteLine("-------------");
            Console.Write("Frame");
            for (j = 1; j < 11; j++)
            {
                Console.Write("│" + "__" + j + "__");
            }
            Console.WriteLine("│");
            Console.Write("Score");
            for (j = 1; j < 10; j++)
            {
                if (Frames1[j] == 10)
                {
                    Console.Write("│" + " " + strike + "│" + "-" + " ");
                }
                else if (Frames1[j] + Frames2[j] == 10)
                {
                    Console.Write("│" + " " + Frames1[j] + "│" + spare + " ");
                }
                else
                {
                    Console.Write("│" + " " + Frames1[j] + "│" + Frames2[j] + " ");
                }
            }
            if (j == 10 && Frames1[j] + Frames2[j] < 10)
            {
                Console.WriteLine("│" + " " + Frames1[j] + "│" + Frames2[j] + " " + "-" + "│");
            }
            else if (j == 10 && Frames1[j] == 10 && Frames2[j] == 10 && Frames3[j] == 10)
            {
                Console.WriteLine("│" + " " + strike + "│" + strike + " " + strike + "│");
            }
            else if (j == 10 && Frames1[j] + Frames2[j] == 10)
            {
                if (Frames3[j] == 10)
                {
                    Console.WriteLine("│" + " " + Frames1[j] + "│" + spare + " " + strike + "│");
                }
                else
                {
                    Console.WriteLine("│" + " " + Frames1[j] + "│" + spare + " " + Frames3[j] + "│");
                }
            }
            else if (j == 10 && Frames1[j] == 10)
            {
                Console.WriteLine("│" + " " + strike + "│" + Frames2[j] + " " + Frames3[j] + "│");
            }
            else if (j == 10 && Frames2[j] == 10)
            {
                Console.WriteLine("│" + " " + Frames1[j] + "│" + strike + " " + Frames3[j] + "│");
            }
            else if (j == 10 && Frames3[j] == 10)
            {
                Console.WriteLine("│" + " " + Frames1[j] + "│" + Frames2[j] + " " + strike + "│");
            }
            Console.Write("Total");
            for (j = 1; j < 10; j++) // Loop to check for total score for each frame
            {
                if (total[j] > 0 && total[j] < 10)
                {
                    Console.Write("│" + " " + total[j] + "   ");
                }
                else if (total[j] >= 10 && total[j] < 100)
                {
                    Console.Write("│" + " " + total[j] + "  ");
                }
                else if (total[j] >= 100 && total[j] <= 300)
                {
                    Console.Write("│" + " " + total[j] + " ");
                }
            }
            if (total[10] > 0 && total[10] < 10) // Tenth Frame total for correct scoreboard spacing
            {
                Console.Write("│" + " " + total[10] + "    " + "│");
            }
            else if (total[10] >= 10 && total[10] < 100)
            {
                Console.Write("│" + " " + total[10] + "   " + "│");
            }
            else if (total[10] >= 100 && total[10] <= 300)
            {
                Console.Write("│" + " " + total[10] + "  " + "│");
            }
            Console.WriteLine("");
            for (j = 1; j < 10; j++)
            {
                Console.Write("------");
            }
            Console.WriteLine("-------------");
        }
        Console.ReadLine();
    }
}