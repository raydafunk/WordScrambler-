using System;
using System.Collections.Generic;
using System.Linq;
using WordScrambler.Data;
using WordScrambler.Helpers;

namespace WordScrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        

        static void Main(string[] args)
        {
            try
            {
                bool contineWordOnScramble = true;
                do
                {

                    Console.WriteLine(Constants.OpitionsOnHowToEnterScrambedWords);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteSrcambledFileWords();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteSrcambledWordsManually();
                            break;

                        default:
                            Console.WriteLine(Constants.EnterScrambledWordsOpitionsNotRecognized);
                            break;
                    }

                    // check to user want to contine 
                    var ContineProcess = string.Empty;

                    do
                    {

                        Console.WriteLine(Constants.OpitionsforContininingTheProgram);
                        ContineProcess = (Console.ReadLine() ?? string.Empty);

                    } while (
                        !ContineProcess.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                        !ContineProcess.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    contineWordOnScramble = ContineProcess.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (contineWordOnScramble);
            }
            catch (Exception ex)
            {

                Console.WriteLine(Constants.ErrorProgramWillbeTerminted + ex.Message);
            }
          

        }

        private static void ExecuteSrcambledWordsManually()
        {
            // input
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplyMatchedWords(scrambledWords);
        }

      

        private static void ExecuteSrcambledFileWords()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambleWords = _fileReader.Read(fileName);
                DisplyMatchedWords(scrambleWords);
            }
            catch (Exception ex)
            {

                Console.WriteLine(Constants.ErrorScrambledWordsCannotbeLoaded + ex.Message);
            }
            
        }

        private static void DisplyMatchedWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
