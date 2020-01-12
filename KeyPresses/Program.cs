using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyPresses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> testCases = new List<string[]>() {
                new string[] { "a,b,c,d", "a,b,c,c,-B,d" },
                new string[] { "-B,-B,-B,c,c", "c,c" },
                new string[] { "", "a,-B,-B,-B,a,-B,a,b,c,c,c,d" },
                new string[] { "a,-B,-B,-B,a,-B,a,b,c,c,c,d", "" }
            };

            foreach(var test in testCases)
            {
                Console.WriteLine(EvaluateKeyPresses(test) ? "Key Strokes are the same" : "Key Strokes are not the same");
            }

            Console.ReadLine();
        }

        private static bool EvaluateKeyPresses(string[] keyStrokes)
        {
            return ParseKeyStrokes(keyStrokes[0].Split(",")).SequenceEqual(ParseKeyStrokes(keyStrokes[1].Split(",")));
        }

        private static List<string> ParseKeyStrokes(string[] keyStrokes)
        {            
            List<string> keySet = new List<string>();

            foreach (string key in keyStrokes)
            {
                if (key == "-B")
                {
                    if (keySet.Count > 0)
                    {
                        keySet.RemoveAt(keySet.Count - 1);
                    }
                }
                else
                {
                    if(!string.IsNullOrWhiteSpace(key))
                    {
                        keySet.Add(key);
                    }
                }
                
            }

            return keySet;
        }
    }
}
