namespace LR1
{
    partial class AuthForm
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
            this.PinCodeBtn = new System.Windows.Forms.Button();
            this.PinCodeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PinCodeBtn
            // 
            this.PinCodeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PinCodeBtn.Location = new System.Drawing.Point(224, 223);
            this.PinCodeBtn.Name = "PinCodeBtn";
            this.PinCodeBtn.Size = new System.Drawing.Size(176, 23);
            this.PinCodeBtn.TabIndex = 0;
            this.PinCodeBtn.Text = "Войти";
            this.PinCodeBtn.UseVisualStyleBackColor = true;
            this.PinCodeBtn.Click += new System.EventHandler(this.PinCodeBtn_Click);
            // 
            // PinCodeTextBox
            // 
            this.PinCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PinCodeTextBox.Location = new System.Drawing.Point(224, 194);
            this.PinCodeTextBox.Name = "PinCodeTextBox";
            this.PinCodeTextBox.PasswordChar = '*';
            this.PinCodeTextBox.PlaceholderText = "Пин-код";
            this.PinCodeTextBox.Size = new System.Drawing.Size(176, 23);
            this.PinCodeTextBox.TabIndex = 1;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.PinCodeTextBox);
            this.Controls.Add(this.PinCodeBtn);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "AuthForm";
            this.Text = "Password Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PinCodeBtn;
        private TextBox PinCodeTextBox;
    }
}