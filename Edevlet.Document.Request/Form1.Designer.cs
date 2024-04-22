namespace Edevlet.Document.Request
{
    partial class FormSample
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtLog = new RichTextBox();
            createDoc = new Button();
            connection = new Button();
            connString = new TextBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(8, 6);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(514, 413);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtLog);
            tabPage1.Controls.Add(createDoc);
            tabPage1.Controls.Add(connection);
            tabPage1.Controls.Add(connString);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(506, 385);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Connection";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(3, 223);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(497, 159);
            txtLog.TabIndex = 4;
            txtLog.Text = "";
            // 
            // createDoc
            // 
            createDoc.Enabled = false;
            createDoc.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            createDoc.Location = new Point(183, 77);
            createDoc.Name = "createDoc";
            createDoc.Size = new Size(151, 71);
            createDoc.TabIndex = 3;
            createDoc.Text = "Create Document";
            createDoc.UseVisualStyleBackColor = true;
            createDoc.Click += createDoc_Click;
            // 
            // connection
            // 
            connection.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            connection.Location = new Point(427, 13);
            connection.Name = "connection";
            connection.Size = new Size(75, 26);
            connection.TabIndex = 2;
            connection.Text = "Connect";
            connection.UseVisualStyleBackColor = true;
            connection.Click += connection_Click;
            // 
            // connString
            // 
            connString.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            connString.Location = new Point(138, 15);
            connString.Name = "connString";
            connString.Size = new Size(283, 25);
            connString.TabIndex = 1;
            connString.Text = "amqp://guest:guest@localhost:5672";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            label1.Location = new Point(9, 21);
            label1.Name = "label1";
            label1.Size = new Size(126, 17);
            label1.TabIndex = 0;
            label1.Text = "Connection String";
            // 
            // FormSample
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 425);
            Controls.Add(tabControl1);
            Name = "FormSample";
            Text = "E-Devlet - Document Creator";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button createDoc;
        private Button connection;
        private TextBox connString;
        private Label label1;
        private RichTextBox txtLog;
    }
}
