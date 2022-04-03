using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackgroundWorkerClass
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.backgroundWorker.DoWork += new DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker.CancelAsync();
            }
        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 1; i <= 10; i++)
            {
                
                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    System.Threading.Thread.Sleep(1000);
                    //worker.ReportProgress(i * 10);
                    backgroundWorker.ReportProgress(i * 10);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
            }
        }
    }
}
