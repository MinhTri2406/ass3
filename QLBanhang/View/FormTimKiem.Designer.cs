namespace QLBanhang.View
{
    partial class FormTimKiem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtKeyTimKiem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvDSTimKiem = new System.Windows.Forms.DataGridView();
            this.btnXong = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHuyBo);
            this.panel1.Controls.Add(this.btnXong);
            this.panel1.Controls.Add(this.cbTimKiem);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtSdt);
            this.panel1.Controls.Add(this.txtKeyTimKiem);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 134);
            this.panel1.TabIndex = 0;
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Số điện thoại",
            "Tên"});
            this.cbTimKiem.Location = new System.Drawing.Point(81, 17);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(192, 21);
            this.cbTimKiem.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(723, 17);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(104, 22);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTen
            // 
            this.txtTen.Enabled = false;
            this.txtTen.Location = new System.Drawing.Point(148, 52);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(336, 20);
            this.txtTen.TabIndex = 3;
            // 
            // txtSdt
            // 
            this.txtSdt.Enabled = false;
            this.txtSdt.Location = new System.Drawing.Point(148, 90);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(336, 20);
            this.txtSdt.TabIndex = 4;
            // 
            // txtKeyTimKiem
            // 
            this.txtKeyTimKiem.Location = new System.Drawing.Point(354, 19);
            this.txtKeyTimKiem.Name = "txtKeyTimKiem";
            this.txtKeyTimKiem.Size = new System.Drawing.Size(363, 20);
            this.txtKeyTimKiem.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ và tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(288, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Từ khóa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm theo";
            // 
            // dtgvDSTimKiem
            // 
            this.dtgvDSTimKiem.AllowUserToAddRows = false;
            this.dtgvDSTimKiem.AllowUserToDeleteRows = false;
            this.dtgvDSTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDSTimKiem.Location = new System.Drawing.Point(12, 152);
            this.dtgvDSTimKiem.Name = "dtgvDSTimKiem";
            this.dtgvDSTimKiem.ReadOnly = true;
            this.dtgvDSTimKiem.Size = new System.Drawing.Size(841, 239);
            this.dtgvDSTimKiem.TabIndex = 2;
            // 
            // btnXong
            // 
            this.btnXong.Enabled = false;
            this.btnXong.Location = new System.Drawing.Point(723, 51);
            this.btnXong.Name = "btnXong";
            this.btnXong.Size = new System.Drawing.Size(104, 23);
            this.btnXong.TabIndex = 5;
            this.btnXong.Text = "Hoàn tất";
            this.btnXong.UseVisualStyleBackColor = true;
            this.btnXong.Click += new System.EventHandler(this.btnXong_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Location = new System.Drawing.Point(723, 86);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(104, 23);
            this.btnHuyBo.TabIndex = 5;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = true;
            // 
            // FormTimKiem
            // 
            this.AcceptButton = this.btnTimKiem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 403);
            this.ControlBox = false;
            this.Controls.Add(this.dtgvDSTimKiem);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "FormTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimKiem_FormClosing);
            this.Load += new System.EventHandler(this.FormTimKiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSTimKiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtKeyTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvDSTimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnXong;
    }
}