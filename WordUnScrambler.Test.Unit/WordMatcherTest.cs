using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordScrambler.Helpers;

namespace WordUnScrambler.Test.Unit
{
    [TestClass]
    public class UnitTest1
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();

        [TestMethod]
        public void ScrambledwordMatchesGivenWordInList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scramlbewords = { "omre" };

            var matchedWords = _wordMatcher.Match(scramlbewords , words);

            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
        }

        [TestMethod]
        public void ScrambledwordMatchesGivenWordsInList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scramlbewords = { "omre", "act"};

            var matchedWords = _wordMatcher.Match(scramlbewords, words);

            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
            Assert.IsTrue(matchedWords[1].ScrambledWord.Equals("act"));
            Assert.IsTrue(matchedWords[1].Word.Equals("cat"));
        }
    }
}
