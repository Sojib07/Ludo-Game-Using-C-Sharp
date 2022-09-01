using System;
using System.Collections.Generic;
using System.Text;

namespace ludo
{
    public class Track
    {
        public static int TrackLength;
        public static int RankCount=1;
        public List<Player> PlayerList { get; set; }


        public void MovePieceByDiceValue(Player player,int pieceNo,int diceValue)
        {
            bool isMatured = player.IsPieceMatured(pieceNo);
            
            int indexAfterMoving=player.MoveAPiece(pieceNo,diceValue);
            if (!player.Matured)
            {
                player.SetRankToPlayer();
            }
            Player existingPlayer = GetPlayerByTrackIndex(indexAfterMoving,player.color);
            if (existingPlayer != null)
            {
                RemoveAPiece(existingPlayer,indexAfterMoving);
            }


        }

        public void ShowTrackStatus()
        {
            Console.WriteLine();

            Console.WriteLine("Rankings....");

            Console.WriteLine($"{PlayerList[0].color} {PlayerList[0].Rank}   {PlayerList[1].color} {PlayerList[1].Rank}   {PlayerList[2].color} {PlayerList[2].Rank}   {PlayerList[3].color} {PlayerList[3].Rank}");


            Console.WriteLine();

            for (int i = TrackLength; i>=0; i--)
            {
                Console.Write(i + "     ");
                bool pieceExist = false;
                foreach(var player in PlayerList)
                {
                    foreach(var piece in player.pieceList)
                    {
                        if (!piece.IsLocked)
                        {
                            if (piece.Index == i)
                            {
                                Console.Write($"{player.color}{piece.PieceNo}");
                                Console.Write(" ");
                                pieceExist = true;
                            }
                        }
                    }

                }
               
                Console.WriteLine();

            }
            Console.WriteLine();

            foreach (var player in PlayerList)
            {
                Console.WriteLine($"{player.color}    {player.lockedPiecesNo}");
            }
            Console.WriteLine();

        }

        public void UnlockPiece(Player player)
        {
            foreach (var piece in player.pieceList)
            {
                if (piece.IsLocked)
                {
                    piece.IsLocked = false;
                    piece.Index = 0;
                    player.UnlockedPiecesNo++;
                    player.lockedPiecesNo--;
                    Console.WriteLine($"{player.color}{piece.PieceNo} unlocked");
                    break;
                }
            }
            Console.WriteLine();

        }
        public Player GetPlayerByTrackIndex(int index,Color color)
        {
            foreach(var player in PlayerList)
            {
                if (player.color == color)
                {
                    continue;
                }
                foreach (var piece in player.pieceList)
                {
                    if (piece.Index == index)
                    {
                        return player;
                    }
                }
            }
            return null;
        }

        public void RemoveAPiece(Player existingPlayer,int indexAfterMoving)
        {
            foreach (var piece in existingPlayer.pieceList)
            {
                if (piece.IsMatured == true)
                {
                    continue;
                }
                if (piece.Index == indexAfterMoving)
                {
                    piece.IsLocked = true;
                    piece.Index = 0;
                    existingPlayer.UnlockedPiecesNo--;
                    existingPlayer.lockedPiecesNo++;
                    if (existingPlayer.lockedPiecesNo > 4)
                    {
                        Console.WriteLine(existingPlayer.lockedPiecesNo);
                    }
                }
            }
        }
    }
}
