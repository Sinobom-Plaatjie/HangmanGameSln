using System;
using HangmanRenderer.Renderer;
namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _word;
        private string _guessed;
        private string[] _wordsToUse = new string[20] { "community", "duplicate", "make", "weather","move",
                                                       "big", "commit","game","searh","length",
                                                        "complete","red","green","blue","purple",
                                                        "laptop","games","man","lady","master"};
        private int _noOfLives = 6;
        private char[] _guess;
        private char[] _guessedProgress;
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }
        public void RandomSelect()
        {
            Random random = new Random();
            _word = _wordsToUse[random.Next(0, 19)];
            _guess = _word.ToCharArray();

            for (int i = 0; i < _guess.Length; i++)
            {
                Console.SetCursorPosition(0, 19);
                _guessed += "_";
            }
            Console.SetCursorPosition(0, 14);
            Console.WriteLine(_guessed);
        }

       /* public void OverWritten(char letterGuessed)
        {

        }*/

        public void Run()
        {
            _renderer.Render(5, 5, _noOfLives);
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            //Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 16);
            Console.ForegroundColor = ConsoleColor.Green;
            while (_noOfLives > 0)
            {
                Console.SetCursorPosition(0, 17);
                Console.Write("What is your next guess: ");
                char nextGuess = char.Parse(Console.ReadLine());
                bool correctguess = false;
                _renderer.Render(5, 5, _noOfLives);
                
                _guessedProgress = _guessed.ToCharArray();
                for (int j = 0; j < _guess.Length; j++)
                {
                    if (_guess[j] == nextGuess)
                    {
                        //nextGuess = _guessedProgress[j];
                        _guessedProgress[j] = _guess[j];
                        correctguess = true;                        
                    }
                  
                }
                _guessed = new string(_guessedProgress);
                Console.SetCursorPosition(0, 14);
                Console.WriteLine(_guessed);
                if (!correctguess)
                {
                    _noOfLives--;
                    _renderer.Render(5, 5, _noOfLives);
                }
                string guessWord = new string(_guess);
                if(_guessed == guessWord)
                {
                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine($"You won!! Guessed word is {guessWord}");
                    
                    break;
                }
            }
            //Console.SetCursorPosition(0, 24);
            
            if(_noOfLives == 0)
            {
                Console.SetCursorPosition(20, 24);
                Console.WriteLine("You are Hanged, Game Over");
            }
        }
    }
}

