using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GridSystem {

    public class Cell
    {

        internal int x, y;
        internal Vector3 worldPosition;

        public Cell(int _x, int _y, Vector3 _worldPosition)
        {

            x = _x;
            y = _y;
            worldPosition = _worldPosition;

        }

    }
}
