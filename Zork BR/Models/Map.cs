﻿using System;
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

        //TODO deze method verwijderen, nog even laten staan zodat jurgen kan zien wat er is gebeurd
        /*
        public void BuildMap2()
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
            for (x = 0; x <= 31; x++)
            {
                for(y=0; y<= 31; y++)
                {
                    System.Diagnostics.Debug.WriteLine("map[{0},{1}] = new {2}();",y,x, map[y,x].GetType().Name ); 
                  //  System.Diagnostics.Debug.WriteLine(map[y, x]);
                }
            }
        }
        */

        public static Location[,] map = new Location[32, 32];


        public void BuildMap()
        {

            map[0, 0] = new Ocean();
            map[1, 0] = new Ocean();
            map[2, 0] = new Ocean();
            map[3, 0] = new Ocean();
            map[4, 0] = new Ocean();
            map[5, 0] = new Ocean();
            map[6, 0] = new Ocean();
            map[7, 0] = new Ocean();
            map[8, 0] = new Ocean();
            map[9, 0] = new Ocean();
            map[10, 0] = new Ocean();
            map[11, 0] = new Ocean();
            map[12, 0] = new Ocean();
            map[13, 0] = new Ocean();
            map[14, 0] = new Ocean();
            map[15, 0] = new Ocean();
            map[16, 0] = new Ocean();
            map[17, 0] = new Ocean();
            map[18, 0] = new Ocean();
            map[19, 0] = new Ocean();
            map[20, 0] = new Ocean();
            map[21, 0] = new Ocean();
            map[22, 0] = new Ocean();
            map[23, 0] = new Ocean();
            map[24, 0] = new Ocean();
            map[25, 0] = new Ocean();
            map[26, 0] = new Ocean();
            map[27, 0] = new Ocean();
            map[28, 0] = new Ocean();
            map[29, 0] = new Ocean();
            map[30, 0] = new Ocean();
            map[31, 0] = new Ocean();
            map[0, 1] = new Ocean();
            map[1, 1] = new Ocean();
            map[2, 1] = new Ocean();
            map[3, 1] = new Ocean();
            map[4, 1] = new Ocean();
            map[5, 1] = new Ocean();
            map[6, 1] = new Ocean();
            map[7, 1] = new Ocean();
            map[8, 1] = new Ocean();
            map[9, 1] = new Ocean();
            map[10, 1] = new Ocean();
            map[11, 1] = new Ocean();
            map[12, 1] = new Ocean();
            map[13, 1] = new Ocean();
            map[14, 1] = new Ocean();
            map[15, 1] = new Ocean();
            map[16, 1] = new Ocean();
            map[17, 1] = new Ocean();
            map[18, 1] = new Ocean();
            map[19, 1] = new Ocean();
            map[20, 1] = new Ocean();
            map[21, 1] = new Ocean();
            map[22, 1] = new Ocean();
            map[23, 1] = new Ocean();
            map[24, 1] = new Ocean();
            map[25, 1] = new Ocean();
            map[26, 1] = new Ocean();
            map[27, 1] = new Ocean();
            map[28, 1] = new Ocean();
            map[29, 1] = new Ocean();
            map[30, 1] = new Ocean();
            map[31, 1] = new Ocean();
            map[0, 2] = new Ocean();
            map[1, 2] = new Ocean();
            map[2, 2] = new Ocean();
            map[3, 2] = new Ocean();
            map[4, 2] = new Ocean();
            map[5, 2] = new Ocean();
            map[6, 2] = new Ocean();
            map[7, 2] = new Ocean();
            map[8, 2] = new Ocean();
            map[9, 2] = new Ocean();
            map[10, 2] = new Ocean();
            map[11, 2] = new Ocean();
            map[12, 2] = new Ocean();
            map[13, 2] = new Ocean();
            map[14, 2] = new Ocean();
            map[15, 2] = new Ocean();
            map[16, 2] = new Ocean();
            map[17, 2] = new Ocean();
            map[18, 2] = new Ocean();
            map[19, 2] = new Ocean();
            map[20, 2] = new Ocean();
            map[21, 2] = new Ocean();
            map[22, 2] = new Ocean();
            map[23, 2] = new Ocean();
            map[24, 2] = new Ocean();
            map[25, 2] = new Ocean();
            map[26, 2] = new Ocean();
            map[27, 2] = new Ocean();
            map[28, 2] = new Ocean();
            map[29, 2] = new Ocean();
            map[30, 2] = new Ocean();
            map[31, 2] = new Ocean();
            map[0, 3] = new Ocean();
            map[1, 3] = new Ocean();
            map[2, 3] = new Ocean();
            map[3, 3] = new Ocean();
            map[4, 3] = new Ocean();
            map[5, 3] = new Ocean();
            map[6, 3] = new Ocean();
            map[7, 3] = new Ocean();
            map[8, 3] = new Ocean();
            map[9, 3] = new Ocean();
            map[10, 3] = new Ocean();
            map[11, 3] = new Ocean();
            map[12, 3] = new Ocean();
            map[13, 3] = new Ocean();
            map[14, 3] = new Ocean();
            map[15, 3] = new Ocean();
            map[16, 3] = new Ocean();
            map[17, 3] = new Ocean();
            map[18, 3] = new Ocean();
            map[19, 3] = new Ocean();
            map[20, 3] = new Ocean();
            map[21, 3] = new Ocean();
            map[22, 3] = new Plain();
            map[23, 3] = new Plain();
            map[24, 3] = new Plain();
            map[25, 3] = new Plain();
            map[26, 3] = new Plain();
            map[27, 3] = new Ocean();
            map[28, 3] = new Ocean();
            map[29, 3] = new Ocean();
            map[30, 3] = new Ocean();
            map[31, 3] = new Ocean();
            map[0, 4] = new Ocean();
            map[1, 4] = new Ocean();
            map[2, 4] = new Ocean();
            map[3, 4] = new Plain();
            map[4, 4] = new Plain();
            map[5, 4] = new Plain();
            map[6, 4] = new Plain();
            map[7, 4] = new Plain();
            map[8, 4] = new Ocean();
            map[9, 4] = new Ocean();
            map[10, 4] = new Ocean();
            map[11, 4] = new Ocean();
            map[12, 4] = new Plain();
            map[13, 4] = new Plain();
            map[14, 4] = new Plain();
            map[15, 4] = new Ocean();
            map[16, 4] = new Ocean();
            map[17, 4] = new Ocean();
            map[18, 4] = new Ocean();
            map[19, 4] = new Ocean();
            map[20, 4] = new Ocean();
            map[21, 4] = new Ocean();
            map[22, 4] = new Plain();
            map[23, 4] = new Plain();
            map[24, 4] = new Plain();
            map[25, 4] = new Plain();
            map[26, 4] = new Plain();
            map[27, 4] = new Plain();
            map[28, 4] = new Plain();
            map[29, 4] = new Ocean();
            map[30, 4] = new Ocean();
            map[31, 4] = new Ocean();
            map[0, 5] = new Ocean();
            map[1, 5] = new Ocean();
            map[2, 5] = new Ocean();
            map[3, 5] = new Plain();
            map[4, 5] = new Plain();
            map[5, 5] = new Plain();
            map[6, 5] = new Plain();
            map[7, 5] = new Plain();
            map[8, 5] = new Plain();
            map[9, 5] = new Ocean();
            map[10, 5] = new Ocean();
            map[11, 5] = new Ocean();
            map[12, 5] = new Plain();
            map[13, 5] = new Plain();
            map[14, 5] = new Plain();
            map[15, 5] = new Ocean();
            map[16, 5] = new Ocean();
            map[17, 5] = new Ocean();
            map[18, 5] = new Ocean();
            map[19, 5] = new Ocean();
            map[20, 5] = new Ocean();
            map[21, 5] = new Ocean();
            map[22, 5] = new Plain();
            map[23, 5] = new Plain();
            map[24, 5] = new Plain();
            map[25, 5] = new Plain();
            map[26, 5] = new Plain();
            map[27, 5] = new Plain();
            map[28, 5] = new Plain();
            map[29, 5] = new Ocean();
            map[30, 5] = new Ocean();
            map[31, 5] = new Ocean();
            map[0, 6] = new Ocean();
            map[1, 6] = new Ocean();
            map[2, 6] = new Ocean();
            map[3, 6] = new Plain();
            map[4, 6] = new Plain();
            map[5, 6] = new Plain();
            map[6, 6] = new Plain();
            map[7, 6] = new Plain();
            map[8, 6] = new Plain();
            map[9, 6] = new Plain();
            map[10, 6] = new Ocean();
            map[11, 6] = new Plain();
            map[12, 6] = new Plain();
            map[13, 6] = new Plain();
            map[14, 6] = new Plain();
            map[15, 6] = new Ocean();
            map[16, 6] = new Ocean();
            map[17, 6] = new Ocean();
            map[18, 6] = new Ocean();
            map[19, 6] = new Ocean();
            map[20, 6] = new Ocean();
            map[21, 6] = new Plain();
            map[22, 6] = new Plain();
            map[23, 6] = new Plain();
            map[24, 6] = new Plain();
            map[25, 6] = new Plain();
            map[26, 6] = new Plain();
            map[27, 6] = new Plain();
            map[28, 6] = new Plain();
            map[29, 6] = new Ocean();
            map[30, 6] = new Ocean();
            map[31, 6] = new Ocean();
            map[0, 7] = new Ocean();
            map[1, 7] = new Ocean();
            map[2, 7] = new Ocean();
            map[3, 7] = new Plain();
            map[4, 7] = new Plain();
            map[5, 7] = new Plain();
            map[6, 7] = new Plain();
            map[7, 7] = new Plain();
            map[8, 7] = new Plain();
            map[9, 7] = new Plain();
            map[10, 7] = new Plain();
            map[11, 7] = new Plain();
            map[12, 7] = new Plain();
            map[13, 7] = new Plain();
            map[14, 7] = new Plain();
            map[15, 7] = new Ocean();
            map[16, 7] = new Ocean();
            map[17, 7] = new Ocean();
            map[18, 7] = new Ocean();
            map[19, 7] = new Ocean();
            map[20, 7] = new Ocean();
            map[21, 7] = new Plain();
            map[22, 7] = new Plain();
            map[23, 7] = new Plain();
            map[24, 7] = new Plain();
            map[25, 7] = new Plain();
            map[26, 7] = new Plain();
            map[27, 7] = new Plain();
            map[28, 7] = new Ocean();
            map[29, 7] = new Ocean();
            map[30, 7] = new Ocean();
            map[31, 7] = new Ocean();
            map[0, 8] = new Ocean();
            map[1, 8] = new Ocean();
            map[2, 8] = new Plain();
            map[3, 8] = new Plain();
            map[4, 8] = new Plain();
            map[5, 8] = new Plain();
            map[6, 8] = new Plain();
            map[7, 8] = new Plain();
            map[8, 8] = new Plain();
            map[9, 8] = new Plain();
            map[10, 8] = new Plain();
            map[11, 8] = new Plain();
            map[12, 8] = new Plain();
            map[13, 8] = new Plain();
            map[14, 8] = new Plain();
            map[15, 8] = new Plain();
            map[16, 8] = new Ocean();
            map[17, 8] = new Ocean();
            map[18, 8] = new Ocean();
            map[19, 8] = new Ocean();
            map[20, 8] = new Plain();
            map[21, 8] = new Plain();
            map[22, 8] = new Plain();
            map[23, 8] = new Plain();
            map[24, 8] = new Plain();
            map[25, 8] = new Plain();
            map[26, 8] = new Plain();
            map[27, 8] = new Plain();
            map[28, 8] = new Ocean();
            map[29, 8] = new Ocean();
            map[30, 8] = new Ocean();
            map[31, 8] = new Ocean();
            map[0, 9] = new Ocean();
            map[1, 9] = new Ocean();
            map[2, 9] = new Plain();
            map[3, 9] = new Plain();
            map[4, 9] = new Plain();
            map[5, 9] = new Plain();
            map[6, 9] = new Plain();
            map[7, 9] = new Plain();
            map[8, 9] = new Plain();
            map[9, 9] = new Plain();
            map[10, 9] = new Plain();
            map[11, 9] = new Plain();
            map[12, 9] = new Plain();
            map[13, 9] = new Plain();
            map[14, 9] = new Plain();
            map[15, 9] = new Plain();
            map[16, 9] = new Plain();
            map[17, 9] = new Plain();
            map[18, 9] = new Plain();
            map[19, 9] = new Plain();
            map[20, 9] = new Plain();
            map[21, 9] = new Plain();
            map[22, 9] = new Plain();
            map[23, 9] = new Plain();
            map[24, 9] = new Plain();
            map[25, 9] = new Plain();
            map[26, 9] = new Plain();
            map[27, 9] = new Plain();
            map[28, 9] = new Ocean();
            map[29, 9] = new Ocean();
            map[30, 9] = new Ocean();
            map[31, 9] = new Ocean();
            map[0, 10] = new Ocean();
            map[1, 10] = new Ocean();
            map[2, 10] = new Plain();
            map[3, 10] = new Plain();
            map[4, 10] = new Plain();
            map[5, 10] = new Plain();
            map[6, 10] = new Plain();
            map[7, 10] = new Plain();
            map[8, 10] = new Plain();
            map[9, 10] = new Plain();
            map[10, 10] = new Plain();
            map[11, 10] = new Plain();
            map[12, 10] = new Plain();
            map[13, 10] = new Plain();
            map[14, 10] = new Plain();
            map[15, 10] = new Plain();
            map[16, 10] = new Plain();
            map[17, 10] = new Plain();
            map[18, 10] = new Plain();
            map[19, 10] = new Plain();
            map[20, 10] = new Plain();
            map[21, 10] = new Plain();
            map[22, 10] = new Plain();
            map[23, 10] = new Plain();
            map[24, 10] = new Plain();
            map[25, 10] = new Plain();
            map[26, 10] = new Plain();
            map[27, 10] = new Plain();
            map[28, 10] = new Ocean();
            map[29, 10] = new Ocean();
            map[30, 10] = new Ocean();
            map[31, 10] = new Ocean();
            map[0, 11] = new Ocean();
            map[1, 11] = new Ocean();
            map[2, 11] = new Plain();
            map[3, 11] = new Plain();
            map[4, 11] = new Plain();
            map[5, 11] = new Plain();
            map[6, 11] = new Plain();
            map[7, 11] = new Plain();
            map[8, 11] = new Plain();
            map[9, 11] = new Plain();
            map[10, 11] = new Plain();
            map[11, 11] = new Plain();
            map[12, 11] = new Plain();
            map[13, 11] = new Plain();
            map[14, 11] = new Plain();
            map[15, 11] = new Plain();
            map[16, 11] = new Plain();
            map[17, 11] = new Plain();
            map[18, 11] = new Plain();
            map[19, 11] = new Plain();
            map[20, 11] = new Plain();
            map[21, 11] = new Plain();
            map[22, 11] = new Plain();
            map[23, 11] = new Plain();
            map[24, 11] = new Plain();
            map[25, 11] = new Plain();
            map[26, 11] = new Plain();
            map[27, 11] = new Plain();
            map[28, 11] = new Ocean();
            map[29, 11] = new Ocean();
            map[30, 11] = new Ocean();
            map[31, 11] = new Ocean();
            map[0, 12] = new Ocean();
            map[1, 12] = new Ocean();
            map[2, 12] = new Plain();
            map[3, 12] = new Plain();
            map[4, 12] = new Plain();
            map[5, 12] = new Plain();
            map[6, 12] = new Plain();
            map[7, 12] = new Plain();
            map[8, 12] = new Plain();
            map[9, 12] = new Plain();
            map[10, 12] = new Plain();
            map[11, 12] = new Plain();
            map[12, 12] = new Plain();
            map[13, 12] = new Plain();
            map[14, 12] = new Plain();
            map[15, 12] = new Plain();
            map[16, 12] = new Plain();
            map[17, 12] = new Plain();
            map[18, 12] = new Plain();
            map[19, 12] = new Plain();
            map[20, 12] = new Plain();
            map[21, 12] = new Plain();
            map[22, 12] = new Plain();
            map[23, 12] = new Plain();
            map[24, 12] = new Plain();
            map[25, 12] = new Plain();
            map[26, 12] = new Plain();
            map[27, 12] = new Plain();
            map[28, 12] = new Ocean();
            map[29, 12] = new Ocean();
            map[30, 12] = new Ocean();
            map[31, 12] = new Ocean();
            map[0, 13] = new Ocean();
            map[1, 13] = new Ocean();
            map[2, 13] = new Plain();
            map[3, 13] = new Plain();
            map[4, 13] = new Plain();
            map[5, 13] = new Plain();
            map[6, 13] = new Plain();
            map[7, 13] = new Plain();
            map[8, 13] = new Plain();
            map[9, 13] = new Plain();
            map[10, 13] = new Plain();
            map[11, 13] = new Plain();
            map[12, 13] = new Plain();
            map[13, 13] = new Plain();
            map[14, 13] = new Plain();
            map[15, 13] = new Plain();
            map[16, 13] = new Plain();
            map[17, 13] = new Plain();
            map[18, 13] = new Plain();
            map[19, 13] = new Plain();
            map[20, 13] = new Plain();
            map[21, 13] = new Plain();
            map[22, 13] = new Plain();
            map[23, 13] = new Plain();
            map[24, 13] = new Plain();
            map[25, 13] = new Plain();
            map[26, 13] = new Plain();
            map[27, 13] = new Plain();
            map[28, 13] = new Ocean();
            map[29, 13] = new Ocean();
            map[30, 13] = new Ocean();
            map[31, 13] = new Ocean();
            map[0, 14] = new Ocean();
            map[1, 14] = new Ocean();
            map[2, 14] = new Plain();
            map[3, 14] = new Plain();
            map[4, 14] = new Plain();
            map[5, 14] = new Plain();
            map[6, 14] = new Plain();
            map[7, 14] = new Plain();
            map[8, 14] = new Plain();
            map[9, 14] = new Plain();
            map[10, 14] = new Plain();
            map[11, 14] = new Plain();
            map[12, 14] = new Plain();
            map[13, 14] = new Plain();
            map[14, 14] = new Plain();
            map[15, 14] = new Plain();
            map[16, 14] = new Plain();
            map[17, 14] = new Plain();
            map[18, 14] = new Plain();
            map[19, 14] = new Plain();
            map[20, 14] = new Plain();
            map[21, 14] = new Plain();
            map[22, 14] = new Plain();
            map[23, 14] = new Plain();
            map[24, 14] = new Plain();
            map[25, 14] = new Plain();
            map[26, 14] = new Plain();
            map[27, 14] = new Plain();
            map[28, 14] = new Ocean();
            map[29, 14] = new Ocean();
            map[30, 14] = new Ocean();
            map[31, 14] = new Ocean();
            map[0, 15] = new Ocean();
            map[1, 15] = new Ocean();
            map[2, 15] = new Plain();
            map[3, 15] = new Plain();
            map[4, 15] = new Plain();
            map[5, 15] = new Plain();
            map[6, 15] = new Plain();
            map[7, 15] = new Plain();
            map[8, 15] = new Plain();
            map[9, 15] = new Plain();
            map[10, 15] = new Plain();
            map[11, 15] = new Plain();
            map[12, 15] = new Plain();
            map[13, 15] = new Plain();
            map[14, 15] = new Plain();
            map[15, 15] = new Plain();
            map[16, 15] = new Plain();
            map[17, 15] = new Plain();
            map[18, 15] = new Plain();
            map[19, 15] = new Plain();
            map[20, 15] = new Plain();
            map[21, 15] = new Plain();
            map[22, 15] = new Plain();
            map[23, 15] = new Plain();
            map[24, 15] = new Plain();
            map[25, 15] = new Plain();
            map[26, 15] = new Plain();
            map[27, 15] = new Plain();
            map[28, 15] = new Ocean();
            map[29, 15] = new Ocean();
            map[30, 15] = new Ocean();
            map[31, 15] = new Ocean();
            map[0, 16] = new Ocean();
            map[1, 16] = new Ocean();
            map[2, 16] = new Plain();
            map[3, 16] = new Plain();
            map[4, 16] = new Plain();
            map[5, 16] = new Plain();
            map[6, 16] = new Plain();
            map[7, 16] = new Plain();
            map[8, 16] = new Plain();
            map[9, 16] = new Plain();
            map[10, 16] = new Plain();
            map[11, 16] = new Plain();
            map[12, 16] = new Plain();
            map[13, 16] = new Plain();
            map[14, 16] = new Plain();
            map[15, 16] = new Plain();
            map[16, 16] = new Plain();
            map[17, 16] = new Plain();
            map[18, 16] = new Plain();
            map[19, 16] = new Plain();
            map[20, 16] = new Plain();
            map[21, 16] = new Plain();
            map[22, 16] = new Plain();
            map[23, 16] = new Plain();
            map[24, 16] = new Plain();
            map[25, 16] = new Plain();
            map[26, 16] = new Plain();
            map[27, 16] = new Plain();
            map[28, 16] = new Ocean();
            map[29, 16] = new Ocean();
            map[30, 16] = new Ocean();
            map[31, 16] = new Ocean();
            map[0, 17] = new Ocean();
            map[1, 17] = new Ocean();
            map[2, 17] = new Ocean();
            map[3, 17] = new Plain();
            map[4, 17] = new Plain();
            map[5, 17] = new Plain();
            map[6, 17] = new Plain();
            map[7, 17] = new Plain();
            map[8, 17] = new Plain();
            map[9, 17] = new Plain();
            map[10, 17] = new Plain();
            map[11, 17] = new Plain();
            map[12, 17] = new Plain();
            map[13, 17] = new Plain();
            map[14, 17] = new Plain();
            map[15, 17] = new Plain();
            map[16, 17] = new Plain();
            map[17, 17] = new Plain();
            map[18, 17] = new Plain();
            map[19, 17] = new Plain();
            map[20, 17] = new Plain();
            map[21, 17] = new Plain();
            map[22, 17] = new Plain();
            map[23, 17] = new Plain();
            map[24, 17] = new Plain();
            map[25, 17] = new Plain();
            map[26, 17] = new Plain();
            map[27, 17] = new Plain();
            map[28, 17] = new Ocean();
            map[29, 17] = new Ocean();
            map[30, 17] = new Ocean();
            map[31, 17] = new Ocean();
            map[0, 18] = new Ocean();
            map[1, 18] = new Ocean();
            map[2, 18] = new Ocean();
            map[3, 18] = new Ocean();
            map[4, 18] = new Plain();
            map[5, 18] = new Plain();
            map[6, 18] = new Plain();
            map[7, 18] = new Plain();
            map[8, 18] = new Plain();
            map[9, 18] = new Plain();
            map[10, 18] = new Plain();
            map[11, 18] = new Plain();
            map[12, 18] = new Plain();
            map[13, 18] = new Plain();
            map[14, 18] = new Plain();
            map[15, 18] = new Plain();
            map[16, 18] = new Plain();
            map[17, 18] = new Plain();
            map[18, 18] = new Plain();
            map[19, 18] = new Plain();
            map[20, 18] = new Plain();
            map[21, 18] = new Plain();
            map[22, 18] = new Plain();
            map[23, 18] = new Plain();
            map[24, 18] = new Plain();
            map[25, 18] = new Plain();
            map[26, 18] = new Plain();
            map[27, 18] = new Plain();
            map[28, 18] = new Ocean();
            map[29, 18] = new Ocean();
            map[30, 18] = new Ocean();
            map[31, 18] = new Ocean();
            map[0, 19] = new Ocean();
            map[1, 19] = new Ocean();
            map[2, 19] = new Ocean();
            map[3, 19] = new Ocean();
            map[4, 19] = new Plain();
            map[5, 19] = new Plain();
            map[6, 19] = new Plain();
            map[7, 19] = new Plain();
            map[8, 19] = new Plain();
            map[9, 19] = new Plain();
            map[10, 19] = new Plain();
            map[11, 19] = new Plain();
            map[12, 19] = new Plain();
            map[13, 19] = new Plain();
            map[14, 19] = new Plain();
            map[15, 19] = new Plain();
            map[16, 19] = new Plain();
            map[17, 19] = new Plain();
            map[18, 19] = new Plain();
            map[19, 19] = new Plain();
            map[20, 19] = new Plain();
            map[21, 19] = new Plain();
            map[22, 19] = new Plain();
            map[23, 19] = new Plain();
            map[24, 19] = new Plain();
            map[25, 19] = new Plain();
            map[26, 19] = new Plain();
            map[27, 19] = new Plain();
            map[28, 19] = new Ocean();
            map[29, 19] = new Ocean();
            map[30, 19] = new Ocean();
            map[31, 19] = new Ocean();
            map[0, 20] = new Ocean();
            map[1, 20] = new Ocean();
            map[2, 20] = new Ocean();
            map[3, 20] = new Ocean();
            map[4, 20] = new Plain();
            map[5, 20] = new Plain();
            map[6, 20] = new Plain();
            map[7, 20] = new Plain();
            map[8, 20] = new Plain();
            map[9, 20] = new Plain();
            map[10, 20] = new Plain();
            map[11, 20] = new Plain();
            map[12, 20] = new Plain();
            map[13, 20] = new Plain();
            map[14, 20] = new Plain();
            map[15, 20] = new Plain();
            map[16, 20] = new Plain();
            map[17, 20] = new Plain();
            map[18, 20] = new Plain();
            map[19, 20] = new Plain();
            map[20, 20] = new Plain();
            map[21, 20] = new Plain();
            map[22, 20] = new Plain();
            map[23, 20] = new Plain();
            map[24, 20] = new Plain();
            map[25, 20] = new Plain();
            map[26, 20] = new Plain();
            map[27, 20] = new Plain();
            map[28, 20] = new Plain();
            map[29, 20] = new Ocean();
            map[30, 20] = new Ocean();
            map[31, 20] = new Ocean();
            map[0, 21] = new Ocean();
            map[1, 21] = new Ocean();
            map[2, 21] = new Ocean();
            map[3, 21] = new Ocean();
            map[4, 21] = new Plain();
            map[5, 21] = new Plain();
            map[6, 21] = new Plain();
            map[7, 21] = new Plain();
            map[8, 21] = new Plain();
            map[9, 21] = new Plain();
            map[10, 21] = new Plain();
            map[11, 21] = new Plain();
            map[12, 21] = new Plain();
            map[13, 21] = new Plain();
            map[14, 21] = new Plain();
            map[15, 21] = new Plain();
            map[16, 21] = new Plain();
            map[17, 21] = new Plain();
            map[18, 21] = new Plain();
            map[19, 21] = new Plain();
            map[20, 21] = new Plain();
            map[21, 21] = new Plain();
            map[22, 21] = new Plain();
            map[23, 21] = new Plain();
            map[24, 21] = new Plain();
            map[25, 21] = new Plain();
            map[26, 21] = new Plain();
            map[27, 21] = new Plain();
            map[28, 21] = new Plain();
            map[29, 21] = new Ocean();
            map[30, 21] = new Ocean();
            map[31, 21] = new Ocean();
            map[0, 22] = new Ocean();
            map[1, 22] = new Ocean();
            map[2, 22] = new Plain();
            map[3, 22] = new Ocean();
            map[4, 22] = new Plain();
            map[5, 22] = new Plain();
            map[6, 22] = new Plain();
            map[7, 22] = new Plain();
            map[8, 22] = new Plain();
            map[9, 22] = new Plain();
            map[10, 22] = new Plain();
            map[11, 22] = new Plain();
            map[12, 22] = new Plain();
            map[13, 22] = new Plain();
            map[14, 22] = new Plain();
            map[15, 22] = new Plain();
            map[16, 22] = new Plain();
            map[17, 22] = new Plain();
            map[18, 22] = new Plain();
            map[19, 22] = new Plain();
            map[20, 22] = new Plain();
            map[21, 22] = new Plain();
            map[22, 22] = new Plain();
            map[23, 22] = new Plain();
            map[24, 22] = new Plain();
            map[25, 22] = new Plain();
            map[26, 22] = new Plain();
            map[27, 22] = new Plain();
            map[28, 22] = new Plain();
            map[29, 22] = new Ocean();
            map[30, 22] = new Ocean();
            map[31, 22] = new Ocean();
            map[0, 23] = new Ocean();
            map[1, 23] = new Ocean();
            map[2, 23] = new Plain();
            map[3, 23] = new Ocean();
            map[4, 23] = new Plain();
            map[5, 23] = new Plain();
            map[6, 23] = new Plain();
            map[7, 23] = new Plain();
            map[8, 23] = new Plain();
            map[9, 23] = new Plain();
            map[10, 23] = new Plain();
            map[11, 23] = new Plain();
            map[12, 23] = new Plain();
            map[13, 23] = new Plain();
            map[14, 23] = new Plain();
            map[15, 23] = new Plain();
            map[16, 23] = new Plain();
            map[17, 23] = new Plain();
            map[18, 23] = new Plain();
            map[19, 23] = new Plain();
            map[20, 23] = new Plain();
            map[21, 23] = new Plain();
            map[22, 23] = new Plain();
            map[23, 23] = new Plain();
            map[24, 23] = new Plain();
            map[25, 23] = new Plain();
            map[26, 23] = new Plain();
            map[27, 23] = new Plain();
            map[28, 23] = new Plain();
            map[29, 23] = new Ocean();
            map[30, 23] = new Ocean();
            map[31, 23] = new Ocean();
            map[0, 24] = new Ocean();
            map[1, 24] = new Ocean();
            map[2, 24] = new Plain();
            map[3, 24] = new Ocean();
            map[4, 24] = new Plain();
            map[5, 24] = new Plain();
            map[6, 24] = new Plain();
            map[7, 24] = new Plain();
            map[8, 24] = new Plain();
            map[9, 24] = new Plain();
            map[10, 24] = new Plain();
            map[11, 24] = new Plain();
            map[12, 24] = new Plain();
            map[13, 24] = new Plain();
            map[14, 24] = new Plain();
            map[15, 24] = new Plain();
            map[16, 24] = new Plain();
            map[17, 24] = new Plain();
            map[18, 24] = new Plain();
            map[19, 24] = new Plain();
            map[20, 24] = new Plain();
            map[21, 24] = new Plain();
            map[22, 24] = new Plain();
            map[23, 24] = new Plain();
            map[24, 24] = new Plain();
            map[25, 24] = new Plain();
            map[26, 24] = new Plain();
            map[27, 24] = new Plain();
            map[28, 24] = new Plain();
            map[29, 24] = new Ocean();
            map[30, 24] = new Ocean();
            map[31, 24] = new Ocean();
            map[0, 25] = new Ocean();
            map[1, 25] = new Ocean();
            map[2, 25] = new Plain();
            map[3, 25] = new Ocean();
            map[4, 25] = new Plain();
            map[5, 25] = new Plain();
            map[6, 25] = new Plain();
            map[7, 25] = new Plain();
            map[8, 25] = new Plain();
            map[9, 25] = new Plain();
            map[10, 25] = new Plain();
            map[11, 25] = new Plain();
            map[12, 25] = new Plain();
            map[13, 25] = new Plain();
            map[14, 25] = new Plain();
            map[15, 25] = new Plain();
            map[16, 25] = new Plain();
            map[17, 25] = new Plain();
            map[18, 25] = new Plain();
            map[19, 25] = new Plain();
            map[20, 25] = new Plain();
            map[21, 25] = new Plain();
            map[22, 25] = new Plain();
            map[23, 25] = new Plain();
            map[24, 25] = new Plain();
            map[25, 25] = new Plain();
            map[26, 25] = new Plain();
            map[27, 25] = new Plain();
            map[28, 25] = new Plain();
            map[29, 25] = new Ocean();
            map[30, 25] = new Ocean();
            map[31, 25] = new Ocean();
            map[0, 26] = new Ocean();
            map[1, 26] = new Ocean();
            map[2, 26] = new Plain();
            map[3, 26] = new Ocean();
            map[4, 26] = new Plain();
            map[5, 26] = new Plain();
            map[6, 26] = new Plain();
            map[7, 26] = new Plain();
            map[8, 26] = new Plain();
            map[9, 26] = new Plain();
            map[10, 26] = new Plain();
            map[11, 26] = new Plain();
            map[12, 26] = new Plain();
            map[13, 26] = new Plain();
            map[14, 26] = new Plain();
            map[15, 26] = new Plain();
            map[16, 26] = new Plain();
            map[17, 26] = new Plain();
            map[18, 26] = new Plain();
            map[19, 26] = new Plain();
            map[20, 26] = new Plain();
            map[21, 26] = new Plain();
            map[22, 26] = new Plain();
            map[23, 26] = new Plain();
            map[24, 26] = new Plain();
            map[25, 26] = new Plain();
            map[26, 26] = new Plain();
            map[27, 26] = new Plain();
            map[28, 26] = new Plain();
            map[29, 26] = new Ocean();
            map[30, 26] = new Ocean();
            map[31, 26] = new Ocean();
            map[0, 27] = new Ocean();
            map[1, 27] = new Ocean();
            map[2, 27] = new Plain();
            map[3, 27] = new Ocean();
            map[4, 27] = new Plain();
            map[5, 27] = new Plain();
            map[6, 27] = new Plain();
            map[7, 27] = new Plain();
            map[8, 27] = new Plain();
            map[9, 27] = new Plain();
            map[10, 27] = new Plain();
            map[11, 27] = new Plain();
            map[12, 27] = new Plain();
            map[13, 27] = new Plain();
            map[14, 27] = new Plain();
            map[15, 27] = new Plain();
            map[16, 27] = new Plain();
            map[17, 27] = new Plain();
            map[18, 27] = new Plain();
            map[19, 27] = new Plain();
            map[20, 27] = new Plain();
            map[21, 27] = new Plain();
            map[22, 27] = new Plain();
            map[23, 27] = new Plain();
            map[24, 27] = new Plain();
            map[25, 27] = new Plain();
            map[26, 27] = new Plain();
            map[27, 27] = new Plain();
            map[28, 27] = new Plain();
            map[29, 27] = new Ocean();
            map[30, 27] = new Ocean();
            map[31, 27] = new Ocean();
            map[0, 28] = new Ocean();
            map[1, 28] = new Ocean();
            map[2, 28] = new Ocean();
            map[3, 28] = new Ocean();
            map[4, 28] = new Plain();
            map[5, 28] = new Plain();
            map[6, 28] = new Plain();
            map[7, 28] = new Plain();
            map[8, 28] = new Ocean();
            map[9, 28] = new Ocean();
            map[10, 28] = new Ocean();
            map[11, 28] = new Plain();
            map[12, 28] = new Plain();
            map[13, 28] = new Plain();
            map[14, 28] = new Plain();
            map[15, 28] = new Plain();
            map[16, 28] = new Plain();
            map[17, 28] = new Ocean();
            map[18, 28] = new Ocean();
            map[19, 28] = new Plain();
            map[20, 28] = new Plain();
            map[21, 28] = new Plain();
            map[22, 28] = new Plain();
            map[23, 28] = new Plain();
            map[24, 28] = new Plain();
            map[25, 28] = new Plain();
            map[26, 28] = new Plain();
            map[27, 28] = new Plain();
            map[28, 28] = new Ocean();
            map[29, 28] = new Ocean();
            map[30, 28] = new Ocean();
            map[31, 28] = new Ocean();
            map[0, 29] = new Ocean();
            map[1, 29] = new Ocean();
            map[2, 29] = new Ocean();
            map[3, 29] = new Ocean();
            map[4, 29] = new Ocean();
            map[5, 29] = new Ocean();
            map[6, 29] = new Ocean();
            map[7, 29] = new Ocean();
            map[8, 29] = new Ocean();
            map[9, 29] = new Ocean();
            map[10, 29] = new Ocean();
            map[11, 29] = new Ocean();
            map[12, 29] = new Ocean();
            map[13, 29] = new Ocean();
            map[14, 29] = new Ocean();
            map[15, 29] = new Ocean();
            map[16, 29] = new Ocean();
            map[17, 29] = new Ocean();
            map[18, 29] = new Ocean();
            map[19, 29] = new Ocean();
            map[20, 29] = new Ocean();
            map[21, 29] = new Ocean();
            map[22, 29] = new Ocean();
            map[23, 29] = new Plain();
            map[24, 29] = new Plain();
            map[25, 29] = new Plain();
            map[26, 29] = new Ocean();
            map[27, 29] = new Ocean();
            map[28, 29] = new Ocean();
            map[29, 29] = new Ocean();
            map[30, 29] = new Ocean();
            map[31, 29] = new Ocean();
            map[0, 30] = new Ocean();
            map[1, 30] = new Ocean();
            map[2, 30] = new Ocean();
            map[3, 30] = new Ocean();
            map[4, 30] = new Ocean();
            map[5, 30] = new Ocean();
            map[6, 30] = new Ocean();
            map[7, 30] = new Ocean();
            map[8, 30] = new Ocean();
            map[9, 30] = new Ocean();
            map[10, 30] = new Ocean();
            map[11, 30] = new Ocean();
            map[12, 30] = new Ocean();
            map[13, 30] = new Ocean();
            map[14, 30] = new Ocean();
            map[15, 30] = new Ocean();
            map[16, 30] = new Ocean();
            map[17, 30] = new Ocean();
            map[18, 30] = new Ocean();
            map[19, 30] = new Ocean();
            map[20, 30] = new Ocean();
            map[21, 30] = new Ocean();
            map[22, 30] = new Ocean();
            map[23, 30] = new Ocean();
            map[24, 30] = new Ocean();
            map[25, 30] = new Ocean();
            map[26, 30] = new Ocean();
            map[27, 30] = new Ocean();
            map[28, 30] = new Ocean();
            map[29, 30] = new Ocean();
            map[30, 30] = new Ocean();
            map[31, 30] = new Ocean();
            map[0, 31] = new Ocean();
            map[1, 31] = new Ocean();
            map[2, 31] = new Ocean();
            map[3, 31] = new Ocean();
            map[4, 31] = new Ocean();
            map[5, 31] = new Ocean();
            map[6, 31] = new Ocean();
            map[7, 31] = new Ocean();
            map[8, 31] = new Ocean();
            map[9, 31] = new Ocean();
            map[10, 31] = new Ocean();
            map[11, 31] = new Ocean();
            map[12, 31] = new Ocean();
            map[13, 31] = new Ocean();
            map[14, 31] = new Ocean();
            map[15, 31] = new Ocean();
            map[16, 31] = new Ocean();
            map[17, 31] = new Ocean();
            map[18, 31] = new Ocean();
            map[19, 31] = new Ocean();
            map[20, 31] = new Ocean();
            map[21, 31] = new Ocean();
            map[22, 31] = new Ocean();
            map[23, 31] = new Ocean();
            map[24, 31] = new Ocean();
            map[25, 31] = new Ocean();
            map[26, 31] = new Ocean();
            map[27, 31] = new Ocean();
            map[28, 31] = new Ocean();
            map[29, 31] = new Ocean();
            map[30, 31] = new Ocean();
            map[31, 31] = new Ocean();
        }
    }
}