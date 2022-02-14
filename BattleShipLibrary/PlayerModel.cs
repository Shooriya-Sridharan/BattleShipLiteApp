using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipLibrary
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public int NumOfShots { get; set; }
        public PlayerModel opponent { get; set; }
        public int ShipsRemaining { get; private set; }

        List<string> positionShips;

    List<string> positionPlaced;
        public PlayerModel()
        {
             positionPlaced = new List<string>
             {
                "A1","A2","A3","A4","A5",
                "B1","B2","B3","B4","B5",
                "C1","C2","C3","C4","C5",
                "D1","D2","D3","D4","D5",
                "E1","E2","E3","E4","E5",
             };

            positionShips = new List<string>
            {
                "A1","A2","A3","A4","A5",
                "B1","B2","B3","B4","B5",
                "C1","C2","C3","C4","C5",
                "D1","D2","D3","D4","D5",
                "E1","E2","E3","E4","E5",
            };
        }
       

        List<GridSpot> placedShips = new List<GridSpot>();
         List<GridSpot> shots = new List<GridSpot>();
        List<GridSpot> opponentShips = new List<GridSpot>();
        
        public bool Shoot(string position)
        {
            if (GridHelper.CheckPositions(position, shots) == false)
                return false;


            shots.Add(CreateGrid(position));
            if(HasBeenHit())
            {
                PrintPositions(position, "{}", positionShips);
            }
            else
            {
                PrintPositions(position, "[]", positionShips);
            }


            return true;
        }
        public bool HasGameWon()
        {
            return opponent.ShipsRemaining == 0;
        }
        private bool HasBeenHit()
        {
           
            foreach (var oppPlaced in opponent.placedShips)
            {
                if (oppPlaced.GridPosition == shots[shots.Count - 1].GridPosition &&
                    oppPlaced.GridNum == shots[shots.Count - 1].GridNum)
                {
                    Console.WriteLine($"hit at {shots[shots.Count - 1].GridPosition}{shots[shots.Count - 1].GridNum}");
                    opponentShips.Add(oppPlaced);
                    opponent.ShipsRemaining--;
                    return true;
                }
                
            }
            return false;

        }

        private static GridSpot CreateGrid(string position)
        {
            GridSpot grid = new GridSpot();
            grid.GridPosition = position[0].ToString();
            grid.GridNum = int.Parse(position[1].ToString());
            grid.hasFired = true;
            return grid;
        }

        public bool Place(string position)
        {
            if (GridHelper.CheckPositions(position,placedShips) == false)
                return false;

            placedShips.Add(CreateGrid(position));
            int index = GridHelper.GetIndexFromPosition(position);
            positionPlaced[index] = "[]";
            
            
            ShipsRemaining++;
            return true;
        }

        private void PrintPositions(string position, string placeHolder, List<string> gridList)
        {
            int index = GridHelper.GetIndexFromPosition(position);

            gridList[index] = placeHolder;
            GridHelper.printGrid(gridList);
           
        }
        
        public void PrintPlacedShips()
        {
            GridHelper.printGrid(positionPlaced);
        }

        

        

       

       
    }
}
