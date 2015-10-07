using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPlotLibrary;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation
{
    public partial class MainForm
    {
        void addTwoDimFunction(string source, function2D f, function2D dfx1, function2D dfx2, PointF start, PointF dir, PointF min, string name)
        {
            var graphFunction = new Function2D();
            graphFunction.source = source;
            graphFunction.Compile(true);
            graphFunction.Color = Color.Red;
            graphFunctions.Add(graphFunction);
            testingFunctions.Add(new FunctionTwoDim(start, min, dir, f, dfx1, dfx2, name));
        }

        void populateFunctions3()
        {
            addTwoDimFunction("return ((pow(x,2)+3*pow(y,2)+2*x*y)%1 < 0.1)?0:1;", TwoDimTestingFunctions.f1,
                TwoDimTestingFunctions.df1x1, TwoDimTestingFunctions.df1x2, new PointF(1, 1), new PointF(2, 3),
                new PointF(0.2558f, -0.1163f), "Функция №10: x1^2+3x2^2+2x1x2");

            addTwoDimFunction("return 100*pow(y-pow(x,2),2)+pow(1-x,2);", TwoDimTestingFunctions.f2,
                TwoDimTestingFunctions.df2x1, TwoDimTestingFunctions.df2x2, new PointF(-1, 0), new PointF(5, 1),
                new PointF(-0.3413f, 0.13172f), "Функция 11: 100(x2-x1^2)^2+(1-x1)^2");

            addTwoDimFunction("return -12*y+4*pow(x,2)+4*pow(y,2)-4*x*y;", TwoDimTestingFunctions.f3,
                TwoDimTestingFunctions.df3x1, TwoDimTestingFunctions.df3x2, new PointF(-0.5f, 1), new PointF(1, 0),
                new PointF(0.5f, 1), "Функция №12: -12x2+4x1^2+4x2^2-4x1x2");

            addTwoDimFunction("return pow(x-2,4)+pow(x-2*y,2);", TwoDimTestingFunctions.f4,
                TwoDimTestingFunctions.df4x1, TwoDimTestingFunctions.df4x2, new PointF(0, 3), new PointF(1, 0),
                new PointF(3.13f, 3.00f), "Функция №13: (x1-2)^4+(x1-2x2)^2");

            addTwoDimFunction("return 4*pow(x-5,2)+pow(y-6,2);", TwoDimTestingFunctions.f5,
                TwoDimTestingFunctions.df5x1, TwoDimTestingFunctions.df5x2, new PointF(8, 9), new PointF(1, 0),
                new PointF(5, 9), "Функция №14: 4(x1-5)^2+(x2-6)^2");

            addTwoDimFunction("return pow(x-2,4)+pow(x-2*y,2);", TwoDimTestingFunctions.f6,
                TwoDimTestingFunctions.df6x1, TwoDimTestingFunctions.df6x2, new PointF(0, 3), new PointF(44, -24.1f),
                new PointF(2.7f, 1.51f), "Функция №15: (x1-2)^4+(x1-2x2)^2");
        }
    }
}
