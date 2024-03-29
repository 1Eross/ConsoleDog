﻿using System;
using System.Collections.Generic;

namespace DungeonSlayer.Units.Players.Perks
{
    class PerksSystem
    {
        public List<Perk> perks;
        public int perksPoint = 0;

        public PerksSystem()
        {
            perks = new List<Perk>();
        }

        public void AddPerk(Perk perk)
        {
            perks.Add(perk);
        }

        public bool CheckPerk(Perk perk)
        {
            return perks.Contains(perk);
        }

        /*public void ShowPerks()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine();
            if (perks.Count == 0)
            {
                Console.WriteLine(" You have no one perk");
            }
            else
            {
                Console.WriteLine(" You have perks:");
                for (int i = 0; i < perks.Count; ++i)
                {
                    Console.WriteLine(" " + perks[i].value + ": " + perks[i].info);
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" [C] - Close shop " + ((perksPoint > 0) ? "[P] - pick new Perk" : "                   "));
            bool commandChose = true;
            while (commandChose)
            {
                char command = Console.ReadKey(true).KeyChar;
                if ((command == 'c') || (command == 'C'))
                {
                    commandChose = false;
                    return;
                }
                if (((command == 'p') || (command == 'P')) && (perksPoint > 0))
                {
                    commandChose = false;
                    int count = 1;
                    for (int i = 0; i < PerksList.perks.Count; ++i)
                    {
                        if (!Gameee.player.perksSystem.CheckPerk(PerksList.perks[i]) && (PerksList.perks[i].level <= Gameee.player.specification.level))
                        {
                            Console.WriteLine(" [" + count + "]: " + PerksList.perks[i].value + " " + PerksList.perks[i].info);
                            ++count;
                        }
                    }
                    bool perkChose = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" ");
                    while (perkChose)
                    {
                        string choseCommand = Console.ReadLine();
                        if (Int32.TryParse(choseCommand, out int perkIndex))
                        {
                            count = 1;
                            for (int i = 0; i < PerksList.perks.Count; ++i)
                            {
                                if (!Gameee.player.perksSystem.CheckPerk(PerksList.perks[i]) && (PerksList.perks[i].level <= Gameee.player.specification.level))
                                {
                                    if (perkIndex == count)
                                    {
                                        --perksPoint;
                                        AddPerk(PerksList.perks[i]);
                                        Console.WriteLine(" Now you have perk: " + PerksList.perks[i].value + " " + PerksList.perks[i].info);
                                        perkChose = false;
                                        Gameee.player.inventory.SetActiveWeapon(Gameee.player.inventory.activeWeapon, PerksList.perks[i].value);
                                        if (PerksList.perks[i].value == EPerkValue.EVASION_PERK)
                                        {
                                            Gameee.player.evasion += 5;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.CRITICAL_PERK)
                                        {
                                            Gameee.player.criticalChance += 4;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.WEAPON_PERK)
                                        {
                                            Gameee.player.attack += 2;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.HP_PERK)
                                        {
                                            Gameee.player.maxHelth += 20;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.MANA_PERK)
                                        {
                                            Gameee.player.maxMana += 20;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.BLOCKING_PERK)
                                        {
                                            Gameee.player.blocking += 3;
                                        }
                                        if (PerksList.perks[i].value == EPerkValue.SPELL_POWER_PERK)
                                        {
                                            Gameee.player.specification.spellPower += 2;
                                        }
                                        break;
                                    }
                                    ++count;
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Incorrect choise");
                        }
                    }
                }
            }
            return;*/
        //}
    }
}
