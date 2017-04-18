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
using UserControlPackage.CustomControls.ImageToggleButton;
using UserControlPackage.CustomControls.SignalBar;

namespace UserControlPackage
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.contentControlView.Content = new SignalBarView();
        }
        private void Button_Click_AppToolBar(object sender, RoutedEventArgs e)
        {
            this.contentControlView.Content = new AppToolBar();
        }
    }
}
