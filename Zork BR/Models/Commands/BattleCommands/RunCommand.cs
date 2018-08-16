namespace Zork_BR.Models.Commands
{
    internal class RunCommand : Command
    {
        public override string MyAction()
        {
            //TODO implement run command
            MyStaticClass.InBattle = false;

            return "You succesfully ran away" + MyStaticClass.WhiteLine();
        }
    }
}