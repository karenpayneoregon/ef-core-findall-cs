namespace WindowsFormsApp1
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
            this.GetSelectedButton = new System.Windows.Forms.Button();
            this.CategoryCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GetSelectedButton
            // 
            this.GetSelectedButton.Enabled = false;
            this.GetSelectedButton.Location = new System.Drawing.Point(198, 20);
            this.GetSelectedButton.Name = "GetSelectedButton";
            this.GetSelectedButton.Size = new System.Drawing.Size(91, 23);
            this.GetSelectedButton.TabIndex = 1;
            this.GetSelectedButton.Text = "Get selected";
            this.GetSelectedButton.UseVisualStyleBackColor = true;
            this.GetSelectedButton.Click += new System.EventHandler(this.GetSelectedButton_Click);
            // 
            // CategoryCheckedListBox
            // 
            this.CategoryCheckedListBox.FormattingEnabled = true;
            this.CategoryCheckedListBox.Location = new System.Drawing.Point(12, 20);
            this.CategoryCheckedListBox.Name = "CategoryCheckedListBox";
            this.CategoryCheckedListBox.Size = new System.Drawing.Size(168, 184);
            this.CategoryCheckedListBox.TabIndex = 2;
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Font = new System.Drawing.Font("Courier New", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsTextBox.Location = new System.Drawing.Point(309, 20);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultsTextBox.Size = new System.Drawing.Size(331, 184);
            this.ResultsTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "FindAll";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 238);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.CategoryCheckedListBox);
            this.Controls.Add(this.GetSelectedButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code sample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button GetSelectedButton;
        private System.Windows.Forms.CheckedListBox CategoryCheckedListBox;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}