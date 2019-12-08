using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GraphBuilder
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class GraphViewWindow : Window
    {
        #region Private Propetries
        private string Function { get; set;
             private string X1 { get; set; }
        private string X2 { get; set; }

        #endregion
        public GraphViewWindow()
        {

            InitializeComponent();
            Plot();
        }

        Dictionary<string,string> convertExpressions = new Dictionary<string, string>();

        private void Plot()
        {
            var x = Enumerable.Range(0, 1001).Select(i => i / 10.0).ToArray();
            Evaluator evaluator = new Evaluator();
            //double result = evaluator.Eval("Math.sin(0.5)");
            double result1 = evaluator.EvalFunc("Math.sin(x)", 0.5);
            try
            {
                var y = x.Select(v => evaluator.EvalFunc("Math.sin(x)*Math.cos(x)*x+x", v)).ToArray();
                linegraph.Plot(x, y);
            }
            catch (Exception ex)
            {

            }

        }

        public void getParameters(string Function, string X1, string X2)
        {
            this.Function = Function;
            this.X1 = X1;
            this.X2 = X2;
        }
    }
}
