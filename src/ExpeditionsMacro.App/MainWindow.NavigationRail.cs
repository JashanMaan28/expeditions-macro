using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using ExpeditionsMacro.App.Controls;
using ExpeditionsMacro.App.Pages;
using ExpeditionsMacro.App.Services;

namespace ExpeditionsMacro.App;

public partial class MainWindow
{
    private const double ExpandedNavigationWidth = 216;
    private const double CollapsedNavigationWidth = 60;
    private const double ResponsiveNavigationBreakpoint = 1110;
    private bool _navigationCollapsedBeforeForced;
    private bool _navigationForcedCollapsed;
    private bool _navigationRailCollapsed;
    private int _navigationRailAnimationToken;

    private RadioButton[] NavigationButtons =>
    [
        DashboardNav,
        MacroPlanNav,
        PlacementNav,
        RecordingsNav,
        DebugNav,
        SettingsNav,
    ];

    private void InitializeNavigationRail()
    {
        foreach (RadioButton button in
                 NavigationButtons)
        {
            string label =
                button.Tag as string ??
                "Navigation";
            button.ToolTip = label;
            AutomationProperties.SetName(
                button,
                label);
        }
        SetNavigationRailCollapsed(false);
        SizeChanged += NavigationRail_SizeChanged;
    }

