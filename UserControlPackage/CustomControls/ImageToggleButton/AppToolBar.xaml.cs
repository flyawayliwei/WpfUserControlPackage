using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlPackage.CustomControls.ImageToggleButton
{
    /// <summary>
    /// AppToolBar.xaml 的交互逻辑
    /// </summary>
    public partial class AppToolBar : UserControl
    {
        public AppToolBar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 右侧工具条按钮选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolButton_Checked(object sender, RoutedEventArgs e)
        {
            return;
            Control control = sender as Control;
            string tag = control.Tag.ToString();
            switch (control.Tag.ToString())
            {
                default: break;
            }
        }
        /// <summary>
        /// 右侧工具条按钮取消选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolButton_Unchecked(object sender, RoutedEventArgs e)
        {
            return;
            Control control = sender as Control;
            string tag = control.Tag.ToString();
            switch (control.Tag.ToString())
            {
                default: break;
            }
        }
        private static Dictionary<string, ToggleButton> ToolBarToggleButtonDic = new Dictionary<string, ToggleButton>();
        /// <summary>
        /// 工具条ToggleButton加载注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBarLoaded(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleBt = sender as ToggleButton;
            if (toggleBt != null && !string.IsNullOrEmpty(toggleBt.Tag.ToString()))
            {
                // 如果字典已存在该Key则重置该项
                if (ToolBarToggleButtonDic.ContainsKey(toggleBt.Tag.ToString()))
                {
                    ToolBarToggleButtonDic.Remove(toggleBt.Tag.ToString());
                }
                ToolBarToggleButtonDic.Add(toggleBt.Tag.ToString(), toggleBt);
            }
        }
    }
}
