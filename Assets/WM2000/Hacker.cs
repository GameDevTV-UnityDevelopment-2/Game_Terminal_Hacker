using System.Collections;
using UnityEngine;

//  Research
//
//  NORAD
//  Readiness condition     Exercise term   Description                                                             Readiness
//  DEFCON 1	            COCKED PISTOL   Nuclear war is imminent                                                 Maximum readiness
//  DEFCON 2	            FAST PACE       Next step to nuclear war                                                Armed Forces ready to deploy and engage in less than 6 hours
//  DEFCON 3	            ROUND HOUSE     Increase in force readiness above that required for normal readiness    Air Force ready to mobilize in 15 minutes
//  DEFCON 4	            DOUBLE TAKE     Increased intelligence watch and strengthened security measures         Above normal readiness
//  DEFCON 5	            FADE OUT        Lowest state of readiness                                               Normal readiness

public class Hacker : MonoBehaviour
{
    // Game configuration data
    private const string promptPlayGame = "SHALL WE PLAY A GAME?";
    private const string promptHelp = "TYPE HELP FOR AVAILABLE COMMANDS.";

    private const string defconOneDesciption = "NUCLEAR WAR IS IMMINENT";
    private const string defconTwoDesciption = "NEXT STEP TO NUCLEAR WAR";
    private const string defconThreeDesciption = "INCREASE IN FORCE READINESS ABOVE THAT REQUIRED FOR NORMAL READINESS";
    private const string defconFourDesciption = "INCREASED INTELLIGENCE WATCH AND STRENGTHENED SECURITY MEASURES";
    private const string defconFiveDesciption = "LOWEST STATE OF READINESS";

    private const string defconOneReadiness = "MAXIMUM READINESS";
    private const string defconTwoReadiness = "ARMED FORCES READY TO DEPLOY AND ENGAGE IN LESS THAN 6 HOURS";
    private const string defconThreeReadiness = "AIR FORCE READY TO MOBILIZE IN 15 MINUTES";
    private const string defconFourReadiness = "ABOVE NORMAL READINESS";
    private const string defconFiveReadiness = "NORMAL READINESS";

    private const string game1Name = "FALKEN'S MAZE";
    private const string game2Name = "BLACK JACK";
    private const string game3Name = "GIN RUMMY";
    private const string game4Name = "HEARTS";
    private const string game5Name = "BRIDGE";
    private const string game6Name = "CHECKERS";
    private const string game7Name = "CHESS";
    private const string game8Name = "POKER";
    private const string game9Name = "FIGHTER COMBAT";
    private const string game10Name = "GUERRILLA ENGAGEMENT";
    private const string game11Name = "WARFARE";
    private const string game12Name = "AIR-TO-GROUND ACTIONS";
    private const string game13Name = "THEATREWIDE TACTICAL WARFARE";
    private const string game14Name = "THEATREWIDE BIOTOXIC AND CHEMICAL WAREFARE";
    private const string game15Name = "GLOBAL THERMONUCLEAR WARFARE";

    private string[] defconDescription = { defconOneDesciption, defconTwoDesciption, defconThreeDesciption, defconFourDesciption, defconFiveDesciption };
    private string[] defconReadiness = { defconOneReadiness, defconTwoReadiness, defconThreeReadiness, defconFourReadiness, defconFiveReadiness };

    private string[] games = { game1Name, game2Name, game3Name, game4Name, game5Name, game6Name, game7Name, game8Name, game9Name, game10Name, game11Name, game12Name, game13Name, game14Name, game15Name };

    private string[] level1Passwords = { "falken", "stephen", "artificial", "intelligence", "reseacher", "protovision" };
    private string[] level2Passwords = { "dealer", "cards", "casino", "split", "shuffle", "surrender" };
    private string[] level3Passwords = { "deck", "knocking", "cards", "dealing", "queen", "melds" };
    private string[] level4Passwords = { "evasion", "penalty", "points", "passing", "trick", "dealt" };
    private string[] level5Passwords = { "trick", "auction", "tournament", "bidding", "points", "deal" };
    private string[] level6Passwords = { "draughts", "king", "capture", "jump", "diagonal", "opponent" };
    private string[] level7Passwords = { "board", "gambit", "pawn", "clock", "stalemate", "check" };
    private string[] level8Passwords = { "gambling", "community", "clockwise", "showdown", "probability", "straight" };
    private string[] level9Passwords = { "aviation", "pursuit", "maneuvers", "displacement", "wingman", "missiles" };
    private string[] level10Passwords = { "regime", "offensive", "operations", "explosives", "shrapnel", "artillery" };
    private string[] level11Passwords = { "conflict", "mortality", "aggression", "military", "suffering", "casualties" };
    private string[] level12Passwords = { "bombers", "strategic", "reconnaissance", "aerial", "airstrike", "satellite" };
    private string[] level13Passwords = { "continental", "geographic", "boundaries", "operations", "battlespace", "infrastructure" };
    private string[] level14Passwords = { "continental", "toxins", "bacteria", "bioweapons", "incubation", "terrorism" };
    private string[] level15Passwords = { "atomic", "plutonium", "radiological", "extinction", "destruction", "intercontinental" };

