﻿using GamePlatform.Data;
using GamePlatform.Interfaces;

namespace GamePlatform.Games
{
    public class MooGame : IDigitGuessGame
    {
        public int GuessCounter { get; private set; }
        public string? PlayerName { get; private set; }
        public string? CurrentGuess { get; private set; }
        public string? DigitsToGuess { get; private set; }

        public void SetPlayerName(string? playerName)
        {
            PlayerName = playerName!.Trim();
        }

        public void SetCurrentGuess(string? guess)
        {
            CurrentGuess= guess!.Trim();
        }

        public void SetupDigitsToGuess()
        {
            Random randomGenerator = new();
            string digits = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                while (digits.Contains(random.ToString()))    //Slumpar fram 4 unika siffror mellan 0 och 9
                {
                    random = randomGenerator.Next(10);        //Skapa en ytterligare funktion som adderar random unique number?
                                                              //Private används bara till Moo, ingår inte i Interface
                }
                digits += random;
            }
           DigitsToGuess = digits;
        }

        public void IncrementGuessCounter()
        {
            GuessCounter++;
        }

        public void ResetGuessCounter()
        {
            GuessCounter = 0;
        }

        public string GetGuessResult()
        {
            string cows = "";
            string bulls = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < CurrentGuess!.Length; j++)
                {
                    if (DigitsToGuess![i] == CurrentGuess[j])
                    {
                        if (i == j)
                        {
                            bulls += 'B';           // Jämför goal och guess och hittar rätt
                        }                           // gissningar baserat på indexplats och innehåll
                                                    // adderar cow för rätt siffra fel index
                        else                        // adderar bulls för rätt siffra rätt index
                        {                           // returnerar antal bulls och cows i en sträng
                            cows += 'C';
                        }
                    }
                }
            }
            return $"{bulls},{cows}";
        }

        
    }
}