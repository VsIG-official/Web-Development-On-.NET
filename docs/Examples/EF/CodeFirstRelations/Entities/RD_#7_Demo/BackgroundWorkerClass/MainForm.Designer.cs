namespace BackgroundWorkerClass
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.resultLabel = new System.Windows.Forms.Label();
            this.startAsyncButton = new System.Windows.Forms.Button();
            this.canselAsyncButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(131, 45);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 0;
            // 
            // startAsyncButton
            // 
            this.startAsyncButton.Location = new System.Drawing.Point(12, 88);
            this.startAsyncButton.Name = "startAsyncButton";
            this.startAsyncButton.Size = new System.Drawing.Size(101, 23);
            this.startAsyncButton.TabIndex = 1;
            this.startAsyncButton.Text = "Start";
            this.startAsyncButton.UseVisualStyleBackColor = true;
            this.startAsyncButton.Click += new System.EventHandler(this.startAsyncButton_Click);
            // 
            // canselAsyncButton
            // 
            this.canselAsyncButton.Location = new System.Drawing.Point(167, 88);
            this.canselAsyncButton.Name = "canselAsyncButton";
            this.canselAsyncButton.Size = new System.Drawing.Size(105, 23);
            this.canselAsyncButton.TabIndex = 2;
            this.canselAsyncButton.Text = "Cancel";
            this.canselAsyncButton.UseVisualStyleBackColor = true;
            this.canselAsyncButton.Click += new System.EventHandler(this.cancelAsyncButton_Click);
            // 
            // backgroundWorker
            // 
            //this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            //this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            //this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(32, 192);
            this.dateTimePicker.Name = "dateTimePicker1";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.canselAsyncButton);
            this.Controls.Add(this.startAsyncButton);
            this.Controls.Add(this.resultLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button startAsyncButton;
        private System.Windows.Forms.Button canselAsyncButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

