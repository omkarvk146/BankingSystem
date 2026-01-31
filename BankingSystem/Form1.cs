using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace BankingSystem
{
    public partial class Form1 : Form
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private string connStr =
            ConfigurationManager.ConnectionStrings["BankDB"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            BankAccountGrid.AutoGenerateColumns = true;
            BankAccountGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BankAccountGrid.MultiSelect = false;
            BankAccountGrid.ReadOnly = true;
            BankAccountGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            AmountNumeric.Minimum = 1;
            AmountNumeric.Value = 1;

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAccountsFromDatabase();
            RefreshGrid();
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

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query =
                    "INSERT INTO BankAccounts (AccountNumber, Owner, Balance) " +
                    "VALUES (@acc, @owner, @bal)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@acc", account.AccountNumber);
                cmd.Parameters.AddWithValue("@owner", account.Owner);
                cmd.Parameters.AddWithValue("@bal", account.Balance);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            RefreshGrid();
            OwnerTxt.Clear();

            MessageBox.Show("Account created successfully");
        }

        private void DepositeBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an account");
                return;
            }

            BankAccount acc =
                BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

            string result = acc.Deposit(AmountNumeric.Value);

            if (result == "Deposit Successful")
            {
                UpdateBalanceInDatabase(acc);
                RefreshGrid();
            }

            AmountNumeric.Value = 1;
            MessageBox.Show(result);
        }


        private void WIthdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an account");
                return;
            }

            BankAccount acc =
                BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;

            string result = acc.Withdraw(AmountNumeric.Value);

            if (result == "Withdrawal Successful")
            {
                UpdateBalanceInDatabase(acc);
                RefreshGrid();
            }

            AmountNumeric.Value = 1;
            MessageBox.Show(result);
        }

        private void UpdateBalanceInDatabase(BankAccount account)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query =
                    "UPDATE BankAccounts SET Balance = @bal WHERE AccountNumber = @acc";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@bal", account.Balance);
                cmd.Parameters.AddWithValue("@acc", account.AccountNumber);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void LoadAccountsFromDatabase()
        {
            accounts.Clear();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query =
                    "SELECT AccountNumber, Owner, Balance FROM BankAccounts";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    BankAccount acc = new BankAccount(dr["Owner"].ToString());

                    typeof(BankAccount)
                        .GetProperty("AccountNumber")
                        .SetValue(acc, (Guid)dr["AccountNumber"]);

                    typeof(BankAccount)
                        .GetProperty("Balance")
                        .SetValue(acc, (decimal)dr["Balance"]);

                    accounts.Add(acc);
                }
            }
        }

        private void RefreshGrid()
        {
            BankAccountGrid.DataSource = null;
            BankAccountGrid.DataSource = accounts;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
{
    LoadAccountsFromDatabase();
    RefreshGrid();
}

        private void OwnerTxt_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
