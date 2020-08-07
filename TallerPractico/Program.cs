using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportSkill OnFire = new SupportSkill("On Fire", "Fire", SupportSkill.EType.AtkUp);
            SupportSkill FireGuardian = new SupportSkill("Fire Guardians", "Fire", SupportSkill.EType.DefUp);
            AttackSkill DragonWitch = new AttackSkill("Dragon Witch", 10, "Fire");

            SupportSkill Charisma = new SupportSkill("Charisma", "Light", SupportSkill.EType.AtkUp);
            SupportSkill Discipline = new SupportSkill("Discipline", "Light", SupportSkill.EType.DefUp);
            AttackSkill FifthForm = new AttackSkill("Fifth Form", 5, "Light");

            SupportSkill DemonGod = new SupportSkill("Demon God", "Dark", SupportSkill.EType.DefUp);
            AttackSkill PrayerCreed = new AttackSkill("Prayer of Creed", 10, "Dark");
            AttackSkill Calamity = new AttackSkill("Calamity", 8, "Dark");

            SupportSkill InstantHeal = new SupportSkill("Intant Heal", "Water", SupportSkill.EType.DefUp);
            AttackSkill WaterGoddess = new AttackSkill("Water Goddess", 5, "Water");
            AttackSkill BeachFlower = new AttackSkill("Beach Flower", 1, "Water");

            SupportSkill EveningBell = new SupportSkill("Evening Bell", "Wind", SupportSkill.EType.DefUp);
            SupportSkill FreezeShield = new SupportSkill("Free Shield", "Wind", SupportSkill.EType.DefUp);
            AttackSkill Sabotage = new AttackSkill("Sabotage", 1, "Wind");

            SupportSkill AlcoholicFruit = new SupportSkill("Alcoholic Fruit", "Earth", SupportSkill.EType.SpdDwn);
            SupportSkill RevenantSuppression = new SupportSkill("Revenant Suppression", "Earth", SupportSkill.EType.SpdDwn);
            AttackSkill BlackBarrel = new AttackSkill("Black Barrel", 10, "Earth");

            List<Skill> 
                FireSkills = new List<Skill> { OnFire, FireGuardian, DragonWitch }, 
                LightSkills = new List<Skill> { Charisma, Discipline, FifthForm }, 
                DarkSkills = new List<Skill> { DemonGod, PrayerCreed, Calamity }, 
                WaterSkills = new List<Skill> { InstantHeal, WaterGoddess, BeachFlower }, 
                WindSkills = new List<Skill> { EveningBell, FreezeShield, Sabotage }, 
                EarthSkills = new List<Skill> { AlcoholicFruit, RevenantSuppression, BlackBarrel };

            Critter Steven = new Critter("StevenF", 90, 100, 25, 15, "Fire", FireSkills);
            Critter Stewart = new Critter("Stewart", 70, 10, 50, 10, "Light", LightSkills);
            Critter Susan = new Critter("Susan", 100, 1, 40, 12, "Dark", DarkSkills);
            Critter Bactery = new Critter("Bactery", 90, 10, 20, 10, "Water", WaterSkills);
            Critter Calvache = new Critter("Calvache", 70, 100, 50, 19, "Wind", WindSkills);
            Critter Rockin = new Critter("Rockin", 50, 10, 25, 20, "Earth", EarthSkills);

            List<Critter> critters = new List<Critter> { Steven, Stewart, Susan, Bactery, Calvache, Rockin };
            int critterSelected;
            Random dice = new Random();

            List<Critter> cPlayer1 = new List<Critter>();
            List<Critter> cPlayer2 = new List<Critter>();

            for (int i = 0; i < 3; i++)
            {
                critterSelected = dice.Next(0, 5);
                cPlayer1.Add(critters[critterSelected]);
            }

            for (int i = 0; i < 3; i++)
            {
                critterSelected = dice.Next(0, 5);
                cPlayer2.Add(critters[critterSelected]);
            }

            Console.WriteLine("Critters of Player 1:");
            foreach (Critter X in cPlayer1)
            {
                Console.WriteLine(X.Name);
            }

            Console.WriteLine("\n" + "Critters of Player 2:");
            foreach (Critter X in cPlayer2)
            {
                Console.WriteLine(X.Name);
            }
        }
    }
}
