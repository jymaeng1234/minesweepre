using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweepreProject.Util
{
    public class MineSweepreFunction
    {
        public static bool[,] CreateMineLocations(int width, int height, int mineCount)
        {
            //지뢰는 랜덤하게 생성됩니다.
            //지뢰는 중복되지 않습니다.

            bool[,] MineMatrix = new bool[width, height];
            int MatrixSize = width * height;

            List<int> selectedNumList = GetRandomNumberList(MatrixSize, mineCount);
            int idx = 0;

            for (int row = 0; row < width; row++)
            {
                for (int col = 0; col < height; col++)
                {
                    idx = row * height + col;

                    MineMatrix[row, col] = selectedNumList.Contains(idx) ? true : false;
                }
            }

            return MineMatrix;
        }

        public static List<int> GetRandomNumberList(int maxCount, int selectCount)
        {
            List<int> selectedList = new List<int>();
            int selectedNum;

            for (int idx = 0; idx < selectCount; idx++)
            {
                do
                {
                    selectedNum = new Random().Next(0, maxCount);
                } while (selectedList.Contains(selectedNum));

                selectedList.Add(selectedNum);
            }
            return selectedList;
        }


        public static int[,] CreateMineMap(bool[,] mineLocations)
        {
            //주변8칸의 지뢰수를 반환합니다.
            //주변에 지뢰가 없거나, 해당위치가 지뢰인 경우에는 0을 반환합니다.

            int mineRow = mineLocations.GetLength(0);
            int mineCol = mineLocations.GetLength(1);

            int[,] mineMap = new int[mineRow, mineCol];

            for (int idxRow = 0; idxRow < mineRow; idxRow++)
            {
                for (int idxCol = 0; idxCol < mineCol ; idxCol++)
                {
                    mineMap[idxRow, idxCol] = GetSurroundMineCount(idxRow, idxCol, mineLocations);
                }
            }

            return mineMap;
        }

        public static int GetSurroundMineCount(int x, int y, bool[,] mineLocations)
        {
            int mineCount = 0;
            int mineRow = mineLocations.GetLength(0);
            int mineCol = mineLocations.GetLength(1);

            for (int idxRow = x - 1; idxRow <= x + 1; idxRow++)
            {
                for (int idxCol = y - 1; idxCol <= y + 1; idxCol++)
                {
                    if (idxRow == x && idxCol == y) continue;
                    if (idxRow < 0 || idxCol < 0) continue;
                    if (idxRow == mineRow || idxCol == mineCol) continue;

                    if (mineLocations[idxRow, idxCol]) mineCount++;


                }
            }

            return mineCount;            
        
        }
    }
}
