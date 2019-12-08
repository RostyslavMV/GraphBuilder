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
        }

        private void ViewGraphButton_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new GraphViewWindow();
            newWindow.Show();
        }
    }
}
