using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW9DartsForPie
{
    class FindPiThread
    {
        private int totalDarts;
        private int innerCircleDarts;
        private Random throwGenerator;

        public FindPiThread(int totalDarts)
        {
            this.totalDarts = totalDarts;
            innerCircleDarts = 0;
            throwGenerator = new Random();
        }

        public int getInnerCircleDarts()
        {
            return innerCircleDarts;
        }

        public void throwDarts()
        {
            while(totalDarts > 0)
            {
                double x = throwGenerator.NextDouble();
                double y = throwGenerator.NextDouble();

                if(Math.Sqrt(x * x + y * y) <= 1)
                {
                    innerCircleDarts += 1;
                }
                totalDarts--;
            }
        }
    }
}
