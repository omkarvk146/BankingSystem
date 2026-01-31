namespace BankingSystem
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            AmountNumeric = new NumericUpDown();
            OwnerTxt = new TextBox();
            BankAccountGrid = new DataGridView();
            DepositeBtn = new Button();
            WIthdrawBtn = new Button();
            CreateAccountBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)AmountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BankAccountGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 124);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 38);
            label1.TabIndex = 0;
            label1.Text = "Owner";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 374);
            label2.Name = "label2";
            label2.Size = new Size(116, 38);
            label2.TabIndex = 1;
            label2.Text = "Amount";
            // 
            // AmountNumeric
            // 
            AmountNumeric.Location = new Point(18, 415);
            AmountNumeric.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            AmountNumeric.Name = "AmountNumeric";
            AmountNumeric.Size = new Size(211, 43);
            AmountNumeric.TabIndex = 2;
            // 
            // OwnerTxt
            // 
            OwnerTxt.Location = new Point(18, 174);
            OwnerTxt.Name = "OwnerTxt";
            OwnerTxt.Size = new Size(241, 43);
            OwnerTxt.TabIndex = 3;
            // 
            // BankAccountGrid
            // 
            BankAccountGrid.AllowUserToAddRows = false;
            BankAccountGrid.AllowUserToDeleteRows = false;
            BankAccountGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BankAccountGrid.Location = new Point(575, 124);
            BankAccountGrid.Name = "BankAccountGrid";
            BankAccountGrid.ReadOnly = true;
            BankAccountGrid.RowHeadersWidth = 51;
            BankAccountGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BankAccountGrid.Size = new Size(598, 260);
            BankAccountGrid.TabIndex = 4;
            // 
            // DepositeBtn
            // 
            DepositeBtn.Location = new Point(620, 411);
            DepositeBtn.Name = "DepositeBtn";
            DepositeBtn.Size = new Size(246, 47);
            DepositeBtn.TabIndex = 5;
            DepositeBtn.Text = "Deposite";
            DepositeBtn.UseVisualStyleBackColor = true;
            DepositeBtn.Click += DepositeBtn_Click;
            // 
            // WIthdrawBtn
            // 
            WIthdrawBtn.Location = new Point(895, 411);
            WIthdrawBtn.Name = "WIthdrawBtn";
            WIthdrawBtn.Size = new Size(245, 43);
            WIthdrawBtn.TabIndex = 6;
            WIthdrawBtn.Text = "Withdraw";
            WIthdrawBtn.UseVisualStyleBackColor = true;
            WIthdrawBtn.Click += WIthdrawBtn_Click;
            // 
            // CreateAccountBtn
            // 
            CreateAccountBtn.Font = new Font("Segoe UI", 14F);
            CreateAccountBtn.Location = new Point(18, 238);
            CreateAccountBtn.Name = "CreateAccountBtn";
            CreateAccountBtn.Size = new Size(241, 43);
            CreateAccountBtn.TabIndex = 7;
            CreateAccountBtn.Text = "Create Account";
            CreateAccountBtn.UseVisualStyleBackColor = true;
            CreateAccountBtn.Click += CreateAccountBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 619);
            Controls.Add(CreateAccountBtn);
            Controls.Add(WIthdrawBtn);
            Controls.Add(DepositeBtn);
            Controls.Add(BankAccountGrid);
            Controls.Add(OwnerTxt);
            Controls.Add(AmountNumeric);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Banking System";
            ((System.ComponentModel.ISupportInitialize)AmountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)BankAccountGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown AmountNumeric;
        private TextBox OwnerTxt;
        private DataGridView BankAccountGrid;
        private Button DepositeBtn;
        private Button WIthdrawBtn;
        private Button CreateAccountBtn;
    }
}
