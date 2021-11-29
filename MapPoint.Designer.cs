
namespace SAAD_PROJECT
{
    partial class MapPoint
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRuta = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClinica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboJudet = new System.Windows.Forms.ComboBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.splitContainer1.Panel1.Controls.Add(this.btnRuta);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtClinica);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cboJudet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1067, 554);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRuta
            // 
            this.btnRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRuta.Location = new System.Drawing.Point(70, 326);
            this.btnRuta.Margin = new System.Windows.Forms.Padding(4);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(171, 55);
            this.btnRuta.TabIndex = 13;
            this.btnRuta.Text = "Search";
            this.btnRuta.UseVisualStyleBackColor = true;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Adresa clinicii";
            // 
            // txtClinica
            // 
            this.txtClinica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClinica.Location = new System.Drawing.Point(157, 259);
            this.txtClinica.Name = "txtClinica";
            this.txtClinica.ReadOnly = true;
            this.txtClinica.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtClinica.Size = new System.Drawing.Size(121, 27);
            this.txtClinica.TabIndex = 11;
            this.txtClinica.Text = "Tibanesti";
            this.txtClinica.TextChanged += new System.EventHandler(this.txtClinica_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Judet pacient";
            // 
            // cboJudet
            // 
            this.cboJudet.FormattingEnabled = true;
            this.cboJudet.Location = new System.Drawing.Point(157, 202);
            this.cboJudet.Name = "cboJudet";
            this.cboJudet.Size = new System.Drawing.Size(121, 24);
            this.cboJudet.TabIndex = 9;
            this.cboJudet.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(746, 554);
            this.webBrowser1.TabIndex = 0;
            // 
            // MapPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MapPoint";
            this.Text = "MapPoint";
            this.Load += new System.EventHandler(this.MapPoint_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboJudet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClinica;
        private System.Windows.Forms.Button btnRuta;
    }
}