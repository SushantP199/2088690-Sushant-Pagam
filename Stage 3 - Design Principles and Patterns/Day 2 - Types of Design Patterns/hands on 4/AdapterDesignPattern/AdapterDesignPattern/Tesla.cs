using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPattern
{
    public class Tesla : Movable
    {
        public double getSpeed()
        {
            return 268;
        }
        public double getPrice()
        {
            return 200;
        }
    }
}
