using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweepreProject.Util
{
    class MineSweepreFunction
    {
        public bool[,] CreateMineLocations(int width, int height, int mineCount)
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

        public List<int> GetRandomNumberList(int maxCount, int selectCount)
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

    }
}
