using System;
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Controls;
using FPlotLibrary;

namespace OptimisationCat
{
    public partial class GraphForm : MaterialForm
    {
        private readonly string _function;

        public GraphForm(string function)
        {
            _function = ConvertToChStyle(function);
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            var cFunction = new Function2D { source = _function};
            cFunction.Compile(true);
            cFunction.lineWidth = 0.001F;
            cFunction.Color = Color.DeepSkyBlue;
            graph.Model.Items.Add(cFunction);
        }

        private static string ConvertToChStyle(string s)
        {
            var i = 1;
            while (s.IndexOf("x" + i, StringComparison.Ordinal) >= 0)
            {
                switch (i)
                {
                    case 1:
                        s = s.Replace("x1", "x");
                        break;
                    case 2:
                        s = s.Replace("x2", "y");
                        break;
                    default:
                        throw new Exception("Нельзя построить граф 3-хмерной функции");
                }

                i++;
            }
            if (s.IndexOf("sin", StringComparison.Ordinal) >= 0)
            {
                s = s.Replace("sin", "Math.Sin");
            }
            if (s.IndexOf("ln", StringComparison.Ordinal) >= 0)
            {
                s = s.Replace("ln", "Math.Log");
            }
            if (s.IndexOf("cos", StringComparison.Ordinal) >= 0)
            {
                s = s.Replace("cos", "Math.Cos");
            }
            if (s.IndexOf("exp", StringComparison.Ordinal) >= 0)
            {
                s = s.Replace("sin", "Math.Exp");
            }
            if (s.IndexOf("e", StringComparison.Ordinal) >= 0)
            {
                s = s.Replace("e", "Math.E");
            }

            for (var c = 0; c < s.Length - 1; c++)
            {
                if (("0123456789".IndexOf(s[c]) >= 0) && ("(x".IndexOf(s[c + 1]) > 0))
                {
                    s = s.Insert(c + 1, "*");
                }
            }

            var b = s.IndexOf("^", StringComparison.Ordinal);
            while (b > 0)
            {
                var t = b;
                byte openBraket = 0;
                while ((t > 0) && (("+*-/".IndexOf(s[t]) < 0) || (openBraket > 0)))
                {
                    t--;
                    if (s[t] == ')') openBraket++;
                    else if (s[t] == '(') openBraket--;
                }
                if (t != 0) t++;
                while ((b < s.Length) && (("+*-/)".IndexOf(s[b]) < 0) || (openBraket > 0)))
                {
                    switch (s[b])
                    {
                        case '(':
                            openBraket++;
                            break;
                        case ')':
                            openBraket--;
                            break;
                        default:
                            break;
                    }
                    b++;
                }
                var s1 = s.Substring(t, b - t).Split('^')[0];
                var s2 = s.Substring(t, b - t).Split('^')[1];
                s = s.Remove(t, b - t);
                s = s.Insert(t, $"Math.Pow({s1},{s2})");
                b = s.IndexOf("^", StringComparison.Ordinal);
            }
            s = "return " + s + ";";
            return s;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            graph.z1 = trackBar1.Value;
        }

        private void graph_Click(object sender, EventArgs e)
        {
        }
    }
}