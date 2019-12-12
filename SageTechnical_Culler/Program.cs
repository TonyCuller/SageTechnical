using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SageTechnical_Culler {
    class Program {
        private static CPersistentString myString;
         static void Main(string[] args) {
            myString = new CPersistentString().SetFilePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + @"TestText.txt"));
            myString.AppendTextWithNewLine("racecar");
            myString.AppendTextWithNewLine(string.Format("racecar is a palindrome: {0}", "racecar".IsPalindrome()));
            myString.AppendTextWithNewLine(string.Format("this is a palindrome: {0}", "this".IsPalindrome()));
            myString.AppendTextWithNewLine(string.Format("racecar has {0} letters", "racecar".GetLength()));
            myString.RemoveText("race");         
        }
    }
}

