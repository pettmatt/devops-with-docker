using System;
using System.Linq;

namespace Loppuprojekti
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reverse-Pyramid Raid
            string title = @"

__________                                         __________                              .__    .___ __________        .__    .___
\______   \ _______  __ ___________  ______ ____   \______   \___.__.____________    _____ |__| __| _/ \______   \_____  |__| __| _/
 |       _// __ \  \/ // __ \_  __ \/  ___// __ \   |     ___<   |  |\_  __ \__  \  /     \|  |/ __ |   |       _/\__  \ |  |/ __ | 
 |    |   \  ___/\   /\  ___/|  | \/\___ \\  ___/   |    |    \___  | |  | \// __ \|  Y Y  \  / /_/ |   |    |   \ / __ \|  / /_/ | 
 |____|_  /\___  >\_/  \___  >__|  /____  >\___  >  |____|    / ____| |__|  (____  /__|_|  /__\____ |   |____|_  /(____  /__\____ | 
        \/     \/          \/           \/     \/             \/                 \/      \/        \/          \/      \/        \/ 

";
            Console.WriteLine(title);
            Console.WriteLine("Text Adventure: Reverse Pyramid Raid");
            Continue();

            GameLoop();
        }

        static public void GameLoop()
        {
            bool levelSettingDone = false;
            bool gameStatus = true;
            Hero player = new Hero();
            Enemy opponent = new Enemy();
            Level lvl = new Level();
            int currentLevel = 1;
            // Generate items and let player create own character.

            Weapon we = new Weapon();
            Armour ar = new Armour();
            we.GenerateWeapons();
            ar.GenerateArmours();
            CreateCharacter(player, we, ar);

            while (gameStatus)
            {
                // Check which level player is on
                if (currentLevel == 1 && !levelSettingDone)
                {
                    lvl = new Level("easy", 5);
                    lvl.Generate();
                    player.SetMaxVisitedRooms(lvl.GetRoomAmount());
                    levelSettingDone = true;

                    // Show level settings.
                    Console.WriteLine(lvl.GetSettings());
                    Continue();
                }

                else if (currentLevel == 2 && !levelSettingDone)
                {
                    lvl = new Level("medium", 10);
                    lvl.Generate();
                    player.SetMaxVisitedRooms(lvl.GetRoomAmount());
                    levelSettingDone = true;

                    // Show level settings.
                    Console.WriteLine(lvl.GetSettings());
                    Continue();
                }

                else if (currentLevel == 3 && !levelSettingDone)
                {
                    lvl = new Level("hard", 20);
                    lvl.Generate();
                    player.SetMaxVisitedRooms(lvl.GetRoomAmount());
                    levelSettingDone = true;

                    // Show level settings.
                    Console.WriteLine(lvl.GetSettings());
                    Continue();
                }

                // If player isn't in any room -> throw player into Entrance.
                if (player.GetRoom() == null)
                {
                    player.SetRoom(lvl.GetRoom("Entrance"));
                }

                // Move player to the next room
                else if (player.GetRoom() != null)
                {
                    // Add visited room to roomsVisited array.
                    player.AddVisitedRoom();
                    player.visitedRoomsCount++;
                    try
                    {
                        player.SetRoom(lvl.GetRoomFromMapLayout(player.visitedRoomsCount));
                    }

                    catch (IndexOutOfRangeException e)
                    {
                        goto Boss;
                    }

                    Console.WriteLine(player.GetName() + " moved to " + player.GetRoom() + " room.");
                    Continue();
                }

                // if not visited encounter happens
                if (!player.GetVisitedRooms().Contains(player.GetRoom()) && player.health > 0)
                {
                    CombatLoop(opponent, player, Dice(1, lvl.GetMaxEnemyAmount(player.GetRoom())));

                    if (player.health > 0)
                    {
                        Rewards(player, ar, we);
                    }
                }

                Boss:
                if (player.GetVisitedRooms().Contains("Boss"))
                {
                    Console.WriteLine("You have beaten the boss of current floor!\nAdvancing to the next floor.");
                    Continue();
                    currentLevel++;
                    levelSettingDone = false;

                    if (currentLevel > 3)
                    {
                        gameStatus = false;
                    }
                }

                if (player.health <= 0)
                {
                    Console.WriteLine("Game Over.\nYou Died.");
                    break;
                }

                else if (gameStatus == false)
                {
                    Console.WriteLine("You have beaten the pyramid!");
                    break;
                }
            }
        }

        static public Hero CreateCharacter(Hero player, Weapon weapon, Armour armour)
        {
            int health = 0;
            string answer = "";

            answer = QuestionInput("Name your character ");
            player.SetName(answer);

            Console.WriteLine("Use numbers to choose.");
            answer = QuestionInput("Choose your race:\n 1 Human\n 2 Dragon-Kin\n 3 Troll ");

            if (answer == "1")
            {
                player.SetRace("human");
            } else if (answer == "2")
            {
                player.SetRace("dragon-kin");
            } else if (answer == "3")
            {
                player.SetRace("troll");
            }

            answer = QuestionInput("\nChoose your equipments.\nWeapons:\n " +
                "1 " + weapon.weaponPool[0].GetName() + ", " + weapon.weaponPool[0].GetDamage() + " damage\n " +
                "2 " + weapon.weaponPool[1].GetName() + ", " + weapon.weaponPool[1].GetDamage() + " damage\n " +
                "3 " + weapon.weaponPool[2].GetName() + ", " + weapon.weaponPool[2].GetDamage() + " damage");

            if (answer == "1")
            {
                player.inv.TakeWeapon(weapon.weaponPool[0]);
                player.inv.EquipWeapon(weapon.weaponPool[0], player);
            }

            else if (answer == "2")
            {
                player.inv.TakeWeapon(weapon.weaponPool[1]);
                player.inv.EquipWeapon(weapon.weaponPool[1], player);
            }

            else if (answer == "3")
            {
                player.inv.TakeWeapon(weapon.weaponPool[2]);
                player.inv.EquipWeapon(weapon.weaponPool[2], player);
            }

            answer = QuestionInput("\nArmour:\n " + 
                "1 " + armour.armourPool[0].GetName() + ", " + armour.armourPool[0].GetArmour() + " armour" + "\n " +
                "2 " + armour.armourPool[1].GetName() + ", " + armour.armourPool[1].GetArmour() + " armour" + "\n " +
                "3 " + armour.armourPool[2].GetName() + ", " + armour.armourPool[2].GetArmour() + " armour");

            if (answer == "1")
            {
                player.inv.TakeArmour(armour.armourPool[0]);
                player.inv.EquipArmour(armour.armourPool[0], player);
            }

            else if (answer == "2")
            {
                player.inv.TakeArmour(armour.armourPool[1]);
                player.inv.EquipArmour(armour.armourPool[1], player);
            }

            else if (answer == "3")
            {
                player.inv.TakeArmour(armour.armourPool[2]);
                player.inv.EquipArmour(armour.armourPool[2], player);
            }

            if (player.race == "human")
            {
                health = 300;
                player.SetHealth(health);
                player.SetMaxHealth(health);
            }

            else if (player.race == "dragon-kin")
            {
                health = 500;
                player.SetHealth(health);
                player.SetMaxHealth(health);
            }

            else if (player.race == "troll")
            {
                health = 700;
                player.SetHealth(health);
                player.SetMaxHealth(health);
            }

            Console.WriteLine("Your character: \n" + player.GetStats());
            Continue();
            return player;
        }

        static public void CombatLoop(Enemy enemy, Hero player, int enemyAmount)
        {
            bool PlTurn = (Dice(0, 3) > 1);
            bool escape = false;
            int nulls = 0;
            int numberOfEnemies = enemyAmount;

            Enemy e = new Enemy();
            Enemy[] enemies = new Enemy[numberOfEnemies];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = e.Generate();
            }

            Console.WriteLine(enemies.Length + " enemies appeared!");
            Continue();

            while (enemies != null)
            {
                if (PlTurn)
                {
                    PlayerTurn(player, enemies, escape);
                    PlTurn = false;
                    if (escape)
                    {
                        Console.WriteLine("Escape is successful!");
                        Continue();
                        break;
                    }
                }

                else if(!PlTurn)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if (enemies[i] != null)
                        {
                            Console.WriteLine(enemies[i].GetName() + "'s turn.");
                            EmemyTurn(enemies[i], player);
                        }
                    }
                    PlTurn = true;
                }

                if (enemies.Contains(null) || player.health <= 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if(enemies[i] == null)
                        {
                            nulls++;
                        }
                    }

                    if(nulls == enemies.Length || player.health <= 0)
                    {
                        break;
                    }
                }
            }
        }

        static void EmemyTurn(Enemy enemy, Hero player)
        {
            if (Dice(0, 10) < 8)
            {
                int damageDealt = enemy.DealDamage(player);
                player.LoseHealth(damageDealt);
                Console.WriteLine(enemy.GetName() + " deals " + damageDealt + " damage.");
                Console.WriteLine(player.GetName() + " has " + player.health + " HP.");
            }

            else
            {
                Console.WriteLine("Enemy misses.");
            }

            Continue();
        }

        static void PlayerTurn(Hero player, Enemy[] enemies, bool escape)
        {
            string answer = QuestionInput(player.GetName() + "'s turn (use numbers to choose).\nAction options:\n 1 Attack\n 2 Use Weapon Ability\n 3 Escape\n 4 Change Equipments");

            if (answer == "1")
            {
                PlayerAttack(player, enemies, answer, 1, false);
            }

            else if (answer == "2")
            {
                if (player.GetWeapon().ToLower().Contains("sword"))
                {
                    PlayerAttack(player, enemies, answer, 4, true);
                }

                else if (player.GetWeapon().ToLower().Contains("scythe"))
                {
                    PlayerAttack(player, enemies, answer, 2, true);
                }

                else if (player.GetWeapon().ToLower().Contains("mallet"))
                {
                    PlayerAttack(player, enemies, answer, 3, true);
                }
            }

            else if (answer == "3")
            {
                escape = (Dice(0, 10) > 7);

                if (!escape)
                {
                    Console.WriteLine("Escape failed.");
                    Continue();
                }
            }

            else if (answer == "4")
            {
                Console.WriteLine("\nYour inventory:");
                Console.WriteLine(player.inv.LookAtInventory());
                int index = Convert.ToInt32(QuestionInput("What would you want to equip? \nNote: you can only choose one equipment to change (use number to choose)"));

                if (index < 4)
                {
                    Weapon we = player.inv.wEment[index-1];
                    player.inv.EquipWeapon(we, player);
                }
                
                else if (index >= 4)
                {
                    Armour ar = player.inv.aEment[index-1-player.inv.wEment.Length];
                    player.inv.EquipArmour(ar, player);
                }
            }
        }

        static public void PlayerAttack(Hero player, Enemy[] enemies, string answer, int kerroin, bool ability)
        {
            int playerDamage = player.damage * kerroin;
            string crit = "";

            if (Dice(0, 100) > 65)
            {
                playerDamage *= 2;
                crit = " critical";
            }

            // Get all the names in enemies array.
            if (enemies.Length > 1)
            {
                string temp = "";
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (temp == "")
                    {
                        temp += (i + 1) + " " + enemies[i].GetName() + "\n ";
                    }

                    else
                    {
                        temp += (i + 1) + " " + enemies[i].GetName() + "\n ";
                    }
                }

                answer = QuestionInput("\nChoose which enemy to attack.\n " + temp);

                // Making sure player attacks the correct enemy
                int tAnswer = (Convert.ToInt32(answer) - 1);
                string message = "";
                // Calculating enemy's health.
                if (!ability)
                {
                    enemies[tAnswer].LoseHealth(playerDamage);
                    message = player.GetName() + " attacks dealing " + playerDamage + crit + " damage.\n" + enemies[tAnswer].GetName() + " has " + enemies[tAnswer].health + " HP.";
                }
                
                else if (ability)
                {
                    message = Ability(player, enemies, tAnswer, playerDamage, crit);
                }

                Console.WriteLine(message);
                Continue();

                if (enemies[tAnswer].GetHealth() <= 0)
                {
                    Console.WriteLine(enemies[tAnswer].GetName() + " dies.");
                    Continue();
                    enemies[tAnswer] = null;

                    int nullEnemies = 0;
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if (enemies[i] == null)
                        {
                            nullEnemies++;
                        }
                    }

                    if (nullEnemies == enemies.Length) enemies = new Enemy[0];
                }
            }

            else
            {
                string message = "";
                if (enemies[0] != null)
                {
                    if (!ability)
                    {
                        enemies[0].LoseHealth(playerDamage);
                        message = player.GetName() + " attacks dealing " + playerDamage + crit + " damage.\n" + enemies[0].GetName() + " has " + enemies[0].health + " HP.";
                    }

                    else if (ability)
                    {
                        message = Ability(player, enemies, 0, playerDamage, crit);
                    }
                
                    Console.WriteLine(message);
                    Continue();

                    if (enemies[0].GetHealth() <= 0)
                    {
                        Console.WriteLine(enemies[0].GetName() + " dies.");
                        enemies[0] = null;

                        int nullEnemies = 0;
                        for (int i = 0; i < enemies.Length; i++)
                        {
                            if (enemies[i] == null)
                            {
                                nullEnemies++;
                            }
                        }

                        if (nullEnemies == enemies.Length) enemies = new Enemy[0];
                    }
                }
            }
        }

        static public string Ability(Hero player, Enemy[] enemies, int tAnswer, int playerDamage, string crit)
        {
            string message = "";
            string abilityName = "";
            string weapon = player.GetWeapon().ToLower();

            if (weapon.Contains("sword"))
            {
                abilityName = "Grand Duelist";
            }

            else if (weapon.Contains("mallet"))
            {
                abilityName = "Hammer Time";
            }

            else if (weapon.Contains("scythe"))
            {
                abilityName = "Harvester Of The Night";
            }

            if (Dice(0, 20) > 8)
            {
                if (abilityName == "Grand Duelist")
                {
                    enemies[tAnswer].LoseHealth(playerDamage);
                    message = player.GetName() + " attacks with " + abilityName + " dealing " + playerDamage + crit + " damage.\n" + enemies[tAnswer].GetName() + " has " + enemies[tAnswer].health + " HP.";
                }

                else if (abilityName == "Hammer Time")
                {
                    enemies[tAnswer].LoseHealth(playerDamage);
                    message = player.GetName() + " attacks with " + abilityName + " dealing " + playerDamage + crit + " damage.\n" + enemies[tAnswer].GetName() + " has " + enemies[tAnswer].health + " HP.";
                }

                else if (abilityName == "Harvester Of The Night")
                {
                    if (Dice(0, 20) > 5)
                    {
                        enemies[tAnswer].LoseHealth(enemies[tAnswer].GetHealth());
                        message = "Death has come for thee.\n" + enemies[tAnswer].GetName() + " has " + enemies[tAnswer].health + " HP.";
                    }

                    else
                    {
                        message = "Enemy dodged Harvester Of The Night.";
                    }
                }
            }

            else message = abilityName + " missed!";

            return message;
        }

        static public void Rewards(Hero player, Armour arm, Weapon wep)
        {
            int chance = Dice(5, 100);
            // Heal player
            player.Heal(Dice(100, 250));
            Console.WriteLine("Mystic powers healed " + player.GetName() + ".\nCurrent HP: " + player.health);

            Armour rewardAr = null;
            Weapon rewardWe = null;

            if (Dice(1, 10) < 3)
            {
                rewardAr = arm.armourPool[Dice(0, arm.armourPool.Length)];
            }

            else if (Dice(1, 10) < 3)
            {
                rewardWe = wep.weaponPool[Dice(0, wep.weaponPool.Length)];
            }

            if (rewardAr != null)
            {
                player.inv.TakeArmour(rewardAr);
            }

            else if (rewardWe != null)
            {
                player.inv.TakeWeapon(rewardWe);
            }

            if (rewardAr != null || rewardWe != null)
            {
                Console.WriteLine("You have got new equipment(s)");
                Console.WriteLine("Now your inventory looks like this...");
                Console.WriteLine(player.inv.LookAtInventory());
            }
        }

        static public int EquipWeapon(Hero player, Weapon weapon)
        {
            player.inv.EquipWeapon(weapon, player);
            player.SetDamage(weapon.GetDamage());
            return player.damage;
        }

        static public int EquipArmour(Hero player, Weapon weapon)
        {
            player.inv.EquipWeapon(weapon, player);
            player.damage = weapon.GetDamage();
            return player.damage;
        }

        static public int Dice(int from, int to)
        {
            Random r = new Random();
            int diceValue = r.Next(from, to);
            return diceValue;
        }

        static public string QuestionInput(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();
            return answer;
        }

        static public void Continue()
        {
            Console.WriteLine("\nContinue by pressing enter...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
