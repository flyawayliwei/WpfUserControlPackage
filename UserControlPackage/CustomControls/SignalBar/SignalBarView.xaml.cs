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

namespace UserControlPackage.CustomControls.SignalBar
{
    /// <summary>
    /// SignalBarView.xaml 的交互逻辑
    /// </summary>
    public partial class SignalBarView : UserControl
    {
        public SignalBarView()
        {
            InitializeComponent();
        }
        private void Button_start_click(object sender, RoutedEventArgs e)
        {
            SignalManager.Instance.Start();
        }

        private void Button_end_click(object sender, RoutedEventArgs e)
        {
            SignalManager.Instance.Stop();
        }
    }
}
