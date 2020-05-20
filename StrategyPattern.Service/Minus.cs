using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Service
{
    public class Minus : ICaculation
    {
        public int Caculation(int iInpuLeft, int iInputRight)
        {
            return iInpuLeft - iInputRight;
        }
    }
}