    private void NavigationRailToggle_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (_navigationForcedCollapsed)
        {
            return;
        }
        SetNavigationRailCollapsed(
            !_navigationRailCollapsed);
    }

    private void NavigationRail_SizeChanged(
        object sender,
        SizeChangedEventArgs e)
    {
        if (_snapshotMode)
        {
            return;
        }

        bool forceCollapsed =
            e.NewSize.Width <
                ResponsiveNavigationBreakpoint;
        if (forceCollapsed ==
            _navigationForcedCollapsed)
        {
            return;
        }

        if (forceCollapsed)
        {
            _navigationCollapsedBeforeForced =
                _navigationRailCollapsed;
            _navigationForcedCollapsed = true;
            SetNavigationRailCollapsed(true);
            return;
        }

        bool restoreCollapsed =
            _navigationCollapsedBeforeForced;
        _navigationForcedCollapsed = false;
        SetNavigationRailCollapsed(
            restoreCollapsed);
    }

    private void SetNavigationRailCollapsed(
        bool collapsed)
    {
        _navigationRailCollapsed = collapsed;
        int token = ++_navigationRailAnimationToken;
        double width = collapsed
            ? CollapsedNavigationWidth
            : ExpandedNavigationWidth;
        if (!IsLoaded ||
            _snapshotMode ||
            !MotionPolicy.AnimationsEnabled)
        {
            NavigationColumn.BeginAnimation(
                ColumnDefinition.WidthProperty,
                null);
            TitleNavigationColumn.BeginAnimation(
                ColumnDefinition.WidthProperty,
                null);
            NavigationColumn.Width =
                new GridLength(width);
            TitleNavigationColumn.Width =
                new GridLength(width);
            ApplyNavigationRailContent(collapsed);
            return;
        }

        // Collapsing swaps to icon-only content before the rail
        // shrinks; expanding restores labels only after the rail has
        // grown, so text never overflows the narrow column.
        if (collapsed)
        {
            ApplyNavigationRailContent(true);
            AnimateNavigationRailWidth(width, null);
            return;
        }
        AnimateNavigationRailWidth(
            width,
            () =>
            {
                if (token ==
                    _navigationRailAnimationToken)
                {
                    ApplyNavigationRailContent(
                        false);
                }
            });
    }

    private void AnimateNavigationRailWidth(
        double targetWidth,
        Action? completed)
    {
        GridLength target = new(targetWidth);
        QuadraticEase ease = new()
        {
            EasingMode = EasingMode.EaseOut,
        };
        GridLengthAnimation Build(
            ColumnDefinition column) => new()
        {
            From = column.Width,
            To = target,
            Duration = new Duration(
                TimeSpan.FromMilliseconds(200)),
            EasingFunction = ease,
            FillBehavior = FillBehavior.Stop,
        };

        GridLengthAnimation navigation =
            Build(NavigationColumn);
        if (completed is not null)
        {
            navigation.Completed += (_, _) =>
                completed();
        }

        // The local value is set to the target first so the column
        // rests there when the Stop-fill animation ends, without a
        // one-frame jump back.
        GridLengthAnimation title =
            Build(TitleNavigationColumn);
        NavigationColumn.Width = target;
        TitleNavigationColumn.Width = target;
        NavigationColumn.BeginAnimation(
            ColumnDefinition.WidthProperty,
            navigation);
        TitleNavigationColumn.BeginAnimation(
            ColumnDefinition.WidthProperty,
            title);
    }

    private void ApplyNavigationRailContent(
        bool collapsed)
    {
        BrandContent.Visibility = collapsed
            ? Visibility.Collapsed
            : Visibility.Visible;
        WorkspaceHeader.Visibility = collapsed
            ? Visibility.Collapsed
            : Visibility.Visible;
        ToolsHeader.Visibility = collapsed
            ? Visibility.Collapsed
            : Visibility.Visible;
        WorkspaceHeaderRow.Margin = collapsed
            ? new Thickness(0, 10, 0, 7)
            : new Thickness(10, 10, 10, 7);

        foreach (RadioButton button in
                 NavigationButtons)
        {
            button.Content = collapsed
                ? null
                : button.Tag;
        }

        NavigationRailToggleButton.ToolTip =
            _navigationForcedCollapsed
                ? "Navigation stays compact at this window size"
                : collapsed
                    ? "Expand navigation"
                    : "Collapse navigation";
        NavigationRailToggleButton.IsEnabled =
            !_navigationForcedCollapsed;
        AutomationProperties.SetName(
            NavigationRailToggleButton,
            NavigationRailToggleButton
                .ToolTip.ToString()!);
        NavigationRailToggleButton
            .HorizontalAlignment = collapsed
                ? HorizontalAlignment.Center
                : HorizontalAlignment.Right;
        NavigationRailToggleButton.Margin =
            new Thickness(0);

        SetFooterButtonCollapsed(
            SetupGuideButton,
            collapsed,
            "Setup guide");
        SetFooterButtonCollapsed(
            JoinDiscordButton,
            collapsed,
            "Join Discord");
        OperationLabel.Visibility = collapsed
            ? Visibility.Collapsed
            : Visibility.Visible;
        HotkeyHint.Visibility = collapsed
            ? Visibility.Collapsed
            : Visibility.Visible;
        if (collapsed)
        {
            OperationRuntime.Visibility =
                Visibility.Collapsed;
        }
        VersionLabel.Visibility = collapsed
            ? Visibility.Collapsed
            : Visibility.Visible;
        OperationStatusBorder.Margin = collapsed
            ? new Thickness(10, 0, 10, 8)
            : new Thickness(12, 0, 12, 6);
        OperationStatusInner.Padding = collapsed
            ? new Thickness(0)
            : new Thickness(10);
        OperationStatusBorder.Height = collapsed
            ? 36
            : double.NaN;
        OperationSummary.HorizontalAlignment =
            collapsed
                ? HorizontalAlignment.Center
                : HorizontalAlignment.Left;
        OperationStatusContent.VerticalAlignment =
            collapsed
                ? VerticalAlignment.Center
                : VerticalAlignment.Stretch;
        OperationDot.Margin = collapsed
            ? new Thickness(0)
            : new Thickness(0, 0, 8, 0);
    }

    private void SetFooterButtonCollapsed(
        Button button,
        bool collapsed,
        string expandedContent)
    {
        button.Content = collapsed
            ? null
            : expandedContent;
        button.Margin = collapsed
            ? new Thickness(10, 0, 10, 8)
            : new Thickness(12, 0, 12, 4);
        if (collapsed)
        {
            button.Style =
                (Style)FindResource(
                    "IconButton");
            button.Width = 40;
            return;
        }

        // The expanded rail uses the quiet ghost treatment so these secondary links do
        // not compete with real actions. Clearing the style would fall back to the
        // implicit secondary Button instead.
        button.Style =
            (Style)FindResource("GhostButton");
        button.ClearValue(
            FrameworkElement.WidthProperty);
    }

    internal void SetNavigationRailCollapsedForSnapshot(
        bool collapsed) =>
        SetNavigationRailCollapsed(collapsed);

    internal void SetPlacementCatalogCollapsedForSnapshot(
        bool collapsed)
    {
        if (_pages.TryGetValue(
                "Placement Setup",
                out IAppPage? page) &&
            page is PlacementModelsPage placement)
        {
            placement
                .SetCatalogCollapsedForSnapshot(
                    collapsed);
        }
    }
}
