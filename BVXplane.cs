using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bvx
{
    public struct BVXPlane
    {
        private BVXVector3d origin;

        public BVXVector3d Origin 
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
            }
        }

        private double rotationX;

        public double RotationX
        {
            get
            {
                return rotationX;
            }
            set
            {
                rotationX = value;
            }
        }

        private double rotationY;

        public double RotationY
        {
            get
            {
                return rotationY;
            }
            set
            {
                rotationY = value;
            }
        }

        private double rotationZ;

        public double RotationZ
        {
            get
            {
                return rotationZ;
            }
            set
            {
                rotationZ = value;
            }
        }
    }
}
