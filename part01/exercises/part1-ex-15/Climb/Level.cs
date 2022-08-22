using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Loppuprojekti
{
    class Level
    {
        string difficulty;
        int roomAmount;
        string[] map;
        // Name of the room, possible enemies
        object[,] roomTypes = new object[,] { 
            { "Entrance", 1 },
            { "Basic", 3 },
            { "Secret", 2 }, 
            { "Hallway", 4 },
            { "Boss", 5 },
            { "Kitchen", 2 },
            { "Relaxing", 3 }
        };

        public Level()
        {
            difficulty = "";
            roomAmount = 0;
            map = new string[roomAmount];
        }

        public Level(string tDifficulty, int tRoomAmount)
        {
            difficulty = tDifficulty;
            roomAmount = tRoomAmount;
            map = new string[roomAmount];
        }

        public string GetSettings()
        {
            return "Level Settings \nDifficulty: " + difficulty + "\nRoom Amount: " + roomAmount;
        }

        public string GetRoom(string roomName)
        {
            string room = "";  
            for(int i = 0; i < roomTypes.Length; i++)
            {
                if(Convert.ToString(roomTypes[i,0]) == roomName)
                {
                    room = Convert.ToString(roomTypes[i, 0]);
                    break;
                }
            }

            return room;
        }

        public void Generate()
        {
            Random r = new Random();

            for (int i = 0; i < map.Length; i++)
            {
                // Choose random room from roomTypes
                string room = Convert.ToString(roomTypes[r.Next(1, roomTypes.Length / 2), 0]);

                if (map[i] == null)
                {
                    // if map does not contain entrance...
                    if (!map.Contains("Entrance"))
                    {
                        // Add entrance
                        map[i] = Convert.ToString(roomTypes[0,0]);
                    }

                    else
                    {
                        // if map has a boss room AND the random room is a boss room...
                        if (map.Contains("Boss") && room == "Boss")
                        {
                            // change random room as long as it is a boss room.
                            while(room == "Boss")
                            {
                                room = Convert.ToString(roomTypes[r.Next(1, roomTypes.Length / 2), 0]);
                            }
                        }

                        // if map is almost created check if map contains a boss room.
                        else if (i == map.Length-1 && !map.Contains("Boss"))
                        {
                            room = "Boss";
                        }

                        map[i] = room;
                    }
                }
            }
        }

        public string[] MapLayout()
        {
            return map;
        }

        public string GetRoomFromMapLayout(int room)
        {
            return map[room];
        }

        public string Map()
        {
            string theMap = "";
            for (int i = 0; i < map.Length; i++)
            {
                theMap += "Room " + (i+1) + ": " + map[i] + "\n";
            }

            return theMap;
        }

        public int GetRoomAmount()
        {
            return map.Length;
        }

        public int GetMaxEnemyAmount(string room)
        {
            int value = 0;
            for(int i = 0; i < roomTypes.Length/2; i++)
            {
                if (Convert.ToString(roomTypes[i, 0]) == room)
                {
                    value = Convert.ToInt32(roomTypes[i, 1]);
                }
            }
            return value;
        }
    }
}
