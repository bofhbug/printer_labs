namespace BarCodeReader2014
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.IdealBarCode = new System.Windows.Forms.PictureBox();
            this.DigitBox = new System.Windows.Forms.TextBox();
            this.BinaryBox = new System.Windows.Forms.TextBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.DecodeBtn = new System.Windows.Forms.Button();
            this.OpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.BrowseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdealBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBox
            // 
            this.PicBox.Location = new System.Drawing.Point(323, 100);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(727, 422);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            // 
            // IdealBarCode
            // 
            this.IdealBarCode.Location = new System.Drawing.Point(17, 224);
            this.IdealBarCode.Name = "IdealBarCode";
            this.IdealBarCode.Size = new System.Drawing.Size(300, 132);
            this.IdealBarCode.TabIndex = 1;
            this.IdealBarCode.TabStop = false;
            // 
            // DigitBox
            // 
            this.DigitBox.Location = new System.Drawing.Point(17, 198);
            this.DigitBox.Name = "DigitBox";
            this.DigitBox.Size = new System.Drawing.Size(300, 20);
            this.DigitBox.TabIndex = 2;
            // 
            // BinaryBox
            // 
            this.BinaryBox.Location = new System.Drawing.Point(17, 172);
            this.BinaryBox.Name = "BinaryBox";
            this.BinaryBox.Size = new System.Drawing.Size(300, 20);
            this.BinaryBox.TabIndex = 3;
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(17, 12);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(300, 20);
            this.PathBox.TabIndex = 4;
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(404, 10);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenBtn.TabIndex = 5;
            this.OpenBtn.Text = "Open";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // DecodeBtn
            // 
            this.DecodeBtn.Location = new System.Drawing.Point(404, 38);
            this.DecodeBtn.Name = "DecodeBtn";
            this.DecodeBtn.Size = new System.Drawing.Size(75, 23);
            this.DecodeBtn.TabIndex = 6;
            this.DecodeBtn.Text = "Decode";
            this.DecodeBtn.UseVisualStyleBackColor = true;
            this.DecodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // OpenDlg
            // 
            this.OpenDlg.FileName = "openFileDialog1";
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(323, 10);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 7;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 587);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.DecodeBtn);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.BinaryBox);
            this.Controls.Add(this.DigitBox);
            this.Controls.Add(this.IdealBarCode);
            this.Controls.Add(this.PicBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdealBarCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.PictureBox IdealBarCode;
        private System.Windows.Forms.TextBox DigitBox;
        private System.Windows.Forms.TextBox BinaryBox;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.Button DecodeBtn;
        private System.Windows.Forms.OpenFileDialog OpenDlg;
        private System.Windows.Forms.Button BrowseBtn;
    }
}

