using System;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace characterCreation
{
    // properties
    public class Players
    {
        private string playerName;
        public string PlayerName{
            get { return this.playerName;  }
            set { this.playerName = value;  }
        }
        public int Gender { get; set; }
        public int HairStyle { get; set; }
        public int HairColor { get; set; }
        public int EyeColor { get; set; }
        public int Race { get; set; }
        public int BodyType { get; set; }
        public int SkinTone { get; set; }

        // Affiliation
        public int SpaceAgency { get; set; }

        //Equipments
        public int Spaceship { get; set; }
        public int HeadGear { get; set; }
        public int ArmGear { get; set; }
        public int TorsoGear { get; set; }
        public int LegGear { get; set; }
        public int Tools { get; set; }
        //stats
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int intelligence { get; set; }
        public int endurance { get; set; }
        public int luck { get; set; }

        public int TotalStat { get; private set; }
        public bool Colortint { get; set; }
        public int Accessories { get; set; }
        public int Companion { get; set; }
        //Destinaton
        public int Destination { get; set; }

        //constructor and .this keyword
        public Players(string name, int gender, int hairstyle, int hairColor, int eyeColor, int race, int bodyType, int skinTone, int strength, int dexterity, int intelligence, int endurance, int luck, int spaceAgency, int spaceship, int headGear, int armGear, int torsoGear, int legGear, int tools, bool colortint, int accessories, int companion, int destination)
        {
            this.PlayerName = name;
            this.Gender = gender;
            this.HairStyle = hairstyle;
            this.HairColor = hairColor;
            this.EyeColor = eyeColor;
            this.Race = race;
            this.BodyType = bodyType;
            this.SkinTone = skinTone;
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
            this.endurance = endurance;
            this.luck = luck;
            this.SpaceAgency = spaceAgency;
            this.Spaceship = spaceship;
            this.HeadGear = headGear;
            this.ArmGear = armGear;
            this.TorsoGear = torsoGear;
            this.LegGear = legGear;
            this.Tools = tools;
            this.Colortint = colortint;
            this.Accessories = accessories;
            this.Companion = companion;
            this.Destination = destination;
        }
        public Players(int strength, int dexterity, int intelligence, int endurance, int luck)
        {
            
        }
        public Players() { }

        //displays
        public void DisplayCharacteristics()
        {
            Console.WriteLine("\nPlayer Characteristics");
            Console.WriteLine($"Character Name  : {PlayerName}");
            Console.WriteLine($"gender          : {GetGender(Gender)}");
            Console.WriteLine($"Hair Style      : {GetHairStyle(HairStyle)}");
            Console.WriteLine($"Hair Color      : {GetHairColor(HairColor)}");
            Console.WriteLine($"Eye Color       : {GetEyeColor(EyeColor)}");
            Console.WriteLine($"Race            : {GetRace(Race)}");
            Console.WriteLine($"Body Type       : {GetBodyType(BodyType)}");
            Console.WriteLine($"Skin tone       : {GetSkinTone(SkinTone)}");
            
        }

        public void DisplayPlayer()
        {
            Console.WriteLine("\nPlayer Affiliation");
            Console.WriteLine($"Space Agency    : {GetAgency(SpaceAgency)}");
            Console.WriteLine($"Spaceship       : {GetSpaceship(Spaceship)}");
            Console.WriteLine("\nPlayer Equipment");
            Console.WriteLine($"Head            : {GetGearSpec(HeadGear)}");
            Console.WriteLine($"Arm             : {GetGearSpec(ArmGear)}");
            Console.WriteLine($"Torso           : {GetGearSpec(TorsoGear)}");
            Console.WriteLine($"Leg             : {GetGearSpec(LegGear)}");
            Console.WriteLine($"Tool            : {GetTools(Tools)}");
            
        }

        public void DisplayExtra()
        {
            Console.WriteLine($"Accessories     : {GetAccessories(Accessories)}");
            Console.WriteLine($"Companion       : {GetCompanion(Companion)}");
            Console.WriteLine($"\nDestination   : {GetDestination(Destination)}");
        }

        public void DisplayConfirmedInfo()
        {
            SqlConnection SqlConnect;
            string DatabaseConnectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ADMIN\SOURCE\REPOS\CONSOLEAPP2\CONSOLEAPP2\DATABASE1.MDF; Integrated Security = True;";
            try
            {
                SqlConnect = new SqlConnection(DatabaseConnectstring);
                SqlConnect.Open();
                string insertquery = "INSERT INTO dbo.CharacterTable (Name, Gender, Hair_Style, Hair_Color, Eye_Color, Race, Body_Type, Skin_Tone, Strength, Dexterity, Intelligence, Endurance, Luck, Space_Agency, Spaceship, Head_Gear, Arm_Gear, Torso_Gear, Leg_Gear, Tool, Colortint, Accessories, Companion, Destination) VALUES (@Name, @Gender, @Hair_Style, @Hair_Color, @Eye_Color, @Race, @Body_Type, @Skin_Tone, @Strength, @Dexterity, @Intelligence, @Endurance, @Luck, @Space_Agency, @Spaceship, @Head_Gear, @Arm_Gear, @Torso_Gear, @Leg_Gear, @Tool, @Colortint, @Accessories, @Companion, @Destination)";

                SqlCommand insert = new SqlCommand(insertquery, SqlConnect);

                insert.Parameters.AddWithValue("@Name", playerName);
                insert.Parameters.AddWithValue("@Gender", GetGender(Gender));
                insert.Parameters.AddWithValue("@Hair_Style", GetHairStyle(HairStyle));
                insert.Parameters.AddWithValue("@Hair_Color", GetHairColor(HairColor));
                insert.Parameters.AddWithValue("@Eye_Color", GetEyeColor(EyeColor));
                insert.Parameters.AddWithValue("@Race", GetRace(Race));
                insert.Parameters.AddWithValue("@Body_Type", GetBodyType(BodyType));
                insert.Parameters.AddWithValue("@Skin_Tone", GetSkinTone(SkinTone));
                insert.Parameters.AddWithValue("@Strength", strength);
                insert.Parameters.AddWithValue("@Dexterity", dexterity);
                insert.Parameters.AddWithValue("@Intelligence", intelligence);
                insert.Parameters.AddWithValue("@Endurance", endurance);
                insert.Parameters.AddWithValue("@Luck", luck);
                insert.Parameters.AddWithValue("@Space_Agency", GetAgency(SpaceAgency));
                insert.Parameters.AddWithValue("@Spaceship", GetSpaceship(Spaceship));
                insert.Parameters.AddWithValue("@Head_Gear", GetGearSpec(HeadGear));
                insert.Parameters.AddWithValue("@Arm_Gear", GetGearSpec(ArmGear));
                insert.Parameters.AddWithValue("@Torso_Gear", GetGearSpec(TorsoGear));
                insert.Parameters.AddWithValue("@Leg_Gear", GetGearSpec(LegGear));
                insert.Parameters.AddWithValue("@Tool", GetTools(Tools));
                insert.Parameters.AddWithValue("@Colortint", Colortint);
                insert.Parameters.AddWithValue("@Accessories", GetAccessories(Accessories));
                insert.Parameters.AddWithValue("@Companion", GetCompanion(Companion));
                insert.Parameters.AddWithValue("@Destination", GetDestination(Destination));
                insert.ExecuteNonQuery();

                Console.WriteLine("Character Created Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void DisplayDatabaseInfo()
        {
            try
            {
                SqlConnection SqlConnect;
                string DatabaseConnectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ADMIN\SOURCE\REPOS\CONSOLEAPP2\CONSOLEAPP2\DATABASE1.MDF; Integrated Security = True;";

                SqlConnect = new SqlConnection(DatabaseConnectstring);
                SqlConnect.Open();
                List<int> characterIds = new List<int>();
                string selectQuery = "SELECT * FROM dbo.CharacterTable";
                SqlCommand selectCommand = new SqlCommand(selectQuery, SqlConnect);
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string destination = reader.GetString(24);
                    characterIds.Add(id);

                }
                reader.Close();
                if (characterIds.Count == 0)
                {
                    Console.WriteLine("No characters found.");
                    Console.WriteLine("Returning to main screen in 5 seconds....");
                    Thread.Sleep(5000);
                    Console.Clear();
                    inputshow inputshow = new inputshow();
                    inputshow.Start();
                    SqlConnect.Close();
                    return;
                }
                inputshow show = new inputshow();

                while (true)
                {
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        Console.WriteLine("Load Game");
                        Console.WriteLine("==================================================");
                        Console.WriteLine("[1] View All characters");
                        Console.WriteLine("[2] View a specific character");
                        Console.WriteLine("[3] Delete a character");
                        Console.WriteLine("[4] Go back to main menu ");
                        Console.Write("==================================================\n> ");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            ViewAllCharacters();
                        }
                        else if(choice == "2")
                        {
                            ViewSpecificCharacter();
                        }
                        else if (choice == "3")
                        {
                            DeleteCharacter();
                        }
                        else if (choice == "4")
                        {
                            show.Start();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please try again.");
                        }
                }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }   
        private void ViewAllCharacters()
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            try
            {
                SqlConnection SqlConnect;
                string DatabaseConnectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ADMIN\SOURCE\REPOS\CONSOLEAPP2\CONSOLEAPP2\DATABASE1.MDF; Integrated Security = True;";
            
                SqlConnect = new SqlConnection(DatabaseConnectstring);
                SqlConnect.Open();
                string selectQuery = "SELECT * FROM dbo.CharacterTable";
                SqlCommand selectCommand = new SqlCommand(selectQuery, SqlConnect);
                SqlDataReader reader = selectCommand.ExecuteReader();

                Console.WriteLine("Characters");
                Console.WriteLine("==================================================");

                while (reader.Read())
                {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string gender = reader.GetString(2);
                            string hairStyle = reader.GetString(3);
                            string hairColor = reader.GetString(4);
                            string eyeColor = reader.GetString(5);
                            string race = reader.GetString(6);
                            string bodyType = reader.GetString(7);
                            string skinTone = reader.GetString(8);
                            int strength = reader.GetInt32(9);
                            int dexterity = reader.GetInt32(10);
                            int intelligence = reader.GetInt32(11);
                            int endurance = reader.GetInt32(12);
                            int luck = reader.GetInt32(13);
                            string spaceAgency = reader.GetString(14);
                            string spaceship = reader.GetString(15);
                            string headGear = reader.GetString(16);
                            string armGear = reader.GetString(17);
                            string torsoGear = reader.GetString(18);
                            string legGear = reader.GetString(19);
                            string tool = reader.GetString(20);
                            bool colorTint = reader.GetBoolean(21);
                            string accessories = reader.GetString(22);
                            string companion = reader.GetString(23);
                            string destination = reader.GetString(24);

                            Console.WriteLine($"    Character Details\n");
                            Console.WriteLine($"Character Name  : {name}");
                            Console.WriteLine($"gender          : {gender}");
                            Console.WriteLine($"Hair Style      : {hairStyle}");
                            Console.WriteLine($"Hair Color      : {hairColor}");
                            Console.WriteLine($"Eye Color       : {eyeColor}");
                            Console.WriteLine($"Race            : {race}");
                            Console.WriteLine($"Body Type       : {bodyType}");
                            Console.WriteLine($"Skin tone       : {skinTone}");
                            Console.WriteLine("\nPlayer Affiliation");
                            Console.WriteLine($"Space Agency    : {spaceAgency}");
                            Console.WriteLine($"Spaceship       : {spaceship}");
                            Console.WriteLine("\nPlayer Stats");
                            Console.WriteLine($"Strength        : {strength}");
                            Console.WriteLine($"Dexterity       : {dexterity}");
                            Console.WriteLine($"Intelligence    : {intelligence}");
                            Console.WriteLine($"Endurance       : {endurance}");
                            Console.WriteLine($"Luck            : {luck}");
                            Console.WriteLine("\nPlayer Equipment");
                            Console.WriteLine($"Head            : {headGear}");
                            Console.WriteLine($"Arm             : {armGear}");
                            Console.WriteLine($"Torso           : {torsoGear}");
                            Console.WriteLine($"Leg             : {legGear}");
                            Console.WriteLine($"Tool            : {tool}");
                            Console.WriteLine($"Colortint       : {colorTint}");
                            Console.WriteLine($"Accessories     : {accessories}");
                            Console.WriteLine($"Companion       : {companion}");
                            Console.WriteLine($"\nDestination   : {destination} ");
                            Console.WriteLine("==================================================");
                }
                reader.Close();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.Write("Press any key to return to the options: ");
            Console.ReadKey();
            DisplayDatabaseInfo();
        }
        private void ViewSpecificCharacter()
        {

            SqlConnection SqlConnect;
            string DatabaseConnectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ADMIN\SOURCE\REPOS\CONSOLEAPP2\CONSOLEAPP2\DATABASE1.MDF; Integrated Security = True;";

            SqlConnect = new SqlConnection(DatabaseConnectstring);
            SqlConnect.Open();
            List<int> characterIds = new List<int>();

            string selectQuery = "SELECT * FROM dbo.CharacterTable";
            SqlCommand selectCommand = new SqlCommand(selectQuery, SqlConnect);
            SqlDataReader reader = selectCommand.ExecuteReader();
            Console.Clear();
            Console.Write("\x1b[3J");
            Console.WriteLine("Characters");
            Console.WriteLine("[0] return to Load Game\n");
            Console.WriteLine("==================================================");
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string destination = reader.GetString(24);
                characterIds.Add(id);
                Console.WriteLine($"ID: {id} \nName: {name}  \nDestination: {destination}");
                Console.WriteLine("==================================================");

            }
            reader.Close();
            int userview;
            inputshow show = new inputshow();
            do
            {
                Console.Write("\nEnter character ID to view information: ");
                string input = Console.ReadLine().ToLower();
                if (int.TryParse(input, out userview) && characterIds.Contains(userview))
                {
                    break;
                }
                else if (input == "0")
                {
                    DisplayDatabaseInfo();
                }
                else
                {
                    Console.WriteLine("Invalid ID. Please try again.");
                    Console.WriteLine("================================================");
                }
            } while (true);
            
            string viewQuery = "SELECT * FROM dbo.CharacterTable WHERE ID = @id";
            SqlCommand viewCommand = new SqlCommand(viewQuery, SqlConnect);
            viewCommand.Parameters.AddWithValue("@id", userview);
            SqlDataReader singleReader = viewCommand.ExecuteReader();

            if (singleReader.Read())
            {
                string name = singleReader.GetString(1);
                string gender = singleReader.GetString(2);
                string hairStyle = singleReader.GetString(3);
                string hairColor = singleReader.GetString(4);
                string eyeColor = singleReader.GetString(5);
                string race = singleReader.GetString(6);
                string bodyType = singleReader.GetString(7);
                string skinTone = singleReader.GetString(8);
                int strength = singleReader.GetInt32(9);
                int dexterity = singleReader.GetInt32(10);
                int intelligence = singleReader.GetInt32(11);
                int endurance = singleReader.GetInt32(12);
                int luck = singleReader.GetInt32(13);
                string spaceAgency = singleReader.GetString(14);
                string spaceship = singleReader.GetString(15);
                string headGear = singleReader.GetString(16);
                string armGear = singleReader.GetString(17);
                string torsoGear = singleReader.GetString(18);
                string legGear = singleReader.GetString(19);
                string tool = singleReader.GetString(20);
                bool colorTint = singleReader.GetBoolean(21);
                string accessories = singleReader.GetString(22);
                string companion = singleReader.GetString(23);
                string destination = singleReader.GetString(24);

                Console.Clear();
                Console.WriteLine($"    Character Details\n");
                Console.WriteLine($"Character Name  : {name}");
                Console.WriteLine($"gender          : {gender}");
                Console.WriteLine($"Hair Style      : {hairStyle}");
                Console.WriteLine($"Hair Color      : {hairColor}");
                Console.WriteLine($"Eye Color       : {eyeColor}");
                Console.WriteLine($"Race            : {race}");
                Console.WriteLine($"Body Type       : {bodyType}");
                Console.WriteLine($"Skin tone       : {skinTone}");
                Console.WriteLine("\nPlayer Affiliation");
                Console.WriteLine($"Space Agency    : {spaceAgency}");
                Console.WriteLine($"Spaceship       : {spaceship}");
                Console.WriteLine("\nPlayer Stats");
                Console.WriteLine($"Strength        : {strength}");
                Console.WriteLine($"Dexterity       : {dexterity}");
                Console.WriteLine($"Intelligence    : {intelligence}");
                Console.WriteLine($"Endurance       : {endurance}");
                Console.WriteLine($"Luck            : {luck}");
                Console.WriteLine("\nPlayer Equipment");
                Console.WriteLine($"Head            : {headGear}");
                Console.WriteLine($"Arm             : {armGear}");
                Console.WriteLine($"Torso           : {torsoGear}");
                Console.WriteLine($"Leg             : {legGear}");
                Console.WriteLine($"Tool            : {tool}");
                Console.WriteLine($"Colortint       : {colorTint}");
                Console.WriteLine($"Accessories     : {accessories}");
                Console.WriteLine($"Companion       : {companion}");
                Console.WriteLine($"\nDestination   : {destination}");

            }
            Console.Write("Press any key to return to the options: ");
            Console.ReadKey();
            ViewSpecificCharacter();


        }
        private void DeleteCharacter()
        {
            Console.Clear();
            Console.Write("\x1b[3J");

            string DatabaseConnectstring = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = C:\USERS\ADMIN\SOURCE\REPOS\CONSOLEAPP2\CONSOLEAPP2\DATABASE1.MDF; Integrated Security = True;";
            List<int> characterIds = new List<int>();

            using (SqlConnection SqlConnect = new SqlConnection(DatabaseConnectstring))
            {
                SqlConnect.Open();

                try
                {
                    string selectQuery = "SELECT * FROM dbo.CharacterTable";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, SqlConnect))
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        Console.WriteLine("Characters");
                        Console.WriteLine("[0] Return to Load Game\n");
                        Console.WriteLine("==================================================");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string destination = reader.GetString(24);
                            characterIds.Add(id);
                            Console.WriteLine($"ID: {id} \nName: {name}  \nDestination: {destination}");
                            Console.WriteLine("==================================================");
                        }
                    }

                    if (characterIds.Count == 0)
                    {
                        Console.WriteLine("No characters found.");
                        Console.WriteLine("Returning to main screen in 5 seconds....");
                        Thread.Sleep(5000);
                        Console.Clear();
                        inputshow inputshow = new inputshow();
                        inputshow.Start();
                        SqlConnect.Close();
                        return;
                    }

                    int userview;
                    do
                    {
                        Console.Write("Enter ID to delete Character: ");
                        string input = Console.ReadLine().ToLower();
                        if (int.TryParse(input, out userview) && characterIds.Contains(userview))
                        {
                            break;
                        }
                        else if (input == "0")
                        {
                            DisplayDatabaseInfo();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please try again.");
                            Console.WriteLine("==================================================");
                        }
                    } while (true);

                    Console.Clear();
                    Console.Write("\x1b[3J");
                    Console.WriteLine($"ID entered: {userview}");

                    while (true)
                    {
                        Console.Write("\nWould you like to delete this character? (yes/no): ");
                        string userChoice = Console.ReadLine().ToLower();

                        if (userChoice == "yes")
                        {
                            string deleteQuery = "DELETE FROM dbo.CharacterTable WHERE ID = @id";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, SqlConnect))
                            {
                                deleteCommand.Parameters.AddWithValue("@id", userview);
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    Console.Clear();
                                    Console.Write("\x1b[3J");
                                    Console.WriteLine("Character successfully deleted.");
                                    Console.WriteLine("Returning to previous screen in 5 seconds....");
                                    Thread.Sleep(5000);
                                    DeleteCharacter();
                                }
                                else
                                {
                                    Console.WriteLine("Failed to delete the character.");
                                }
                            }
                        }
                        else if (userChoice == "no")
                        {
                            Console.Clear();
                            Console.WriteLine("Character not deleted.");
                            Thread.Sleep(2000);
                            DeleteCharacter();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Error: Enter yes or no (y/n)");
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
        }
            

        static string GetGender(int gender)
        {
            switch (gender)
            {
                case 1: return "Male";
                case 2: return "Female";
                default: return "Caesar";
            }
        }
        static string GetHairStyle(int style)
        {
            switch (style)
            {
                case 1: return "Curly";
                case 2: return "Flat Top";
                case 3: return "Buzz Cut";
                case 4: return "Amber";
                case 5: return "Pompadour";
                default: return "Caesar";
            }
        }

        static string GetHairColor(int color)
        {
            switch (color)
            {
                case 1: return "Blonde";
                case 2: return "Auburn";
                case 3: return "Black";
                case 4: return "Brown";
                case 5: return "Red";
                default: return "Unknown";
            }
        }
        static string GetEyeColor(int color)
        {
            switch (color)
            {
                case 1: return "Black";
                case 2: return "Crystal white";
                case 3: return "Azure";
                case 4: return "Amber";
                case 5: return "Jade";
                default: return "Unknown";
            }
        }

        static string GetRace(int race)
        {
            switch (race)
            {
                case 1: return "Human";
                case 2: return "Chiss";
                case 3: return "Togruta";
                case 4: return "Twi’lek";
                case 5: return "Zabrak";
                default: return "Unknown";
            }
        }

        static string GetBodyType(int body)
        {
            switch (body)
            {
                case 1: return "Slim";
                case 2: return "Stocky";
                case 3: return "Petite";
                case 4: return "Round";
                case 5: return "Lanky";
                default: return "Unknown";
            }
        }

        static string GetSkinTone(int skin)
        {
            switch (skin)
            {
                case 1: return "Porcelain";
                case 2: return "Ivory";
                case 3: return "Natural";
                case 4: return "Golden";
                case 5: return "Chestnut";
                default: return "Unknown";
            }
        }

        static string GetAgency(int agency)
        {
            switch (agency)
            {
                case 1: return "NASA";
                case 2: return "ISRO";
                case 3: return "CNSA";
                case 4: return "ESA";
                case 5: return "DLR";
                default: return "Unknown";
            }
        }
        static string GetSpaceship(int spaceship)
        {
            switch (spaceship)
            {
                case 1: return "Saturn-V";
                case 2: return "V-2";
                case 3: return "Starship";
                case 4: return "Delta IV";
                case 5: return "Ariane";
                default: return "Unknown";
            }
        }

        static string GetGearSpec(int gear)
        {
            switch (gear)
            {
                case 1: return "A-6871";
                case 2: return "S-3215";
                case 3: return "AZ-4711";
                case 4: return "O-9381";
                case 5: return "U-2489";
                default: return "Unknown";
            }
        }

        static string GetTools(int tools)
        {
            switch (tools)
            {
                case 1: return "Laser Gun";
                case 2: return "Lightsaber";
                case 3: return "Multi-tool";
                case 4: return "Healing Kits";
                case 5: return "Detonators";
                default: return "Unknown";
            }
        }


        static string GetAccessories(int agency)
        {
            switch (agency)
            {
                case 1: return "Stealth Bracelet";
                case 2: return "Star Map";
                case 3: return "Resource Censor";
                case 4: return "Nanomachine Synthesia";
                case 5: return "Incarcerated Weaver";
                default: return "Unknown";
            }
        }

        static string GetCompanion(int companion)
        {
            switch (companion)
            {
                case 1: return "Droid";
                case 2: return "Giggs";
                case 3: return "Iguana";
                case 4: return "Tooka";
                case 5: return "Wellagrin";
                default: return "Unknown";
            }
        }

        static string GetDestination(int destination)
        {
            switch (destination)
            {
                case 1: return "Kepler 667";
                case 2: return "Titan IX";
                case 3: return "Apollo 11";
                case 4: return "Proxima";
                case 5: return "Super Earth";
                default: return "Unknown";
            }
        }

    }

    //abstract, inheritance, override, polymorphism
    abstract class ColorTint
    {
        public abstract bool AskColortint();
    }

    class colors : ColorTint
    {
        public bool colortintchoice;

        public override bool AskColortint()
        {
            string userInput;

            do
            {
                Console.WriteLine("17. Would you like to Colortint to your weapons?\n");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No"); 
                Console.Write("===========================================================================\n> ");
                userInput = Console.ReadLine().Trim();

                if (userInput == "1")
                {
                    colortintchoice = true;
                    return true;
                }
                else if (userInput == "2")
                {
                    colortintchoice = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Yes or 2 for No.");
                    Console.WriteLine("===========================================================================");
                }
            }
            while (true);

        }
        public void displaytint()  
        {
            bool colortintChoice = colortintchoice;
            Console.WriteLine($"Colortint       : {(colortintChoice ? "True" : "False")}");
        }
        public bool confirmation()
        {
            return colortintchoice;
        }
    }
    // interface, inheritance, struct
    interface ICharacterStat
    {
        int TotalStat { get; }
        int totalStat(int strength, int dexterity, int intelligence, int endurance, int luck);
        void PrintStats();
    }

    public struct Stats : ICharacterStat
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Endurance { get; set; }
        public int Luck { get; set; }
        public int TotalStat { get; private set; }

        public int totalStat(int strength, int dexterity, int intelligence, int endurance, int luck)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Endurance = endurance;
            Luck = luck;
            TotalStat = Strength + Dexterity + Intelligence + Endurance + Luck;
            return TotalStat;
        }

        public void PrintStats()
        {
            Console.WriteLine($"\nCharacter Stats");
            Console.WriteLine($"Strength        : {Strength}");
            Console.WriteLine($"Dexterity       : {Dexterity}");
            Console.WriteLine($"Intelligence    : {Intelligence}");
            Console.WriteLine($"Endurance       : {Endurance}");
            Console.WriteLine($"Luck            : {Luck}");
            Console.WriteLine($"Total Stat      : {TotalStat}/10");
        }
    }

} 
