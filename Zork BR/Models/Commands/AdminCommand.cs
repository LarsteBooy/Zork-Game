namespace Zork_BR.Models.Commands
{
    public class AdminCommand : Command
    {
        private readonly string input;
        PlayerStats playerStats = null;

        public AdminCommand(string input, PlayerStats playerStats)
        {
            this.input = input;
            this.playerStats = playerStats;
        }

        public override string MyAction()
        {
            switch (input)
            {
                case "render": playerStats.RenderMinimap = true;
                    break;
                case "bagspace": playerStats.MaximumItemsInInventory = playerStats.MaximumItemsInInventory + 2;
                    break;
            }

            return "";
        }
    }
}