using System.Collections.Generic;
using System.Linq;
using System;
namespace GunvorRecruitment
{
    public class Algorithm
    {
        public string ReverseEveryOtherWord(string inputString)
        {
            var reversed = "";
            var stringArray = inputString.Split(' ');
            var skeep = true;
            foreach (var word in stringArray)
            {
                if (skeep)
                {
                    reversed += word + " ";
                }
                else
                {
                    var wordArray = word.ToCharArray().ToList();
                    wordArray.Reverse();
                    var newWord = String.Join("", wordArray);

                    reversed += newWord + " ";
                }
                skeep = !skeep;
            }
            return reversed.TrimEnd();
        }
    }
}