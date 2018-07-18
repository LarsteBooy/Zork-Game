using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class HelpCommand : Command
    {
        private string helpText;
        private readonly int id = 0;

        public HelpCommand(int id)
        {
            this.id = id;
        }

        public override void MyAction()
        {
            helpText = "    Commands\n--------------------\n    [Movement]\n--------------------\nNorth - Move North\nWest - Move West\nSouth - Move South\nEast - Move East\n--------------------\n  [Items / Actions]\n--------------------\nEquip\nAttack\n--------------------\n  [Fun commands]\n--------------------\n - Dance\n - Poke\n - More\n====================\n";
            using (var context = ApplicationDbContext.Create())
            {
                Story story = context.Stories.Find(id);

                //Alleen de bijgevoegde tekst toevoegen i.v.m. saven door appendstory methode
                story.MyStory += helpText;

                context.SaveChanges();
            }
        }
    }
}
