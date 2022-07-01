using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace ConsoleApp57
{
    class Program
    {
        private static void printHangman(int wrong) 
        {
            if(wrong == 0) 
            {

            }
            else if(wrong == 1) 
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("         |");
                Console.WriteLine("         |");
                Console.WriteLine("         |");
                Console.WriteLine("        ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("   O     |");
                Console.WriteLine("         |");
                Console.WriteLine("         |");
                Console.WriteLine("        ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("   O     |");
                Console.WriteLine("   |     |");
                Console.WriteLine("         |");
                Console.WriteLine("        ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("   O     |");
                Console.WriteLine("  /|     |");
                Console.WriteLine("         |");
                Console.WriteLine("        ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("   O     |");
                Console.WriteLine("  /|\\    |");
                Console.WriteLine("         |");
                Console.WriteLine("        ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("   O     |");
                Console.WriteLine("  /|\\    |");
                Console.WriteLine("  /      |");
                Console.WriteLine("        ===");
            }
            else if (wrong == 7)
            {
                Console.WriteLine("\n   +---+");
                Console.WriteLine("   O     |");
                Console.WriteLine("  /|\\    |");
                Console.WriteLine("  /\\     |");
                Console.WriteLine("        ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord) 
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord) 
            {
                if (guessedLetters.Contains(c)) 
                {
                    Console.Write(c + " \t");
                    rightLetters++;
                }
                else 
                {
                    Console.Write(" \t");
                }
                counter++;
            }
            return rightLetters;
        }
        
        private static void printLines(String randomWord) 
        {
            Console.Write("\r");
            foreach(char c in randomWord) 
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 \t");    
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman :");
            Console.WriteLine("_____________________________________________");

            Random random = new Random();
            List<String> wordDictonary = new List<string> { "rainbow", "sunflower", "diamonds", "Mysterious", "honeybun", "spherical", "hotdogdiggitydog", "hangman"};
            int index = random.Next(wordDictonary.Count);
            String randomWord = wordDictonary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthofWordToGuess = randomWord.Length;
            int amountofTimesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int currentLettersWrite = 0;


            while (amountofTimesWrong != 7 && currentLettersWrite != lengthofWordToGuess) 
            {
                Console.Write("\nLetters guessed so far: ");
                foreach(char letter in currentLettersGuessed) 
                {
                    Console.Write(letter + " \t");                   
                }
                // Prompt user for input
                Console.Write("\nGuess a Letter: ");
                char letterGuessed = Console.ReadLine()[0];
                //check if letter has already been selected
                if (currentLettersGuessed.Contains(letterGuessed)) 
                {
                    Console.Write("\r\nYou have already guessed that letter, please try again");
                    printHangman(amountofTimesWrong);
                    currentLettersWrite = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else 
                {
                    //check if letter is in the word
                    bool right = false;
                    for(int i = 0; i < randomWord.Length; i++) { if(letterGuessed == randomWord[i]) { right = true;  } }

                    if (right) 
                    {
                        printHangman(amountofTimesWrong);
                        currentLettersGuessed.Add(letterGuessed);
                        currentLettersWrite = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else 
                    {
                        amountofTimesWrong++;
                        currentLettersGuessed.Add(letterGuessed);
                        printHangman(amountofTimesWrong);
                        currentLettersWrite = printWord(currentLettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame Over! Thanks for playing :) ");

        }
    }
}
