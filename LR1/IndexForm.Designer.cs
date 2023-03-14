namespace LR1
{
    partial class IndexForm
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
            this.AccountsGridView = new System.Windows.Forms.DataGridView();
            this.Site = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FilterTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewAccountBtn = new System.Windows.Forms.Button();
            this.NewAccountPasswordTextBox = new System.Windows.Forms.TextBox();
            this.NewAccountLoginTextBox = new System.Windows.Forms.TextBox();
            this.NewAccountSiteTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccountsGridView
            // 
            this.AccountsGridView.AllowUserToAddRows = false;
            this.AccountsGridView.AllowUserToDeleteRows = false;
            this.AccountsGridView.AllowUserToResizeColumns = false;
            this.AccountsGridView.AllowUserToResizeRows = false;
            this.AccountsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Site,
            this.Login,
            this.Password,
            this.Delete});
            this.AccountsGridView.Location = new System.Drawing.Point(0, 29);
            this.AccountsGridView.Name = "AccountsGridView";
            this.AccountsGridView.RowTemplate.Height = 25;
            this.AccountsGridView.Size = new System.Drawing.Size(624, 306);
            this.AccountsGridView.TabIndex = 0;
            // 
            // Site
            // 
            this.Site.HeaderText = "Site";
            this.Site.Name = "Site";
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.Name = "Login";
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterTextBox.Location = new System.Drawing.Point(0, 0);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.PlaceholderText = "Filter";
            this.FilterTextBox.Size = new System.Drawing.Size(624, 23);
            this.FilterTextBox.TabIndex = 1;
            this.FilterTextBox.TextChanged += new System.EventHandler(this.FilterTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NewAccountBtn);
            this.panel1.Controls.Add(this.NewAccountPasswordTextBox);
            this.panel1.Controls.Add(this.NewAccountLoginTextBox);
            this.panel1.Controls.Add(this.NewAccountSiteTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 100);
            this.panel1.TabIndex = 2;
            // 
            // NewAccountBtn
            // 
            this.NewAccountBtn.Location = new System.Drawing.Point(321, 34);
            this.NewAccountBtn.Name = "NewAccountBtn";
            this.NewAccountBtn.Size = new System.Drawing.Size(100, 23);
            this.NewAccountBtn.TabIndex = 3;
            this.NewAccountBtn.Text = "Add New";
            this.NewAccountBtn.UseVisualStyleBackColor = true;
            this.NewAccountBtn.Click += new System.EventHandler(this.NewAccountBtn_Click);
            // 
            // NewAccountPasswordTextBox
            // 
            this.NewAccountPasswordTextBox.Location = new System.Drawing.Point(215, 34);
            this.NewAccountPasswordTextBox.Name = "NewAccountPasswordTextBox";
            this.NewAccountPasswordTextBox.PasswordChar = '*';
            this.NewAccountPasswordTextBox.PlaceholderText = "Password";
            this.NewAccountPasswordTextBox.Size = new System.Drawing.Size(100, 23);
            this.NewAccountPasswordTextBox.TabIndex = 2;
            // 
            // NewAccountLoginTextBox
            // 
            this.NewAccountLoginTextBox.Location = new System.Drawing.Point(109, 34);
            this.NewAccountLoginTextBox.Name = "NewAccountLoginTextBox";
            this.NewAccountLoginTextBox.PasswordChar = '*';
            this.NewAccountLoginTextBox.PlaceholderText = "Login";
            this.NewAccountLoginTextBox.Size = new System.Drawing.Size(100, 23);
            this.NewAccountLoginTextBox.TabIndex = 1;
            // 
            // NewAccountSiteTextBox
            // 
            this.NewAccountSiteTextBox.Location = new System.Drawing.Point(3, 34);
            this.NewAccountSiteTextBox.Name = "NewAccountSiteTextBox";
            this.NewAccountSiteTextBox.PlaceholderText = "Site";
            this.NewAccountSiteTextBox.Size = new System.Drawing.Size(100, 23);
            this.NewAccountSiteTextBox.TabIndex = 0;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FilterTextBox);
            this.Controls.Add(this.AccountsGridView);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "IndexForm";
            this.Text = "Password Manager";
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView AccountsGridView;
        private TextBox FilterTextBox;
        private Panel panel1;
        private TextBox NewAccountPasswordTextBox;
        private TextBox NewAccountLoginTextBox;
        private TextBox NewAccountSiteTextBox;
        private Button NewAccountBtn;
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        private DataGridViewTextBoxColumn Site;
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        private DataGridViewTextBoxColumn Login;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewButtonColumn Delete;
    }
}