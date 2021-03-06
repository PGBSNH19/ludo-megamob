﻿using LudoGameEngine;
using System;

namespace LudoConsoleGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameInteraction gi = new GameInteraction(new ConsoleIOController());
            gi.StartInteractiveLudoGame();
            gi.ChooseMenuOption();

            Console.WriteLine("Game over!! Press any key!");
            Console.ReadKey();
        }
    }
}