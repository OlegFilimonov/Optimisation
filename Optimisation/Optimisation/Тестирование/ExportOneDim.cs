using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    public class ExportOneDim
    {
        private string methodName;
        private uint iterCount;
        private double answer;
        private double realMin;
        private double requestedEps;
        private double realEps;

        public ExportOneDim(string methodName, uint iterCount, double answer, double realMin, double requestedEps, double realEps)
        {
            this.methodName = methodName;
            this.iterCount = iterCount;
            this.answer = answer;
            this.realMin = realMin;
            this.requestedEps = requestedEps;
            this.realEps = realEps;
        }

        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }

        public uint IterCount
        {
            get { return iterCount; }
            set { iterCount = value; }
        }

        public double Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public double RealMin
        {
            get { return realMin; }
            set { realMin = value; }
        }

        public double RequestedEps
        {
            get { return requestedEps; }
            set { requestedEps = value; }
        }

        public double RealEps
        {
            get { return realEps; }
            set { realEps = value; }
        }
    }
}
