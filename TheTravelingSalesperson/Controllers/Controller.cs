using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    public class Controller
    {
        #region FIELDS

        private bool _usingApplication;

        //
        // declare ConsoleView and Salesperson objects for the Controller to use
        // Note: There is no need for a Salesperson or ConsoleView property given only the Controller 
        //       will access the ConsoleView object and will pass the Salesperson object to the ConsoleView.
        //
        private ConsoleView _consoleView;
        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            InitializeController();

            //
            // instantiate a Salesperson object
            //
            _salesperson = new Salesperson();

            //
            // instantiate a ConsoleView object
            //
            _consoleView = new ConsoleView(_salesperson);

            //
            // begins running the application UI
            //
            ManageApplicationLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the controller 
        /// </summary>
        private void InitializeController()
        {
            _usingApplication = true;
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageApplicationLoop()
        {
            MenuOption userMenuChoice;

            _consoleView.DisplayWelcomeScreen();

            _consoleView.DisplaySetupAccount();

            //
            // application loop
            //
            while (_usingApplication)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        break;
                    case MenuOption.DisplayAccountInfo:
                        _consoleView.DisplayAccountInfo();
                        break;
                    case MenuOption.DisplayCities:
                        _consoleView.DisplayCitiesTraveled();
                        break;
                    case MenuOption.Travel:
                        string _nextCity;
                        _nextCity = _consoleView.DisplayGetNextCity();
                        //only add city if we were actually given a city
                        if (_nextCity != "") {
                            _salesperson.Cities.Add(_nextCity);
                        }
                        break;
                    case MenuOption.Buy:
                        _salesperson.WidgetItem.AddWidgets(_consoleView.DisplayGetNumberOfUnitsToBuy());
                        break;
                    case MenuOption.Sell:
                        _salesperson.WidgetItem.SubtractWidgets(_consoleView.DisplayGetNumberOfUnitsToSell());
                        break;
                    case MenuOption.DisplayInventory:
                        _consoleView.DisplayInventory();
                        break;
                    case MenuOption.UpdateAccountInformation:
                        _consoleView.DisplaySetupAccount();
                        break;
                    case MenuOption.Exit:
                        _usingApplication = false;
                        break;
                    default:
                        break;
                }
            }

            _consoleView.DisplayClosingScreen();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        #endregion
    }
}
