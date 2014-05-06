using System.Collections.Generic;
using System.Linq;

namespace ExercismCSharp.sum_of_multiples
{
    public class SumOfMultiples
    {
        private List<int> multiples;

        public SumOfMultiples()
        {
            multiples = new List<int> { 5, 3 };
        }

        public SumOfMultiples(IEnumerable<int> multiplesToCheck)
        {
            multiples = multiplesToCheck.ToList();
        }

        public int To(int limit)
        {
            int sum = 0;

            for (int i = 1; i < limit; i++)
            {
                if (IsMultiple(i))
                {
                    sum += i;
                }
            }

            return sum;
        }

        private bool IsMultiple(int input)
        {
            bool isMultiple = false;

            if (multiples.Any())
            {
                multiples.ForEach(multiple =>
                {
                    if (input % multiple == 0)
                    {
                        isMultiple = true;
                    }
                });
            }

            return isMultiple;
        }
    }
}