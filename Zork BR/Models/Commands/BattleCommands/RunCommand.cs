namespace Zork_BR.Models.Commands
{
    internal class RunCommand : Command
    {
        Player player = null;

        public RunCommand(Player player)
        {
            this.player = player;
        }

        public override string MyAction()
        {
            //TODO implement run command
            player.InBattle = false;

            return "You succesfully ran away" + MyStaticClass.WhiteLine();
        }
    }
}