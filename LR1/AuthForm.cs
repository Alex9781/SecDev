namespace LR1
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();         
        }

        private void PinCodeBtn_Click(object sender, EventArgs e)
        {
            SecurityManager securityManager = new(this.PinCodeTextBox.Text);

            if (securityManager.FileExist())
            {
                if (securityManager.PasswordValid())
                {
                    NextForm(securityManager);
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }
            }
            else
            {
                securityManager.CreateNewAccountsFile();
                NextForm(securityManager);
            }

        }

        private void NextForm(SecurityManager sm)
        {
            this.Hide();

            IndexForm indexForm = new(sm);
            indexForm.StartPosition = FormStartPosition.Manual;
            indexForm.Location = this.Location;
            indexForm.Closed += (s, args) => this.Close();

            indexForm.Show();
        }
    }
}
