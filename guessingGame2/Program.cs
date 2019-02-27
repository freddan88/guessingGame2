using System;

namespace guessingGame2
{
    class Program
    {
        private static bool gamePlaying = true;

        static void Main(string[] args)
        {
            while (gamePlaying)
            {
                myGame();
            }
        }

        private static void promptUser(string word)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(word);

            for (int i = 0; i < word.Length; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
        }

        private static void myGame()
        {
            int retries = 0;
            int yourInt = 0;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Generating your random number between 1 - 100");
            Console.WriteLine("_____________________________________________");

            Random cpRandomIntGenerator = new Random();
            int cpRandomInt = cpRandomIntGenerator.Next(1, 100);

            // Uncomment to print the random number to screen
            // Console.WriteLine($"Your random number is: {cpRandomInt}");

            askAgain:
            Console.WriteLine();
            Console.WriteLine($"You guessed: {retries} times!");
            Console.WriteLine();
            Console.Write("Guess a number between 1 - 100: ");
            string input = Console.ReadLine();

            if (!Int32.TryParse(input, out yourInt))
            {
                promptUser("You need to give a number between 1 - 100");
                goto askAgain;
            }
            else if (yourInt > 100)
            {
                promptUser("You need to give a number between 1 - 100");
                goto askAgain;
            }
            else if (yourInt < 1)
            {
                promptUser("You need to give a number between 1 - 100");
                goto askAgain;
            }
            else if (input.StartsWith("0"))
            {
                promptUser("You need to give a number between 1 - 100");
                goto askAgain;
            }

            if (yourInt == cpRandomInt  + 1 || yourInt == cpRandomInt - 1)
            {
                retries++;
                promptUser("Your guess is wery close to the right answear");
                goto askAgain;
            }
            else if (yourInt > cpRandomInt)
            {
                retries++;
                promptUser("The guessed number is to high");
                goto askAgain;
            }
            else if (yourInt < cpRandomInt)
            {
                retries++;
                promptUser("The guessed number is to low");
                goto askAgain;
            }
            else
            {
                promptUser("You guessed on the right number");
                Console.WriteLine();
                Console.WriteLine($"The right answear were: {cpRandomInt} You guessed: {retries} times");
                Console.WriteLine();
                Console.Write("Press Enter to restart the game...");

                ConsoleKeyInfo keyPress = Console.ReadKey();

                if (keyPress.Key != ConsoleKey.Enter)
                {
                    gamePlaying = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Bye!");
                }
            }
        }
    }
}