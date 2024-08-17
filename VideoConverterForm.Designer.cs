namespace VideoConverter
{
    partial class Form1
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
            this.InputTextbox = new System.Windows.Forms.TextBox();
            this.OutputTextbox = new System.Windows.Forms.TextBox();
            this.convert = new System.Windows.Forms.Button();
            this.filesComboBox = new System.Windows.Forms.ComboBox();
            this.outputDirText = new System.Windows.Forms.TextBox();
            this.inputDirText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputTextbox
            // 
            this.InputTextbox.Location = new System.Drawing.Point(12, 116);
            this.InputTextbox.Multiline = true;
            this.InputTextbox.Name = "InputTextbox";
            this.InputTextbox.ReadOnly = true;
            this.InputTextbox.Size = new System.Drawing.Size(388, 328);
            this.InputTextbox.TabIndex = 0;
            this.InputTextbox.TextChanged += new System.EventHandler(this.InputTextbox_TextChanged);
            // 
            // OutputTextbox
            // 
            this.OutputTextbox.Location = new System.Drawing.Point(407, 116);
            this.OutputTextbox.Multiline = true;
            this.OutputTextbox.Name = "OutputTextbox";
            this.OutputTextbox.ReadOnly = true;
            this.OutputTextbox.Size = new System.Drawing.Size(381, 328);
            this.OutputTextbox.TabIndex = 1;
            // 
            // convert
            // 
            this.convert.Location = new System.Drawing.Point(713, 77);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(75, 23);
            this.convert.TabIndex = 2;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // filesComboBox
            // 
            this.filesComboBox.FormattingEnabled = true;
            this.filesComboBox.Location = new System.Drawing.Point(12, 79);
            this.filesComboBox.Name = "filesComboBox";
            this.filesComboBox.Size = new System.Drawing.Size(695, 21);
            this.filesComboBox.TabIndex = 3;
            // 
            // outputDirText
            // 
            this.outputDirText.Location = new System.Drawing.Point(135, 53);
            this.outputDirText.Name = "outputDirText";
            this.outputDirText.Size = new System.Drawing.Size(572, 20);
            this.outputDirText.TabIndex = 4;
            // 
            // inputDirText
            // 
            this.inputDirText.Location = new System.Drawing.Point(135, 27);
            this.inputDirText.Name = "inputDirText";
            this.inputDirText.Size = new System.Drawing.Size(572, 20);
            this.inputDirText.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Input Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output Directory";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputDirText);
            this.Controls.Add(this.outputDirText);
            this.Controls.Add(this.filesComboBox);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.OutputTextbox);
            this.Controls.Add(this.InputTextbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextbox;
        private System.Windows.Forms.TextBox OutputTextbox;
        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.ComboBox filesComboBox;
        private System.Windows.Forms.TextBox outputDirText;
        private System.Windows.Forms.TextBox inputDirText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

