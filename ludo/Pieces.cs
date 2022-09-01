using System;
using System.Collections.Generic;
using System.Text;

namespace ludo
{
    public class Piece
    {
        public int PieceNo { get; set; }
        public int Index { get; set; }
        public bool IsLocked { get; set; }
        public bool IsMatured { get; set; }
        public Piece(int no)
        {
            PieceNo = no;
            IsLocked = true;
            IsMatured = false;
        }
    }
}