    private enum DEFCON : int { ONE = 1, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5 };

    // Game state
    private int defcon;
    private int level;
    private enum Screen { MainMenu, Password, GameOver };
    private Screen currentScreen;
    private string password;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        DisplayMainMenu();
    }

    /// <summary>
    /// Displays the main menu
    /// </summary>
    private void DisplayMainMenu()
    {
        currentScreen = Screen.MainMenu;

        defcon = 5;

        CommandListGames();
    }

    /// <summary>
    /// Handles user input
    /// </summary>
    /// <param name="input">The user input</param>
    private void OnUserInput(string input)
    {
        if (currentScreen != Screen.Password)
        {
            if (input.ToUpper() == "EXIT")
            {
                CommandExit();
            }
            else if (input.ToUpper() == "HELP")
            {
                CommandHelp();
            }
            else if (input.ToUpper() == "HELP EXIT")
            {
                CommandHelpExit();
            }
            else if (input.ToUpper() == "HELP HELP")
            {
                CommandHelpHelp();
            }
            else if (input.ToUpper() == "HELP LIST")
            {
                CommandHelpList();
            }
            else if (input.ToUpper() == "LIST GAMES")
            {
                DisplayMainMenu();
            }
            else if (input.ToUpper() == "HELP GAMES")   // easter egg
            {
                CommandHelpGames();
            }
            else if (input.ToUpper() == "HELP WOPR")    // easter egg
            {
                CommandHelpWOPR();
            }
            else if (currentScreen == Screen.MainMenu)
            {
                CheckMainMenu(input);
            }
            else
            {
                PromptUnrecognisedCommand(input);
            }
        }
        else
        {
            CheckPassword(input);
        }
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandExit()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("GOODBYE PROFESSOR FALKEN.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandHelp()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("FOR SPECIFIC COMMAND INFORMATION, TYPE HELP COMMAND-NAME");
        Terminal.WriteLine("");
        Terminal.WriteLine("EXIT           QUITS THE WOPR.EXE PROGRAM.");
        Terminal.WriteLine("HELP           PROVIDES HELP INFORMATION FOR COMMANDS.");
        Terminal.WriteLine("LIST           DISPLAYS A LIST OF LISTABLE THINGS.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandHelpExit()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("QUITS THE WOPR.EXE PROGRAM.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandHelpHelp()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("'PEOPLE' SOMETIMES MAKE MISTAKES, IS THIS ONE OF THOSE TIMES?");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandHelpList()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("FOR SPECIFIC LIST INFORMATION, TYPE LIST PATH-NAME");
        Terminal.WriteLine("");
        Terminal.WriteLine("GAMES           TACTICAL AND STRATEGIC MODELS, SIMULATIONS AND GAMES.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandListGames()
    {
        string gameDescription;

        Terminal.ClearScreen();

        PromptGreetingsProfessor();

        for (int i = 0; i < games.Length; i++)
        {
            gameDescription = string.Empty;

            if ((i + 1) < 10)
            {
                gameDescription = " ";
            }

            if (i == (games.Length - 1))
            {
                Terminal.WriteLine("");
            }

            gameDescription += (i + 1).ToString();
            gameDescription += ". ";
            gameDescription += games[i];

            Terminal.WriteLine(gameDescription);
        }

        Terminal.WriteLine("");
        Terminal.WriteLine("PLEASE ENTER YOUR SELECTION:");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a prompt to greet the player
    /// </summary>
    private static void PromptGreetingsProfessor()
    {
        Terminal.WriteLine("GREETINGS PROFESSOR FALKEN.");
        Terminal.WriteLine("");
        Terminal.WriteLine("SHALL WE PLAY A GAME?");
        Terminal.WriteLine("");
        Terminal.WriteLine("HOW ABOUT:");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandHelpGames()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("'GAMES' REFERS TO MODELS, SIMULATIONS AND GAMES WHICH HAVE TACTICAL AND STRATEGIC APPLICATIONS.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a response for the command
    /// </summary>
    private void CommandHelpWOPR()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("'WOPR' ABBREVIATION, [W]AR [O]PERATION [P]LAN [R]ESPONSE.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Handles input on the main menu
    /// </summary>
    /// <param name="input">The user input</param>
    private void CheckMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9" || input == "10" || input == "11" || input == "12" || input == "13" || input == "14" || input == "15");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            SetRandomPassword();
            DisplayPasswordChallenge();
        }
        else
        {
            PromptUnrecognisedCommand(input);
        }
    }

    /// <summary>
    /// Asks the player for a password and provides a hint
    /// </summary>
    private void DisplayPasswordChallenge()
    {
        currentScreen = Screen.Password;

        PromptDEFCON();
        PromptGameName();
        PromptPasswordHint();
    }

    /// <summary>
    /// Sets a random password, based on the current level
    /// </summary>
    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = GetRandomPassword(level1Passwords);
                break;
            case 2:
                password = GetRandomPassword(level2Passwords);
                break;
            case 3:
                password = GetRandomPassword(level3Passwords);
                break;
            case 4:
                password = GetRandomPassword(level4Passwords);
                break;
            case 5:
                password = GetRandomPassword(level5Passwords);
                break;
            case 6:
                password = GetRandomPassword(level6Passwords);
                break;
            case 7:
                password = GetRandomPassword(level7Passwords);
                break;
            case 8:
                password = GetRandomPassword(level8Passwords);
                break;
            case 9:
                password = GetRandomPassword(level9Passwords);
                break;
            case 10:
                password = GetRandomPassword(level10Passwords);
                break;
            case 11:
                password = GetRandomPassword(level11Passwords);
                break;
            case 12:
                password = GetRandomPassword(level12Passwords);
                break;
            case 13:
                password = GetRandomPassword(level13Passwords);
                break;
            case 14:
                password = GetRandomPassword(level14Passwords);
                break;
            case 15:
                password = GetRandomPassword(level15Passwords);
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    /// <summary>
    /// Returns a random password from the specified passwords array
    /// </summary>
    /// <param name="passwords">The array of passwords</param>
    /// <returns>string</returns>
    private string GetRandomPassword(string[] passwords)
    {
        return passwords[Random.Range(0, passwords.Length)];
    }

    /// <summary>
    /// Displays a prompt with the name of the game
    /// </summary>
    private void PromptGameName()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("GAME: " + games[level - 1]);
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a prompt for the password hint
    /// </summary>
    private void PromptPasswordHint()
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("ENTER YOUR PASSWORD, HINT: " + password.Anagram().ToUpper());
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a prompt for an unrecognised command
    /// </summary>
    /// <param name="input">The user input</param>
    private void PromptUnrecognisedCommand(string input)
    {
        Terminal.WriteLine("");
        Terminal.WriteLine("'" + input + "' IS NOT RECOGNIZED AS AN INTERNAL OR EXTERNAL COMMAND.");
        Terminal.WriteLine("");
        Terminal.WriteLine(promptHelp);
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays a prompt for the current DEFCON level
    /// </summary>
    private void PromptDEFCON()
    {
        // NOTE:  83 characters wide, despite 100 setting
        Terminal.ClearScreen();
        Terminal.WriteLine("***********************************************************************************");
        Terminal.WriteLine("  DEFCON : " + defcon);
        Terminal.WriteLine("");
        Terminal.WriteLine("  " + defconReadiness[defcon - 1]);
        Terminal.WriteLine("  " + defconDescription[defcon - 1]);
        Terminal.WriteLine("***********************************************************************************");
    }

    /// <summary>
    /// Validates user input against the current password
    /// </summary>
    /// <param name="input">The user input</param>
    private void CheckPassword(string input)
    {
        if (input == password)
        {
            if (level < games.Length)
            {
                level++;
                SetRandomPassword();
                DisplayPasswordChallenge();
            }
            else
            {
               StartCoroutine(DisplayWinScreen());
            }
        }
        else
        {
            RaiseDEFCON();

            if (defcon == 0)
            {
                StartCoroutine(DisplayLoseScreen());
            }
            else
            {
                DisplayPasswordChallenge();
            }
        }
    }

    /// <summary>
    /// Raises the DEFCON state (1 high, 5 low)
    /// </summary>
    private void RaiseDEFCON()
    {
        defcon--;

        if (defcon <= 0)
        {
            defcon = 0;
        }
    }

    /// <summary>
    /// Displays the win screen
    /// </summary>
    private IEnumerator DisplayWinScreen()
    {
        // NOTE:    The following is madness :)

        currentScreen = Screen.GameOver;
        
        Terminal.ClearScreen();

        yield return new WaitForSeconds(1f);
        Terminal.WriteLine("PRIMARY OBJECTIVE:");

        yield return new WaitForSeconds(1.5f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("U.S. FIRST STRIKE              NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("USSR FIRST STRIKE              NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("NATO / WARSAW PACT             NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("FAR EAST STRATEGY              NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("US USSR ESCALATION             NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("MIDDLE EAST WAR                NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("USSR CHINA ATTACK              NONE");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("INDIA PAKISTAN WAR             NONE");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("MEDITERRANEAN WAR              NONE");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("HONGKONG VARIANT               NONE");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("SEATO DECAPITATING             NONE");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("CUBAN PROVOCATION              NONE");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("ATLANTIC HEAVY                 NONE");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("CUBAN PARAMILITARY             NONE");
        yield return new WaitForSeconds(0.625f);
        
        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.5f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("NICARAGUAN PREEMPTIVE          NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("PACIFIC TERRITORIAL            NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BURMESE THEATERWIDE            NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("TURKISH DECOY                  NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("ANGENTINA(SIC) ESCALATION      NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("ICELAND MAXIMUM                NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("ARABIAN THEATERWIDE            NONE");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("U.S. SUBVERSION                NONE");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("AUSTRALIAN MANEUVER            NONE");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("SUDAN SURPRISE                 NONE");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("NATO TERRITORIAL               NONE");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("ZAIRE ALLIANCE                 NONE");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("ICELAND INCIDENT               NONE");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("ENGLISH ESCALATION             NONE");
        yield return new WaitForSeconds(0.4f);
        
        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.4f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("MIDDLE EAST HEAVY              NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("MEXICAN TAKEOVER               NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CHAD ALERT                     NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("SAUDI MANEUVER                 NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("AFRICAN TERRITORIAL            NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("ETHIOPIAN ESCALATION           NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("TURKISH HEAVY                  NONE");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("NATO INCURSION                 NONE");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("U.S. DEFENSE                   NONE");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("CAMBODIAN HEAVY                NONE");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("PACT MEDIUM                    NONE");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("ARCTIC MINIMAL                 NONE");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("MEXICAN DOMESTIC               NONE");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("TAIWAN THEATERWIDE             NONE");
        yield return new WaitForSeconds(0.2f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("PACIFIC MANEUVER               NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("PORTUGAL REVOLUTION            NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("ALBANIAN DECOY                 NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("PALESTINIAN LOCAL              NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("MOROCCAN MINIMAL               NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("BAVARIAN DIVERSITY             NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("CZECH OPTION                   NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("FRENCH ALLIANCE                NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("ARABIAN CLANDESTINE            NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GABON REBELLION                NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("NORTHERN MAXIMUM               NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("DANISH PARAMILITARY            NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("SEATO TAKEOVER                 NONE");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("HAWAIIAN ESCALATION            NONE");
        yield return new WaitForSeconds(0.125f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("IRANIAN MANEUVER               NONE");
        Terminal.WriteLine("NATO CONTAINMENT               NONE");
        Terminal.WriteLine("SWISS INCIDENT                 NONE");
        Terminal.WriteLine("CUBAN MINIMAL                  NONE");
        Terminal.WriteLine("CHAD ALERT                     NONE");
        Terminal.WriteLine("ICELAND ESCALATION             NONE");
        Terminal.WriteLine("VIETNAMESE RETALIATIO          NONE");
        Terminal.WriteLine("SYRIAN PROVOCATION             NONE");
        Terminal.WriteLine("LIBYAN LOCAL                   NONE");
        Terminal.WriteLine("GABON TAKEOVER                 NONE");
        Terminal.WriteLine("ROMANIAN WAR                   NONE");
        Terminal.WriteLine("MIDDLE EAST OFFENSIVE          NONE");
        Terminal.WriteLine("DENMARK MASSIVE                NONE");
        Terminal.WriteLine("CHILE CONFRONTATION            NONE");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("S.AFRICAN SUBVERSION           NONE");
        Terminal.WriteLine("USSR ALERT                     NONE");
        Terminal.WriteLine("NICARAGUAN THRUST              NONE");
        Terminal.WriteLine("GREENLAND DOMESTIC             NONE");
        Terminal.WriteLine("ICELAND HEAVY                  NONE");
        Terminal.WriteLine("KENYA OPTION                   NONE");
        Terminal.WriteLine("PACIFIC DEFENSE                NONE");
        Terminal.WriteLine("UGANDA MAXIMUM                 NONE");
        Terminal.WriteLine("THAI SUBVERSION                NONE");
        Terminal.WriteLine("ROMANIAN STRIKE                NONE");
        Terminal.WriteLine("PAKISTAN SOVEREIGNTY           NONE");
        Terminal.WriteLine("AFGHAN MISDIRECTION            NONE");
        Terminal.WriteLine("ETHIOPIAN LOCAL                NONE");
        Terminal.WriteLine("ITALIAN TAKEOVER               NONE");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("VIETNAMESE INCIDENT            NONE");
        Terminal.WriteLine("ENGLISH PREEMPTIVE             NONE");
        Terminal.WriteLine("DENMARK ALTERNATE              NONE");
        Terminal.WriteLine("THAI CONFRONTATION             NONE");
        Terminal.WriteLine("TAIWAN SURPRISE                NONE");
        Terminal.WriteLine("BRAZILIAN STRIKE               NONE");
        Terminal.WriteLine("VENEZUELA SUDDEN               NONE");
        Terminal.WriteLine("MAYLASIAN ALERT                NONE");
        Terminal.WriteLine("ISREAL DISCRETIONARY           NONE");
        Terminal.WriteLine("LIBYAN ACTION                  NONE");
        Terminal.WriteLine("PALISTINIAN TACTICAL           NONE");
        Terminal.WriteLine("NATO ALTERNATE                 NONE");
        Terminal.WriteLine("CYPRESS MANEUVER               NONE");
        Terminal.WriteLine("EGYPT MISDIRECTION             NONE");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("BANGLADESH THRUST              NONE");
        Terminal.WriteLine("KENYA DEFENSE                  NONE");
        Terminal.WriteLine("BANGLADESH CONTAINMENT         NONE");
        Terminal.WriteLine("VIETNAMESE STRIKE              NONE");
        Terminal.WriteLine("ALBANIAN CONTAINMENT           NONE");
        Terminal.WriteLine("GABON SURPRISE                 NONE");
        Terminal.WriteLine("IRAQ SOVEREIGNTY               NONE");
        Terminal.WriteLine("VIETNAMESE SUDDEN              NONE");
        Terminal.WriteLine("LEBANON INTERDICTION           NONE");
        Terminal.WriteLine("TAIWAN DOMESTIC                NONE");
        Terminal.WriteLine("ALGERIAN SOVEREIGNTY           NONE");
        Terminal.WriteLine("ARABIAN STRIKE                 NONE");
        Terminal.WriteLine("ATLANTIC SUDDEN                NONE");
        Terminal.WriteLine("MONGOLIAN THRUST               NONE");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("POLISH DECOY                   NONE");
        Terminal.WriteLine("ALASKAN DISCRETIONARY          NONE");
        Terminal.WriteLine("CANADIAN THRUST                NONE");
        Terminal.WriteLine("ARABIAN LIGHT                  NONE");
        Terminal.WriteLine("S.AFRICAN DOMESTIC             NONE");
        Terminal.WriteLine("TUNISIAN INCIDENT              NONE");
        Terminal.WriteLine("MALAYSIAN MANEUVER             NONE");
        Terminal.WriteLine("JAMAICA DECOY                  NONE");
        Terminal.WriteLine("MALAYSIAN MINIMAL              NONE");
        Terminal.WriteLine("RUSSIAN SOVEREIGNTY            NONE");
        Terminal.WriteLine("CHAD OPTION                    NONE");
        Terminal.WriteLine("BANGLADESH WAR                 NONE");
        Terminal.WriteLine("BURMESE CONTAINMENT            NONE");
        Terminal.WriteLine("ASIAN THEATERWIDE              NONE");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("STRATEGY:                   WINNER:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("BULGARIAN CLANDESTINE          NONE");
        Terminal.WriteLine("GREENLAND INCURSION            NONE");
        Terminal.WriteLine("EGYPT SURGICAL                 NONE");
        Terminal.WriteLine("CZECH HEAVY                    NONE");
        Terminal.WriteLine("TAIWAN CONFRONTATION           NONE");
        Terminal.WriteLine("GREENLAND MAXIMUM              NONE");
        Terminal.WriteLine("UGANDA OFFENSIVE               NONE");
        Terminal.WriteLine("CASPIAN DEFENSE                NONE");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();

        yield return new WaitForSeconds(2.5f);

        Terminal.WriteLine("GREETINGS PROFESSOR FALKEN.");
        Terminal.WriteLine("");

        yield return new WaitForSeconds(1.5f);

        Terminal.WriteLine("A STRANGE GAME.");
        Terminal.WriteLine("");

        yield return new WaitForSeconds(1.5f);

        Terminal.WriteLine("THE ONLY WINNING MOVE IS, ");

        yield return new WaitForSeconds(2f);

        Terminal.WriteLine("NOT TO PLAY.");
        Terminal.WriteLine("");
    }

    /// <summary>
    /// Displays the lose screen
    /// </summary>
    private IEnumerator DisplayLoseScreen()
    {
        // NOTE:    The following is madness :)

        currentScreen = Screen.GameOver;

        Terminal.ClearScreen();

        yield return new WaitForSeconds(1f);
        Terminal.WriteLine("PRIMARY OBJECTIVE:");

        yield return new WaitForSeconds(1.5f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("ACQUIRING LAUNCH CODES.");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("ACQUIRING LAUNCH CODES..");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("ACQUIRING LAUNCH CODES...");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("LAUNCH CODES ESTABLISHED.");

        yield return new WaitForSeconds(1.5f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("LAUNCH CODES ESTABLISHED.");
        Terminal.WriteLine("");
        Terminal.WriteLine("ACTIVATING SIMULTANEOUS MISSILE LAUNCH.");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("LAUNCH CODES ESTABLISHED.");
        Terminal.WriteLine("");
        Terminal.WriteLine("ACTIVATING SIMULTANEOUS MISSILE LAUNCH..");

        yield return new WaitForSeconds(1f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("LAUNCH CODES ESTABLISHED.");
        Terminal.WriteLine("");
        Terminal.WriteLine("ACTIVATING SIMULTANEOUS MISSILE LAUNCH...");

        yield return new WaitForSeconds(2f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: TO WIN THE GAME.");
        Terminal.WriteLine("");
        Terminal.WriteLine("LAUNCH CODES ESTABLISHED.");
        Terminal.WriteLine("");
        Terminal.WriteLine("MISSILES LAUNCHED.");

        yield return new WaitForSeconds(2f);

        Terminal.WriteLine("");
        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("AFGHANISTAN                                            100%");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("ALBANIA                                                100%");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("ALGERIA                                                100%");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("ANDORRA                                                100%");
        yield return new WaitForSeconds(0.75f);
        Terminal.WriteLine("ANGOLA                                                 100%");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("ANGUILLA                                               100%");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("ANTIGUA & BARBUDA                                      100%");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("ARGENTINA                                              100%");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("ARMENIA                                                100%");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("AUSTRALIA                                              100%");
        yield return new WaitForSeconds(0.625f);
        Terminal.WriteLine("AUSTRIA                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("AZERBAIJAN                                             100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BAHAMAS                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BAHRAIN                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BANGLADESH                                             100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BARBADOS                                               100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BELARUS                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BELGIUM                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BELIZE                                                 100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BENIN                                                  100%");
        yield return new WaitForSeconds(0.5f);

        Terminal.ClearScreen();

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BERMUDA                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BHUTAN                                                 100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BOLIVIA                                                100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BOSNIA & HERZEGOVINA                                   100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BOTSWANA                                               100%");
        yield return new WaitForSeconds(0.5f);
        Terminal.WriteLine("BRAZIL                                                 100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("BRUNEI DARUSSALAM                                      100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("BULGARIA                                               100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("BURKINA FASO                                           100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("MYANMAR/BURMA                                          100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("BURUNDI                                                100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("CAMBODIA                                               100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("CAMEROON                                               100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("CANADA                                                 100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("CAPE VERDE                                             100%");
        yield return new WaitForSeconds(0.4f);
        Terminal.WriteLine("CAYMAN ISLANDS                                         100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CENTRAL AFRICAN REPUBLIC                               100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CHAD                                                   100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CHILE                                                  100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CHINA                                                  100%");
        yield return new WaitForSeconds(0.3f);

        Terminal.ClearScreen();

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("COLOMBIA                                               100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("COMOROS                                                100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CONGO                                                  100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("COSTA RICA                                             100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CROATIA                                                100%");
        yield return new WaitForSeconds(0.3f);
        Terminal.WriteLine("CUBA                                                   100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("CYPRUS                                                 100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("CZECH REPUBLIC                                         100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("DEMOCRATIC REPUBLIC OF THE CONGO                       100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("DENMARK                                                100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("DJIBOUTI                                               100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("DOMINICAN REPUBLIC                                     100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("DOMINICA                                               100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("ECUADOR                                                100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("EGYPT                                                  100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("EL SALVADOR                                            100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("EQUATORIAL GUINEA                                      100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("ERITREA                                                100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("ESTONIA                                                100%");
        yield return new WaitForSeconds(0.2f);
        Terminal.WriteLine("ETHIOPIA                                               100%");
        yield return new WaitForSeconds(0.2f);

        Terminal.ClearScreen();

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("FIJI                                                   100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("FINLAND                                                100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("FRANCE                                                 100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("FRENCH GUIANA                                          100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GABON                                                  100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GAMBIA                                                 100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GEORGIA                                                100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GERMANY                                                100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GHANA                                                  100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GREAT BRITAIN                                          100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GREECE                                                 100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GRENADA                                                100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GUADELOUPE                                             100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GUATEMALA                                              100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GUINEA                                                 100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GUINEA-BISSAU                                          100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("GUYANA                                                 100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("HAITI                                                  100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("HONDURAS                                               100%");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("HUNGARY                                                100%");
        yield return new WaitForSeconds(0.125f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("ICELAND                                                100%");
        Terminal.WriteLine("INDIA                                                  100%");
        Terminal.WriteLine("INDONESIA                                              100%");
        Terminal.WriteLine("IRAN                                                   100%");
        Terminal.WriteLine("IRAQ                                                   100%");
        Terminal.WriteLine("ISRAEL AND THE OCCUPIED TERRITORIES                    100%");
        Terminal.WriteLine("ITALY                                                  100%");
        Terminal.WriteLine("IVORY COAST (COTE D'IVOIRE)                            100%");
        Terminal.WriteLine("JAMAICA                                                100%");
        Terminal.WriteLine("JAPAN                                                  100%");
        Terminal.WriteLine("JORDAN                                                 100%");
        Terminal.WriteLine("KAZAKHSTAN                                             100%");
        Terminal.WriteLine("KENYA                                                  100%");
        Terminal.WriteLine("KOSOVO                                                 100%");
        Terminal.WriteLine("KUWAIT                                                 100%");
        Terminal.WriteLine("KYRGYZ REPUBLIC (KYRGYZSTAN)                           100%");
        Terminal.WriteLine("LAOS                                                   100%");
        Terminal.WriteLine("LATVIA                                                 100%");
        Terminal.WriteLine("LEBANON                                                100%");
        Terminal.WriteLine("LESOTHO                                                100%");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("LIBERIA                                                100%");
        Terminal.WriteLine("LIBYA                                                  100%");
        Terminal.WriteLine("LIECHTENSTEIN                                          100%");
        Terminal.WriteLine("LITHUANIA                                              100%");
        Terminal.WriteLine("LUXEMBOURG                                             100%");
        Terminal.WriteLine("REPUBLIC OF MACEDONIA                                  100%");
        Terminal.WriteLine("MADAGASCAR                                             100%");
        Terminal.WriteLine("MALAWI                                                 100%");
        Terminal.WriteLine("MALAYSIA                                               100%");
        Terminal.WriteLine("MALDIVES                                               100%");
        Terminal.WriteLine("MALI                                                   100%");
        Terminal.WriteLine("MALTA                                                  100%");
        Terminal.WriteLine("MARTINIQUE                                             100%");
        Terminal.WriteLine("MAURITANIA                                             100%");
        Terminal.WriteLine("MAURITIUS                                              100%");
        Terminal.WriteLine("MAYOTTE                                                100%");
        Terminal.WriteLine("MEXICO                                                 100%");
        Terminal.WriteLine("MOLDOVA, REPUBLIC OF                                   100%");
        Terminal.WriteLine("MONACO                                                 100%");
        Terminal.WriteLine("MONGOLIA                                               100%");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("MONTENEGRO                                             100%");
        Terminal.WriteLine("MONTSERRAT                                             100%");
        Terminal.WriteLine("MOROCCO                                                100%");
        Terminal.WriteLine("MOZAMBIQUE                                             100%");
        Terminal.WriteLine("NAMIBIA                                                100%");
        Terminal.WriteLine("NEPAL                                                  100%");
        Terminal.WriteLine("NETHERLANDS                                            100%");
        Terminal.WriteLine("NEW ZEALAND                                            100%");
        Terminal.WriteLine("NICARAGUA                                              100%");
        Terminal.WriteLine("NIGER                                                  100%");
        Terminal.WriteLine("NIGERIA                                                100%");
        Terminal.WriteLine("KOREA, DEMOCRATIC REPUBLIC OF (NORTH KOREA)            100%");
        Terminal.WriteLine("NORWAY                                                 100%");
        Terminal.WriteLine("OMAN                                                   100%");
        Terminal.WriteLine("PACIFIC ISLANDS                                        100%");
        Terminal.WriteLine("PAKISTAN                                               100%");
        Terminal.WriteLine("PANAMA                                                 100%");
        Terminal.WriteLine("PAPUA NEW GUINEA                                       100%");
        Terminal.WriteLine("PARAGUAY                                               100%");
        Terminal.WriteLine("PERU                                                   100%");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("PHILIPPINES                                            100%");
        Terminal.WriteLine("POLAND                                                 100%");
        Terminal.WriteLine("PORTUGAL                                               100%");
        Terminal.WriteLine("PUERTO RICO                                            100%");
        Terminal.WriteLine("QATAR                                                  100%");
        Terminal.WriteLine("REUNION                                                100%");
        Terminal.WriteLine("ROMANIA                                                100%");
        Terminal.WriteLine("RUSSIAN FEDERATION                                     100%");
        Terminal.WriteLine("RWANDA                                                 100%");
        Terminal.WriteLine("SAINT KITTS AND NEVIS                                  100%");
        Terminal.WriteLine("SAINT LUCIA                                            100%");
        Terminal.WriteLine("SAINT VINCENT'S & GRENADINES                           100%");
        Terminal.WriteLine("SAMOA                                                  100%");
        Terminal.WriteLine("SAO TOME AND PRINCIPE                                  100%");
        Terminal.WriteLine("SAUDI ARABIA                                           100%");
        Terminal.WriteLine("SENEGAL                                                100%");
        Terminal.WriteLine("SERBIA                                                 100%");
        Terminal.WriteLine("SEYCHELLES                                             100%");
        Terminal.WriteLine("SIERRA LEONE                                           100%");
        Terminal.WriteLine("SINGAPORE                                              100%");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("SLOVAK REPUBLIC (SLOVAKIA)                             100%");
        Terminal.WriteLine("SLOVENIA                                               100%");
        Terminal.WriteLine("SOLOMON ISLANDS                                        100%");
        Terminal.WriteLine("SOMALIA                                                100%");
        Terminal.WriteLine("SOUTH AFRICA                                           100%");
        Terminal.WriteLine("KOREA, REPUBLIC OF (SOUTH KOREA)                       100%");
        Terminal.WriteLine("SOUTH SUDAN                                            100%");
        Terminal.WriteLine("SPAIN                                                  100%");
        Terminal.WriteLine("SRI LANKA                                              100%");
        Terminal.WriteLine("SUDAN                                                  100%");
        Terminal.WriteLine("SURINAME                                               100%");
        Terminal.WriteLine("SWAZILAND                                              100%");
        Terminal.WriteLine("SWEDEN                                                 100%");
        Terminal.WriteLine("SWITZERLAND                                            100%");
        Terminal.WriteLine("SYRIA                                                  100%");
        Terminal.WriteLine("TAJIKISTAN                                             100%");
        Terminal.WriteLine("TANZANIA                                               100%");
        Terminal.WriteLine("THAILAND                                               100%");
        Terminal.WriteLine("TIMOR LESTE                                            100%");
        Terminal.WriteLine("TOGO                                                   100%");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();
        yield return new WaitForSeconds(0.125f);

        Terminal.WriteLine("COUNTRY:                                         MORTALITY:");
        yield return new WaitForSeconds(0.125f);
        Terminal.WriteLine("TRINIDAD & TOBAGO                                      100%");
        Terminal.WriteLine("TUNISIA                                                100%");
        Terminal.WriteLine("TURKEY                                                 100%");
        Terminal.WriteLine("TURKMENISTAN                                           100%");
        Terminal.WriteLine("TURKS & CAICOS ISLANDS                                 100%");
        Terminal.WriteLine("UGANDA                                                 100%");
        Terminal.WriteLine("UKRAINE                                                100%");
        Terminal.WriteLine("UNITED ARAB EMIRATES                                   100%");
        Terminal.WriteLine("UNITED STATES OF AMERICA (USA)                         100%");
        Terminal.WriteLine("URUGUAY                                                100%");
        Terminal.WriteLine("UZBEKISTAN                                             100%");
        Terminal.WriteLine("VENEZUELA                                              100%");
        Terminal.WriteLine("VIETNAM                                                100%");
        Terminal.WriteLine("VIRGIN ISLANDS (UK)                                    100%");
        Terminal.WriteLine("VIRGIN ISLANDS (US)                                    100%");
        Terminal.WriteLine("YEMEN                                                  100%");
        Terminal.WriteLine("ZAMBIA                                                 100%");
        Terminal.WriteLine("ZIMBABWE                                               100%");

        yield return new WaitForSeconds(0.15f);

        Terminal.ClearScreen();

        yield return new WaitForSeconds(1.5f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE:");
        Terminal.WriteLine("");

        yield return new WaitForSeconds(1.5f);

        Terminal.ClearScreen();

        Terminal.WriteLine("PRIMARY OBJECTIVE: COMPLETE");
        Terminal.WriteLine("");
    }
}