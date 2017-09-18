﻿using System;
using System.Text;

namespace TheTravelingSalesperson
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Salesperson object for the Controller to use
        // Note: There is no need for a Salesperson property given the Controller already 
        //       has access to the same Salesperson object.
        //
        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Salesperson salesperson)
        {
            _salesperson = salesperson;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "Lame Headache Productions - The Travelling Salesperson";
            ConsoleUtil.HeaderText = " The Travelling Salesperson";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for using the application. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Thank you for choosing Lame Headache Productions!");
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up your account details.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// Note: To maintain the pattern of only the Controller changing the data this method should
        ///       return a Salesperson object with the initial data to the controller. For simplicity in 
        ///       this demo, the ConsoleView object is allowed to access the Salesperson object's properties.
        /// </summary>
        public void DisplaySetupAccount()
        {
            bool gotInput = false;
            int qty;
            string was = "";

            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Setup your account now.");
            Console.WriteLine();



            if (_salesperson.FirstName != null) {
                was = $" (was set to: {_salesperson.FirstName})";
            }

            ConsoleUtil.DisplayPromptMessage($"Enter your first name{was}: ");
            _salesperson.FirstName = Console.ReadLine();
            Console.WriteLine();

            if (_salesperson.LastName != null)
            {
                was = $" (was set to: {_salesperson.LastName})";
            }
            ConsoleUtil.DisplayPromptMessage($"Enter your last name{was}: ");
            _salesperson.LastName = Console.ReadLine();
            Console.WriteLine();

            if (_salesperson.AccountID != null)
            {
                was = $" (was set to: {_salesperson.AccountID})";
            }
            ConsoleUtil.DisplayPromptMessage($"Enter your account ID{was}: ");
            _salesperson.AccountID = Console.ReadLine();
            Console.WriteLine();

            if (_salesperson.WidgetItem.Type.ToString() != "None")
            {
                was = $" (was set to: {_salesperson.WidgetItem.Type.ToString()})";
            }
            while (!gotInput) {
                ConsoleUtil.DisplayPromptMessage($"Enter widget type (Furry, Spotted, Dancing) {was}: ");
                switch (Console.ReadLine().ToLower())
                {
                    case "furry":
                        _salesperson.WidgetItem.Type = TheTravelingSalesperson.WidgetItemStock.WidgetType.Furry;
                        gotInput = true;
                        break;
                    case "spotted":
                        _salesperson.WidgetItem.Type = TheTravelingSalesperson.WidgetItemStock.WidgetType.Spotted;
                        gotInput = true;
                        break;
                    case "dancing":
                        _salesperson.WidgetItem.Type = TheTravelingSalesperson.WidgetItemStock.WidgetType.Dancing;
                        gotInput = true;
                        break;
                }
            }

            
            Console.WriteLine();

            if (_salesperson.WidgetItem.NumberOfUnits != 0)
            {
                was = $" (was set to: {_salesperson.WidgetItem.NumberOfUnits})";
            }

            gotInput = false;
            while (!gotInput)
            {
                ConsoleUtil.DisplayPromptMessage($"Enter the current number of widgets in your stock{was}: ");
                //reset inventory count if we're updating...
                if(_salesperson.WidgetItem.NumberOfUnits > 0)
                {
                    _salesperson.WidgetItem.SubtractWidgets(_salesperson.WidgetItem.NumberOfUnits);
                }

                if (Int32.TryParse(Console.ReadLine(), out qty)){
                    _salesperson.WidgetItem.AddWidgets(qty);
                    gotInput = true;
                }
                
            }
   
            Console.WriteLine();

            //
            // TODO prompt the user to input all of the required account information
            //

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a closing screen when the user quits the application
        /// </summary>
        public void DisplayClosingScreen()
        {
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Thanks for using this lame product!");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            //
            // TODO enable each application function separately and test
            //
            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Travel" + Environment.NewLine +
                    "\t" + "2. Buy" + Environment.NewLine +
                    "\t" + "3. Sell" + Environment.NewLine +
                    "\t" + "4. Update Account Info" + Environment.NewLine +
                    "\t" + "5. Display Inventory" + Environment.NewLine +
                    "\t" + "6. Display Cities Travelled" + Environment.NewLine +
                    "\t" + "7. Display Account Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {

                    case '1':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.UpdateAccountInformation;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '7':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    //case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        //
                        // TODO handle invalid menu responses from user
                        //
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }
        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";

            ConsoleUtil.HeaderText = "Next City of Travel";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayPromptMessage("Enter the name of the city: ");
            nextCity = Console.ReadLine();


            return nextCity;
        }

        /// <summary>
        /// get the number of widget units to buy from the user
        /// </summary>
        /// <returns>int number of units to buy</returns>
        public int DisplayGetNumberOfUnitsToBuy()
        {
            int numberOfUnitsToAdd = 0;
            bool gotinput = false;

            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();

            while (!gotinput)
            {
                ConsoleUtil.DisplayPromptMessage($"Enter the number of {_salesperson.WidgetItem.Type.ToString()} widgets to purchase: ");
                gotinput = Int32.TryParse(Console.ReadLine(), out numberOfUnitsToAdd);
                if (!(numberOfUnitsToAdd > 0))
                {   //got bad input.
                    gotinput = false;
                    numberOfUnitsToAdd = 0;
                }
            }


            return numberOfUnitsToAdd;
        }

        /// <summary>
        /// get the number of widget units to sell from the user
        /// </summary>
        /// <returns>int number of units to buy</returns>
        public int DisplayGetNumberOfUnitsToSell()
        {
            int numberOfUnitsToSell = 0;
            bool gotinput = false;

            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();

            while (!gotinput)
            {
                ConsoleUtil.DisplayPromptMessage($"Enter the number of {_salesperson.WidgetItem.Type.ToString()} widgets to sell: ");
                gotinput = Int32.TryParse(Console.ReadLine(), out numberOfUnitsToSell);
                if (!(numberOfUnitsToSell > 0))
                {   //got bad input.
                    gotinput = false;
                    numberOfUnitsToSell = 0;
                }
            }
            return numberOfUnitsToSell;
        }

        /// <summary>
        /// display the current inventory
        /// </summary>
        public void DisplayInventory()
        {
            ConsoleUtil.HeaderText = "Current Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Widget Type: " + _salesperson.WidgetItem.Type.ToString());
            ConsoleUtil.DisplayMessage("Widget Qty: " + _salesperson.WidgetItem.NumberOfUnits.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of the cities traveled
        /// </summary>
        public void DisplayCitiesTraveled()
        {
            ConsoleUtil.HeaderText = "Cities Traveled To";
            ConsoleUtil.DisplayReset();
            int count = 0;
            foreach (string city in _salesperson.Cities)
            {
                count++;
                ConsoleUtil.DisplayMessage(count+". "+city);
            }
            if (count ==0)
            {
                ConsoleUtil.DisplayMessage("No Cities Travelled yet.");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo()
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("First Name: " + _salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + _salesperson.LastName);
            ConsoleUtil.DisplayMessage("Account ID: " + _salesperson.AccountID);
            //ConsoleUtil.DisplayMessage("Widget Type: " + _salesperson.WidgetItem.Type.ToString());
            //ConsoleUtil.DisplayMessage("Widget Qty: " + _salesperson.WidgetItem.NumberOfUnits.ToString());


            DisplayContinuePrompt();
        }

        #endregion
    }
}