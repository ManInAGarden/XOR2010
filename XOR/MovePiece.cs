using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class MovePiece : Element
    {
        bool m_isMoving;

        public bool IsMoving
        {
            get { return m_isMoving; }
            set { m_isMoving = value; }
        }

        public MovePiece()
            : base()
        {
            
        }

     
    }
}
