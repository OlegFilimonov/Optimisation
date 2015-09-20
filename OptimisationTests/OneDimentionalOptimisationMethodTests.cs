using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optimisation.Одномерные;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimisation.Testing;

namespace Optimisation.Одномерные.Tests
{
    [TestClass()]
    public class OneDimentional
    {
        private OneDimentionalOptimisationMethod test;
        private Function f = new Function(TestingFunctions.f1,TestingFunctions.df1,"test");

        [TestMethod()]
        public void svenOneTest()
        {
            test = new BolzanoMethod(f.F,f.Df);
            Assert.IsTrue(test.A < test.B);
        }

        [TestMethod()]
        public void svenThreeTest()
        {
            test = new BolzanoMethod(f.F, f.Df);
            test.setSven3Interval();
            Assert.IsTrue(test.A < test.B && test.B < test.C);
            Assert.IsTrue(Math.Abs(test.B - test.A - (test.C - test.B)) < test.Eps);
        }

        [TestMethod()]
        public void bolzanoTest()
        {
            test = new BolzanoMethod(f.F, f.Df);
            Assert.IsTrue(Math.Abs(test.B - test.A) < test.Eps);
        }

        [TestMethod()]
        public void DSK_Test()
        {
            test = new DSK_Method(f.F);
            Assert.IsTrue(Math.Abs(test.A - test.C) < test.Eps);
        }

        [TestMethod()]
        public void ExtrapolationTest()
        {
            test = new DSK_Method(f.F);
            Assert.IsTrue(Math.Abs(test.A - test.C) < test.Eps);
        }

        [TestMethod()]
        public void Fibonacci1Test()
        {
            test = new FibonacciMethod1(f.F);
            var length = Math.Abs(test.A - test.B);
            Assert.IsTrue(length < test.Eps);
        }

        [TestMethod()]
        public void Fibonacci2Test()
        {
            test = new FibonacciMethod2(f.F);
            Assert.IsTrue(Math.Abs(test.A - test.B) < test.Eps);
        }

        [TestMethod()]
        public void GoldenRatio1Test()
        {
            test = new GoldenRatioMethod1(f.F);
            Assert.IsTrue(Math.Abs(test.A - test.B) < test.Eps);
        }

        [TestMethod()]
        public void GoldenRatio2Test()
        {
            test = new GoldenRatioMethod2(f.F);
            Assert.IsTrue(Math.Abs(test.A - test.B) < test.Eps);
        }
    }
}