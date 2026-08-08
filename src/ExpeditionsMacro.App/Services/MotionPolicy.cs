using System.Windows;

namespace ExpeditionsMacro.App.Services;

/// <summary>
/// One source of truth for whether decorative motion may run. Windows exposes the
/// user's reduced-animation preference through <see cref="SystemParameters.ClientAreaAnimation"/>;
/// every storyboard in the application honours it so state is still readable from
/// colour and text alone when animation is switched off.
/// </summary>
public static class MotionPolicy
{
    /// <summary>
    /// Set while rendering UI snapshots so every enter animation is
    /// skipped and captures are deterministic instead of racing
    /// storyboard clocks.
    /// </summary>
    public static bool SnapshotMode { get; set; }

    public static bool AnimationsEnabled =>
        !SnapshotMode &&
        SystemParameters.ClientAreaAnimation;

    /// <summary>
    /// Removes an element's locally set animation style when motion is disabled, leaving
    /// the element's resting appearance untouched.
    /// </summary>
    public static void SuppressIfDisabled(FrameworkElement element)
    {
        ArgumentNullException.ThrowIfNull(element);
        if (AnimationsEnabled)
        {
            return;
        }
        element.ClearValue(FrameworkElement.StyleProperty);
        element.Opacity = 1.0;
    }
}
