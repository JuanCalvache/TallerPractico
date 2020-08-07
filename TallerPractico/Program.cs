using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Program
    {
        static void Main(string[] args)
        {
            //Construir las habilidades de los Critters
            Skill OnFire = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.AtkUp, "On Fire", 0, "Fire");
            Skill FireGuardian = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.DefUp, "Fire Guardians", 0, "Fire");
            Skill DragonWitch = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Dragon Witch", 10, "Fire");

            Skill Charisma = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.AtkUp, "Charisma", 0, "Light");
            Skill Discipline = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.DefUp, "Discipline", 0, "Light");
            Skill FifthForm = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Fifth Form", 5, "Light");

            Skill DemonGod = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.DefUp, "Demon God", 0, "Dark");
            Skill PrayerCreed = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Prayer of Creed", 10, "Dark");
            Skill Calamity = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Calamity", 8, "Dark");

            Skill InstantHeal = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.DefUp, "Intant Heal", 0, "Water");
            Skill WaterGoddess = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Water Goddess", 5, "Water");
            Skill BeachFlower = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Beach Flower", 1, "Water");

            Skill EveningBell = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.DefUp, "Evening Bell", 0,"Wind");
            Skill FreezeShield = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.DefUp, "Freeze Shield", 0,"Wind");
            Skill Sabotage = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Sabotage", 10, "Wind");

            Skill AlcoholicFruit = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.SpdDwn, "Alcoholic Fruit", 0, "Earth");
            Skill RevenantSuppression = new Skill(Skill.EType.SupportSkill, Skill.ESubtype.SpdDwn, "Revenant Suppression", 0, "Earth");
            Skill BlackBarrel = new Skill(Skill.EType.AttackSkill, Skill.ESubtype.None, "Black Barrel", 10, "Earth");

            //Crear listas de habilidades para cada Critter
            List<Skill> 
                FireSkills = new List<Skill> { OnFire, FireGuardian, DragonWitch }, 
                LightSkills = new List<Skill> { Charisma, Discipline, FifthForm }, 
                DarkSkills = new List<Skill> { DemonGod, PrayerCreed, Calamity }, 
                WaterSkills = new List<Skill> { InstantHeal, WaterGoddess, BeachFlower }, 
                WindSkills = new List<Skill> { EveningBell, FreezeShield, Sabotage }, 
                EarthSkills = new List<Skill> { AlcoholicFruit, RevenantSuppression, BlackBarrel };

            //Construir los critters
            Critter Steven = new Critter("StevenF", 90, 100, 25, 160, "Fire", FireSkills);
            Critter Stewart = new Critter("Stewart", 70, 10, 50, 90, "Light", LightSkills);
            Critter Susan = new Critter("Susan", 100, 50, 40, 100, "Dark", DarkSkills);
            Critter Bactery = new Critter("Bactery", 90, 10, 20, 120, "Water", WaterSkills);
            Critter Calvache = new Critter("Calvache", 70, 100, 40, 300, "Wind", WindSkills);
            Critter Rockin = new Critter("Rockin", 50, 10, 25, 90, "Earth", EarthSkills);

            //Crear una lista con los critters disponibles - Banco de Critters
            List<Critter> critters = new List<Critter> { Steven, Stewart, Susan, Bactery, Calvache, Rockin };
            int critterSelected;
            Random dice = new Random();

            //Construir dos listas de critters, seleccionados aleatoriamente para cada jugador. (3 Para cada Uno)
            List<Critter> cPlayer1 = new List<Critter>();
            List<Critter> cPlayer2 = new List<Critter>();

            //Llenamos las listas de Critters para los jugadores
            for (int i = 0; i < 3; i++)
            {
                critterSelected = dice.Next(0, 6);
                cPlayer1.Add(critters[critterSelected]);
            }

            for (int i = 0; i < 3; i++)
            {
                critterSelected = dice.Next(0, 6);
                cPlayer2.Add(critters[critterSelected]);
            }

            //Incia el Juego
            int ID = 0;
            Console.WriteLine("[Death Duel with Critters]" + "\n");

            //Construimos a los jugadores con su respectiva lista de Critters
            Player player_1 = new Player(cPlayer1);
            Player player_2 = new Player(cPlayer2);

            //Variables de Interfaz
            Console.WriteLine("\n" + "Start Duel:");
            bool duelFinish = false;
            int turnCount = 0;
            int critterSelecterP1 = 0, critterSelecterP2 = 0, skillSelecterP1 = 0, skillSelecterP2 = 0;
            float damageInflicted = 0, speedReduce = 0, buffBonus = 0;

            //GameController
            while (!duelFinish)
            {
                //Contamos los turnos
                turnCount += 1;
                Console.WriteLine("\n" + "Turn {0}:", turnCount);

                //Escribimos los critters VIVOS del enemigo
                ID = 0;
                Console.WriteLine("Enemy's Critters:");
                foreach (Critter X in cPlayer2)
                {
                    ID += 1;
                    Console.WriteLine
                        ("\t" + ID + ". " + X.Name + "\tHP: " + X.CurrentHp + " Afinity: " + X.Afinity +
                        "\t[Attack: " + X.CurrentAttack + ", Defense: " + X.CurrentDefense + ", Speed: " + X.CurrentSpeed + "]");
                }

                //Escribimos los critters VIVOS del Jugador
                ID = 0;
                Console.WriteLine("\n" + "Your Critters:");
                foreach (Critter X in cPlayer1)
                {
                    ID += 1;
                    Console.WriteLine
                       ("\t" + ID + ". " + X.Name + "\tHP: " + X.CurrentHp + " Afinity: " + X.Afinity +
                        "\t[Attack: " + X.CurrentAttack + ", Defense: " + X.CurrentDefense + ", Speed: " + X.CurrentSpeed + "]");
                }

                //El enemigo elige con que Critter atacar en cada turno, solo elige los que tenga en su lista
                critterSelecterP2 = dice.Next(player_2.MyCritters.Count);
                Console.WriteLine("Your enemy has choosen: [{0}]", player_2.MyCritters[critterSelecterP2].Name);

                //El jugador escoge que Critter usar, ingresando el numero del Critter.
                Console.WriteLine("Select Your Critter, write the critter ID:");
                critterSelecterP1 = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("{0} I choose you!!", player_1.MyCritters[critterSelecterP1].Name);

                //Cuando el Critter del Jugador tiene una velocidad igual o mayor que la del enemigo
                if (player_1.MyCritters[critterSelecterP1].CurrentSpeed >= player_2.MyCritters[critterSelecterP2].CurrentSpeed)
                {
                    ID = 0;
                    //Selecciona una Habilidad: [1, 2 o 3]
                    Console.WriteLine("\n" + "Select a Skill:");
                    //Muestra una lista con las habilidades.
                    foreach (Skill X in player_1.MyCritters[critterSelecterP1].Moveset)
                    {
                        ID += 1;
                        Console.WriteLine
                            ("\t" + ID + ". " + X.Name + "\t" + "Power: " + X.Power +
                            "\tType: " + X.Type + " SubType: " + X.Subtype);
                    }
                    skillSelecterP1 = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine
                        ("You has choosen {0}", player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Name);

                    //Verifica que el Critter aliado no este muerto.
                    if (player_1.MyCritters[critterSelecterP1].CurrentHp > 0)
                    {
                        //Cuando se escoge una habilidad de tipo Ataque
                        if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Type.Equals(Skill.EType.AttackSkill))
                        {
                            //Calcula el daño
                            damageInflicted =
                                player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate
                                (player_2.MyCritters[critterSelecterP2], player_1.MyCritters[critterSelecterP1].CurrentAttack);
                            Console.WriteLine(damageInflicted);

                            //Reduce la vida del enemigo
                            player_2.MyCritters[critterSelecterP2].CurrentHp = player_2.MyCritters[critterSelecterP2].CurrentHp - damageInflicted;

                            //Vizualizamos la vida del enemigo.
                            Console.WriteLine("Your enemy has {0} / {1} HP", player_2.MyCritters[critterSelecterP2].CurrentHp, player_2.MyCritters[critterSelecterP2].HP);                           
                        }
                        //Cuando escoge una habilidad de tipo Soporte, y es de Reduccion de Velocidad
                        else if(player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Type.Equals(Skill.EType.SupportSkill)
                            && player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Subtype.Equals(Skill.ESubtype.SpdDwn))
                        {
                            //Calcula el porcentaje
                            speedReduce =
                                player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate
                                (player_2.MyCritters[critterSelecterP2]);

                            //Reduce la velocidad del critter enemigo.
                            player_2.MyCritters[critterSelecterP2].CurrentSpeed -= speedReduce * player_2.MyCritters[critterSelecterP2].BaseSpeed;
                            Console.WriteLine("The enemy has penalized with {0}%, {1} SpeedPoints", speedReduce * 100, player_2.MyCritters[critterSelecterP2].CurrentSpeed);
                            Console.WriteLine("Remaining uses: " + (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillLimit - player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillCount));
                        }
                        //Cuando escoge una habilidad de tipo Soporte, y NO es de Reduccion de Velocidad
                        else
                        {
                            //Puede...
                            if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Subtype.Equals(Skill.ESubtype.AtkUp))
                            {
                                //Aumentar el daño...
                                buffBonus =
                                    player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate();

                                player_1.MyCritters[critterSelecterP1].CurrentAttack += buffBonus;
                                Console.WriteLine("Attack incresed to {0} ({1})", player_1.MyCritters[critterSelecterP1].CurrentAttack, player_1.MyCritters[critterSelecterP1].BaseAttack);
                                Console.WriteLine("Remaining uses: " + (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillLimit - player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillCount));
                            }
                            else if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Subtype.Equals(Skill.ESubtype.DefUp))
                            {
                                //Aumentar la defensa...
                                buffBonus =
                                    player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate();

                                player_1.MyCritters[critterSelecterP1].CurrentDefense += buffBonus;
                                Console.WriteLine("Defense incresed to {0} ({1})", player_1.MyCritters[critterSelecterP1].CurrentDefense, player_1.MyCritters[critterSelecterP1].BaseDefense);
                                Console.WriteLine("Remaining uses: " + (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillLimit - player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillCount));
                            }
                        }
                    }

                    //El enemigo elige una habilidad al azar
                    skillSelecterP2 = dice.Next(3);
                    Console.WriteLine
                        ("\n" + "{0} is using {1}", player_2.MyCritters[critterSelecterP2].Name, player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Name);
                    //Se asegura que el enemigo no este muerto.
                    if (player_2.MyCritters[critterSelecterP2].CurrentHp > 0)
                    {
                        //Sigue la misma logica del Jugador > Verificar si es ataque o Soporte, y que tipo de Soporte.
                        if (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Type.Equals(Skill.EType.AttackSkill))
                        {
                            damageInflicted =
                                player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate
                                (player_1.MyCritters[critterSelecterP1], player_2.MyCritters[critterSelecterP2].CurrentAttack);
                            Console.WriteLine(damageInflicted);

                            player_1.MyCritters[critterSelecterP1].CurrentHp = player_1.MyCritters[critterSelecterP1].CurrentHp - damageInflicted;

                            Console.WriteLine("Your critter has {0} / {1} HP", player_1.MyCritters[critterSelecterP1].CurrentHp, player_1.MyCritters[critterSelecterP1].HP);
                        }
                        else if (player_2.MyCritters[critterSelecterP1].Moveset[skillSelecterP2].Type.Equals(Skill.EType.SupportSkill)
                            && player_2.MyCritters[critterSelecterP1].Moveset[skillSelecterP2].Subtype.Equals(Skill.ESubtype.SpdDwn))
                        {
                            speedReduce =
                                player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate
                                (player_1.MyCritters[critterSelecterP1]);

                            player_1.MyCritters[critterSelecterP1].CurrentSpeed -= speedReduce * player_1.MyCritters[critterSelecterP1].BaseSpeed;
                            Console.WriteLine("The enemy has penalized with {0}%, {1} SpeedPoints", speedReduce * 100, player_1.MyCritters[critterSelecterP1].CurrentSpeed);
                            Console.WriteLine("Remaining uses: " + (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillLimit - player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillCount));
                        }
                        else
                        {
                            if (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Subtype.Equals(Skill.ESubtype.AtkUp))
                            {
                                buffBonus =
                                    player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate();

                                player_2.MyCritters[critterSelecterP2].CurrentAttack += buffBonus;
                                Console.WriteLine("Attack incresed to {0} ({1})", player_2.MyCritters[critterSelecterP2].CurrentAttack, player_2.MyCritters[critterSelecterP2].BaseAttack);
                                Console.WriteLine("Remaining uses: " + (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillLimit - player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillCount));
                            }
                            else if (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Subtype.Equals(Skill.ESubtype.DefUp))
                            {
                                buffBonus =
                                    player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate();

                                player_2.MyCritters[critterSelecterP2].CurrentDefense += buffBonus;
                                Console.WriteLine("Defense incresed to {0} ({1})", player_2.MyCritters[critterSelecterP2].CurrentDefense, player_2.MyCritters[critterSelecterP2].BaseDefense);
                                Console.WriteLine("Remaining uses: " + (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillLimit - player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillCount));
                            }
                        }
                    }
                }
                //Cuando es el enemigo quien tiene mas velocidad.
                else
                {
                    //El enemigo selecciona primero una habilidad al azar
                    ID = 0;
                    skillSelecterP2 = dice.Next(3);
                    Console.WriteLine
                        ("\n" + "{0} is using {1}", player_2.MyCritters[critterSelecterP2].Name, player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Name);

                    //Se asegura que el enemigo no este muerto.
                    if (player_2.MyCritters[critterSelecterP2].CurrentHp > 0)
                    {
                        //Sigue la misma logica del Jugador > Verificar si es ataque o Soporte, y que tipo de Soporte.
                        if (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Type.Equals(Skill.EType.AttackSkill))
                        {
                            damageInflicted =
                                player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate
                                (player_1.MyCritters[critterSelecterP1], player_2.MyCritters[critterSelecterP2].CurrentAttack);
                            Console.WriteLine(damageInflicted);

                            player_1.MyCritters[critterSelecterP1].CurrentHp = player_1.MyCritters[critterSelecterP1].CurrentHp - damageInflicted;

                            Console.WriteLine("Your critter has {0} / {1} HP", player_1.MyCritters[critterSelecterP1].CurrentHp, player_1.MyCritters[critterSelecterP1].HP);
                        }
                        else if (player_2.MyCritters[critterSelecterP1].Moveset[skillSelecterP2].Type.Equals(Skill.EType.SupportSkill)
                            && player_2.MyCritters[critterSelecterP1].Moveset[skillSelecterP2].Subtype.Equals(Skill.ESubtype.SpdDwn))
                        {
                            speedReduce =
                                player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate
                                (player_1.MyCritters[critterSelecterP1]);

                            player_1.MyCritters[critterSelecterP1].CurrentSpeed -= speedReduce * player_1.MyCritters[critterSelecterP1].BaseSpeed;
                            Console.WriteLine("The enemy has penalized with {0}%, {1} SpeedPoints", speedReduce * 100, player_1.MyCritters[critterSelecterP1].CurrentSpeed);
                            Console.WriteLine("Remaining uses: " + (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillLimit - player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillCount));
                        }
                        else
                        {
                            if (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Subtype.Equals(Skill.ESubtype.AtkUp))
                            {
                                buffBonus =
                                    player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate();

                                player_2.MyCritters[critterSelecterP2].CurrentAttack += buffBonus;
                                Console.WriteLine("Attack incresed to {0} ({1})", player_2.MyCritters[critterSelecterP2].CurrentAttack, player_2.MyCritters[critterSelecterP2].BaseAttack);
                                Console.WriteLine("Remaining uses: " + (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillLimit - player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillCount));
                            }
                            else if (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Subtype.Equals(Skill.ESubtype.DefUp))
                            {
                                buffBonus =
                                    player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].Calculate();

                                player_2.MyCritters[critterSelecterP2].CurrentDefense += buffBonus;
                                Console.WriteLine("Defense incresed to {0} ({1})", player_2.MyCritters[critterSelecterP2].CurrentDefense, player_2.MyCritters[critterSelecterP2].BaseDefense);
                                Console.WriteLine("Remaining uses: " + (player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillLimit - player_2.MyCritters[critterSelecterP2].Moveset[skillSelecterP2].SkillCount));
                            }
                        }
                    }

                    //Procede como lo anterior pero despues de que el enemigo lo hace: Escoger una Habilidad
                    Console.WriteLine("\n" + "Select a Skill:");
                    foreach (Skill X in player_1.MyCritters[critterSelecterP1].Moveset)
                    {
                        ID += 1;
                        Console.WriteLine("\t" + ID + ". " + X.Name);
                    }
                    skillSelecterP1 = int.Parse(Console.ReadLine()) - 1;
                    Console.WriteLine
                        ("You has choosen {0}", player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Name);

                    //Verifica que el Critter aliado no halla muerto.
                    if (player_1.MyCritters[critterSelecterP1].CurrentHp > 0)
                    {
                        //Sigue la misma logica de antes > Verificar si es ataque o Soporte, y que tipo de Soporte.
                        if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Type.Equals(Skill.EType.AttackSkill))
                        {
                            damageInflicted =
                                player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate
                                (player_2.MyCritters[critterSelecterP2], player_1.MyCritters[critterSelecterP1].CurrentAttack);
                            Console.WriteLine(damageInflicted);

                            player_2.MyCritters[critterSelecterP2].CurrentHp = player_2.MyCritters[critterSelecterP2].CurrentHp - damageInflicted;

                            Console.WriteLine("Your enemy has {0} / {1} HP", player_2.MyCritters[critterSelecterP2].CurrentHp, player_2.MyCritters[critterSelecterP2].HP);
                        }
                        else if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Type.Equals(Skill.EType.SupportSkill)
                            && player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Subtype.Equals(Skill.ESubtype.SpdDwn))
                        {
                            speedReduce =
                                player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate
                                (player_2.MyCritters[critterSelecterP2]);

                            player_2.MyCritters[critterSelecterP2].CurrentSpeed -= speedReduce * player_2.MyCritters[critterSelecterP2].BaseSpeed;
                            Console.WriteLine("The enemy has penalized with {0}%, {1} SpeedPoints", speedReduce * 100, player_2.MyCritters[critterSelecterP2].CurrentSpeed);
                            Console.WriteLine("Remaining uses: " + (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillLimit - player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillCount));
                        }
                        else
                        {
                            if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Subtype.Equals(Skill.ESubtype.AtkUp))
                            {
                                buffBonus =
                                    player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate();

                                player_1.MyCritters[critterSelecterP1].CurrentAttack += buffBonus;
                                Console.WriteLine("Attack incresed to {0} ({1})", player_1.MyCritters[critterSelecterP1].CurrentAttack, player_1.MyCritters[critterSelecterP1].BaseAttack);
                                Console.WriteLine("Remaining uses: " + (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillLimit - player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillCount));
                            }
                            else if (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Subtype.Equals(Skill.ESubtype.DefUp))
                            {
                                buffBonus =
                                    player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].Calculate();

                                player_1.MyCritters[critterSelecterP1].CurrentDefense += buffBonus;
                                Console.WriteLine("Defense incresed to {0} ({1})", player_1.MyCritters[critterSelecterP1].CurrentDefense, player_1.MyCritters[critterSelecterP1].BaseDefense);
                                Console.WriteLine("Remaining uses: " + (player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillLimit - player_1.MyCritters[critterSelecterP1].Moveset[skillSelecterP1].SkillCount));
                            }
                        }
                    }
                }

                //Cuando un critter del jugador muerte, es transferido al enemigo
                if(player_1.MyCritters[critterSelecterP1].CurrentHp <= 0)
                {
                    player_2.ObtainCritter(player_1.LoseCritter(player_1.MyCritters[critterSelecterP1]));
                }
                //Cuando un critter del enemigo muere, es trasnferido al jugador
                else if(player_2.MyCritters[critterSelecterP2].CurrentHp <= 0)
                {
                    player_1.ObtainCritter(player_2.LoseCritter(player_2.MyCritters[critterSelecterP2]));
                }

                //Cuando uno de los dos se queda sin critters, termina el juego.
                if (player_1.MyCritters.Count == 0 || player_2.MyCritters.Count == 0)
                {
                    duelFinish = true;
                    Console.WriteLine("Game Finished...");
                }
            }
        }
    }
}
