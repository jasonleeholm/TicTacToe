using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        public String myPiece { get; set; }
        public string myType { get; set; }
        public string mySkill { get; set; }

        public Player(string piece = "!", string type = "Human", string skill = "Amateur")
        {
            myPiece = piece;
            myType = type;
            mySkill = skill;
        }
    }
}
