using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    public class Salesperson
    {
        #region FIELDS

        private string _firstName;
        private string _lastName;
        private string _accountID;
        WidgetItemStock _widgetItem;
        
        private List<string> _citiesVisited;



        #endregion

        #region PROPERTIES

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public List<string> Cities
        {
            get { return _citiesVisited; }
            set { _citiesVisited = value; }
        }
        public string AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }

        public WidgetItemStock WidgetItem
        {
            get => _widgetItem;
            set => _widgetItem = value;
        }


        #endregion

        #region CONSTRUCTORS

        public Salesperson()
        {
            InitializeSalesperson();
        }

        public Salesperson(string firstName)
        {
            InitializeSalesperson();
            _firstName = firstName;
        }

        public Salesperson(string firstName, string lastName)
        {
            InitializeSalesperson();
            _firstName = firstName;
            _lastName = lastName;
        }
        #endregion


        #region METHODS
        private void InitializeSalesperson()
        {
            WidgetItem = new WidgetItemStock();
            _citiesVisited = new List<string>();
        }


        #endregion
    }
}
