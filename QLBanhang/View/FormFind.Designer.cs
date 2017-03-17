namespace QLBanhang.View
{
    partial class FormFind
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
            this.cbTuychontimkiem = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtLoiNhac = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm theo";
            // 
            // cbTuychontimkiem
            // 
            this.cbTuychontimkiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTuychontimkiem.FormattingEnabled = true;
            this.cbTuychontimkiem.Items.AddRange(new object[] {
            "Số điện thoại",
            "Tên"});
            this.cbTuychontimkiem.Location = new System.Drawing.Point(116, 45);
            this.cbTuychontimkiem.Name = "cbTuychontimkiem";
            this.cbTuychontimkiem.Size = new System.Drawing.Size(203, 21);
            this.cbTuychontimkiem.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(157, 72);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 43);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtLoiNhac
            // 
            this.txtLoiNhac.BackColor = System.Drawing.SystemColors.Control;
            this.txtLoiNhac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoiNhac.Location = new System.Drawing.Point(47, 121);
            this.txtLoiNhac.Multiline = true;
            this.txtLoiNhac.Name = "txtLoiNhac";
            this.txtLoiNhac.Size = new System.Drawing.Size(309, 78);
            this.txtLoiNhac.TabIndex = 4;
            // 
            // FormFind
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 222);
            this.Controls.Add(this.txtLoiNhac);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbTuychontimkiem);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tùy chọn tìm kiếm";
            this.Load += new System.EventHandler(this.FormFind_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTuychontimkiem;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtLoiNhac;
    }
}