namespace BankingSystem
{
    public partial class Form1 : Form
    {

        List<BankAccount> Accounts = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();
            BankAccountGrid.AutoGenerateColumns = true;
            BankAccountGrid.AutoSize = true;
            BankAccountGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OwnerTxt.Text))
            {
                MessageBox.Show("Owner name cannot be empty");
                return;
            }
            BankAccount bankAccount = new BankAccount(OwnerTxt.Text);
            Accounts.Add(bankAccount);
            MessageBox.Show("Account Created Successfully");
            RefreshGrid();
            OwnerTxt.Clear();
        }

        private void RefreshGrid()
        {
            BankAccountGrid.DataSource = null;
            BankAccountGrid.DataSource = Accounts;

        }

        private void OwnerTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void AmountNumeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DepositeBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count == 1 && AmountNumeric.Value > 0)
            {
                BankAccount selectedAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

                string msg = selectedAccount.Deposit(AmountNumeric.Value);

                BankAccountGrid.Refresh();
                AmountNumeric.Value = 0;
                MessageBox.Show(msg);
            }
        }

        private void WIthdrawBtn_Click(object sender, EventArgs e)
        {
            if(BankAccountGrid.SelectedRows.Count == 1 && AmountNumeric.Value > 0)
            {
                BankAccount selectedAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;
                string msg = selectedAccount.Withdraw(AmountNumeric.Value);
                BankAccountGrid.Refresh();
                AmountNumeric.Value = 0;
                MessageBox.Show(msg);
            }
        }
    }
}
