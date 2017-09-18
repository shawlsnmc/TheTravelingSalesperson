using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTravelingSalesperson
{
    public class WidgetItemStock
    {
        #region ENUMERABLES

        public enum WidgetType
        {
            None,
            Furry,
            Spotted,
            Dancing
        }

        #endregion
        
        #region FIELDS

        private WidgetType _type;
        private int _numberOfUnits;

        #endregion

        
        #region PROPERTIES

        public WidgetType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int NumberOfUnits
        {
            get { return _numberOfUnits; }
        }

        #endregion


        #region CONSTRUCTORS

        public WidgetItemStock()
        {
            _type = WidgetType.None;
            _numberOfUnits = 0;
        }

        public WidgetItemStock(WidgetType type, int numberOfUnits)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
        }

        #endregion


        #region METHODS

        /// <summary>
        /// add widgets to the inventory
        /// </summary>
        /// <param name="unitsToAdd">number of units to add</param>
        public void AddWidgets(int unitsToAdd)
        {
            _numberOfUnits += unitsToAdd;
        }

        // TODO - validate to disable negative stock unit values
        /// <summary>
        /// subtract widgets from the inventory
        /// </summary>
        /// <param name="unitsToSubtract">number of units to subtract</param>
        public void SubtractWidgets(int unitsToSubtract)
        {
            _numberOfUnits -= unitsToSubtract;
        }

        #endregion
    }
}
