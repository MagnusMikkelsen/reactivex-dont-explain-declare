namespace _1._Imperative
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            labelStatus.Text = "Ready for test";
            buttonControl.Enabled = false;
        }

        private async void buttonTest_Click(object sender, EventArgs e)
        {
            labelStatus.BackColor = Color.Yellow;
            labelStatus.Text = "Testing...";
            buttonTest.Enabled = false;
            await Testing();
        }

        private async Task Testing()
        {
            await Task.Delay(1000);
            labelStatus.Text = "Ready for control";
            buttonControl.Enabled = true;
        }

        private async void buttonControl_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Controlling...";
            buttonControl.Enabled = false;
            await Controlling();
        }

        private async Task Controlling()
        {
            await Task.Delay(1000);
            labelStatus.BackColor = Color.GreenYellow;
            labelStatus.Text = "OK";
            
            await Task.Delay(1000);
            buttonTest.Enabled = true;
            labelStatus.BackColor = DefaultBackColor;
            labelStatus.Text = "Ready for test";
        }
    }
}
