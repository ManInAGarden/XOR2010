using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Shield : Element
    {
        public Shield()
            : base()
        {
        }

        override public bool CanMoveTo(int toX, int toY)
        {
            Element elWhereWeGo = World.ElementAt(toX, toY);
            if (elWhereWeGo == null) return true;

            if (elWhereWeGo.CanBeEaten(this))
            {
                elWhereWeGo.Eat();
                return true;
            }
            else
                return false;
        }

        public override bool CanBeEaten(Element by)
        {
            //we can only be eaten by chicken or fish in movement
            bool answ = false;
            MovePiece mp = by as MovePiece;
            

            if ((mp != null) && (mp.IsMoving) && !(mp is Doll))
                answ = true;
            else
            {
                Bomb bomb = by as Bomb;
                if ((bomb != null) && (bomb.IsMoving))
                    answ = true;
            }

            return answ;
        }

        public override void Eat()
        {
            MainFrm.OoopsShield(this);
            //MainFrm.DecrementShieldCount(); // End game is in here when there's no shield left

            //when the currently active shield died switch to the other one
            //if(MainFrm.CurrShield==this)
            //    MainFrm.SwitchShield();

            base.Eat();
        }

       
    }
}
