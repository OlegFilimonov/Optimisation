using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    public class ExportOneDim
    {
        public ExportOneDim(string methodName, uint iterCount, string answer, string realMin, double requestedEps, double realEps)
        {
            this.MethodName = methodName;
            this.IterCount = iterCount;
            this.Answer = answer;
            this.RealMin = realMin;
            this.RequestedEps = requestedEps;
            this.RealEps = realEps;
        }

        public ExportOneDim(string methodName, uint iterCount, double answer, double realMin, double requestedEps, double realEps)
        {
            this.MethodName = methodName;
            this.IterCount = iterCount;
            this.Answer = Convert.ToString(answer);
            this.RealMin = Convert.ToString(realMin);
            this.RequestedEps = requestedEps;
            this.RealEps = realEps;
        }

        public ExportOneDim(string methodName, uint iterCount, PointF answer, PointF realMin, double requestedEps, double realEps)
        {
            this.MethodName = methodName;
            this.IterCount = iterCount;
            this.Answer = Convert.ToString(answer.X + "; " + answer.Y);
            this.RealMin = Convert.ToString(realMin.X + "; " + realMin.Y);
            this.RequestedEps = requestedEps;
            this.RealEps = realEps;
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
