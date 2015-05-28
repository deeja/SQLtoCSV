namespace SqlToCsv
{
    partial class SQLToCSV
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
            this.setCsv = new System.Windows.Forms.Button();
            this.csvFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlConnectionStringBox = new System.Windows.Forms.TextBox();
            this.sqlQueryBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.runQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // setCsv
            // 
            this.setCsv.Location = new System.Drawing.Point(15, 79);
            this.setCsv.Name = "setCsv";
            this.setCsv.Size = new System.Drawing.Size(38, 23);
            this.setCsv.TabIndex = 0;
            this.setCsv.Text = "Set";
            this.setCsv.UseVisualStyleBackColor = true;
            this.setCsv.Click += new System.EventHandler(this.setCsv_Click);
            // 
            // csvFileName
            // 
            this.csvFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvFileName.Location = new System.Drawing.Point(59, 82);
            this.csvFileName.Name = "csvFileName";
            this.csvFileName.Size = new System.Drawing.Size(719, 20);
            this.csvFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Target CSV File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SQL Connection String:";
            // 
            // sqlConnectionStringBox
            // 
            this.sqlConnectionStringBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlConnectionStringBox.Location = new System.Drawing.Point(12, 34);
            this.sqlConnectionStringBox.Name = "sqlConnectionStringBox";
            this.sqlConnectionStringBox.Size = new System.Drawing.Size(766, 20);
            this.sqlConnectionStringBox.TabIndex = 5;
            this.sqlConnectionStringBox.Text = "Data Source=SERVERNAME; Initial Catalog=DATABASE; Integrated Security=SSPI";
            // 
            // sqlQueryBox
            // 
            this.sqlQueryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sqlQueryBox.Location = new System.Drawing.Point(15, 126);
            this.sqlQueryBox.Multiline = true;
            this.sqlQueryBox.Name = "sqlQueryBox";
            this.sqlQueryBox.Size = new System.Drawing.Size(763, 171);
            this.sqlQueryBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "SQL Query";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.FormattingEnabled = true;
            this.logBox.Location = new System.Drawing.Point(15, 343);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(763, 121);
            this.logBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Log";
            // 
            // runQuery
            // 
            this.runQuery.Location = new System.Drawing.Point(15, 301);
            this.runQuery.Name = "runQuery";
            this.runQuery.Size = new System.Drawing.Size(179, 23);
            this.runQuery.TabIndex = 10;
            this.runQuery.Text = "Run Query";
            this.runQuery.UseVisualStyleBackColor = true;
            this.runQuery.Click += new System.EventHandler(this.runQuery_Click);
            // 
            // SQLToCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.runQuery);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sqlQueryBox);
            this.Controls.Add(this.sqlConnectionStringBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.csvFileName);
            this.Controls.Add(this.setCsv);
            this.Name = "SQLToCSV";
            this.Text = "SQL to CSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setCsv;
        private System.Windows.Forms.TextBox csvFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sqlConnectionStringBox;
        private System.Windows.Forms.TextBox sqlQueryBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button runQuery;
    }
}

