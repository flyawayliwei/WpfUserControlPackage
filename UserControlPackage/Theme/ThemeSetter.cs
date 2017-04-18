using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UserControlPackage.Theme
{

    class ThemeSetter
    {
        private static ThemeSetter _ThemeSetter = null;
        public static ThemeSetter getInstance()
        {
            if (_ThemeSetter == null)
            {
                _ThemeSetter = new ThemeSetter();
            }

            return _ThemeSetter;
        }
        #region 事件注册
        /// <summary>
        /// 定义控件加载委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ControlsLoadedEventHandler(object sender, RoutedEventArgs e);


        private static Dictionary<string, Button> ButtonDictionary = new Dictionary<string, Button>();
        private static Dictionary<string, Grid> GridDictionary = new Dictionary<string, Grid>();
        private static Dictionary<string, Border> BorderDictionary = new Dictionary<string, Border>();
        private static Dictionary<string, Window> WindowDictionary = new Dictionary<string, Window>();

        // 白色调
        SolidColorBrush whiteTheme = new SolidColorBrush(Color.FromArgb(85, 255, 255, 255));//通用

        // 普通控件 蓝色调
        SolidColorBrush commonBlueTheme = new SolidColorBrush(Color.FromArgb(180, 0, 114, 198));
        // popup 蓝色调 
        SolidColorBrush popupBlueTheme = new SolidColorBrush(Color.FromArgb(180, 0, 114, 198));
        // 窗体 蓝色调 不透明
        SolidColorBrush windowBlueTheme = new SolidColorBrush(Color.FromArgb(255, 0, 114, 198));
        // 控件加载事件
        /// <summary>
        /// 定义控件加载委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CommonLoadedControlsMethod(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button)
                {
                    Button btn = sender as Button;
                    btn.Background = GetBackaground(true);
                    // 将控件添加进字典
                    ButtonDictionary.Add(btn.Name, btn);
                }
                else if (sender is Grid)
                {
                    Grid grid = sender as Grid;
                    grid.Background = GetBackaground(true);
                    // 将控件添加进字典
                    GridDictionary.Add(grid.Name, grid);
                }
                else if (sender is Border)
                {
                    Border border = sender as Border;
                    border.Background = GetBackaground(true);
                    // 将控件添加进字典
                    BorderDictionary.Add(border.Name, border);
                }
                else if (sender is Window)
                {
                    Window window = sender as Window;
                    window.Background = GetBackaground(true);
                    // 将控件添加进字典
                    WindowDictionary.Add(window.Name, window);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 设置控件背景色
        /// </summary>
        /// <param name="isBlueTransparent">蓝色调是否可透明</param>
        /// <returns></returns>
        private SolidColorBrush GetBackaground(bool isBlueTransparent)
        {
            //// 蓝色调
            //SolidColorBrush blueTheme;
            //// 蓝色调透明
            //if (isBlueTransparent)
            //{
            //    blueTheme = new SolidColorBrush(Color.FromArgb(180, 0, 114, 198));
            //}
            //// 蓝色调不透明
            //else
            //{
            //    blueTheme = new SolidColorBrush(Color.FromArgb(255, 0, 114, 198));
            //}
            //// 白色调
            //SolidColorBrush whiteTheme = new SolidColorBrush(Color.FromArgb(85, 255, 255, 255));
            //// 根据登录页面选择设置主题色
            //if (SysSignIn.getInstance().ThemeComboBox.SelectedIndex == 1)
            //{
            //    return blueTheme;
            //}
            //else
            //{
            //    return whiteTheme;
            //}
            //return new SolidColorBrush(Color.FromArgb(180, 0, 114, 198)); ;
            return whiteTheme;


        }


        #endregion

        #region 重新设置所有控件背景
        /// <summary>
        /// 设置控件背景
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isWhiteTheme"></param>
        /// <returns></returns>
        private SolidColorBrush SetControlsBackaground(string name, bool isWhiteTheme)
        {
            if (name.ToUpper().IndexOf("POPUP") > 0)
            {
                if (isWhiteTheme)
                {
                    return whiteTheme;
                }
                else
                {
                    return popupBlueTheme;
                }
            }
            else if (name.ToUpper().IndexOf("WINDOW") > 0)
            {
                if (isWhiteTheme)
                {
                    return whiteTheme;
                }
                else
                {
                    return windowBlueTheme;
                }
            }
            else
            {
                if (isWhiteTheme)
                {
                    return whiteTheme;
                }
                else
                {
                    return commonBlueTheme;
                }
            }
        }

        /// <summary>
        /// 重新设置控件背景
        /// </summary>
        public void RestAllBackaground(bool isWhiteTheme)
        {
            foreach (var item in ButtonDictionary)
            {
                item.Value.Background = SetControlsBackaground(item.Key.ToUpper(), isWhiteTheme);
            }

            foreach (var item in GridDictionary)
            {
                item.Value.Background = SetControlsBackaground(item.Key.ToUpper(), isWhiteTheme);
            }

            foreach (var item in BorderDictionary)
            {
                item.Value.Background = SetControlsBackaground(item.Key.ToUpper(), isWhiteTheme);
            }

            // 窗口控件
            foreach (var item in WindowDictionary)
            {
                item.Value.Background = SetControlsBackaground(item.Key.ToUpper(), isWhiteTheme);
            }
        }

        #endregion
    }
}
