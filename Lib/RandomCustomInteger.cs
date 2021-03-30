using System;
using System.Collections.Generic;

namespace Lib
{
    public class RandomCustomInteger
    {
        private readonly int startNumber;
        private readonly List<int> intsToIgnore;
        private readonly int finalNumber;

        public RandomCustomInteger(int StartNumber, int FinalNumber, List<int> IntsToIgnore = null)
        {
            startNumber = StartNumber;
            finalNumber = FinalNumber;
            intsToIgnore = IntsToIgnore ?? new List<int> ();
            finalNumber = FinalNumber + 1;
        }

        private int GenNewIntRandomic => new Random().Next(minValue: startNumber, maxValue: finalNumber);

        public int Process()
        {
            if (startNumber >= finalNumber) return startNumber;
            int newIntRandom = GenNewIntRandomic;
            for (int i = 0; i < 100; i++)
            {
                if(newIntRandom >= startNumber && newIntRandom <= finalNumber && !intsToIgnore.Exists(item => item.Equals(newIntRandom))) break;
                newIntRandom = GenNewIntRandomic;
                if (i.Equals(99))
                {
                    newIntRandom = startNumber;
                    break;
                }
            }
            return newIntRandom;
        }
    }
}
