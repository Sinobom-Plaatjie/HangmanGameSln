using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{


    public class HangmanGame
    {
        private string _guessword;
        private string _guessProgress;

        private string[] words = new string[] { "came", "decide", "duplicate", "source" };
        private int _noOflives = 6;
        private char letter;
        private GallowsRenderer _renderer;


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }
        public void PickWord(string word)
        {
            _guessProgress = _guessword;
            Random random = new Random();
            _guessword = words[random.Next(words.Length)];

            for (int i = 0; i < _guessword.Length; i++)
            {
                _guessProgress += "_";
            }
        }
        public string GetGuessProgress()
        {
            return _guessProgress;
        }
        public void AddGuess()
        {

           
                char[] guessProgressArray = _guessProgress.ToCharArray();
                bool correct = false;
               
                while (_noOflives > 0)
                {
                _renderer.Render(5, 5, _noOflives);
                for (int index = 0; index < _guessProgress.Length; index++)
                {
                    if (_guessword[index] == letter)
                    {
                        guessProgressArray[index] = letter;
                        correct = true;

                    }
                }
                _guessProgress = new string(guessProgressArray);
                Console.SetCursorPosition(0, 18);
                Console.WriteLine(_guessProgress);
                if (!correct)
                {
                    _noOflives--;
                    _renderer.Render(5, 5, _noOflives);
                }
                }
                Console.SetCursorPosition(2, 22);
                if (_noOflives == 0)
                {
                    Console.WriteLine("Sorry you died.");
                }
                else
                {
                    Console.WriteLine($"You Survived /n You won ");
                }
               
            

        }
        public void Run()
        {

            _renderer.Render(5, 5, _noOflives);

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            AddGuess();
               /* _renderer.Render(5, 5, _noOflives);
                Console.SetCursorPosition(0, 17);
                _guessword = Console.ReadLine();*/
                /*_guessword = Console.ReadLine();
                char[] guessProgressArray = _guessProgress.ToCharArray();
                //Console.SetCursorPosition(0, 17);
                bool correct = false;
                for (int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] == playerguess)
                    {
                        guessProgressArray[i] = guess[i];
                        correct = true;
                    }
                }
                _guessProgress = new string(guessProgressArray);*/
                /* Console.SetCursorPosition(0, 18);
                 Console.WriteLine(_guessProgress);
                 if (!correct)
                 {
                     noOflives--;
                     _renderer.Render(5, 5, noOflives);
                 }
             }*/
            
           
        }


    }
}


