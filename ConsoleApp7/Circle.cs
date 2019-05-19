using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Circle
    {
        public double GetCircleLength(double radius)
        {
            var length = Math.PI * 2 * radius;
            return length;
        }

        public double GetCircleSquare(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetSphereVolume(double radius)
        {
            return (double)4 / 3 * Math.PI * Math.Pow(radius, 3);
        }
    }
}
