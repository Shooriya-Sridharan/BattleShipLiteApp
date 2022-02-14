using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipLibrary
{
    static internal class GridHelper
    {
        public static bool isGridValid(string position)
        {
            if (position.Length > 2)
                return false;

            if ((position[0] >= 'A' && position[0] <= 'E') == false)
                return false;

            if ((position[1] >= '0' && position[1] <= '5') == false)
                return false;

            return true;
        }

        public static string GetPositionFromString(string position)
        {
            return position[0].ToString();
        }

        public static int GetNumFromSring(string position)
        {
            return int.Parse(position[1].ToString());
        }

        public static bool CheckPositions(string position, List<GridSpot> grids)
        {
            if (isGridValid(position) == false)
            {
                return false;
            }

            if (hasShotOrPlaced(position, grids) == true)
            {
                return false;
            }
            return true;
        }

        private static bool hasShotOrPlaced(string position, List<GridSpot> grids)
        {
            if (grids == null)
                return false;
            foreach (GridSpot grid in grids)
            {
                if (position[0].ToString() != grid.GridPosition ||
                    position[1].ToString() != grid.GridNum.ToString())
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        internal static void printGrid(List<string> gridList)
        {
            for (int i = 0; i < gridList.Count; i++)
            {
                if ((i % 5 == 0))
                    Console.WriteLine();
                Console.Write(gridList[i]);
            }
            Console.WriteLine();
        }
        internal static int GetIndexFromPosition(string position)
        {
            int index = (position[0] - 'A') * 5 + int.Parse(position[1].ToString()) - 1;
            return index;
        }
    }
}
