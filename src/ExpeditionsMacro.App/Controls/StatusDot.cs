using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ExpeditionsMacro.App.Services;

namespace ExpeditionsMacro.App.Controls;

public enum StatusDotState
{
    Idle,
    Running,
    Waiting,
    Recovering,
    Succeeded,
    Stopped,
    Failed,
}

public sealed class StatusDot : Control
{
    public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
        nameof(State),
        typeof(StatusDotState),
        typeof(StatusDot),
        new FrameworkPropertyMetadata(StatusDotState.Idle, OnStateChanged));

    private Storyboard? _pulse;

    public StatusDotState State
    {
        get => (StatusDotState)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }

    private static void OnStateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        ((StatusDot)sender).UpdatePulse();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        UpdatePulse();
    }

    private void UpdatePulse()
    {
        bool live = State is StatusDotState.Running or StatusDotState.Recovering;
        // A live state must stay readable through its colour and label alone when the
        // user has switched animation off.
        if (live && MotionPolicy.AnimationsEnabled)
        {
            if (_pulse is null && TryFindResource("StatusPulse") is Storyboard template)
            {
                _pulse = template.Clone();
            }
            _pulse?.Begin(this, true);
            return;
        }

        _pulse?.Stop(this);
        Opacity = 1.0;
    }
}
