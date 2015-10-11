using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Тестирование
{
    public class ExportTwoDim
    {
        private string methodName;

        private uint iterCount;

        private double answerX;
        private double answerY;

        private double realMinX;
        private double realMinY;

        private double requestedEps;
        private double realEps;

        public ExportTwoDim(string methodName, uint iterCount, double answerX, double answerY, double realMinX, double realMinY, double requestedEps, double realEps)
        {
            this.methodName = methodName;
            this.iterCount = iterCount;
            this.answerX = answerX;
            this.answerY = answerY;
            this.realMinX = realMinX;
            this.realMinY = realMinY;
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

        public double AnswerX
        {
            get { return answerX; }
            set { answerX = value; }
        }

        public double AnswerY
        {
            get { return answerY; }
            set { answerY = value; }
        }

        public double RealMinX
        {
            get { return realMinX; }
            set { realMinX = value; }
        }

        public double RealMinY
        {
            get { return realMinY; }
            set { realMinY = value; }
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
