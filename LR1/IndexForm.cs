using System.Data;

namespace LR1
{
    public partial class IndexForm : Form
    {
        private readonly SecurityManager _securityManager;
        private readonly List<Account> _accounts;

        private List<Account> _filteredAccounts;

        internal IndexForm(SecurityManager securityManager)
        {
            InitializeComponent();

            _accounts = securityManager.GetAccounts();
            _filteredAccounts = _accounts;
            _securityManager = securityManager;

            FillGridView();

            this.AccountsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.AccountsGridView.CellFormatting += AccountsGridView_CellFormatting;
            this.AccountsGridView.CellMouseClick += AccountsGridView_CellMouseClick;
        }

        private void FillGridView()
        {
            this.AccountsGridView.Rows.Clear();
            foreach (var account in _filteredAccounts)
            {
                this.AccountsGridView.Rows.Add(account.Site, account.Login, account.Password);
            }
        }

        private void AccountsGridView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 1 || e.ColumnIndex == 2) && e.Value != null)
            {
                e.Value = "********";
            }
        }

        private void AccountsGridView_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Account accountToDelete = _filteredAccounts[e.RowIndex];
                _filteredAccounts.Remove(accountToDelete);
                _accounts.Remove(accountToDelete);

                _securityManager.WriteAccountsToFile(_accounts);
                FilterTextBox_TextChanged(sender!, e);
            }
            else
            {
                string toCopy = "";
                if (e.ColumnIndex == 0)
                {
                    toCopy = _filteredAccounts[e.RowIndex].Site;
                }
                else if (e.ColumnIndex == 1)
                {
                    toCopy = _filteredAccounts[e.RowIndex].Login;
                    toCopy = _securityManager.DecryptString(toCopy);
                }
                else if (e.ColumnIndex == 2)
                {
                    toCopy = _filteredAccounts[e.RowIndex].Password;
                    toCopy = _securityManager.DecryptString(toCopy);
                }

                Clipboard.SetText(toCopy);
                ClearClipboard();
            }
        }


        private static async void ClearClipboard()
        {
            await Task.Delay(1000 * 20);
            Clipboard.Clear();
        }

        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            string filter = FilterTextBox.Text;
            _filteredAccounts = _accounts.Where(t => t.Site.Contains(filter)).ToList();
            FillGridView();
        }

        private void NewAccountBtn_Click(object sender, EventArgs e)
        {
            string site, login, password;
            site = this.NewAccountSiteTextBox.Text;
            login = _securityManager.EncryptString(this.NewAccountLoginTextBox.Text);
            password = _securityManager.EncryptString(this.NewAccountPasswordTextBox.Text);

            Account newAccount = new(site, login, password);
            _accounts.Add(newAccount);
            _securityManager.WriteAccountsToFile(_accounts);
            FilterTextBox_TextChanged(sender, e);
        }
    }
}
