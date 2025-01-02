using System.IO;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;
namespace ITEC_Final_Project__2_
{
    internal class Program
    {
        public static void SlowWrite(string text) // displays the text slowly
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(1);
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            
            int questionIndex = 0;
            int answerIndex = 0;
            int score = 0;
            String Divider = "====================================================================================================";

            //title screen start
            SlowWrite(Divider);
            Console.WriteLine("");
            SlowWrite("                                       Flashcard Flashdance!");
            SlowWrite("                                     by Marious Joaquin Cuenca\n                                       Michelle Ann Empalmado\n                                        and Ricci Ann Lacap");
            Console.WriteLine("");

            SlowWrite("                                        PRESS ENTER TO PLAY");
            Console.ReadKey();
            Console.WriteLine("");
            SlowWrite(Divider);

            //quiz set select start

            qselpoint:
            Console.WriteLine("");
            SlowWrite("                                          SELECT QUIZ SET");
            Console.WriteLine("");
            SlowWrite("1. Easy");
            SlowWrite("2. Medium");
            SlowWrite("3. Difficult");
            Console.WriteLine("");
            String Filename;
            try
            {
                int QuizSelect = int.Parse(Console.ReadLine());
                switch (QuizSelect)// pulls questions
                {
                    case 1:
                        Filename = "questions1.txt";
                        break;
                    case 2:
                        Filename = "questions2.txt";
                        break;
                    case 3:
                        Filename = "questions3.txt";
                        break;
                    default:
                        SlowWrite("\n\nInvalid Input! Please Try Again");
                        goto qselpoint;
                }
            }
            catch
            {
                SlowWrite("\n\nInvalid Input! Please Try Again");
                goto qselpoint;
            }
            String[] text = File.ReadAllLines(Filename);

            List<string> questions = new List<string>();
            List<string> answers = new List<string>();

            SlowWrite("\n" + Divider + "\n");

            for (int i = 0; i < text.Length; i++) // sorts questions and answers
            {
                if (i % 4 == 0) //if text is at this line, add it to questions list
                {
                    questions.Add(text[i]);
                }
                else
                {
                    answers.Add(text[i]);
                }
            }

            while (questionIndex < questions.Count)
            {
                SlowWrite(questions[questionIndex]);
                
                int correctAnsIndex = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (answers[answerIndex].StartsWith(">"))//makes sure the program knows which answer is correct
                    {
                        correctAnsIndex = i + 1;
                    }

                    SlowWrite((i + 1) + "." + answers[answerIndex].Replace(">", ""));//makes sure the user cannot see which answer is correct

                    answerIndex++;
                }

                try
                {
                    int answerInput = int.Parse(Console.ReadLine());//user inputs answer

                    if (answerInput == correctAnsIndex)//checks if the answer is correct
                    {
                        SlowWrite("Correct!");
                        score++;
                    }
                    else
                    {
                        SlowWrite("\nIncorrect! Sorry!");
                        SlowWrite("Score: " + score);
                        Console.ReadKey();
                        return;
                    }
                }
                catch
                {
                    SlowWrite("\nIncorrect! Sorry!");
                    SlowWrite("Score: " + score);
                    Console.ReadKey();
                    return;
                }
                questionIndex++;
                Console.WriteLine("");
            }

            SlowWrite(Divider);
            SlowWrite("Quiz Over! Congratulations!");
            SlowWrite("Score: " + score);
            Console.ReadKey();
        }
    }
}

