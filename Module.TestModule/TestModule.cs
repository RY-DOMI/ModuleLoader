using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.Logging;

namespace Module
{
    public class TestModule : Module
    {

        public const string Prefix = "[TestModule] ";

        public TestModule() : base(new ModuleDescription("Test", "1.0.0", new string[] { "Dominik Auer" }, "https://github.com/RY-DOMI")) { }

        public override void OnEnable()
        {
            Logger.Debug(Prefix + "This is only an example!");
            Logger.Info(Prefix + ">> Enabled!");
        }

        public override void OnDisable()
        {
            Logger.Info(Prefix + ">> Disabled!");
        }
    }
}
