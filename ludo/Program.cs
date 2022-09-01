using System;
using System.Collections.Generic;

namespace ludo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the no of sides of dice");
            Dice.DiceSize = int.Parse(Console.ReadLine());
            List<Piece> piecesList = new List<Piece>(){new Piece(1),new Piece(2),new Piece(3),new Piece(4)};
            List<Player> list = new List<Player>()
            {
                new Player(Color.RED,new List<Piece>(){new Piece(1),new Piece(2),new Piece(3),new Piece(4)}),
                new Player(Color.BLUE,new List<Piece>(){new Piece(1),new Piece(2),new Piece(3),new Piece(4)}),
                new Player(Color.GREEN,new List<Piece>(){new Piece(1),new Piece(2),new Piece(3),new Piece(4)}),
                new Player(Color.YELLOW,new List<Piece>(){new Piece(1),new Piece(2),new Piece(3),new Piece(4)})
            };

            Track track = new Track();
            track.PlayerList = list;
            Console.WriteLine("Enter the length of track: ");
            Track.TrackLength = int.Parse(Console.ReadLine());

            track.ShowTrackStatus();
            for(int i = 0; i < 1000; i++)
            {
                foreach(var player in track.PlayerList)
                {
                    if (!player.Matured)
                    {
                        
                        int diceValue=Dice.RollDice();
                        Console.WriteLine($"{player.color} player's dice value is: {diceValue}");
                        if (diceValue == Dice.DiceSize && player.lockedPiecesNo > 0)
                        {
                                Console.WriteLine("Do you want to unlock a piece?y/n");
                                if (Console.ReadLine() == "y")
                                {
                                    track.UnlockPiece(player);
                                    track.ShowTrackStatus();
                                    continue;
                                }
                        }
                        if (player.UnlockedPiecesNo>0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Which piece do you want to move?");
                            int pieceNo = int.Parse(Console.ReadLine());
                            track.MovePieceByDiceValue(player, pieceNo, diceValue);
                            track.ShowTrackStatus();
                        }
                        else
                        {
                            Console.WriteLine("No Unlocked pieces");
                            Console.WriteLine();

                        }

                    }
                }
            }
        }
    }
}
