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

        private double[] x { get; set; }

        private double[] y { get; set; }

        #endregion

        public GraphViewWindow()
        {

            InitializeComponent();
        }

        Dictionary<string,string> convertExpressions = new Dictionary<string, string>();

        private void Plot()
        {
            linegraph.Plot(x, y);
        }

        public void SetParameters(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
            Plot();
        }
    }
}
