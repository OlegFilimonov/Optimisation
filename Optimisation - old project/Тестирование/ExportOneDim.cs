using System;
using System.Drawing;

// ReSharper disable All

namespace Optimisation.Тестирование
{
    public class ExportOneDim
    {
        public ExportOneDim(string methodName, uint iterCount, string answer, string realMin, double requestedEps,
            double realEps)
        {
            MethodName = methodName;
            IterCount = iterCount;
            Answer = answer;
            RealMin = realMin;
            RequestedEps = requestedEps;
            RealEps = realEps;
        }

        public ExportOneDim(string methodName, uint iterCount, double answer, double realMin, double requestedEps,
            double realEps)
        {
            MethodName = methodName;
            IterCount = iterCount;
            Answer = Convert.ToString(answer);
            RealMin = Convert.ToString(realMin);
            RequestedEps = requestedEps;
            RealEps = realEps;
        }

        public ExportOneDim(string methodName, uint iterCount, PointF answer, PointF realMin, double requestedEps,
            double realEps)
        {
            MethodName = methodName;
            IterCount = iterCount;
            Answer = Convert.ToString(answer.X + "; " + answer.Y);
            RealMin = Convert.ToString(realMin.X + "; " + realMin.Y);
            RequestedEps = requestedEps;
            RealEps = realEps;
        }

        public string MethodName { get; set; }

        public uint IterCount { get; set; }

        public string Answer { get; set; }

        public string RealMin { get; set; }

        public double RequestedEps { get; set; }

        public double RealEps { get; set; }

        public string FunctionName { get; set; }
    }
}