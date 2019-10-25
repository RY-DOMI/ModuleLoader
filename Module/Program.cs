using System;
using Module.Logging;

namespace Module
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Debug("########################################");
            Logger.Debug("");
            Logger.Debug("      + Made by Dominik Auer");
            Logger.Debug("      + Version: 1.0.0");
            Logger.Debug("");
            Logger.Debug("########################################");
            Logger.Debug("");

            ModuleLoader moduleLoader = new ModuleLoader();
            moduleLoader.PrepareModule("Test");

            Console.ReadKey();
        }
    }
}
