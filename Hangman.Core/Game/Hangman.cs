using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    

    public class HangmanGame
    {
        private string _guessword;
        private string _guessProgress;

        private string[] words = new string[] { "came", "decide", "duplicate", "source" };
        //private List<string[]> handmanwords = new List<string[]>("ujs","jhsijjis","mjsji", "jwjss");
        private GallowsRenderer _renderer;
        

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }
        public void PickWord(string word)
        {
            _guessProgress = _guessword;
            Random random = new Random();
            
            for(int i = 0; i < words.Length; i++)
            {
                int index = random.Next(words.Length); 
                word = words[index];
                _guessProgress += "_";
            }
        }
        public string GetGuessProgress()
        {
            return _guessProgress;
        }
        public void AddGuess(char letter)
        {
            while (true)
            {
                char[] guessProgressArray = _guessProgress.ToCharArray();

                for (int index = 0; index < _guessProgress.Length; index++)
                {
                    if (_guessword[index] == letter)
                    {
                        guessProgressArray[index] = letter;

                    }
                }
                _guessProgress = new string(guessProgressArray);

            }
        }
        public void Run()
        {
            int lives = 6;
            _renderer.Render(5, 5, lives);

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            while (true)
            {
                _guessword = Console.ReadLine();

            }
            lives--;
            
        }

    }
}
