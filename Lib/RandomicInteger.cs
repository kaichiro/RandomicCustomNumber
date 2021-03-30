using System.Collections.Generic;

namespace Lib
{
    public static class RandomicInteger
    {
        public static int GenRandomicInt(int StartNumber, int FinalNumber, List<int> IntsToIgnore = null)
            => new RandomCustomInteger(StartNumber: StartNumber, FinalNumber: FinalNumber, IntsToIgnore: IntsToIgnore).Process();
    }
}
