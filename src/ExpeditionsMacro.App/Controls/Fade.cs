using System.Windows;
using System.Windows.Media.Animation;
using ExpeditionsMacro.App.Services;

namespace ExpeditionsMacro.App.Controls;

/// <summary>
/// Attached opacity fade for hover and selection layers inside control
/// templates. Template triggers toggle <c>Fade.Shown</c> and the layer
/// fades in over 100ms and out over 150ms; when the system disables
/// client-area animation the layer snaps instantly instead.
/// </summary>
public static class Fade
{
    public static readonly DependencyProperty ShownProperty =
        DependencyProperty.RegisterAttached(
            "Shown",
            typeof(bool),
            typeof(Fade),
            new PropertyMetadata(false, OnShownChanged));

    public static bool GetShown(DependencyObject element) =>
        (bool)element.GetValue(ShownProperty);

    public static void SetShown(
        DependencyObject element,
        bool value) =>
        element.SetValue(ShownProperty, value);

    private static void OnShownChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        if (d is not UIElement element)
        {
            return;
        }

        bool shown = (bool)e.NewValue;
        double target = shown ? 1.0 : 0.0;
        if (!MotionPolicy.AnimationsEnabled)
        {
            element.BeginAnimation(
                UIElement.OpacityProperty,
                null);
            element.Opacity = target;
            return;
        }

        DoubleAnimation animation = new(
            target,
            TimeSpan.FromMilliseconds(shown ? 100 : 150))
        {
            EasingFunction = new QuadraticEase
            {
                EasingMode = EasingMode.EaseOut,
            },
        };
        element.BeginAnimation(
            UIElement.OpacityProperty,
            animation);
    }
}
