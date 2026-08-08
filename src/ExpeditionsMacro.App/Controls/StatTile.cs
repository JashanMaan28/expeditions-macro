using System.Windows;
using System.Windows.Controls;

namespace ExpeditionsMacro.App.Controls;

public enum StatTone
{
    Neutral,
    Success,
    Warning,
    Error,
}

/// <summary>
/// A flat labelled counter tile for the run supervision surface. A tone only reaches the
/// value when the value carries signal: a zero count stays muted so colour never becomes
/// decoration.
/// </summary>
public sealed class StatTile : Control
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label),
        typeof(string),
        typeof(StatTile),
        new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
        nameof(Value),
        typeof(string),
        typeof(StatTile),
        new PropertyMetadata(string.Empty, OnValueChanged));

    public static readonly DependencyProperty ToneProperty = DependencyProperty.Register(
        nameof(Tone),
        typeof(StatTone),
        typeof(StatTile),
        new PropertyMetadata(StatTone.Neutral));

    private static readonly DependencyPropertyKey HasSignalKey = DependencyProperty.RegisterReadOnly(
        nameof(HasSignal),
        typeof(bool),
        typeof(StatTile),
        new PropertyMetadata(false));

    public static readonly DependencyProperty HasSignalProperty = HasSignalKey.DependencyProperty;

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public StatTone Tone
    {
        get => (StatTone)GetValue(ToneProperty);
        set => SetValue(ToneProperty, value);
    }

    public bool HasSignal => (bool)GetValue(HasSignalProperty);

    private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        string? value = args.NewValue as string;
        bool signal = !string.IsNullOrWhiteSpace(value) && value.AsSpan().ContainsAnyExcept("0:. ");
        sender.SetValue(HasSignalKey, signal);
    }
}
