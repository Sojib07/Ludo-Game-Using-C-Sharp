using System;
using System.Collections.Generic;
using System.Text;

namespace ludo
{
    public class Player:Person
    {
        public Color color { get; set; }
        public int UnlockedPiecesNo { get; set; }
        public int lockedPiecesNo { get; set; }
        public bool Matured { get; set; }
        public int Rank { get; set; }

        public List<Piece> pieceList { get; set; }
        public Player(Color color, List<Piece> pieceList)
        {
            this.color = color;
            this.UnlockedPiecesNo = 0;
            this.lockedPiecesNo = 4;
            this.Matured = false;
            this.pieceList = pieceList;
        }

        public void UnlockPiece(Player player)
        {
            foreach(var piece in player.pieceList)
            {
                if (piece.IsLocked)
                {
                    piece.IsLocked = false;
                    piece.Index = 0;
                    lockedPiecesNo--;
                    List<Piece> abc = pieceList;
                    break;
                }
            }
        }
        public int MoveAPiece(int pieceNo,int step)
        {
            if (pieceList[pieceNo - 1].IsMatured)
            {
                throw new Exception("This piece is already matured");
            }
            pieceList[pieceNo - 1].Index += step;
            if(pieceList[pieceNo - 1].Index >= Track.TrackLength)
            {
                pieceList[pieceNo - 1].IsMatured = true;
                pieceList[pieceNo - 1].Index = Track.TrackLength;
                UnlockedPiecesNo--;
            }
            
            return pieceList[pieceNo - 1].Index;
        }
        public bool IsPieceMatured(int pieceNo)
        {
            return pieceList[pieceNo - 1].Index>Track.TrackLength;
        }
        public int SetRankToPlayer()
        {
            bool flag = true;
            foreach(var piece in pieceList)
            {
                if (!piece.IsMatured)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Matured = true;
                Rank = Track.RankCount++;

            }
            return Rank;
        }
    }


    public enum Color
    {
        RED,BLUE,GREEN,YELLOW
    }
}
