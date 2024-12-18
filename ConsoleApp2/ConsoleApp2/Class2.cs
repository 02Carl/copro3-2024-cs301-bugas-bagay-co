using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace characterCreation
{


    public class inputshow
    {
        //exceptions
        public string Name(string name)
        {
            SqlConnection SqlConnect;
            string DatabaseConnectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ADMIN\SOURCE\REPOS\CONSOLEAPP2\CONSOLEAPP2\DATABASE1.MDF; Integrated Security = True;";

            SqlConnect = new SqlConnection(DatabaseConnectstring);
            if (!Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
            {
                throw new ArgumentException("The name can contain only letters and numbers.");
            }
            else if (name.Length < 6 || name.Length > 16)
            {
                throw new ArgumentException("The name must be between 6 and 16 characters.");
            }
            else
            {
                // Check for duplicate names in the database
                using (SqlConnect = new SqlConnection(DatabaseConnectstring))
                {
                    SqlConnect.Open();
                    string selectQuery = "SELECT Name FROM dbo.CharacterTable";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, SqlConnect);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        string existingName = reader.GetString(0);
                        if (existingName.ToLower() == name.ToLower())
                        {
                            reader.Close();
                            throw new ArgumentException("The name is already taken! Please create a new name.");
                        }
                    }
                    reader.Close();
                }
                return name;
            }
        }
        public int input(int number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException("Negative number or 0 is not allowed, Please try again");
            }
            else if (number > 5)
            {
                throw new ArgumentOutOfRangeException("Numbers exceeding 5 is not allowed, Please try again");
            }
            return number;
        }
        public int gendercheck(int number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException("Negative number or 0 is not allowed, Please try again");
            }
            else if (number > 2)
            {
                throw new ArgumentOutOfRangeException("Numbers exceeding 2 is not allowed, Please try again");
            }
            return number;
        }
        public int add(int a, int b, int c)
        {
            return a + b + c;
        }

        public int add(int a, int b, int c, int d, int e)
        {
            return a + b + c + d + e;
        }
        public void Start()
        {
            while (true)
            {
                try
                {
                    string playerName, confirmation;
                    int gender, hairStyle, hairColor, eyeColor, race, bodyType, skinTone, spaceAgency, spaceship, headGear, armGear, torsoGear, legGear, Tools, accessories, companion, destination;

                    bool colortint = false;
                    Console.Clear();
                    Console.Write("\x1b[3J");
                    Console.WriteLine("________________________________________________");
                    Console.WriteLine("|        The Universe's Cosmic Voyagers        |");
                    Console.WriteLine("|______________________________________________|");
                    Console.WriteLine("|              [1] NEW GAME                    |");
                    Console.WriteLine("|              [2] Load Game                   |");
                    Console.WriteLine("|              [3] Campaign Mode               |");
                    Console.WriteLine("|              [4] CREDITS                     |");
                    Console.WriteLine("|              [5] Exit                        |");
                    Console.WriteLine("|______________________________________________|");

                    Console.Write("                  > ");
                    int UserChoice = input(Convert.ToInt32(Console.ReadLine()));

                    if (UserChoice == 1)
                    {
                        Console.Clear();

                        colors color = new colors();

                        Console.WriteLine("===========================================================================");
                        Console.WriteLine("Create your Character!");
                        Console.WriteLine("===========================================================================");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("1. Enter player name (16 characters, no special characters): ");
                                Console.Write("===========================================================================\n> ");
                                playerName = Name(Console.ReadLine());

                                break;

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("2. Gender\n");
                                Console.WriteLine("[1] Male");
                                Console.WriteLine("[2] Female");
                                Console.Write("=========================================================================== \n> ");
                                gender = gendercheck(int.Parse(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }

                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("3. Hair Style\n");
                                Console.WriteLine("[1] Curly");
                                Console.WriteLine("[2] Flat Top");
                                Console.WriteLine("[3] Buzz Cut");
                                Console.WriteLine("[4] Pompadour");
                                Console.WriteLine("[5] Caesar ");
                                Console.Write("===========================================================================\n> ");
                                hairStyle = input(int.Parse(Console.ReadLine()));
                                break;

                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("4. Hair Color\n");
                                Console.WriteLine("[1] Blonde");
                                Console.WriteLine("[2] Auburn");
                                Console.WriteLine("[3] Black");
                                Console.WriteLine("[4] Brown");
                                Console.WriteLine("[5] Red");
                                Console.Write("===========================================================================\n> ");
                                hairColor = input(int.Parse(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("5. Eye Color\n");
                                Console.WriteLine("[1] Black");
                                Console.WriteLine("[2] Crystal White");
                                Console.WriteLine("[3] Azure");
                                Console.WriteLine("[4] Amber");
                                Console.WriteLine("[5] Jade");
                                Console.Write("===========================================================================\n> ");
                                eyeColor = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("6. Race\n");
                                Console.WriteLine("[1] Human\nPros: Adaptable, versatile, and strong.\nCons: Physically limited, susceptible to disease.");
                                Console.WriteLine("[2] Chiss\nPros: Highly intelligent, skilled strategists.\nCons: Can be cold and calculating.");
                                Console.WriteLine("[3] Togruta\nPros: Highly intuitive, skilled in combat.\nCons: Prone to impulsive decisions.");
                                Console.WriteLine("[4] Twi’lek\nPros: Adaptable, agile.\nCons: Emotional, susceptible to manipulation.");
                                Console.WriteLine("[5] Zabrak\nPros: Strong, resilient.\nCons: Impulsive, often misunderstood.");
                                Console.Write("===========================================================================\n> ");
                                race = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("7. Body Type\n");
                                Console.WriteLine("[1] Slim\nPros: Decent at anything.\nCons: Jack of all trades.");
                                Console.WriteLine("[2] Stocky\nPros: Strong, sturdy.\nCons: Heavy and slow.");
                                Console.WriteLine("[3] Petite\nPros: Nimble and flexible.\nCons: Weak endurance.");
                                Console.WriteLine("[4] Round\nPros: Enduring, powerful.\nCons: Low stamina.");
                                Console.WriteLine("[5] Lanky\nPros: High range contact.\nCons: Limited agility.");
                                Console.Write("===========================================================================\n> ");
                                bodyType = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("8. Skin Tone\n");
                                Console.WriteLine("[1] Porcelain");
                                Console.WriteLine("[2] Ivory");
                                Console.WriteLine("[3] Natural");
                                Console.WriteLine("[4] Golden");
                                Console.WriteLine("[5] Chestnut");
                                Console.Write("===========================================================================\n> ");
                                skinTone = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        ICharacterStat characterStats = new Stats();
                        int strength = 0, dexterity = 0, intelligence = 0, endurance = 0, luck = 0;
                        int totalStat = 0;

                        bool Condition = true;
                        do
                        {
                            try
                            {
                                Console.WriteLine("9. Enter Character Stats (10 points to distribute, max 3 per stat)\n Stats: Strength, Dexterity, Intelligence, Endurance, Luck");
                                Console.Write("\nStrength (0-3): ");
                                strength = int.Parse(Console.ReadLine());

                                Console.Write("\nDexterity (0-3): ");
                                dexterity = int.Parse(Console.ReadLine());

                                Console.Write("\nIntelligence (0-3): ");
                                intelligence = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Curent Stat: {add(strength, dexterity, intelligence)}");

                                Console.Write("\nEndurance (0-3): ");
                                endurance = int.Parse(Console.ReadLine());

                                Console.Write("\nLuck (0-3): ");
                                luck = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Curent Stat: {add(strength, dexterity, intelligence, endurance, luck)}");
                                

                                totalStat = strength + dexterity + intelligence + endurance + luck;
                                

                                if (strength < 0 || strength > 3 || dexterity < 0 || dexterity > 3 || intelligence < 0 || intelligence > 3 || endurance < 0 || endurance > 3 || luck < 0 || luck > 3)
                                {
                                    Console.WriteLine("\nEach stat must be between 0 and 3. Please try again.");
                                }
                                else if (totalStat > 10)
                                {
                                    Console.WriteLine("\nThe total stat points must not exceed 10. Please try again.");
                                }
                                else
                                {
                                    
                                    Console.WriteLine($"\nYou have entered the following stats:");
                                    Console.WriteLine($"Strength    : {strength}");
                                    Console.WriteLine($"Dexterity   : {dexterity}");
                                    Console.WriteLine($"Intelligence: {intelligence}");
                                    Console.WriteLine($"Endurance   : {endurance}");
                                    Console.WriteLine($"Luck        : {luck}");
                                    Console.WriteLine($"Total Points: {totalStat}/10");
                                    Console.WriteLine("===========================================================================");
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.Write("Accept these stats? (yes/no): ");
                                            confirmation = Console.ReadLine()?.Trim().ToLower();


                                            if (confirmation == "yes")
                                            {
                                                characterStats.totalStat(strength, dexterity, intelligence, endurance, luck);
                                                
                                                Condition = false;
                                                break;
                                            }
                                            else if (confirmation == "no")
                                            {
                                                Console.WriteLine("Re-enter your stats.");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("invalid input try again");
                                                Console.WriteLine("===========================================================================");
                                            }

                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            Console.WriteLine($"Error: Enter a yes or no (y/n)");
                                            Console.WriteLine("===========================================================================");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Error: {ex.Message}");
                                            Console.WriteLine("===========================================================================");
                                        }
                                    }
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        } while (Condition == true);
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        while (true)
                        {
                            try
                            {
                                
                                Console.WriteLine("10. Space Agency\n");
                                Console.WriteLine("[1] NASA\nPros: Extensive experience.\nCons: Risk-averse.");
                                Console.WriteLine("[2] ISRO\nPros: Cost-effective.\nCons: Limited resources.");
                                Console.WriteLine("[3] CNSA\nPros: Ambitious goals.\nCons: Less transparent.");
                                Console.WriteLine("[4] ESA\nPros: Collaborative approach.\nCons: Bureaucratic.");
                                Console.WriteLine("[5] DLR\nPros: Strong research.\nCons: Relies on partnerships.");
                                Console.Write("===========================================================================\n> ");
                                spaceAgency = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }

                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("11. Spaceship\n");
                                Console.WriteLine("[1] Saturn-V\nPros: Powerful, proven, and historically significant. \nCons: Large, expensive, and limited payload capacity.");
                                Console.WriteLine("[2] V-2 \nPros: Historic, relatively simple design, and can be adapted for various missions. \nCons: Limited payload capacity, short range, and outdated technology.");
                                Console.WriteLine("[3] Starship\nPros: Reusable, large payload capacity, and potential for interplanetary travel. \nCons: Still in development, unproven technology, and potential safety risks.");
                                Console.WriteLine("[4] Delta IV\nPros: Reliable, versatile, and capable of launching a wide range of payloads.\nCons: Expensive, limited payload capacity compared to larger rockets.");
                                Console.WriteLine("[5] Ariane\nPros: Powerful, reliable, and has a strong track record of successful launches.\nCons: Expensive, complex, and limited payload capacity compared to newer rockets.");
                                Console.Write("===========================================================================\n> ");
                                spaceship = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("12. Space suit customization Head\n");
                                Console.WriteLine("[1] A-6871 Specs:\nToughness+: Enhanced durability against micrometeoroids and radiation.\nVisibility+: Wide-angle visor for optimal situational awareness.\nWeight: Medium");
                                Console.WriteLine("[2] S-3215 Specs:\nAerodynamics+: Streamlined design for improved maneuverability in zero-gravity.\nHeat Dissipation+: Advanced cooling system for extended missions.\nWeight: Lightweight.");
                                Console.WriteLine("[3] AZ-4711 Specs:\nTech Integration+: Real-time data overlay and mission critical information.\nNight Vision+: Infrared capabilities for low-light and dark environments.\nWeight: Heavy");
                                Console.WriteLine("[4] O-9381 Specs:\nProtection+: Reinforced shielding against extreme temperature fluctuations.\nSelf-Repair+: Nanobot technology for rapid damage repair.\nWeight: Heavy");
                                Console.WriteLine("[5] U-2489 Specs:\nCompatibility+: Interchangeable with various torso systems.\nModular Design+: Customizable for specific mission requirements.\nWeight: Medium");
                                Console.Write("===========================================================================\n> ");
                                headGear = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("13. Space suit customization Arms\n");
                                Console.WriteLine("[1] A-6871 Specs:\nToughness+: Enhanced durability against micrometeoroids and radiation.\nVisibility+: Wide-angle visor for optimal situational awareness.\nWeight: Medium");
                                Console.WriteLine("[2] S-3215 Specs:\nAerodynamics+: Streamlined design for improved maneuverability in zero-gravity.\nHeat Dissipation+: Advanced cooling system for extended missions.\nWeight: Lightweight.");
                                Console.WriteLine("[3] AZ-4711 Specs:\nTech Integration+: Real-time data overlay and mission critical information.\nNight Vision+: Infrared capabilities for low-light and dark environments.\nWeight: Heavy");
                                Console.WriteLine("[4] O-9381 Specs:\nProtection+: Reinforced shielding against extreme temperature fluctuations.\nSelf-Repair+: Nanobot technology for rapid damage repair.\nWeight: Heavy");
                                Console.WriteLine("[5] U-2489 Specs:\nCompatibility+: Interchangeable with various torso systems.\nModular Design+: Customizable for specific mission requirements.\nWeight: Medium");
                                Console.Write("===========================================================================\n> ");
                                armGear = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("14. Space suit customization Torso\n");
                                Console.WriteLine("[1] A-6871 Specs:\nToughness+: Enhanced durability against micrometeoroids and radiation.\nVisibility+: Wide-angle visor for optimal situational awareness.\nWeight: Medium");
                                Console.WriteLine("[2] S-3215 Specs:\nAerodynamics+: Streamlined design for improved maneuverability in zero-gravity.\nHeat Dissipation+: Advanced cooling system for extended missions.\nWeight: Lightweight.");
                                Console.WriteLine("[3] AZ-4711 Specs:\nTech Integration+: Real-time data overlay and mission critical information.\nNight Vision+: Infrared capabilities for low-light and dark environments.\nWeight: Heavy");
                                Console.WriteLine("[4] O-9381 Specs:\nProtection+: Reinforced shielding against extreme temperature fluctuations.\nSelf-Repair+: Nanobot technology for rapid damage repair.\nWeight: Heavy");
                                Console.WriteLine("[5] U-2489 Specs:\nCompatibility+: Interchangeable with various torso systems.\nModular Design+: Customizable for specific mission requirements.\nWeight: Medium");
                                Console.Write("===========================================================================\n> ");
                                torsoGear = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("15. Space suit customization Legs\n");
                                Console.WriteLine("[1] A-6871 Specs:\nToughness+: Enhanced durability against micrometeoroids and radiation.\nVisibility+: Wide-angle visor for optimal situational awareness.\nWeight: Medium");
                                Console.WriteLine("[2] S-3215 Specs:\nAerodynamics+: Streamlined design for improved maneuverability in zero-gravity.\nHeat Dissipation+: Advanced cooling system for extended missions.\nWeight: Lightweight.");
                                Console.WriteLine("[3] AZ-4711 Specs:\nTech Integration+: Real-time data overlay and mission critical information.\nNight Vision+: Infrared capabilities for low-light and dark environments.\nWeight: Heavy");
                                Console.WriteLine("[4] O-9381 Specs:\nProtection+: Reinforced shielding against extreme temperature fluctuations.\nSelf-Repair+: Nanobot technology for rapid damage repair.\nWeight: Heavy");
                                Console.WriteLine("[5] U-2489 Specs:\nCompatibility+: Interchangeable with various torso systems.\nModular Design+: Customizable for specific mission requirements.\nWeight: Medium");
                                Console.Write("===========================================================================\n> ");
                                legGear = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("16. Tools\n");
                                Console.WriteLine("[1] Laser Gun\nShoots out highly concentrated power that is capable of erasing anything.");
                                Console.WriteLine("[2] Lightsaber\nCapable of producing a blade of concentrated energy that can slice anything.");
                                Console.WriteLine("[3] Multi-tool\nThe ultimate combination of pickaxe, axe, and shovels.");
                                Console.WriteLine("[4] Healing Kits\nMedical supplies to restore health and stamina.");
                                Console.WriteLine("[5] Detonators\nRemote-controlled explosives for precise demolition.");
                                Console.Write("===========================================================================\n> ");
                                Tools = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        bool addColorTint = color.AskColortint();

                        colortint = color.confirmation();
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("18. Accessories\n");
                                Console.WriteLine("[1] Stealth Bracelet\nSignal dampeners, cloaking devices, thermal suppressors.");
                                Console.WriteLine("[2] Star Map\nAn ancient celestial map, possibly alien in origin, detailing distant star systems.");
                                Console.WriteLine("[3] Resource Censor\nDetects possible resources in the vicinity.");
                                Console.WriteLine("[4] Nanomachine Synthesia\nAdvanced recollection of the area before its current state.");
                                Console.WriteLine("[5] Incarcerated Weaver\nDetection of imminent threat.");
                                Console.Write("===========================================================================\n> ");
                                accessories = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("19. Companion\n");
                                Console.WriteLine("[1] Droid\nPros: Reliable, efficient, and can handle complex tasks.\nCons: Lacks emotional intelligence and social skills.");
                                Console.WriteLine("[2] Giggs\nPros: Strong, loyal, and a skilled fighter.\nCons: Can be impulsive and prone to aggression.");
                                Console.WriteLine("[3] Iguana\nPros: Excellent climber, stealthy, and has a unique perspective.\nCons: Requires specific environmental conditions and can be temperamental.");
                                Console.WriteLine("[4] Tooka\nPros: Intelligent, adaptable, and can communicate with various species.\nCons: Small size and can be easily overlooked.");
                                Console.WriteLine("[5] Wellagrin\nPros: Wise, experienced, and offers guidance and support.\nCons: Can be cautious and sometimes hesitant to take risks.");
                                Console.Write("===========================================================================\n> ");
                                companion = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("20. Destination\n");
                                Console.WriteLine("[1] Kepler 667\nCharacteristics: Potentially habitable exoplanet, stable orbit, temperate climate.\nChallenges: Extreme distance, unknown environmental conditions, and potential for alien life.");
                                Console.WriteLine("[2] Titan IX\nCharacteristics: Moons of Saturn, diverse landscapes, and potential for liquid water.\nChallenges: Harsh radiation, extreme cold, and thick atmosphere.");
                                Console.WriteLine("[3] Apollo 11\nCharacteristics: Historic site, lunar surface, and low gravity.\nChallenges: Harsh lunar environment, limited resources, and potential for lunar dust.");
                                Console.WriteLine("[4] Proxima\nCharacteristics: Nearest exoplanet to Earth, potentially habitable, and rocky terrain.\nChallenges: Extreme radiation, tidal forces, and unknown atmospheric conditions.");
                                Console.WriteLine("[5] Super Earth\nCharacteristics: Larger and more massive than Earth, potentially habitable, and diverse environments.\nChallenges: High gravity, unknown atmospheric conditions, and potential for extreme weather events.");
                                Console.Write("===========================================================================\n> ");
                                destination = input(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            finally
                            {
                                Console.WriteLine("===========================================================================");
                            }
                        }
                        Console.Clear();
                        Console.Write("\x1b[3J");

                        Players characteristics = new Players(playerName, gender, hairStyle, hairColor, eyeColor, race, bodyType, skinTone, strength, dexterity, intelligence, endurance, luck, spaceAgency, spaceship, headGear, armGear, torsoGear, legGear, Tools, colortint, accessories, companion, destination);

                        characteristics.DisplayConfirmedInfo();
                        characteristics.DisplayCharacteristics();
                        characterStats.PrintStats();
                        characteristics.DisplayPlayer();
                        color.displaytint();
                        characteristics.DisplayExtra();


                        Console.Write("Press any key to continue: ");
                        Console.ReadKey();
                    }
                    else if (UserChoice == 2)
                    {
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        Players play = new Players();
                        play.DisplayDatabaseInfo();
                    }
                    else if (UserChoice == 3)
                    {
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        Console.WriteLine(" _____________________________________________________________________________________________________");
                        Console.WriteLine("|                                            LORE                                                     |");
                        Console.WriteLine("|_____________________________________________________________________________________________________|");
                        Console.WriteLine("|          In the year 20XX, with the advancement of science, The Alliance were able                  |");
                        Console.WriteLine("|         to explore such boundaries, even worlds beyond spaces. The Worlds beyond                    |");
                        Console.WriteLine("|          has now reached its current peak because of its advanced technologies that                 |");
                        Console.WriteLine("|          were invented and innovated, but took a counterpart of being more prone to                 |");
                        Console.WriteLine("|          celestial invasions. That is why governments around the globe assembled                    |");
                        Console.WriteLine("|          to protect Earth from other worldly beings. Various space agencies and                     |");
                        Console.WriteLine("|          alliances have been assembled to prepare for the unknown. This is a new                    |");
                        Console.WriteLine("|          era of exploration as well as risky experiences, survival, and discovery.                  |");
                        Console.WriteLine("|                                                                                                     |");
                        Console.WriteLine("|        Ikaw na bihasa at ang katalinuhan tungkol sa pangkalawakan ay mas mataas pa                  |");
                        Console.WriteLine("|        kumpara sa iba. Ikaw ay nabigyan ng isang opportunity para makipag-cooperate                 |");
                        Console.WriteLine("|        sa agreement ng mga gobyerno sa iba’t-ibang bansa sa mundo. Isa ka rin sa mga                |");
                        Console.WriteLine("|        napili bilang mahalagang parte ng misyon na ito. Pero ang tanong, tatanggapin                |");
                        Console.WriteLine("|         mo ba o may pag-aalanganin ka pa? Nasa iyong mga kamay ang unang hakbang sa.                |");
                        Console.WriteLine("|             Misyon na magtatakda ng kapakanan ng iyong mundong tinitirahan.                         |");
                        Console.WriteLine("|                                                                                                     |");
                        Console.WriteLine("|     The age of discovering the stars is now here, brace yourselves for an immersive                 |");
                        Console.WriteLine("|    world full of different wonders! And it’s up to you to make the world know of such planets!      |");
                        Console.WriteLine("|         Accept the challenge and let the space witness your courage and intelligence.               |");
                        Console.WriteLine("|     It is up to you to explore distant planets and face unimaginable and formidable threats.        |");
                        Console.WriteLine("|    Every second counts, and every choice you make will define and reflect your legacy.              |");
                        Console.WriteLine("|    The fate of your own planet as well as the secret of space are now in your hands.                |");
                        Console.WriteLine("|                                    BE PREPARED.                                                     |");
                        Console.WriteLine("|_____________________________________________________________________________________________________|");
                        Console.Write("Press any key to continue: ");
                        Console.ReadKey();
                    }
                    else if (UserChoice == 4)
                    {

                        Console.Clear();
                        Console.Write("\x1b[3J");
                        Console.WriteLine("             CREDITS");
                        Console.WriteLine("");
                        Console.WriteLine("            PROGRAMMER");
                        Console.WriteLine("        BUGAS, TRISTAN CARL");
                        Console.WriteLine("");
                        Console.WriteLine("          DOCUMENTATION");
                        Console.WriteLine("         BAGAY,NEIL ANDREW");
                        Console.WriteLine("          CO,JOHN VINCENT");
                        Console.Write("\n\nPress any key to continue: ");                       
                        Console.ReadKey();
                    }
                    else if (UserChoice == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you for playing our game!");
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
    }
}