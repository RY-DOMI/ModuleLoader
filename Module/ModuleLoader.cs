using Module.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Module
{
    public class ModuleLoader
    {
        public IDictionary<string, Module> modules { get; set; }
        public IList<Module> runningModules { get; set; }

        public ModuleLoader()
        {
            Directory.CreateDirectory("./modules");

            modules = new Dictionary<string, Module>();
            runningModules = new List<Module>();
        }

        public void PrepareModule(string name)
        {
            LoadModule(name);
            EnableModule(name);
        }

        public void LoadModule(string name)
        {
            if (!modules.ContainsKey(name))
            {
                Logger.Info("Module [Name=" + name + "] loading...");
                string path = "./modules/" + name + "Module.dll";
                if (File.Exists(path))
                {
                    Assembly assembly = Assembly.LoadFile(Path.GetFullPath(path));
                    // Module.TestModule
                    Type type = assembly.GetType("Module." + name + "Module");
                    Module module = (Module)Activator.CreateInstance(type);

                    modules.Add(name, module);
                    Logger.Info(module.Description.ToString(false) + " loaded.");
                } 
                else
                {
                    Logger.Warn("Could not find any module with the name " + name + "!");
                }
            }
        }

        public void EnableModule(string name)
        {
            Module module = null;
            modules.TryGetValue(name, out module);

            if (module == null)
            {
                Logger.Warn("Could not find any module with the name " + name + "!");
            }
            else
            {
                Logger.Info(module.Description.ToString(true) + " enabled.");
                Logger.Info("");

                module.OnEnable();
                runningModules.Add(module);
            }
        }

        public void DisableModule(string name)
        {
            if (modules.ContainsKey(name))
            {
                Module module = null;
                modules.TryGetValue(name, out module);

                module.OnDisable();
                runningModules.Remove(module);

                Logger.Info(module.Description.ToString(false) + " disabled!");
            } 
            else
            {
                Logger.Warn("Could not find any module with the name " + name + "!");
            }
        }
    }
}
