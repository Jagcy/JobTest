using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_Four
{
    class Polar
    {
        /// <summary>
        /// rotate an gameobject around a given coordinate
        /// </summary>
        public static void Rotate(GameObject pGO, float pMagnitude, double pAngle, int px, int py)
        {
            pGO.x = px + (int)(Math.Cos(pAngle) * pMagnitude);
            pGO.y = py + (int)(Math.Sin(pAngle) * pMagnitude);
        }
    }
}
