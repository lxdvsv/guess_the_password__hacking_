namespace guess_the_password__hacking_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secretCode = GenerateSecretCode();
            int tryCount = 0;

            Console.WriteLine("Автоматический подбор 4-значного пароля.");

            string guessedCode = FindPassword(secretCode, ref tryCount);

            Console.WriteLine($"Пароль {secretCode} был подобран за {tryCount} попыток.");
        }

        static string GenerateSecretCode()
        {
            Random rnd = new Random();
            string secretCode = "";
            for (int i = 0; i < 4; i++)
            {
                secretCode += rnd.Next(0, 10).ToString();
            }
            return secretCode;
        }

        static string FindPassword(string secretCode, ref int tryCount)
        {
            tryCount = 0;
            string guess = "0000";

            while (guess != secretCode)
            {
                tryCount++;
                guess = NextGuess(guess);
            }

            return guess;
        }

        static string NextGuess(string current)
        {
            int number = int.Parse(current);
            number++;
            return number.ToString("D4");
        }
    }
}
