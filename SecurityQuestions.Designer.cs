namespace LibraryIS
{
    partial class SecurityQuestions
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtAnswerThree = new System.Windows.Forms.TextBox();
            this.txtAnswerTwo = new System.Windows.Forms.TextBox();
            this.txtAnswerOne = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.secOne = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.button1.Location = new System.Drawing.Point(49, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 23);
            this.button1.TabIndex = 93;
            this.button1.Text = "CONFIRM";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAnswerThree
            // 
            this.txtAnswerThree.Location = new System.Drawing.Point(49, 259);
            this.txtAnswerThree.Name = "txtAnswerThree";
            this.txtAnswerThree.Size = new System.Drawing.Size(245, 20);
            this.txtAnswerThree.TabIndex = 92;
            // 
            // txtAnswerTwo
            // 
            this.txtAnswerTwo.Location = new System.Drawing.Point(49, 203);
            this.txtAnswerTwo.Name = "txtAnswerTwo";
            this.txtAnswerTwo.Size = new System.Drawing.Size(245, 20);
            this.txtAnswerTwo.TabIndex = 91;
            // 
            // txtAnswerOne
            // 
            this.txtAnswerOne.Location = new System.Drawing.Point(49, 146);
            this.txtAnswerOne.Name = "txtAnswerOne";
            this.txtAnswerOne.Size = new System.Drawing.Size(245, 20);
            this.txtAnswerOne.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(51, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 17);
            this.label2.TabIndex = 89;
            this.label2.Text = "3. In what city did your parents meet?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(46, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 17);
            this.label1.TabIndex = 88;
            this.label1.Text = "2. What was your childhood nickname?";
            // 
            // secOne
            // 
            this.secOne.AutoSize = true;
            this.secOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.secOne.Location = new System.Drawing.Point(46, 124);
            this.secOne.Name = "secOne";
            this.secOne.Size = new System.Drawing.Size(253, 17);
            this.secOne.TabIndex = 87;
            this.secOne.Text = "1. What is your mother\'s middle name?";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(73, 42);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(199, 24);
            this.titleLabel.TabIndex = 86;
            this.titleLabel.Text = "Security Questions";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(74, 75);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(40, 16);
            this.txtEmail.TabIndex = 94;
            this.txtEmail.Text = "email";
            // 
            // SecurityQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 364);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAnswerThree);
            this.Controls.Add(this.txtAnswerTwo);
            this.Controls.Add(this.txtAnswerOne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secOne);
            this.Controls.Add(this.titleLabel);
            this.Name = "SecurityQuestions";
            this.Text = "Security Questions";
            this.Load += new System.EventHandler(this.SecurityQuestions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAnswerThree;
        private System.Windows.Forms.TextBox txtAnswerTwo;
        private System.Windows.Forms.TextBox txtAnswerOne;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label secOne;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label txtEmail;
    }
}