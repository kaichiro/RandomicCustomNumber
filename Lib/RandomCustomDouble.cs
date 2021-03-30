using System;
using System.Collections.Generic;

namespace Lib
{
    public class RandomCustomDouble
    {
        private double startNumber;
        private double finalNumber;
        private readonly int precisionDecimal;
        private List<double> doublesToIgnore;

        public RandomCustomDouble(double StartNumber, double FinalNumber, int PrecisionDecimal = 3, List<double> DoublesToIgnore = null)
        {
            startNumber = StartNumber;
            finalNumber = FinalNumber;
            precisionDecimal = PrecisionDecimal;
            doublesToIgnore = DoublesToIgnore ?? new List<double> ();
        }

        private double NormalizeDecimalsDouble(double numb) 
        {
            int intPart = (int) numb;
            double durtyDoublePart = numb - intPart;
            double doublePart = durtyDoublePart * Math.Pow(10, precisionDecimal);
            int onlyDoublePartPrecision = (int) doublePart;
            double numb1 = intPart + (onlyDoublePartPrecision / Math.Pow(10, precisionDecimal));
            return numb1;
        }

        private List<double> NormalizeDecimalsDoublesToIgnore()
        {
            List<double> listDouble = new List<double> ();
            doublesToIgnore.ForEach(delegate (double item)
            {
                listDouble.Add(NormalizeDecimalsDouble(item));
            });
            return listDouble;
        }

        private void NormalizeFields()
        {
            startNumber = NormalizeDecimalsDouble(startNumber);
            finalNumber = NormalizeDecimalsDouble(finalNumber);
            doublesToIgnore = NormalizeDecimalsDoublesToIgnore();
        }

        private double NewDoubleRandom => 
            NormalizeDecimalsDouble(RandomicInteger.GenRandomicInt(StartNumber: (int)startNumber, FinalNumber: (int)finalNumber) + new Random().NextDouble());
        // private double NewDoubleRandom()
        // {
        //     int intRandom = new RandomCustomInteger(StartNumber: (int)startNumber, FinalNumber: (int)finalNumber).Process();
        //     double newDoubleRand = intRandom + new Random().NextDouble();
        //     return NormalizeDecimalsDouble(newDoubleRand);
        // }

        public double Process()
        {
            NormalizeFields();
            if (startNumber >= finalNumber) return startNumber;
            double varNewDoubleRandom = NewDoubleRandom;
            for (int i = 0; i < 100; i++)
            {
                if (varNewDoubleRandom >= startNumber && varNewDoubleRandom <= finalNumber && !doublesToIgnore.Exists(item => item.Equals(varNewDoubleRandom))) break;
                varNewDoubleRandom = NewDoubleRandom;
                if (i.Equals(99))
                {
                    varNewDoubleRandom = startNumber;
                    break;
                }
            }
            return varNewDoubleRandom;
        }

        public string AsString()
        {
            string v = $"| PrecisionDecimal: {precisionDecimal}";
            string concatDoubles = string.Empty;
            doublesToIgnore.ForEach(delegate (double item)
            {
                concatDoubles += (concatDoubles.Equals(string.Empty) ? "": "  ") + item.ToString();
            });
            string v1 = $"| {(doublesToIgnore.Count > 0 ? string.Concat("doublesToIgnore: ", concatDoubles) : string.Empty)}";
            return $"startNumber: {startNumber} | finalNumber: {finalNumber} {v} {v1}";
        } 

        public override string ToString() 
        {
            double v = Process();
            return $"{AsString()} | new Double Random: {v}";
        }
    }
}