using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimisation.Одномерные;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Optimisation.Testing;

namespace Optimisation.Одномерные.Tests
{
    [TestClass()]
    public class OneDimentional
    {
        private OneDimMethod test;
        private Function f = new Function(OneDimTestingFunctions.f1,OneDimTestingFunctions.df1,"test",0.46915021069498823332105D);

        [TestMethod()]
        public void svenOneTest()
        {
            test = new GoldenRatioMethod2(f.F);
            test.setSvenInterval();
            Assert.IsTrue(test.A < test.B);
            Assert.IsTrue(f.Min<test.B && f.Min > test.A);
        }

        [TestMethod()]
        public void svenTwoTest()
        {
            test = new BolzanoMethod(f.F, f.Df);
            test.setSven2Interval();
            Assert.IsTrue(test.A < test.B);
            Assert.IsTrue(f.Min < test.B && f.Min > test.A);
        }

        [TestMethod()]
        public void svenThreeTest()
        {
            test = new BolzanoMethod(f.F, f.Df);
            test.setSven3Interval();
            Assert.IsTrue(test.A < test.B && test.B < test.C);
            Assert.IsTrue(Math.Abs(test.B - test.A - (test.C - test.B)) < test.Eps);
            Assert.IsTrue(f.Min < test.B && f.Min > test.A);
        }

        [TestMethod()]
        public void bolzanoTest()
        {
            test = new BolzanoMethod(f.F, f.Df);
            test.setSvenInterval();
            test.execute();
            Assert.IsTrue(Math.Abs(test.B - test.A) < test.Eps);
            Assert.IsTrue(f.Min < test.B && f.Min > test.A);
        }

        [TestMethod()]
        public void DSK_Test()
        {
            test = new DSK_Method(f.F);
            test.setSvenInterval();
            test.execute();
            Assert.IsTrue(f.Min <= test.B && f.Min >= test.A);
        }

        [TestMethod()]
        public void ExtrapolationTest()
        {
            test = new ExtrapolationMethod(f.F);
            test.setSvenInterval();
            test.execute();
        }

        [TestMethod()]
        public void Fibonacci1Test()
        {
            test = new FibonacciMethod1(f.F);
            test.setSvenInterval();
            test.execute();
            var length = Math.Abs(test.A - test.B);

            Assert.IsTrue(length < test.Eps);
            Assert.IsTrue(f.Min <= test.B && f.Min >= test.A);
        }

        [TestMethod()]
        public void Fibonacci2Test()
        {
            test = new FibonacciMethod2(f.F);
            test.setSvenInterval();
            test.execute();
            var length = f.Min;
            Assert.IsTrue(Math.Abs(test.A - test.B) < test.Eps);
            Assert.IsTrue(f.Min <= test.B && f.Min >= test.A);

        }

        [TestMethod()]
        public void GoldenRatio1Test()
        {
            test = new GoldenRatioMethod1(f.F);
            test.setSvenInterval();
            test.execute();
            Assert.IsTrue(Math.Abs(test.A - test.B) < test.Eps);
            Assert.IsTrue(f.Min < test.B && f.Min > test.A);
        }

        [TestMethod()]
        public void GoldenRatio2Test()
        {
            test = new GoldenRatioMethod2(f.F);
            test.setSvenInterval();
            test.execute();
            Assert.IsTrue(Math.Abs(test.A - test.B) < test.Eps);
            Assert.IsTrue(f.Min < test.B && f.Min > test.A);
        }

        [TestMethod()]
        public void DihotomyTest()
        {
            test = new DichotomyMethod(f.F);
            test.setSvenInterval();
            test.execute();
        }
    }
}