using System.Collections.Generic;

namespace Lib
{
    public static class RandomicDouble
    {
        public static double GenRandomicDouble(double StartNumber, double FinalNumber, int PrecisionDecimal = 3, List<double> DoublesToIgnore = null)
            => new RandomCustomDouble(StartNumber: StartNumber, FinalNumber: FinalNumber, PrecisionDecimal: PrecisionDecimal = 2, DoublesToIgnore: DoublesToIgnore = null).Process();
    }
}
