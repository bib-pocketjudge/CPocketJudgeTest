using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace CPocketJudgeTest
{
    /// <summary>
    /// Small console program that allows the user to fetch information about a Magic: The Gathering(c) card using the Scryfall(c) REST-like API.
    /// </summary>
    class Program
    {
        #region Parameters

        //initial input parameter
        public static string ini_input = "";

        public static string search_option = "";

        public static string name = "";
        #endregion

        #region Program

        static void Main(string[] args)
        {
            while (ini_input != "x")
            {
                ShowMenu();

                switch (ini_input)
                {
                    case "-h":
                        ShowHelp();
                        break;
                    case "-g":
                        GMenu();
                        break;
                    case "-r":
                        RMenu();
                        break;
                    case "-x":
                        Console.WriteLine("Shutting down...");
                        System.Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Functions

            #region GetJSON_functions

            /// <summary>
            /// 
            /// </summary>
            /// <param name="search_option">Specifies a search option.</param>
            /// <param name="name">Specifies a name format.</param>
            /// <returns></returns>
            public static string GetRulingJSON(string search_option, string name)
            {

                string responseFromServer = "";

                string url = "https://api.scryfall.com/cards/named?" + search_option + "=" + name;
                Console.WriteLine(url);

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Console.WriteLine(" This : " + ((HttpWebResponse)response).StatusDescription);

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    responseFromServer = reader.ReadToEnd();

                }

                //get card_rulings_url from deserialized card json
                string card_rulings_url = deserialiseJSON_For_Rulings(responseFromServer);

                Console.WriteLine(card_rulings_url);

                string responseFromServer_rulings = "";

                WebRequest rulings_request = WebRequest.Create(card_rulings_url);

                WebResponse rulings_response = rulings_request.GetResponse();

                Console.WriteLine(" This : " + ((HttpWebResponse)rulings_response).StatusDescription);

                using (Stream dataStream = rulings_response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    responseFromServer_rulings = reader.ReadToEnd();

                }

                //deserialize rulings
                deserialiseJSON_Rulings(responseFromServer_rulings);

                // Close the response.  
                rulings_response.Close();
                return responseFromServer_rulings;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="search_option">Specifies a search option.</param>
            /// <param name="name">Specifies a name format.</param>
            /// <returns></returns>
            public static string GetCardJSON(string search_option, string name)
            {
                string responseFromServer = "";

                string url = "https://api.scryfall.com/cards/named?" + search_option + "=" + name;
                Console.WriteLine(url);

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Console.WriteLine(" This : " + ((HttpWebResponse)response).StatusDescription);

                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    responseFromServer = reader.ReadToEnd();

                }

                // Display the content.  
                //serialised
                //Console.WriteLine(responseFromServer);

                //deserialised
                deserialiseJSON_Card(responseFromServer);

                // Close the response.  
                response.Close();
                return responseFromServer;
            }

            #endregion

            #region DeserializeJSON_functions

            public static void deserialiseJSON_dynamic(string json_string)
            {
                try
                {
                    var cardJSON = JsonConvert.DeserializeObject<dynamic>(json_string);
                    Console.WriteLine("Deserialized : \n {0}", cardJSON.ToString());

                    /*Does work...safe to use???
                    Console.WriteLine("Deserialized : \n {0}", cardJSON.oracle_text.ToString());
                    Console.WriteLine("Deserialized : \n {0}", cardJSON.rulings_uri.ToString());
                    */
                }
                catch (Exception deserialise_JSON_ex)
                {
                    Console.WriteLine("Error : {0}", deserialise_JSON_ex.Source);
                    throw;
                }
            }

            public static void deserialiseJSON_Card(string json_string)
            {
                try
                {
                    var cardJSON = JsonConvert.DeserializeObject<Card>(json_string);
                    //Console.WriteLine("Deserialized : \n {0}", cardJSON.ToString());

                    Console.WriteLine("Printing card");
                    PrintCard(cardJSON);
                }
                catch (Exception deserialise_JSON_ex)
                {
                    Console.WriteLine("Error : {0}", deserialise_JSON_ex.Source);
                    throw;
                }
            }

            public static void deserialiseJSON_Rulings(string json_string)
            {
                try
                {
                    var rulingsJSON = JsonConvert.DeserializeObject<Rulings>(json_string);
                    //Console.WriteLine("Deserialized : \n {0}", cardJSON.ToString());

                    Console.WriteLine("Printing rulings");
                    PrintRulings(rulingsJSON);
                }
                catch (Exception deserialise_JSON_ex)
                {
                    Console.WriteLine("Error : {0}", deserialise_JSON_ex.Source);
                    throw;
                }
            }

            /// <summary>
            /// Get rulings uri for further processing.
            /// </summary>
            /// <param name="json_string"></param>
            /// <returns></returns>
            public static string deserialiseJSON_For_Rulings(string json_string)
            {
                try
                {
                    var cardJSON = JsonConvert.DeserializeObject<Card>(json_string);

                    string rulings_uri_string = cardJSON.rulings_uri.ToString();

                    Console.WriteLine("Rulings url : {0}",rulings_uri_string);

                    return rulings_uri_string;
                }
                catch (Exception deserialise_JSON_ex)
                {
                    Console.WriteLine("Error : {0}", deserialise_JSON_ex.Source);
                    throw;
                }
    
            }

            #endregion

            #region Print Objects

            /// <summary>
            /// A function that prints information of a card.
            /// </summary>
            /// <param name="card">Class that defines a Magic: The Gathering(c) card.</param>
            public static void PrintCard(Card card)
            {
                Console.WriteLine("Oracle ID   : {0}", card.oracle_id.ToString());
                Console.WriteLine("Name        : {0}", card.name.ToString());
                Console.WriteLine("Small img   : {0}", card.image_uris.small.ToString());
                Console.WriteLine("Normal img  : {0}", card.image_uris.normal.ToString());
                Console.WriteLine("Large img   : {0}", card.image_uris.large.ToString());
                Console.WriteLine("Img as png  : {0}", card.image_uris.png.ToString());
                Console.WriteLine("Art crop    : {0}", card.image_uris.art_crop.ToString());
                Console.WriteLine("Border crop : {0}", card.image_uris.border_crop.ToString());
                Console.WriteLine("Mana cost   : {0}", card.mana_cost.ToString());
                Console.WriteLine("CMC         : {0}", card.cmc.ToString());
                Console.WriteLine("Type line   : {0}", card.type_line.ToString());
                Console.WriteLine("Oracle text : {0}", card.oracle_text.ToString());
                Console.WriteLine("Rulings URI : {0}", card.rulings_uri.ToString());
            }

            /// <summary>
            /// A function that prints the rulings of a card.
            /// </summary>
            /// <param name="rulings">Class containing rules changes and/or additions to a Magic: The Gathering(c) card.</param>
            public static void PrintRulings(Rulings rulings)
            {
                Datum[] data = rulings.data;

                foreach (var item in data)
                {
                    Console.WriteLine("--");
                    Console.WriteLine("Oracle ID   : {0}", item.oracle_id.ToString());
                    Console.WriteLine("Source      : {0}", item.source);
                    Console.WriteLine("Published   : {0}", item.published_at.ToString());

                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
                    Console.WriteLine("    Comment:");
                    Console.WriteLine("    {0}", item.comment);
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
                }
            }

            #endregion

        #endregion

        #region Menus

        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("|Scryfall API - Menu        |");
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("|Param -h : Show help       |");
            Console.WriteLine("|Param -g : Get card by name|");
            Console.WriteLine("|Param -r : Print ruling    |");
            Console.WriteLine("|Param -x : Close           |");
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("");
            Console.Write("Enter : ");
            ini_input = Console.ReadLine();
            Console.WriteLine();
        }

        public static string ShowMenuSlim()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("| -g : Get card by name     |");
            Console.WriteLine("| -r : Print ruling         |");
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("");
            Console.Write("Enter : ");
            ini_input = Console.ReadLine();
            Console.WriteLine();
            return ini_input;
        }

        public static void GMenu()
        {
            Console.WriteLine("Searching...                                           (see help using -h for more information about search parameters)");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.Write("like : ");
            search_option = Console.ReadLine();
            if (search_option == "-h")
            {
                search_option = "";
                name = "";
                HelpToG_searchOption();
                Console.WriteLine("\nHopefully your question has been answered\n");
                GMenu();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("For...                                                   (see help using -h for more information about name formatting)");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.Write("name : ");
                name = Console.ReadLine();

                if (name == "-h")
                {
                    search_option = "";
                    name = "";
                    HelpToG_nameFormatting();
                    Console.WriteLine("\nHopefully your question has been answered\n");
                    GMenu();
                }
                else
                {
                    Console.WriteLine();
                    GetCardJSON(search_option.ToLower(), name.ToLower());
                    Console.WriteLine();
                }
                
            }
            
        }

        public static void RMenu()
        {
            Console.WriteLine("Searching...                                           (see help using -h for more information about search parameters)");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.Write("like : ");
            search_option = Console.ReadLine();
            if (search_option == "-h")
            {
                search_option = "";
                name = "";
                HelpToG_searchOption();
                Console.WriteLine("\nHopefully your question has been answered\n");
                RMenu();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("For...                                                   (see help using -h for more information about name formatting)");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.Write("name : ");
                name = Console.ReadLine();

                if (name == "-h")
                {
                    search_option = "";
                    name = "";
                    HelpToG_nameFormatting();
                    Console.WriteLine("\nHopefully your question has been answered\n");
                    RMenu();
                }
                else
                {
                    Console.WriteLine();
                    GetRulingJSON(search_option.ToLower(), name.ToLower());
                }
                
            }
            
        }

        #endregion

        #region Help

        public static void ShowHelp()
        {
            Console.WriteLine("To which operation do you seek help?");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            string ti = ShowMenuSlim();

            switch (ti)
            {
                case "-g":
                    HelpToG();
                    break;
                case "-r":
                    HelpToG();
                    break;
                default:
                    ShowHelp();
                    break;
            }
        }

        public static void HelpToG_searchOption()
        {
            Console.WriteLine();
            Console.WriteLine("Help : Search option: ");
            Console.WriteLine();
            Console.WriteLine("#######################################################################################################################");
            Console.WriteLine("First you are asked to enter your search parameter\n\nThe options are:\n   exact or fuzzy\n");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("exact : \n   If you provide the exact parameter, a card with that exact name is returned.\n  Otherwise, a 404 Error is returned because no card matches.");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("fuzzy : \n   If you provide the fuzzy parameter and a card name matches that string, then that card is returned.\n   If not, a fuzzy search is executed for your card name.\n   The server allows misspellings and partial words to be provided. For example: jac bele will match Jace Beleren.");
            Console.WriteLine("#######################################################################################################################");
            Console.WriteLine();
        }

        public static void HelpToG_nameFormatting()
        {
            Console.WriteLine();
            Console.WriteLine("Help : Name formatting: ");
            Console.WriteLine();
            Console.WriteLine("#######################################################################################################################");
            Console.WriteLine("\n   For both exact and fuzzy, card names are case-insensitive and punctuation is optional\n   (you can drop apostrophes and periods etc).\n   For example: fIReBALL is the same as Fireball and smugglers copter is the same as Smuggler's Copter.\n");
            Console.WriteLine("#######################################################################################################################");
            Console.WriteLine();
        }

        public static void HelpToG()
        {
            Console.WriteLine("HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP");
            Console.WriteLine("--");
            HelpToG_searchOption();
            HelpToG_nameFormatting();
            Console.WriteLine("--");
            Console.WriteLine("HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP_HELP");
            Console.WriteLine();
        }

        #endregion
    }
}
