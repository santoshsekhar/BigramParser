using Santosh_BigramParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Santosh_Bigramparser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Any())
            {
                var filePath = args[0];
                if (File.Exists(filePath))
                {
                    var values = new BigramCounter();
                    try
                    {
                        var results = values.InputFile(filePath);
                        foreach (var result in results)
                        {
                            Console.WriteLine($" '{result.Key}' \t {result.Value}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Could not find file at {filePath}");
                }
            }
            Console.ReadLine();
        }
    }
}


