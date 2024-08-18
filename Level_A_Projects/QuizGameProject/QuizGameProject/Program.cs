using System.Reflection.Metadata;

namespace QuizGameProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- make number of questions 
            // 2- compare user answers with the right answers 
            // 3- give the score to the user 
            Console.WriteLine("welcome to QuizGame ");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("please Anwer The Following Questions");

            int score = 0;
            String[] questions = new string[8]
           {
               "What is the capital of egypt?",
               "What is the largest animal in the world?",
               "How many letters are in the English language?",
               "What is the largest continent in the world by area?",
               "What is the planet Mars called?",
               "What is the number of planets in the solar system?",
               //عدد كواكب المجموعه الشمسيه
               "What is the most abundant chemical element in the human body?",
               //ما هو أكثر عنصر كيميائي متواجد في جسم الإنسان
               "What is the staple food for a third of the world's population?",
               //ماهو الغذاء الاساسسي لثلث سكان العالم
           };

            string[] answers = new string[8]
            {
               "cairo",
               "blue whale",
               "26",
               "asia",
               "red planet",
               "8",
               "oxygen",
               "rice",
            };
          
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(questions[i]);

                string ans = Console.ReadLine();
                try
                {
                    bool answer = isCorrect(ans, answers[i]);
                    if (answer)
                    {
                        score++;
                        Console.WriteLine("correct asnwer !");
                    }
                    else
                    {
                        Console.WriteLine($"incorrect answer ,the correct answer is {answers[i]}");
                    }
                    Console.WriteLine("********************************************************8");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            Console.WriteLine($"your score is {score} from 8");
            Console.WriteLine("congratulations !! The game is over,thank U for playing ");

        }
        private static bool isCorrect(string ans,string cor)
        {
            if(string.IsNullOrEmpty(ans))
            {
                throw new Exception("the answer can't be empty!! please enter answer");
            }
            String a = ans.ToLower();
            string b = cor.ToLower();
            if (a==b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
