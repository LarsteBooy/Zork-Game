using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Zork_BR.Models.Locations;

namespace Zork_BR.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }

        //public Location[,] map = new Location[32,32];
        //List<List<Location>> map = new List<List<Location>>();
        //ArrayList<Location>[][] map = new System.Collections.ArrayList<Location>[32][32];

        public void BuildMap()
        {
            var x = 32;
            var y = 32;

            Location[,] map = new Location[y,x]; //Left is row(y coord) right is column(x coord) See map for coords
            
            //Fill everything with ocean
            for( x = 0; x <= 31; x++)
            {
                for( y = 0; y <= 31; y++)
                {
                    map[y,x] = new Ocean();
                }
            }
            //Fill [4,9] to [27,27] with plains
            for (x = 9; x <= 27; x++)
            {
                for (y = 4; y <= 27; y++)
                {
                    map[y,x] = new Plain();
                }
            }
            //Fill row 2 with plains according to map
            for (x = 8; x <= 27; x++)
            {
                for (y = 2; y <= 2; y++)
                {
                    if (x >= 17 && x <= 21)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }
                }
            }
            //Fill row 3 with plains according to map
            for (x = 4; x <= 17; x++)
            {
                for (y = 3; y <= 3; y++)
                {
                    if(x == 18 || x == 19)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }  
                }
            }
            //Fill [4,4] to [7,8] with plains
            for (x = 4; x <= 8; x++)
            {
                for (y = 4; y <= 7; y++)
                {
                    map[y, x] = new Plain();
                }
            }
            //Fill [8,5] to [9,8] with plains according to map
            for (x = 5; x <= 8; x++)
            {
                for (y = 8; y <= 9; y++)
                {
                    if (x == 5 && y == 9)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }
                }
            }
            //Fill [10,6] to [11,9] with plains according to map
            for (x = 6; x <= 9; x++)
            {
                for (y = 10; y <= 11; y++)
                {
                    if (x == 6 && y == 10)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }
                }
            }
            //Fill [12,4] to [14,8] with plains
            for (x = 4; x <= 8; x++)
            {
                for (y = 12; y <= 14; y++)
                {
                    map[y, x] = new Plain();
                }
            }
            //TODO change these ones for beach [15,8] and [20,8]
            map[15, 8] = new Plain();
            map[20, 8] = new Plain();

            //Fill row 21 with plains according to map
            for (x = 6; x <= 8; x++)
            {
                for (y = 21; y <= 21; y++)
                {
                    map[y, x] = new Plain();
                }
            }
            //Fill [22,3] to [27,8] with plains according to map
            for (x = 3; x <= 8; x++)
            {
                for (y = 22; y <= 27; y++)
                {
                    if (x == 3 && y == 27)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }
                }
            }
            //Fill row 28 with plains according to map
            for (x = 4; x <= 27; x++)
            {
                for (y = 28; y <= 28; y++)
                {
                    if (x >= 7 && x <= 19)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }
                }
            }
            //Fill column 28 with plains according to map
            for (x = 28; x <= 28; x++)
            {
                for (y = 4; y <= 27; y++)
                {
                    if (y == 8 || y == 9 || y == 10 || y == 17 || y == 18)
                    {
                        //Do nothing
                    }
                    else
                    {
                        map[y, x] = new Plain();
                    }
                }
            }
            //Fill column 29 with plains according to map
            for(x = 29; x <= 29; x++)
            {
                for (y = 23; y <= 25; y++)
                {
                    map[y, x] = new Plain();
                }
            }

            //Mapcheck 
            for(x = 0; x <= 31; x++)
            {
                for(y=0; y<= 31; y++)
                {
                    System.Diagnostics.Debug.Print("[{0},{1}]",y,x ); 
                    System.Diagnostics.Debug.WriteLine(map[y, x]);
                }
            }
        }
    }
}