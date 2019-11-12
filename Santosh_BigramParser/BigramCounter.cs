using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Santosh_BigramParser
{
    public class BigramCounter
    {
        public Dictionary<string, int> InputFile(string path)
        {
            var bucket = new Dictionary<string, int>();
            if (!File.Exists(path)) return bucket;

            using (var doc = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var buffer = new BufferedStream(doc))
            using (var stream = new StreamReader(buffer))
            {
                string input;
                while ((input = stream.ReadLine()) != null)
                {
                    var after = RemoveSymbols(input);
                    var words = after.ToLower().Split(' ');
                    for (var i = 0; i < words.Length - 1; i++)
                    {
                        var sentence = $"{words[i]} {words[i + 1]}";
                        var term = bucket.FirstOrDefault(r => r.Key == sentence);
                        if (term.Value > 0)
                        {
                            bucket[sentence] = term.Value + 1;
                        }
                        else
                        {
                            bucket.Add(sentence, 1);
                        }
                    }
                }
            }
            return bucket;
        }

        private static string RemoveSymbols(string input)
        {
            return input.Replace(".", "").Replace("!", "").Replace("?", "").Replace("\"", "").Replace(",", "").Replace("#", "").Replace(":", "")
                .Replace(";", "").Replace("%", "").Replace("^", "").Replace("*", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "")
                .Replace("/", "").Replace("~", "").Replace("|", "").Replace("<", "").Replace(">", "").Replace("@", "").Replace("$", "").Replace("&", "").Replace("`", "");
        }
    }
}
