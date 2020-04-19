using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace LudoConsoleGame
{
    public class ConsoleIOController : IGameIOController
    {
        public int GetIntFromMessage(string message)
        {
            Console.Write(message);
            var output = Console.ReadLine();
            Console.WriteLine();

            int parsedInt;
            var result = int.TryParse(output, out parsedInt);
            if (!result)
            {
                throw new Exception("Unable to parse input to an int");
            }
            return parsedInt;
        }

        public string GetStringFromMessage(string message)
        {
            Console.Write(message);
            var output = Console.ReadLine();
            Console.WriteLine();
            return output;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}