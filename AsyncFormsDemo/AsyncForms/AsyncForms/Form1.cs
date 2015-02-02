using System;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SleepClick(object sender, EventArgs e)
        {
            label1.Text = "Working";
            Thread.Sleep(5000);
            label1.Text = "Done";
        }

        private async void  DelayClick(object sender, EventArgs e)
        {
            label1.Text = "Working";
            await Task.Delay(5000);
            label1.Text = "Done";
        }
        private async void  AsyncSleepClick(object sender, EventArgs e)
        {
            label1.Text = "Working";
            await Task.Factory.StartNew(() => Thread.Sleep(5000));
            label1.Text = "Done";
        }


        private async Task DoWorkAsync(Label label)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                label.Text = i.ToString();
            }
            label.Text = "Done";

        }

        private async void SequenceClick(object sender, EventArgs e)
        {
            label1.Text = "Sequence";

            await DoWorkAsync(label2);
            await DoWorkAsync(label3);

            label1.Text = "Done";

        }

        private async void ParallelClick(object sender, EventArgs e)
        {
            label1.Text = "Parallel";

            var tasks = new Task[2];

            tasks[0] = DoWorkAsync(label2);
            tasks[1] = DoWorkAsync(label3);

            await Task.WhenAll(tasks);

            label1.Text = "Done";

        }
    }
}
