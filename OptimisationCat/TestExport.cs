using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimisationCat
{
    public class TestExport
    {
        public string Name { get; set; }
        public string Func { get; set; }
        public string Answer { get; set; }
        public string Iterations { get; set; }
        public string Time{ get; set; }
        public string Eps { get; set; }

        public TestExport(string name, string func, string answer, string iterations, string time, string eps)
        {
            Name = name;
            Func = func;
            Answer = answer;
            Iterations = iterations;
            Time = time;
            Eps = eps;
        }
    }
}
