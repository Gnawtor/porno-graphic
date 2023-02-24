using System;
using System.Drawing;
using System.Windows.Forms;

namespace Porno_Graphic.Classes
{
    class NumberSliderPanel : Panel
    {
        private class NumericUpDownPlain : NumericUpDown
        {
            public NumericUpDownPlain()
            {
                Controls[0].Hide();
            }
            protected override void OnTextBoxResize(object source, EventArgs e)
            {
                Controls[1].Width = Width - 4;
            }
        }

        private TrackBar Slider;
        private NumericUpDownPlain ValueBox;
        private Label IdTextLabel;

        private string mIdText;
        private uint mValue;
        private uint mMinimum;
        private uint mMaximum;
        private int mControlPadding;

        public string IdText { get { return mIdText; }
            set
            {
                mIdText = value;
                IdTextLabel.Text = value;
                RecomputeLayout();
            }
        }

        public uint Value { get { return mValue; } 
            set 
            {
                mValue = (value >= Minimum && value <= Maximum) ? value : Maximum;
                SetSlider((int)value);
                SetValueBox((int)value);
                if (ValueChanged != null) ValueChanged.Invoke(this, new NumberSliderPanelEventArgs { Value = value });
            } 
        }

        public uint Minimum { get { return mMinimum; }
            set
            {
                mMinimum = value;
                Slider.Minimum = (int)value;
                ValueBox.Minimum = (int)value;
            }
        }

        public uint Maximum { get { return mMaximum; }
            set
            {
                mMaximum = value;
                Slider.Maximum = (int)value;
                ValueBox.Maximum = (int)value;
            }
        }

        public int ControlPadding { get { return mControlPadding; }
            set
            {
                mControlPadding = value;
                RecomputeLayout();
            }
        }

        public NumberSliderPanel() : base()
        {
            Slider = new TrackBar
            {
                Minimum = (int)this.Minimum,
                Maximum = (int)this.Maximum,
                SmallChange = 1,
                LargeChange = 1,
                Width = 300,
                TickStyle = TickStyle.BottomRight,
                TickFrequency = 16,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            IdTextLabel = new Label
            {
                Text = String.Empty,
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            };

            ValueBox = new NumericUpDownPlain
            {
                Width = 25,
                Hexadecimal = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            Controls.Add(Slider);
            Controls.Add(IdTextLabel);
            Controls.Add(ValueBox);

            Slider.ValueChanged += HandleSliderValueChanged;
        }

        public void RecomputeLayout()
        {
            int labelAndNudWidth = IdTextLabel.Width + ValueBox.Width + (ControlPadding * 2);
            int sliderWidth = this.Width - labelAndNudWidth;
            if (sliderWidth < 0) sliderWidth = 1;
            Slider.Width = sliderWidth;
            Slider.Location = new System.Drawing.Point(0, 0);
            IdTextLabel.Location = new System.Drawing.Point(sliderWidth + ControlPadding, 2);
            ValueBox.Location = new System.Drawing.Point(IdTextLabel.Location.X + IdTextLabel.Width + ControlPadding, 0);
            Invalidate();
        }

        public void SetLabel(string text)
        {
            IdTextLabel.Text = text;
            this.Invalidate();
        }

        private void SetSlider(int value)
        {
            if (value >= Slider.Minimum && value <= Slider.Maximum)
            {
                Slider.ValueChanged -= HandleSliderValueChanged;
                Slider.Value = value;
                Slider.ValueChanged += HandleSliderValueChanged;
            }
        }

        private void SetValueBox(int value)
        {
            ValueBox.ValueChanged -= HandleValueBoxChanged;
            ValueBox.Value = value;
            ValueBox.ValueChanged += HandleValueBoxChanged;
        }

        private void HandleSliderValueChanged(object sender, EventArgs e)
        {
            Value = (uint)Slider.Value;
        }

        private void HandleValueBoxChanged(object sender, EventArgs e)
        {
            Value = (uint)ValueBox.Value;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            RecomputeLayout();
        }

        //private void HandleValueBoxKeyDown(object sender, KeyEventArgs e)
        //{
        //    Keys keyCode = e.KeyCode;
        //    IsHexKeyPress = (keyCode >= Keys.D0 && keyCode <= Keys.D9) || (keyCode >= Keys.A && keyCode <= Keys.F) ? true : false; // Only allow hex values
        //}

        //private void HandleValueBoxKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!IsHexKeyPress) e.Handled = true; // skip if non-hex value key
        //}

        //private void HandleValueBoxTextChanged(object sender, EventArgs e)
        //{
        //    uint parsedValue = 0U;
        //    //if (uint.TryParse(ValueBox.Text, System.Globalization.NumberStyles.HexNumber, out parsedValue)) Value = parsedValue;
        //    if (uint.TryParse(ValueBox.Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out parsedValue)) Value = parsedValue;
        //    else Value = 0U;
        //}

        //public void SetValue(uint value)
        //{
        //    if (value >= 0 && value <= 255) Value = value;
        //}

        public event EventHandler<NumberSliderPanelEventArgs> ValueChanged;

        protected virtual void OnValueChanged(NumberSliderPanelEventArgs e)
        {
            EventHandler<NumberSliderPanelEventArgs> handler = ValueChanged;
            if (handler != null) handler.Invoke(this, e);
        }

        public class NumberSliderPanelEventArgs : EventArgs
        {
            public uint Value { get; set; }
        }
    }
}
