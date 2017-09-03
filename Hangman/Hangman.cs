using System;
using System.Text;

namespace Hangman
{
    class Hangman
    {
        private string WordToGuess { get; set; }
        private StringBuilder DashedWord = new StringBuilder();
        private int MistakeCount = 0;
        private string GuessList = "";
        private int NumberOfLives = 6;

        public Hangman(string wordToGuess)
        {
            WordToGuess = wordToGuess.ToUpper();
            for (var i = 0; i < WordToGuess.Length; i++)
            {
                DashedWord.Append("_");
            }
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine($"The word to guess is below. It is {WordToGuess.Length} letters long.");
            PrintDashedWord();
            while (MistakeCount < 6) 
            {
                Console.Write("Enter your guess:  ");
                var guess = Console.ReadLine()[0].ToString();
                Console.Clear();
                ProcessGuess(guess);
                if(WordCorrectlyGuessed())
                {
                    Console.WriteLine($"Congratulations! You guess your word, {WordToGuess}, correctly!");
                    break;
                }
                PrintHangman();
                PrintDashedWord();
                
                PrintGuessList();
                PrintRemainingLives();
            }
            if(MistakeCount == NumberOfLives)
                Console.WriteLine($"You are out of lives. The word was {WordToGuess}.");

            Console.Read();
        }

        public void PrintDashedWord()
        {
            Console.WriteLine("Guess list: ");
            for (var i = 0; i < DashedWord.Length; i++)
                Console.Write(DashedWord[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
        }
        
        public void PrintGuessList()
        {
            foreach(var character in GuessList)
            {
                Console.Write($"{character} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintRemainingLives()
        {
            var remainingLives = NumberOfLives - MistakeCount;
            if(remainingLives > 1)
            {
                Console.WriteLine($"{remainingLives} lives remaining");
            }
            else
            {
                Console.WriteLine("1 life remaining");
            }
            Console.WriteLine();
        }

        public bool WordCorrectlyGuessed()
        {
            for (var i = 0; i < DashedWord.Length; i++)
            {
                if (DashedWord[i] == '_')
                    return false;
            }
            return true;
        }

        public void ProcessGuess(string guess)
        {
            guess = guess.ToUpper();
            if (GuessList.Contains(guess))
            {
                Console.WriteLine("You already guessed this. Try again.");
                Console.WriteLine();
            }
            else if (WordToGuess.Contains(guess))
            {
                ReplaceDashWithGuess(guess);
                GuessList += guess.ToUpper();
                Console.WriteLine("Correct!");
                Console.WriteLine();
            }
            else
            {
                MistakeCount++;
                GuessList += guess;
                Console.WriteLine("Incorrect!");
                Console.WriteLine();
            }
        }

        public void ReplaceDashWithGuess(string guess)
        {
            for (var i = 0; i < WordToGuess.Length; i++)
            {
                if (WordToGuess[i] == guess[0])
                {
                    DashedWord[i] = guess[0];
                }
            }
        }
        public void PrintHangman()
        {
            switch (MistakeCount)
            {
                case 0:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|_____");
                    break;
                case 1:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |  O");
                    Console.WriteLine(" |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|_____");
                    break;
                case 2:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |  O");
                    Console.WriteLine(" |  |");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|_____");
                    break;
                case 3:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |  O");
                    Console.WriteLine(" | /|");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|_____");
                    break;
                case 4:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |  O");
                    Console.WriteLine(" | /|\\");
                    Console.WriteLine(" |");
                    Console.WriteLine("_|_____");
                    break;
                case 5:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |  O");
                    Console.WriteLine(" | /|\\");
                    Console.WriteLine(" | /");
                    Console.WriteLine("_|_____");
                    break;
                case 6:
                    Console.WriteLine(" ;--,");
                    Console.WriteLine(" |  O");
                    Console.WriteLine(" | /|\\");
                    Console.WriteLine(" | / \\");
                    Console.WriteLine("_|_____");
                    break;
            }
            Console.WriteLine();
        }
    }
}
