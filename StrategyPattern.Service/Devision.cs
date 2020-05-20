using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Service
{
    public class Devision : ICaculation
    {
        public int Caculation(int iInpuLeft, int iInputRight)
        {
            if (iInputRight == 0) throw new Exception();
            return iInpuLeft / iInputRight;
        }
    }
}
