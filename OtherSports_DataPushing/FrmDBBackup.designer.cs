namespace OtherSports_DataPushing
{
    partial class FrmDBBackup
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.lblVideoNo = new System.Windows.Forms.Label();
            this.btnPath1 = new System.Windows.Forms.Button();
            this.btnPath2 = new System.Windows.Forms.Button();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRestorePath = new System.Windows.Forms.TextBox();
            this.btnDBRestore = new System.Windows.Forms.Button();
            this.btnRestorePath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(110, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 485;
            this.label1.Text = "Database Backup";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(162, 221);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(84, 29);
            this.btnSubmit.TabIndex = 484;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtPath1
            // 
            this.txtPath1.Location = new System.Drawing.Point(125, 98);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.Size = new System.Drawing.Size(204, 22);
            this.txtPath1.TabIndex = 483;
            // 
            // lblVideoNo
            // 
            this.lblVideoNo.AutoSize = true;
            this.lblVideoNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoNo.ForeColor = System.Drawing.Color.Gray;
            this.lblVideoNo.Location = new System.Drawing.Point(35, 100);
            this.lblVideoNo.Name = "lblVideoNo";
            this.lblVideoNo.Size = new System.Drawing.Size(59, 14);
            this.lblVideoNo.TabIndex = 482;
            this.lblVideoNo.Text = "Path  1:";
            // 
            // btnPath1
            // 
            this.btnPath1.Location = new System.Drawing.Point(335, 96);
            this.btnPath1.Name = "btnPath1";
            this.btnPath1.Size = new System.Drawing.Size(30, 23);
            this.btnPath1.TabIndex = 486;
            this.btnPath1.Text = "....";
            this.btnPath1.UseVisualStyleBackColor = true;
            this.btnPath1.Click += new System.EventHandler(this.btnPath1_Click);
            // 
            // btnPath2
            // 
            this.btnPath2.Location = new System.Drawing.Point(335, 154);
            this.btnPath2.Name = "btnPath2";
            this.btnPath2.Size = new System.Drawing.Size(30, 23);
            this.btnPath2.TabIndex = 489;
            this.btnPath2.Text = "....";
            this.btnPath2.UseVisualStyleBackColor = true;
            this.btnPath2.Click += new System.EventHandler(this.btnPath2_Click);
            // 
            // txtPath2
            // 
            this.txtPath2.Location = new System.Drawing.Point(125, 156);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.Size = new System.Drawing.Size(204, 22);
            this.txtPath2.TabIndex = 488;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(35, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 487;
            this.label2.Text = "Path  2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(71, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 14);
            this.label3.TabIndex = 490;
            this.label3.Text = "Database BackUp has been created successful";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblVideoNo);
            this.groupBox1.Controls.Add(this.btnPath2);
            this.groupBox1.Controls.Add(this.txtPath1);
            this.groupBox1.Controls.Add(this.txtPath2);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPath1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(18, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 267);
            this.groupBox1.TabIndex = 491;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRestorePath);
            this.groupBox2.Controls.Add(this.btnDBRestore);
            this.groupBox2.Controls.Add(this.btnRestorePath);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(450, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 267);
            this.groupBox2.TabIndex = 492;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(110, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 25);
            this.label4.TabIndex = 485;
            this.label4.Text = "Database Restore";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(65, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 14);
            this.label5.TabIndex = 490;
            this.label5.Text = "Database BackUp has been created successful";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(50, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 14);
            this.label6.TabIndex = 482;
            this.label6.Text = "Path :";
            // 
            // txtRestorePath
            // 
            this.txtRestorePath.Location = new System.Drawing.Point(125, 98);
            this.txtRestorePath.Name = "txtRestorePath";
            this.txtRestorePath.Size = new System.Drawing.Size(204, 22);
            this.txtRestorePath.TabIndex = 483;
            // 
            // btnDBRestore
            // 
            this.btnDBRestore.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDBRestore.Location = new System.Drawing.Point(171, 184);
            this.btnDBRestore.Name = "btnDBRestore";
            this.btnDBRestore.Size = new System.Drawing.Size(84, 29);
            this.btnDBRestore.TabIndex = 484;
            this.btnDBRestore.Text = "Submit";
            this.btnDBRestore.UseVisualStyleBackColor = true;
            // 
            // btnRestorePath
            // 
            this.btnRestorePath.Location = new System.Drawing.Point(335, 96);
            this.btnRestorePath.Name = "btnRestorePath";
            this.btnRestorePath.Size = new System.Drawing.Size(30, 23);
            this.btnRestorePath.TabIndex = 486;
            this.btnRestorePath.Text = "....";
            this.btnRestorePath.UseVisualStyleBackColor = true;
            // 
            // FrmDBBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 303);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDBBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDBBackup";
            this.Load += new System.EventHandler(this.FrmDBBackup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtPath1;
        private System.Windows.Forms.Label lblVideoNo;
        private System.Windows.Forms.Button btnPath1;
        private System.Windows.Forms.Button btnPath2;
        private System.Windows.Forms.TextBox txtPath2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRestorePath;
        private System.Windows.Forms.Button btnDBRestore;
        private System.Windows.Forms.Button btnRestorePath;
    }
}