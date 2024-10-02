﻿namespace PrincessBrideTrivia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = GetFilePath();
            Question[] questions = LoadQuestions(filePath);

            List<Question> incorrectQuestions = new List<Question>();

            int numberCorrect = 0;
            // Ask each question once
            for (int i = 0; i < questions.Length; i++)
            {
                bool result = AskQuestion(questions[i]);
                if (result)
                {
                    numberCorrect++;
                }
                else
                {
                    // Store the questions answered wrong
                    incorrectQuestions.Add(questions[i]);
                }
            }

            Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct.");

            // While loop to keep asking the incorrect questions till they get them all right
            while (incorrectQuestions.Count > 0)
            {
                Console.WriteLine("\nLets make sure you know all the correct answers. You have " + incorrectQuestions.Count + " questions to try again!\n");

                // Get the new list of incorrect questions
                List<Question> stillIncorrectQuestions = new List<Question>();

                foreach (Question question in incorrectQuestions)
                {
                    bool result = AskQuestion(question);
                    if (result)
                    {
                        numberCorrect++;
                    }
                    else
                    {
                        // If answered wrong again, add it back to the list.
                        stillIncorrectQuestions.Add(question);
                    }
                }

                // Update the list of incorrect questions
                incorrectQuestions = stillIncorrectQuestions;
            }

            // Final result
            Console.WriteLine("Now you got them all!");
            
        }

        public static string GetPercentCorrect(int numberCorrectAnswers, int numberOfQuestions)
        {
            return ((float)numberCorrectAnswers / numberOfQuestions * 100) + "%";
        }

        public static bool AskQuestion(Question question)
        {
            DisplayQuestion(question);

            string userGuess = GetGuessFromUser();
            return DisplayResult(userGuess, question);
        }

        public static string GetGuessFromUser()
        {
            return Console.ReadLine();
        }

        public static bool DisplayResult(string userGuess, Question question)
        {
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return true;
            }

            Console.WriteLine("Incorrect");
            return false;
        }

        public static void DisplayQuestion(Question question)
        {
            Console.WriteLine("Question: " + question.Text);
            for (int i = 0; i < question.Answers.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + question.Answers[i]);
            }
        }

        public static string GetFilePath()
        {
            return "Trivia.txt";
        }

        public static Question[] LoadQuestions(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Question[] questions = new Question[lines.Length / 5];
            for (int i = 0; i < questions.Length; i++)
            {
                int lineIndex = i * 5;
                string questionText = lines[lineIndex];

                string answer1 = lines[lineIndex + 1];
                string answer2 = lines[lineIndex + 2];
                string answer3 = lines[lineIndex + 3];

                string correctAnswerIndex = lines[lineIndex + 4];

                Question question = new();
                question.Text = questionText;
                question.Answers = new string[3];
                question.Answers[0] = answer1;
                question.Answers[1] = answer2;
                question.Answers[2] = answer3;
                question.CorrectAnswerIndex = correctAnswerIndex;
                questions[i] = question;
            }
            return questions;
        }
    }
}
