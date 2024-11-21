using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlinkingLed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var rnd = new Random();

            Observable
                .Interval(TimeSpan.FromMilliseconds(400))
                .Subscribe(x => Led.BackColor = (x % 4) switch
                {
                    1 => Color.GreenYellow,
                    2 => Color.Blue,
                    3 => Color.Red,
                    _ => SystemColors.Control
                });
        }
    }
}