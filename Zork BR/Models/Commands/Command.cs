namespace Zork_BR.Models
{
    public abstract class Command
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public abstract string MyAction();
    }
}