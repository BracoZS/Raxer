using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Raxer.Controls;

[TemplatePart(Name = "UpButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "DownButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "TextElement", Type = typeof(TextBox))]
public class NumericUpDown : Control
{
    static NumericUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NumericUpDown),
            new FrameworkPropertyMetadata(typeof(NumericUpDown)));
    }

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value),
            typeof(int),
            typeof(NumericUpDown),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnValueChanged));

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register(
            nameof(Minimum),
            typeof(int),
            typeof(NumericUpDown),
            new PropertyMetadata(int.MinValue));

    public int Minimum
    {
        get => (int)GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register(
            nameof(Maximum),
            typeof(int),
            typeof(NumericUpDown),
            new PropertyMetadata(int.MaxValue));

    public int Maximum
    {
        get => (int)GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    public static readonly DependencyProperty SmallChangeProperty =
        DependencyProperty.Register(
            nameof(SmallChange),
            typeof(int),
            typeof(NumericUpDown),
            new PropertyMetadata(1));

    public int SmallChange
    {
        get => (int)GetValue(SmallChangeProperty);
        set => SetValue(SmallChangeProperty, value);
    }

    private TextBox? _textElement;
    private RepeatButton? _upButton;
    private RepeatButton? _downButton;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _textElement = GetTemplateChild("TextElement") as TextBox;
        _upButton = GetTemplateChild("UpButton") as RepeatButton;
        _downButton = GetTemplateChild("DownButton") as RepeatButton;

        if (_upButton != null)
            _upButton.Click += UpButton_Click;

        if (_downButton != null)
            _downButton.Click += DownButton_Click;

        if (_textElement != null)
        {
            _textElement.PreviewTextInput += TextElement_PreviewTextInput;
            _textElement.PreviewKeyDown += TextElement_PreviewKeyDown;
            _textElement.LostFocus += TextElement_LostFocus;

            DataObject.AddPastingHandler(
                _textElement,
                TextElement_Pasting);

            UpdateText();
        }
    }

    private static void OnValueChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)d;

        control.Value = Math.Clamp(
            (int)e.NewValue,
            control.Minimum,
            control.Maximum);

        control.UpdateText();

        control.RaiseEvent(
            new ValueChangedEventArgs(
                ValueChangedEvent,
                control.Value));
    }

    public static readonly RoutedEvent ValueChangedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(ValueChanged),
            RoutingStrategy.Direct,
            typeof(ValueChangedEventHandler),
            typeof(NumericUpDown));

    public event ValueChangedEventHandler ValueChanged
    {
        add => AddHandler(ValueChangedEvent, value);
        remove => RemoveHandler(ValueChangedEvent, value);
    }

    private void UpButton_Click(object sender, RoutedEventArgs e)
    {
        Value = Math.Min(
            Maximum,
            Value + SmallChange);
    }

    private void DownButton_Click(object sender, RoutedEventArgs e)
    {
        Value = Math.Max(
            Minimum,
            Value - SmallChange);
    }

    private void TextElement_PreviewTextInput(
        object sender,
        TextCompositionEventArgs e)
    {
        if (_textElement == null)
            return;

        string text = _textElement.Text;

        text = text.Remove(
            _textElement.SelectionStart,
            _textElement.SelectionLength);

        text = text.Insert(
            _textElement.SelectionStart,
            e.Text);

        e.Handled = !IsValidNumber(text);
    }

    private static bool IsValidNumber(string text)
    {
        if (text == "-")
            return true;

        if (text.Length == 0)
            return true;

        int start = text[0] == '-' ? 1 : 0;

        if (start == 1 && text.Length == 1)
            return true;

        for (int i = start; i < text.Length; i++)
        {
            if (!char.IsDigit(text[i]))
                return false;
        }

        return true;
    }

    private void TextElement_PreviewKeyDown(
        object sender,
        KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                UpButton_Click(this, new RoutedEventArgs());
                e.Handled = true;
                break;

            case Key.Down:
                DownButton_Click(this, new RoutedEventArgs());
                e.Handled = true;
                break;

            case Key.Enter:
                CommitValue();
                e.Handled = true;
                break;
        }
    }

    private void TextElement_LostFocus(
        object sender,
        RoutedEventArgs e)
    {
        CommitValue();
    }

    private void CommitValue()
    {
        if (_textElement == null)
            return;

        if (int.TryParse(_textElement.Text, out int value))
        {
            Value = Math.Clamp(
                value,
                Minimum,
                Maximum);
        }
        else
        {
            UpdateText();
        }
    }

    private void UpdateText()
    {
        if (_textElement != null)
            _textElement.Text = Value.ToString();
    }

    private void TextElement_Pasting(
        object sender,
        DataObjectPastingEventArgs e)
    {
        if (!e.DataObject.GetDataPresent(typeof(string)))
        {
            e.CancelCommand();
            return;
        }

        string? pasted =
            e.DataObject.GetData(typeof(string)) as string;

        if (pasted == null || !IsValidNumber(pasted))
            e.CancelCommand();
    }
}

public delegate void ValueChangedEventHandler(
    object sender,
    ValueChangedEventArgs e);

public sealed class ValueChangedEventArgs : RoutedEventArgs
{
    public ValueChangedEventArgs(
        RoutedEvent routedEvent,
        int value)
        : base(routedEvent)
    {
        Value = value;
    }

    public int Value { get; }
}