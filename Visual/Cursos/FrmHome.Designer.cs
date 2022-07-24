namespace Visual.Cursos
{
    partial class FrmHome
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReclusos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ColCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclusos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 24);
            this.label1.TabIndex = 52;
            this.label1.Text = "Reclusos con condena menor a 100 días.";
            // 
            // dgvReclusos
            // 
            this.dgvReclusos.AllowUserToAddRows = false;
            this.dgvReclusos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReclusos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReclusos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReclusos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReclusos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvReclusos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReclusos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReclusos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReclusos.ColumnHeadersHeight = 21;
            this.dgvReclusos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCod,
            this.ColNom,
            this.ColApe,
            this.col_Cedula,
            this.ColGen,
            this.ColEd});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReclusos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReclusos.EnableHeadersVisualStyles = false;
            this.dgvReclusos.GridColor = System.Drawing.Color.White;
            this.dgvReclusos.Location = new System.Drawing.Point(23, 124);
            this.dgvReclusos.Name = "dgvReclusos";
            this.dgvReclusos.ReadOnly = true;
            this.dgvReclusos.RowHeadersVisible = false;
            this.dgvReclusos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReclusos.Size = new System.Drawing.Size(546, 227);
            this.dgvReclusos.TabIndex = 51;
            this.dgvReclusos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReclusos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReclusos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReclusos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReclusos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReclusos.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReclusos.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.dgvReclusos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvReclusos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReclusos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvReclusos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReclusos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvReclusos.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvReclusos.ThemeStyle.ReadOnly = true;
            this.dgvReclusos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReclusos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReclusos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvReclusos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReclusos.ThemeStyle.RowsStyle.Height = 22;
            this.dgvReclusos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReclusos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ColCod
            // 
            this.ColCod.HeaderText = "Codigo";
            this.ColCod.Name = "ColCod";
            this.ColCod.ReadOnly = true;
            // 
            // ColNom
            // 
            this.ColNom.HeaderText = "Nombres";
            this.ColNom.Name = "ColNom";
            this.ColNom.ReadOnly = true;
            // 
            // ColApe
            // 
            this.ColApe.HeaderText = "Apellidos";
            this.ColApe.Name = "ColApe";
            this.ColApe.ReadOnly = true;
            // 
            // col_Cedula
            // 
            this.col_Cedula.HeaderText = "Cédula";
            this.col_Cedula.Name = "col_Cedula";
            this.col_Cedula.ReadOnly = true;
            // 
            // ColGen
            // 
            this.ColGen.HeaderText = "Genero";
            this.ColGen.Name = "ColGen";
            this.ColGen.ReadOnly = true;
            // 
            // ColEd
            // 
            this.ColEd.HeaderText = "FechaNac";
            this.ColEd.Name = "ColEd";
            this.ColEd.ReadOnly = true;
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Visual.Properties.Resources.ReclusoBG6;
            this.ClientSize = new System.Drawing.Size(591, 405);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReclusos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclusos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReclusos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEd;
    }
}