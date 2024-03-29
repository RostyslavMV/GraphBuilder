﻿using Calc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private string[] expressionsToConvert = {"abs","acos","asin","atan","ceil","cos","exp","floor","log","pow","round",
        "sin","sqrt","tan"};

        double[] x { get; set; }

        double[] y { get; set; }
        #endregion

        private void CalculateX(string x0, string x1)
        {
            double X0, X1;
            if (Double.TryParse(x0, out X0) && Double.TryParse(x1, out X1) && X1 > X0)
            {
                x = Enumerable.Range(0, 1001).Select(i => X0 + (X1 - X0) / 1000 * i).ToArray();
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

        private string ConvertFunctionFormat(string function)
        {
            string resfunction = function;
            foreach (string expression in expressionsToConvert)
            {
                string pattern = @"\b" + "(" + expression + ")";
                var regex = new Regex(pattern);
                resfunction = regex.Replace(resfunction, "Math."+expression);
            }
            return resfunction;
        }

        private void ViewGraphButton_Click(object sender, RoutedEventArgs e)
        {
            CalculateX(x0.Text, x1.Text);
            if (x != null)
            {
                CalculateY(ConvertFunctionFormat(fnc.Text));
                if (y != null)
                {
                    ExceptionMessage.Text = "";
                    var newGraphWindow = new GraphViewWindow();
                    newGraphWindow.Title = "y(x)="+fnc.Text;
                    newGraphWindow.linegraph.Description = "y(x)="+fnc.Text;
                    newGraphWindow.SetParameters(x, y);
                    newGraphWindow.Show();
                }
            }
        }
    }
}
