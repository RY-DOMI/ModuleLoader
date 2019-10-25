namespace Module
{
    public abstract class Module
    {
        public ModuleDescription Description { get; set; }

        public Module(ModuleDescription description)
        {
            Description = description;
        }

        public abstract void OnEnable();

        public abstract void OnDisable();

    }
}
