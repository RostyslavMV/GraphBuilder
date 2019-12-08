using Calc;
using System;
using System.Linq;
using System.Windows;

namespace GraphBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Plot();
        }


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
    }
}
