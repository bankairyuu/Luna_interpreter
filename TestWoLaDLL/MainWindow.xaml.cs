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
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Parsing_Click(object sender, RoutedEventArgs e)
        {
            string instructions = InputBox.Text;
            int instanceId = 39;

            WoLaDLL.WoLaParser parser = new WoLaDLL.WoLaParser();

            parser.Setup(instanceId, "test", "test");
            object returnValue = parser.StartParsing(instructions);
            output.Content = returnValue.ToString();
            InputBox.Text = parser.ReductionTree;
        }
    }
}
