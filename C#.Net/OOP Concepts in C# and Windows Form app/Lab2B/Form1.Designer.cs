namespace Lab2B
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
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.textBoxNumofClientVisit = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonAdult = new System.Windows.Forms.RadioButton();
            this.radioButtonChild = new System.Windows.Forms.RadioButton();
            this.radioButtonStudent = new System.Windows.Forms.RadioButton();
            this.radioButtonSenior = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxCut = new System.Windows.Forms.CheckBox();
            this.checkBoxColour = new System.Windows.Forms.CheckBox();
            this.checkBoxExtension = new System.Windows.Forms.CheckBox();
            this.checkBoxHighlights = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonJane = new System.Windows.Forms.RadioButton();
            this.radioButtonPat = new System.Windows.Forms.RadioButton();
            this.radioButtonRon = new System.Windows.Forms.RadioButton();
            this.radioButtonSue = new System.Windows.Forms.RadioButton();
            this.radioButtonLaura = new System.Windows.Forms.RadioButton();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalPrice.Location = new System.Drawing.Point(249, 517);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(129, 25);
            this.labelTotalPrice.TabIndex = 34;
            this.labelTotalPrice.Text = "Total Price: ";
            // 
            // textBoxNumofClientVisit
            // 
            this.textBoxNumofClientVisit.Location = new System.Drawing.Point(27, 70);
            this.textBoxNumofClientVisit.Name = "textBoxNumofClientVisit";
            this.textBoxNumofClientVisit.Size = new System.Drawing.Size(236, 30);
            this.textBoxNumofClientVisit.TabIndex = 1;
            this.textBoxNumofClientVisit.Text = "1";
            this.textBoxNumofClientVisit.TextChanged += new System.EventHandler(this.textBoxNumofClientVisit_TextChanged);
            this.textBoxNumofClientVisit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumofClientVisit_KeyPress);
            this.textBoxNumofClientVisit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxNumofClientVisit_KeyUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxNumofClientVisit);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(397, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 202);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Client Visits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Client Visits:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonAdult);
            this.groupBox3.Controls.Add(this.radioButtonChild);
            this.groupBox3.Controls.Add(this.radioButtonStudent);
            this.groupBox3.Controls.Add(this.radioButtonSenior);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(75, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(303, 202);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Client Type";
            // 
            // radioButtonAdult
            // 
            this.radioButtonAdult.AutoSize = true;
            this.radioButtonAdult.Checked = true;
            this.radioButtonAdult.Location = new System.Drawing.Point(21, 35);
            this.radioButtonAdult.Name = "radioButtonAdult";
            this.radioButtonAdult.Size = new System.Drawing.Size(177, 29);
            this.radioButtonAdult.TabIndex = 14;
            this.radioButtonAdult.TabStop = true;
            this.radioButtonAdult.Text = "Standard Adult";
            this.radioButtonAdult.UseVisualStyleBackColor = true;
            // 
            // radioButtonChild
            // 
            this.radioButtonChild.AutoSize = true;
            this.radioButtonChild.Location = new System.Drawing.Point(21, 71);
            this.radioButtonChild.Name = "radioButtonChild";
            this.radioButtonChild.Size = new System.Drawing.Size(238, 29);
            this.radioButtonChild.TabIndex = 15;
            this.radioButtonChild.Text = "Child (12 and under) ";
            this.radioButtonChild.UseVisualStyleBackColor = true;
            // 
            // radioButtonStudent
            // 
            this.radioButtonStudent.AutoSize = true;
            this.radioButtonStudent.Location = new System.Drawing.Point(21, 108);
            this.radioButtonStudent.Name = "radioButtonStudent";
            this.radioButtonStudent.Size = new System.Drawing.Size(108, 29);
            this.radioButtonStudent.TabIndex = 16;
            this.radioButtonStudent.Text = "Student";
            this.radioButtonStudent.UseVisualStyleBackColor = true;
            // 
            // radioButtonSenior
            // 
            this.radioButtonSenior.AutoSize = true;
            this.radioButtonSenior.Location = new System.Drawing.Point(21, 146);
            this.radioButtonSenior.Name = "radioButtonSenior";
            this.radioButtonSenior.Size = new System.Drawing.Size(190, 29);
            this.radioButtonSenior.TabIndex = 17;
            this.radioButtonSenior.Text = "Senior (over 65)";
            this.radioButtonSenior.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxCut);
            this.groupBox2.Controls.Add(this.checkBoxColour);
            this.groupBox2.Controls.Add(this.checkBoxExtension);
            this.groupBox2.Controls.Add(this.checkBoxHighlights);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(397, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 209);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Services";
            // 
            // checkBoxCut
            // 
            this.checkBoxCut.AutoSize = true;
            this.checkBoxCut.Checked = true;
            this.checkBoxCut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCut.Location = new System.Drawing.Point(24, 40);
            this.checkBoxCut.Name = "checkBoxCut";
            this.checkBoxCut.Size = new System.Drawing.Size(68, 29);
            this.checkBoxCut.TabIndex = 18;
            this.checkBoxCut.Text = "Cut";
            this.checkBoxCut.UseVisualStyleBackColor = true;
            // 
            // checkBoxColour
            // 
            this.checkBoxColour.AutoSize = true;
            this.checkBoxColour.Location = new System.Drawing.Point(24, 74);
            this.checkBoxColour.Name = "checkBoxColour";
            this.checkBoxColour.Size = new System.Drawing.Size(98, 29);
            this.checkBoxColour.TabIndex = 19;
            this.checkBoxColour.Text = "Colour";
            this.checkBoxColour.UseVisualStyleBackColor = true;
            // 
            // checkBoxExtension
            // 
            this.checkBoxExtension.AutoSize = true;
            this.checkBoxExtension.Location = new System.Drawing.Point(24, 141);
            this.checkBoxExtension.Name = "checkBoxExtension";
            this.checkBoxExtension.Size = new System.Drawing.Size(140, 29);
            this.checkBoxExtension.TabIndex = 21;
            this.checkBoxExtension.Text = "Extensions";
            this.checkBoxExtension.UseVisualStyleBackColor = true;
            // 
            // checkBoxHighlights
            // 
            this.checkBoxHighlights.AutoSize = true;
            this.checkBoxHighlights.Location = new System.Drawing.Point(24, 107);
            this.checkBoxHighlights.Name = "checkBoxHighlights";
            this.checkBoxHighlights.Size = new System.Drawing.Size(129, 29);
            this.checkBoxHighlights.TabIndex = 20;
            this.checkBoxHighlights.Text = "Highlights";
            this.checkBoxHighlights.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonJane);
            this.groupBox1.Controls.Add(this.radioButtonPat);
            this.groupBox1.Controls.Add(this.radioButtonRon);
            this.groupBox1.Controls.Add(this.radioButtonSue);
            this.groupBox1.Controls.Add(this.radioButtonLaura);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(75, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 209);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hairdresser";
            // 
            // radioButtonJane
            // 
            this.radioButtonJane.AutoSize = true;
            this.radioButtonJane.Checked = true;
            this.radioButtonJane.Location = new System.Drawing.Point(21, 40);
            this.radioButtonJane.Name = "radioButtonJane";
            this.radioButtonJane.Size = new System.Drawing.Size(159, 29);
            this.radioButtonJane.TabIndex = 9;
            this.radioButtonJane.TabStop = true;
            this.radioButtonJane.Text = "Jane Samley";
            this.radioButtonJane.UseVisualStyleBackColor = true;
            // 
            // radioButtonPat
            // 
            this.radioButtonPat.AutoSize = true;
            this.radioButtonPat.Location = new System.Drawing.Point(21, 74);
            this.radioButtonPat.Name = "radioButtonPat";
            this.radioButtonPat.Size = new System.Drawing.Size(154, 29);
            this.radioButtonPat.TabIndex = 10;
            this.radioButtonPat.Text = "Pat Johnson";
            this.radioButtonPat.UseVisualStyleBackColor = true;
            // 
            // radioButtonRon
            // 
            this.radioButtonRon.AutoSize = true;
            this.radioButtonRon.Location = new System.Drawing.Point(21, 106);
            this.radioButtonRon.Name = "radioButtonRon";
            this.radioButtonRon.Size = new System.Drawing.Size(176, 29);
            this.radioButtonRon.TabIndex = 11;
            this.radioButtonRon.Text = "Ron Chambers";
            this.radioButtonRon.UseVisualStyleBackColor = true;
            // 
            // radioButtonSue
            // 
            this.radioButtonSue.AutoSize = true;
            this.radioButtonSue.Location = new System.Drawing.Point(21, 140);
            this.radioButtonSue.Name = "radioButtonSue";
            this.radioButtonSue.Size = new System.Drawing.Size(138, 29);
            this.radioButtonSue.TabIndex = 12;
            this.radioButtonSue.Text = "Sue Pallon";
            this.radioButtonSue.UseVisualStyleBackColor = true;
            // 
            // radioButtonLaura
            // 
            this.radioButtonLaura.AutoSize = true;
            this.radioButtonLaura.Location = new System.Drawing.Point(21, 172);
            this.radioButtonLaura.Name = "radioButtonLaura";
            this.radioButtonLaura.Size = new System.Drawing.Size(171, 29);
            this.radioButtonLaura.TabIndex = 13;
            this.radioButtonLaura.Text = "Laura Renkins";
            this.radioButtonLaura.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(577, 590);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(108, 37);
            this.buttonExit.TabIndex = 29;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(346, 590);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(127, 37);
            this.buttonClear.TabIndex = 28;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculate.Location = new System.Drawing.Point(96, 590);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(121, 37);
            this.buttonCalculate.TabIndex = 27;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 662);
            this.Controls.Add(this.labelTotalPrice);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonCalculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.TextBox textBoxNumofClientVisit;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonAdult;
        private System.Windows.Forms.RadioButton radioButtonChild;
        private System.Windows.Forms.RadioButton radioButtonStudent;
        private System.Windows.Forms.RadioButton radioButtonSenior;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxCut;
        private System.Windows.Forms.CheckBox checkBoxColour;
        private System.Windows.Forms.CheckBox checkBoxExtension;
        private System.Windows.Forms.CheckBox checkBoxHighlights;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonJane;
        private System.Windows.Forms.RadioButton radioButtonPat;
        private System.Windows.Forms.RadioButton radioButtonRon;
        private System.Windows.Forms.RadioButton radioButtonSue;
        private System.Windows.Forms.RadioButton radioButtonLaura;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCalculate;
    }
}

