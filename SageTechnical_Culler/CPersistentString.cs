using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SageTechnical_Culler {
    public class CPersistentString : StringWriter {
        private string filePath;

        public CPersistentString(string text) {
            AppendText(text);
        }

        public CPersistentString() { }

        ~CPersistentString() { //Destructor - Before being GC'ed or the program exiting, save current string to a file
            Persist();
        }

        public CPersistentString SetFilePath(string filePath) {
            this.filePath = filePath;
            return this;
        }

        public void Load() {
            AppendText(base.Load(filePath));
        }

        public void Persist() {
            base.Persist(filePath, BodyString);
            ClearText();
        }
               
        public override int GetLength() {
            return BodyString.GetLength();
        }

        public override bool IsPalindrome() {
            return BodyString.IsPalindrome();
        }        
    }

    public abstract class StringWriter{
        public string BodyString { get; private set; }

        public StringWriter() { } 

        public string Load(string filePath) {            
            if(!File.Exists(filePath)) {
                throw new FileNotFoundException("The specified path does not exist");
            }
            else {
                return File.ReadAllText(filePath);
            }
        }

        public void Persist(string filePath, string textToWrite) {
            if (!File.Exists(filePath)) {
                File.WriteAllText(filePath, textToWrite);
            }
            else {
                File.AppendAllText(filePath, textToWrite);
            }
        }

        public void AppendText(string text) {
            BodyString += text;            
        }

        public void AppendTextWithNewLine(string text) {
            BodyString += text + Environment.NewLine;
        }

        public string AppendTextWithResult(string text) {
            AppendText(text);
            return BodyString;
        }

        public void ClearText() {
            BodyString = null;
        }

        public void RemoveText(string text) { //Will remove all occurrences of specified string
           BodyString = BodyString.Replace(text, "");
        }

        public abstract int GetLength();
        public abstract bool IsPalindrome();
        
    }

    public static class LocalExtensions {
        public static int GetLength(this string str) { //Counts Spaces      
            str += '\0'; //Null character      
            int i = 0;
            while (str[i] != '\0') {
                ++i;
            }                
            
            return i;
        }

        public static bool IsPalindrome(this string str) {
            int length = str.GetLength();
            str = str.ToLower();
            if(length == 0) {
                return false;
            }
            else { 
                for(int i = 0; i <= length / 2;  i++) { //Only need to check half the length
                    if(str[i] != str[length - i - 1]) {
                        return false;
                    }
                }                    
            }
            return true;
        }
    }
}    

