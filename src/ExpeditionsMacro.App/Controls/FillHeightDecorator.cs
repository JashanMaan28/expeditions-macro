using System.Windows;
using System.Windows.Controls;

namespace ExpeditionsMacro.App.Controls;

/// <summary>
/// Hosts scrollable content that should stretch into leftover
/// space without its content size ever contributing to layout,
/// so growth inside (for example the run log) can never resize
/// the surrounding card.
/// </summary>
public sealed class FillHeightDecorator : Decorator
{
    protected override Size MeasureOverride(
        Size constraint)
    {
        if (Child is null)
        {
            return new Size(0, 0);
        }

        double height =
            double.IsPositiveInfinity(constraint.Height)
                ? 0
                : constraint.Height;
        Child.Measure(
            new Size(constraint.Width, height));
        return new Size(Child.DesiredSize.Width, 0);
    }
}
