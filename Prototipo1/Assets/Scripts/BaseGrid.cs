using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{

    public class BaseGrid : MonoBehaviour
    {

        [SerializeField]
        private GridConfigData configData;

        public GameObject CellPrefab;

        protected List<Cell> Cells = new List<Cell>();

        void Start()
        {
            CreateGrid(configData);
        }

        #region API

        public void CreateGrid(GridConfigData _configData)
        {
            // iterazione per la dimensione X della griglia
            for (int x = 0; x < configData.DimX; x++)
            {
                for (int y = 0; y < configData.DimY; y++)
                {

                    Cell cellToAdd = new Cell(x, y, new Vector3(
                        transform.position.x + (x * configData.CellDim),
                        0,
                        transform.position.z + (y * configData.CellDim)
                        ));

                    Cells.Add(cellToAdd);
                    // Debug
                    Instantiate(CellPrefab, cellToAdd.worldPosition, Quaternion.identity);
                }
            }
        }

        public Vector3 GetWorldPosition(int _x, int _y)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.x == _x && cell.y == _y)
                {
                    return cell.worldPosition;
                }
            }

            return Vector3.zero;
        }

        #endregion

    }
}
