namespace A_journey_through_miniature_Uzhhorod.MVVM.Model
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;

    public class GridLengthAnimation : AnimationTimeline
    {
        public override Type TargetPropertyType => typeof(GridLength);

        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(GridLength), typeof(GridLengthAnimation));

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(GridLength), typeof(GridLengthAnimation));

        public GridLength From
        {
            get => (GridLength)GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }

        public GridLength To
        {
            get => (GridLength)GetValue(ToProperty);
            set => SetValue(ToProperty, value);
        }

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            if (From.Value > To.Value)
            {
                double newValue = From.Value - ((From.Value - To.Value) * animationClock.CurrentProgress.Value);
                return new GridLength(newValue, GridUnitType.Pixel);
            }
            else
            {
                double newValue = From.Value + ((To.Value - From.Value) * animationClock.CurrentProgress.Value);
                return new GridLength(newValue, GridUnitType.Pixel);
            }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }
    }

}
