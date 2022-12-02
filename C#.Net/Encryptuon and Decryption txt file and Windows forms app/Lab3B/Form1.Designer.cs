namespace Lab3B
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxChargedItems = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxPrice = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxSelectService = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxHairDresser = new System.Windows.Forms.ComboBox();
            this.buttonAddService = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxTotalPrice = new System.Windows.Forms.ListBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxChargedItems);
            this.groupBox3.Location = new System.Drawing.Point(476, 62);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(203, 238);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Charged Items:";
            // 
            // listBoxChargedItems
            // 
            this.listBoxChargedItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxChargedItems.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.listBoxChargedItems.FormattingEnabled = true;
            this.listBoxChargedItems.ItemHeight = 22;
            this.listBoxChargedItems.Location = new System.Drawing.Point(7, 32);
            this.listBoxChargedItems.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxChargedItems.Name = "listBoxChargedItems";
            this.listBoxChargedItems.Size = new System.Drawing.Size(186, 202);
            this.listBoxChargedItems.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxPrice);
            this.groupBox4.Location = new System.Drawing.Point(686, 62);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(185, 238);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Price:";
            // 
            // listBoxPrice
            // 
            this.listBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPrice.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.listBoxPrice.FormattingEnabled = true;
            this.listBoxPrice.ItemHeight = 22;
            this.listBoxPrice.Location = new System.Drawing.Point(1, 32);
            this.listBoxPrice.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPrice.Name = "listBoxPrice";
            this.listBoxPrice.Size = new System.Drawing.Size(177, 202);
            this.listBoxPrice.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxSelectService);
            this.groupBox2.Location = new System.Drawing.Point(246, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(225, 238);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select a Service:";
            // 
            // listBoxSelectService
            // 
            this.listBoxSelectService.FormattingEnabled = true;
            this.listBoxSelectService.ItemHeight = 18;
            this.listBoxSelectService.Items.AddRange(new object[] {
            "Cut",
            "Wash, blow-dry, and style",
            "Colour",
            "Highlights",
            "Extensions",
            "Up-do"});
            this.listBoxSelectService.Location = new System.Drawing.Point(7, 32);
            this.listBoxSelectService.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxSelectService.Name = "listBoxSelectService";
            this.listBoxSelectService.Size = new System.Drawing.Size(212, 202);
            this.listBoxSelectService.TabIndex = 0;
            this.listBoxSelectService.SelectedValueChanged += new System.EventHandler(this.listBoxSelectService_SelectedValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxHairDresser);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(219, 238);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select a Hairdresser:";
            // 
            // comboBoxHairDresser
            // 
            this.comboBoxHairDresser.FormattingEnabled = true;
            this.comboBoxHairDresser.Items.AddRange(new object[] {
            "Jane Samley",
            "Pat Johnson",
            "Ron Chambers",
            "Sue Pallon",
            "Laura Renkins"});
            this.comboBoxHairDresser.Location = new System.Drawing.Point(7, 32);
            this.comboBoxHairDresser.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxHairDresser.Name = "comboBoxHairDresser";
            this.comboBoxHairDresser.Size = new System.Drawing.Size(205, 30);
            this.comboBoxHairDresser.TabIndex = 0;
            this.comboBoxHairDresser.Tag = "";
            this.comboBoxHairDresser.Text = "Jane Samley";
            // 
            // buttonAddService
            // 
            this.buttonAddService.Location = new System.Drawing.Point(84, 394);
            this.buttonAddService.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddService.Name = "buttonAddService";
            this.buttonAddService.Size = new System.Drawing.Size(211, 49);
            this.buttonAddService.TabIndex = 6;
            this.buttonAddService.Text = "Add Service";
            this.buttonAddService.UseVisualStyleBackColor = true;
            this.buttonAddService.Click += new System.EventHandler(this.buttonAddService_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(299, 394);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(205, 49);
            this.buttonCalculate.TabIndex = 7;
            this.buttonCalculate.Text = "Calculate Total Price";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(509, 394);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(171, 49);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(684, 394);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(175, 49);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 344);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Total Price: ";
            // 
            // listBoxTotalPrice
            // 
            this.listBoxTotalPrice.FormattingEnabled = true;
            this.listBoxTotalPrice.ItemHeight = 18;
            this.listBoxTotalPrice.Location = new System.Drawing.Point(676, 332);
            this.listBoxTotalPrice.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxTotalPrice.Name = "listBoxTotalPrice";
            this.listBoxTotalPrice.Size = new System.Drawing.Size(124, 40);
            this.listBoxTotalPrice.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 448);
            this.Controls.Add(this.listBoxTotalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.buttonAddService);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Perfect Cut Hair Salon";
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxHairDresser;
        private System.Windows.Forms.Button buttonAddService;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxChargedItems;
        private System.Windows.Forms.ListBox listBoxPrice;
        private System.Windows.Forms.ListBox listBoxSelectService;
        private System.Windows.Forms.ListBox listBoxTotalPrice;
    }
}

