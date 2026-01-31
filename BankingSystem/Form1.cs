using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class Form1 : Form
    {
        private List<BankAccount> accounts = new List<BankAccount>();

        public Form1()
        {
            InitializeComponent();

            BankAccountGrid.AutoGenerateColumns = true;
            BankAccountGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BankAccountGrid.MultiSelect = false;
            BankAccountGrid.ReadOnly = true;
            BankAccountGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OwnerTxt.Text))
            {
                MessageBox.Show("Owner name cannot be empty");
                return;
            }

            BankAccount account = new BankAccount(OwnerTxt.Text);
            accounts.Add(account);

            RefreshGrid();
            OwnerTxt.Clear();

            MessageBox.Show("Account created successfully");
        }

        private void RefreshGrid()
        {
            BankAccountGrid.DataSource = null;
            BankAccountGrid.DataSource = accounts;
        }

        private void DepositeBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an account");
                return;
            }

            BankAccount selectedAccount =
                BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

            try
            {
                selectedAccount.Deposit(AmountNumeric.Value);
                RefreshGrid();
                AmountNumeric.Value = 0;
                MessageBox.Show("Deposit successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WIthdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an account");
                return;
            }

            BankAccount selectedAccount =
                BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

            try
            {
                selectedAccount.Withdraw(AmountNumeric.Value);
                RefreshGrid();
                MessageBox.Show("Withdrawal successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                AmountNumeric.Value = 0;
            }
        }
    }
}
