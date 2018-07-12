using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zork_BR.Models.Commands
{
    public class AliveCommand : Command
    {
        private readonly int id = 0;
        public static int enemyCount = 99;

        public AliveCommand(int id)
        {
            this.id = id;
        }

        public override void MyAction()
        {
            using (var context = ApplicationDbContext.Create())
            {
                Story story = context.Stories.Find(id);

                story.MyStory += String.Format("There are {0} enemies remaining\n\n", enemyCount);

                context.SaveChanges();
            }
        }
    }
}