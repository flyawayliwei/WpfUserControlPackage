using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace UserControlPackage.CustomControls.ImageToggleButton
{
    /// <summary>
    /// 图片ToggleButton:自定义控件,继承自ToggleButton,具有ToggleButton的两种状态，可互相切换
    /// </summary>
    public class ImageToggleButton : ToggleButton
    {
        private object toolTip;//uncheck非选中时:文字提示
        private object checkedToolTip;//check选中:文字提示

        /// <summary>
        /// 自定义控件构造函数
        /// </summary>
        public ImageToggleButton()
        {
            Loaded += ImageToggleButton_Loaded;//Loaded事件委托，自定义函数ImageToggleButton_Loaded

        }
        private void ImageToggleButton_Loaded(object sender, RoutedEventArgs e)
        {
            toolTip = ToolTip; //保存初始的Tooltip,用于在点击切换过程中恢复原有的提示文字
            checkedToolTip = CheckedToolTip;
            Checked += ImageToggleButton_Checked;//Checked事件委托，自定义函数ImageToggleButton_Checked
            Unchecked += ImageToggleButton_Unchecked;//Unchecked事件委托，自定义函数ImageToggleButton_Unchecked
        }

        private void ImageToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToolTip = checkedToolTip;//check后显示文字提示
        }

        private void ImageToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ToolTip = toolTip;//uncheck后还原文字显示
        }
        /// <summary>
        /// 默认图片
        /// </summary>
        public ImageSource DefaultImage
        {
            get { return (ImageSource)GetValue(DefaultImageProperty); }
            set { SetValue(DefaultImageProperty, value); }
        }
        public static readonly DependencyProperty DefaultImageProperty =
        DependencyProperty.Register("DefaultImage", typeof(ImageSource), typeof(ImageToggleButton));
        /// <summary>
        /// 高亮图片
        /// </summary>
        public ImageSource HighLightImage
        {
            get { return (ImageSource)GetValue(HighLightImageProperty); }
            set { SetValue(HighLightImageProperty, value); }
        }
        public static readonly DependencyProperty HighLightImageProperty =
            DependencyProperty.Register("HighLightImage", typeof(ImageSource), typeof(ImageToggleButton));
        /// <summary>
        /// 选中图片
        /// </summary>
        public ImageSource DownImage
        {
            get { return (ImageSource)GetValue(DownImageProperty); }
            set { SetValue(DownImageProperty, value); }
        }
        public static readonly DependencyProperty DownImageProperty =
            DependencyProperty.Register("DownImage", typeof(ImageSource), typeof(ImageToggleButton));

        /// <summary>
        /// 按钮高亮背景
        /// </summary>
        public Brush HighlightBackground
        {
            get { return (Brush)GetValue(HighlightBackgroundProperty); }
            set { SetValue(HighlightBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightBackground.  This enables animation, styling, binding, etc...
        //注册HighlightBackgroundProperty(高亮背景属性)，属性名称为HighlightBackground
        public static readonly DependencyProperty HighlightBackgroundProperty =
            DependencyProperty.Register("HighlightBackground", typeof(Brush), typeof(ImageToggleButton));

        /// <summary>
        /// 高亮字体颜色
        /// </summary>
        public Brush HighlightForeground
        {
            get { return (Brush)GetValue(HighlightForegroundProperty); }
            set { SetValue(HighlightForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightForeground.  This enables animation, styling, binding, etc...
        //注册HighlightForegroundProperty(高亮前景属性)，属性名称为HighlightForeground
        public static readonly DependencyProperty HighlightForegroundProperty =
            DependencyProperty.Register("HighlightForeground", typeof(Brush), typeof(ImageToggleButton));


        /// <summary>
        /// CheckedToolTipProperty 在xaml界面设置,通过get方法获取xaml的设置值
        /// </summary>
        public object CheckedToolTip
        {
            get { return (object)GetValue(CheckedToolTipProperty); }
            set { SetValue(CheckedToolTipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckedToolTip.  This enables animation, styling, binding, etc...
        //注册CheckedToolTipProperty，属性名称为CheckedToolTip
        public static readonly DependencyProperty CheckedToolTipProperty =
            DependencyProperty.Register("CheckedToolTip", typeof(object), typeof(ImageToggleButton));

    }
}
