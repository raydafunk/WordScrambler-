using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordScrambler.Data;

namespace WordScrambler.Helpers
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambleWords, string[] wordList)
        {
            // hold our empty list of matched words
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambleWord in scrambleWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambleWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(FindNewMatchedWord(scrambleWord, word));
                    }
                    else
                    {
                        var scrambledWordArray = scrambleWord.ToCharArray();
                        var wordArrary = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArrary);

                        var sortedScrambleWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArrary);

                        if (sortedScrambleWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(FindNewMatchedWord(scrambleWord, word));
                        }
                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord FindNewMatchedWord(string scrambleWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord
            {
                ScrambledWord = scrambleWord,
                Word = word
            };

            return matchedWord;
        }
    }
}
