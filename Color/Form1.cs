using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorApp;

namespace ColorSelector
{
    public partial class Form1 : Form
    {
        private Random _rnd = new Random();

        private KnownColor[] _knownColors =
            Enum
                .GetValues(typeof(KnownColor))
                .Cast<KnownColor>()
                .ToArray();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadColorComboBox();

            Observable
                .Merge(
                    WhenColorFromRgb(),
                    WhenColorFromHsl(),
                    WhenColorFromCombo())
                .DistinctUntilChanged()
                .StartWith(NextRandomKnownColor())
                .ObserveOn(SynchronizationContext.Current!)
                .Subscribe(c =>
                {
                    UpdatePanelColor(c);
                    UpdateRgb(c);
                    UpdateHsl(c);
                    UpdateColorComboBox(c);
                });

            base.OnLoad(e);
        }

        private void LoadColorComboBox()
        {
            comboBox1.Items.AddRange(_knownColors.Cast<object>().ToArray());

            comboBox1
                .WhenDrawItem()
                .Subscribe(DrawItem);
        }

        private void DrawItem(EventPattern<DrawItemEventArgs> ep)
        {
            var e = ep.EventArgs;

            var color = Color.FromKnownColor(_knownColors[e.Index]);
            var brush = new SolidBrush(color);
            e.Graphics.DrawRectangle(new Pen(brush), e.Bounds);
            e.Graphics.FillRectangle(brush, e.Bounds);

            var textColor = color.GetBrightness() > 0.3 ? new SolidBrush(Color.Black) : new SolidBrush(Color.White);

            e.Graphics.DrawString(color.Name, comboBox1.Font, textColor, e.Bounds.X, e.Bounds.Y);
        }

        private IObservable<Color> WhenColorFromRgb()
        {
            return Observable.Merge(
                    trackBarR.WhenScroll(),
                    trackBarGreen.WhenScroll(),
                    trackBarBlue.WhenScroll())
                .Select(c => Color.FromArgb(
                    trackBarR.Value,
                    trackBarGreen.Value,
                    trackBarBlue.Value))
                .DistinctUntilChanged();
        }

        private IObservable<Color> WhenColorFromHsl()
        {
            return Observable.Merge(
                    trackBarHue.WhenScroll(),
                    trackBarSaturation.WhenScroll(),
                    trackBarBrightness.WhenScroll())
                .Select(c => ColorConversion.ColorFromHsl(
                    trackBarHue.Value,
                    trackBarSaturation.Value / 255.0f,
                    trackBarBrightness.Value / 510.0f))
                .DistinctUntilChanged();
        }

        private IObservable<Color> WhenColorFromCombo()
        {
            return comboBox1
                .WhenSelectionChangeCommitted()
                .Select(c => Color.FromKnownColor((KnownColor)comboBox1.SelectedItem));
        }


        public Color NextRandomKnownColor() => Color.FromKnownColor(_knownColors[_rnd.Next(_knownColors.Length)]);

        private void UpdatePanelColor(Color c)
        {
            panelColor.BackColor = c;
        }

        private void UpdateRgb(Color c)
        {
            trackBarR.Value = c.R;
            trackBarGreen.Value = c.G;
            trackBarBlue.Value = c.B;
        }

        private void UpdateHsl(Color c)
        {
            trackBarHue.Value = (int)(c.GetHue());
            trackBarSaturation.Value = (int)Math.Round(c.GetSaturation() * 255);
            trackBarBrightness.Value = (int)Math.Round(c.GetBrightness() * 510);
        }

        private void UpdateColorComboBox(Color c)
        {
            comboBox1.SelectedItem = c.ToKnownColor() > 0 ? (object)c.ToKnownColor() : null;
            comboBox1.BackColor = c;
            comboBox1.ForeColor = c.GetBrightness() > 0.3 ? Color.Black : Color.White;
        }
    }

    public static class Extensions
    {
        public static IObservable<Unit> WhenScroll(this TrackBar trackBar)
        {
            return Observable.FromEventPattern<EventHandler, EventArgs>(
                    h => trackBar.Scroll += h,
                    h => trackBar.Scroll -= h)
                .Select(_ => Unit.Default);
        }

        public static IObservable<Unit> WhenSelectionChangeCommitted(this ComboBox combo)
        {
            return Observable.FromEventPattern<EventHandler, EventArgs>(
                    h => combo.SelectionChangeCommitted += h,
                    h => combo.SelectionChangeCommitted -= h)
                .Select(x => Unit.Default);
        }

        public static IObservable<EventPattern<DrawItemEventArgs>> WhenDrawItem(this ComboBox combo)
        {
            return Observable.FromEventPattern<DrawItemEventHandler, DrawItemEventArgs>(
                h => combo.DrawItem += h,
                h => combo.DrawItem -= h);
        }
    }
}