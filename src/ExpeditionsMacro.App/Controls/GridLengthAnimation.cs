using System.Windows;
using System.Windows.Media.Animation;

namespace ExpeditionsMacro.App.Controls;

/// <summary>
/// Pixel-unit <see cref="GridLength"/> animation for the collapsible
/// rails; WPF ships no animation type for grid columns.
/// </summary>
public sealed class GridLengthAnimation : AnimationTimeline
{
    public static readonly DependencyProperty FromProperty =
        DependencyProperty.Register(
            nameof(From),
            typeof(GridLength),
            typeof(GridLengthAnimation),
            new PropertyMetadata(new GridLength(0)));

    public static readonly DependencyProperty ToProperty =
        DependencyProperty.Register(
            nameof(To),
            typeof(GridLength),
            typeof(GridLengthAnimation),
            new PropertyMetadata(new GridLength(0)));

    public static readonly DependencyProperty EasingFunctionProperty =
        DependencyProperty.Register(
            nameof(EasingFunction),
            typeof(IEasingFunction),
            typeof(GridLengthAnimation),
            new PropertyMetadata(null));

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

    public IEasingFunction? EasingFunction
    {
        get => (IEasingFunction?)GetValue(
            EasingFunctionProperty);
        set => SetValue(EasingFunctionProperty, value);
    }

    public override Type TargetPropertyType =>
        typeof(GridLength);

    protected override Freezable CreateInstanceCore() =>
        new GridLengthAnimation();

    public override object GetCurrentValue(
        object defaultOriginValue,
        object defaultDestinationValue,
        AnimationClock animationClock)
    {
        double progress =
            animationClock.CurrentProgress ?? 0;
        if (EasingFunction is { } easing)
        {
            progress = easing.Ease(progress);
        }
        double from = From.Value;
        double to = To.Value;
        return new GridLength(
            from + ((to - from) * progress),
            GridUnitType.Pixel);
    }
}
