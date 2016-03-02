using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWoLaDLL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes the Main Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Click event for Parsing (Content name: Feldolgozás)
        /// Start a parsing method with the WoLaDLL
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">routed event</param>
        private void Parsing_Click(object sender, RoutedEventArgs e)
        {
            string instructions = InputBox.Text;
            int instanceId = 39;

            WoLaDLL.WoLaParser parser = new WoLaDLL.WoLaParser();

            parser.Setup(instanceId, "test", "test");
            object returnValue = parser.StartParsing(instructions);
            if (returnValue is List<string>)
            {
                //string assets = "";
                //for (int i=0; i < ((List<string>)returnValue).Count; i++)
                //{
                //    assets += ((List<string>)returnValue)[i] + ", ";
                //}
                //output.Content = assets;

                new ListViewWindow((List<string>)returnValue).Show();
                output.Content = "See results in the ListViewWindow!";
            }
            else
            {
                output.Content = returnValue.ToString();
            }
            InputBox.Text = parser.ReductionTree;
        }
    }
}
