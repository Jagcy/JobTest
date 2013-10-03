using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_Four
{
    class Planet : GameObject
    {
        public float orbitMagnitude;
        public float orbitDegree;
        public float orbitSpeed;

        /// <summary>
        /// constructor
        /// </summary>
        public Planet(string name = "", string nametex = "", int px = 0, int py = 0, float pscalex = 0f, float pscaley = 0f, float porbitmagnitude = 0f, float porbitdegree = 0f, float porbitspeed = 0f, bool locked = false) : base(name, nametex, px, py, pscalex, pscaley, locked)
        {
            orbitMagnitude = porbitmagnitude;
            orbitDegree = porbitdegree;
            orbitSpeed = porbitspeed;
        }
    }
}
