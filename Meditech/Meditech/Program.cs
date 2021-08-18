using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Meditech
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),@"Files\MeditechIn.txt"));
            
            const int tabLength= 8;

            List<string> newlInesToFile = new List<string>();

            foreach (string line in lines)
            {
                var newLine = "";

                var splitLines = line.Split('\t');


                foreach (string splitLine in splitLines)
                {
                    var newChar = splitLine;
                    if (splitLine.Length > 0)
                    {
                        int numberOfSpaces;
                        if (splitLine.Length > tabLength)
                        {
                            numberOfSpaces = splitLine.Length % tabLength;
                            numberOfSpaces = tabLength - numberOfSpaces;
                        }
                        else
                        {
                            numberOfSpaces = tabLength - splitLine.Length;
                        }

                        for (int C = 0; C < numberOfSpaces; C++)
                        {
                            newChar = newChar + " ";
                        }

                        newLine = newLine + newChar;
                    }

                }
                newlInesToFile.Add(newLine);

            }
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Files\Meditech Out.txt"), newlInesToFile);

            Console.WriteLine("Press any key to exit.");

            System.Console.ReadKey();
        }
    }
}
