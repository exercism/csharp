using System;

namespace CollatzConjecture
{
    public static class CollatzConjecture
    {
        public static int GetSteps(int input)
        {
            if(input <= 0)
            {
                throw new ArgumentException("Only positive numbers are allowed");
            }

            int stepCount = 0;

            while(input != 1)
            {
                if(input % 2 == 0)
                {
                    input /= 2;
                }
                else
                {
                    input = (input * 3) + 1;
                }

                stepCount++;
            }

            return stepCount;
        }
    }
}
