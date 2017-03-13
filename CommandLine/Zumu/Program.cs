using MainarizumuVerifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zumu
{
    class Program
    {
        /// <summary>
        /// Reads the input file, runs the Mainarizumu solver
        /// and outputs the resulting solution to the standard output.
        
        /// </summary>
        /// <param name="args">arg[0] should be a valid filename.</param>
        /// <returns>
        ///     0 on success
        ///     1 on incorrect paramters
        ///     2 on file not found.
        ///     3 on file unreadable.
        /// </returns>
        static int Main(string[] args)
        {
            if(args.Length != 1)
            {
                System.Console.WriteLine("Specify input file: zumu.exe <inputfile>");
                return 1; 
            }
            string fileName = args[0];
            if(!File.Exists(fileName))
            {
                System.Console.WriteLine($"The filename '{fileName}' was not found.");
                return 2;
            }
            string inputPuzzle = "";
            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fileName))
                {
                    inputPuzzle = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"The filename '{fileName}' could not be read from.");
                System.Console.WriteLine(ex.Message);
                return 3;
            }
            Mainarizumu solver = new Mainarizumu(inputPuzzle);
            System.Console.WriteLine(solver.GetSolution());
            return 0;
        }
    }
}
