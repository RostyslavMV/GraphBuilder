using Calc;
using System;
using System.Collections.Generic;
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
        }

        #region Private Propetries
        private Dictionary<string, string> convertExpressions;

        double[] x { get; set; }

        double[] y { get; set; }
        #endregion

        private void CalculateX(string x0, string x1)
        {
            int X0, X1;
            if (Int32.TryParse(x0, out X0) && Int32.TryParse(x1, out X1) && X1 > X0)
            {
                x = Enumerable.Range(X0, X1 + 1).Select(i => i / 10.0).ToArray();
            }
            else ExceptionMessage.Text = "Please, enter correct X0 and X1";
        }

        private void CalculateY(string convertedFunction)
        {
            Evaluator evaluator = new Evaluator();
            try
            {
                y = x.Select(v => evaluator.EvalFunc(convertedFunction, v)).ToArray();
            }
            catch (Exception ex)
            {
                ExceptionMessage.Text = ex.Message;
            }
        }

        private void ConvertFunctionFormat(string function)
        {

        }

        private void ViewGraphButton_Click(object sender, RoutedEventArgs e)
        {
            var newGraphWindow = new GraphViewWindow();
            // newGraphWindow.SetParameters(fnc.Text, x0.Text, x1.Text);
            newGraphWindow.Show();
        }
    }
}
