using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace UserControlPackage.CustomControls.SignalBar
{
    class SingnalLight : ContentControl
    {
        public int ValueA
        {
            get { return (int)GetValue(ValueAProperty); }
            set { SetValue(ValueAProperty, value); }
        }

        public double LightHeight
        {
            get { return (double)GetValue(LightHeightProperty); }
            set { SetValue(LightHeightProperty, value); }
        }

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public SingnalLight()
        {
            this.AllowDrop = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _currentPoint = e.GetPosition(this);
                X += _currentPoint.X - _startPoint.X;
                Y += _currentPoint.Y - _startPoint.Y;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            _startPoint = e.GetPosition(this);
            this.CaptureMouse();
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            this.ReleaseMouseCapture();
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if (ActualHeight > 0) LightHeight = ActualHeight * .7;
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            return base.ArrangeOverride(arrangeBounds);
        }

        static SingnalLight()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SingnalLight), new FrameworkPropertyMetadata(typeof(SingnalLight)));
        }

        public static readonly DependencyProperty LightHeightProperty =
            DependencyProperty.Register("LightHeight", typeof(double), typeof(SingnalLight), new PropertyMetadata((double)0));

        public static readonly DependencyProperty ValueAProperty =
            DependencyProperty.Register("ValueA", typeof(int), typeof(SingnalLight), new PropertyMetadata(0));

        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(SingnalLight), new PropertyMetadata((double)0));

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(SingnalLight), new PropertyMetadata((double)0));

        private Point _startPoint;
        private Point _currentPoint;
    }

    public class SingnalLightStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush result = Brushes.Transparent;
            if (value.GetType() == typeof(int))
            {
                var color = System.Convert.ToInt32(value);
                if (color < 50) result = Brushes.Green;
                else if (color < 85 && color >= 50) result = Brushes.Yellow;
                else if (color <= 100 && color >= 85) result = Brushes.Red;
                else result = Brushes.Gray;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SingnalLightValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = 0;
            if (values[0].GetType() == typeof(int) && values[1].GetType() == typeof(double))
            {
                result = (double)values[1] / 100 * System.Convert.ToDouble(values[0]);
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
