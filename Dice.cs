using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    class Dice
    {
        #region properties

        private string _color;
        private int _numSides;

        #endregion
        #region constructors
        public Dice(int _numSides, string _color)
        {
            {
                this.NumSides = _numSides;
                this.Color = _color;
            }
        }

        public string Color
        { get; set; }

        public int NumSides
        { get; set; }

        #endregion 
    }
}
