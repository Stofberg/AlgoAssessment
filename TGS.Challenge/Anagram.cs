using System;
using System.Text.RegularExpressions;

namespace TGS.Challenge
{
  /*
        Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
        one another return true, else return false

        "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
        phrase to produce a new word or phrase, using all the original letters exactly once; for example
        orchestra can be rearranged into carthorse.

        areAnagrams("horse", "shore") should return true
        areAnagrams("horse", "short") should return false

        NOTE: Punctuation, including spaces should be ignored, e.g.

        horse!! shore = true
        horse  !! shore = true
          horse? heroes = true

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class Anagram
    {
      public bool AreAnagrams(string word1, string word2)
      {
        string word1Clean = removePunc(word1);
        string word2Clean = removePunc(word2);

        if (String.IsNullOrEmpty(word1))
        {
          throw new ArgumentException(nameof(word1));
        }
        else if (String.IsNullOrEmpty(word2))
        {
          throw new ArgumentException(nameof(word2));
        }
        else
        {
          if (word1Clean.Length != word2Clean.Length)
          {
            return false;
          }

          char[] word1CharArray = word1Clean.ToLower().ToCharArray();
          char[] word2CharArray = word2Clean.ToLower().ToCharArray();

          Array.Sort(word1CharArray);
          Array.Sort(word2CharArray);

          return string.Equals(word1CharArray, word1CharArray);
        }
      }

      private string removePunc(string word)
      {
        return Regex.Replace(word, @"[\W_]", string.Empty);
      }
    }
}
