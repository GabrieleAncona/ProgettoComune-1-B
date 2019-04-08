
using UnityEngine;

namespace GridSystem
{


    [CreateAssetMenu(fileName = "New Grid config", menuName = "Grid/Config", order = 1)]
    public class GridConfigData : ScriptableObject
    {

        [SerializeField]
        internal int DimX;
        [SerializeField]
        internal int DimY;
        [SerializeField]
        internal int CellDim;

    }
}
