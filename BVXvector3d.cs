using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bvx
{

    public struct BVXVector3d
    {

        public BVXVector3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        private double x;

        public double X 
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        private double y;

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        private double z;

        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
    }
}