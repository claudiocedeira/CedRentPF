namespace CedRentPFtester
{
    partial class CedRentPFtesterForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CedRentPFtesterForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.NroCertif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonedaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaConst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentaDetalleImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentaDetalleParticipacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RentaDetalleMontoAlDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TotalesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.FechatextBox = new System.Windows.Forms.TextBox();
            this.ConsultarRentaClientebutton = new System.Windows.Forms.Button();
            this.ImporteARSTextBox = new System.Windows.Forms.TextBox();
            this.ParticipacionARSTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ParticipacionUSDTextBox = new System.Windows.Forms.TextBox();
            this.ImporteUSDTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.TotalesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1236, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1236, 358);
            this.panel2.TabIndex = 8;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroCertif,
            this.ProductoId,
            this.MonedaId,
            this.Capital,
            this.Tasa,
            this.Plazo,
            this.FechaConst,
            this.FechaVto,
            this.RentaDetalleImporte,
            this.RentaDetalleParticipacion,
            this.RentaDetalleMontoAlDia,
            this.Accion});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(1236, 358);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dataGridView_CellStateChanged);
            // 
            // NroCertif
            // 
            this.NroCertif.DataPropertyName = "NroCertif";
            this.NroCertif.HeaderText = "NroCertif";
            this.NroCertif.Name = "NroCertif";
            this.NroCertif.ReadOnly = true;
            this.NroCertif.Width = 73;
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "ProductoId";
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            this.ProductoId.Width = 84;
            // 
            // MonedaId
            // 
            this.MonedaId.DataPropertyName = "MonedaId";
            this.MonedaId.HeaderText = "MonedaId";
            this.MonedaId.Name = "MonedaId";
            this.MonedaId.ReadOnly = true;
            this.MonedaId.Width = 80;
            // 
            // Capital
            // 
            this.Capital.DataPropertyName = "Capital";
            this.Capital.HeaderText = "Capital";
            this.Capital.Name = "Capital";
            this.Capital.ReadOnly = true;
            this.Capital.Width = 64;
            // 
            // Tasa
            // 
            this.Tasa.DataPropertyName = "Tasa";
            this.Tasa.HeaderText = "Tasa";
            this.Tasa.Name = "Tasa";
            this.Tasa.ReadOnly = true;
            this.Tasa.Width = 56;
            // 
            // Plazo
            // 
            this.Plazo.DataPropertyName = "Plazo";
            this.Plazo.HeaderText = "Plazo";
            this.Plazo.Name = "Plazo";
            this.Plazo.ReadOnly = true;
            this.Plazo.Width = 58;
            // 
            // FechaConst
            // 
            this.FechaConst.DataPropertyName = "FechaConst";
            this.FechaConst.HeaderText = "FechaConst";
            this.FechaConst.Name = "FechaConst";
            this.FechaConst.ReadOnly = true;
            this.FechaConst.Width = 89;
            // 
            // FechaVto
            // 
            this.FechaVto.DataPropertyName = "FechaVto";
            this.FechaVto.HeaderText = "FechaVto";
            this.FechaVto.Name = "FechaVto";
            this.FechaVto.ReadOnly = true;
            this.FechaVto.Width = 78;
            // 
            // RentaDetalleImporte
            // 
            this.RentaDetalleImporte.DataPropertyName = "RentaDetalleImporte";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RentaDetalleImporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.RentaDetalleImporte.HeaderText = "Renta";
            this.RentaDetalleImporte.Name = "RentaDetalleImporte";
            this.RentaDetalleImporte.ReadOnly = true;
            this.RentaDetalleImporte.Visible = false;
            this.RentaDetalleImporte.Width = 61;
            // 
            // RentaDetalleParticipacion
            // 
            this.RentaDetalleParticipacion.DataPropertyName = "RentaDetalleParticipacion";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RentaDetalleParticipacion.DefaultCellStyle = dataGridViewCellStyle2;
            this.RentaDetalleParticipacion.HeaderText = "%";
            this.RentaDetalleParticipacion.Name = "RentaDetalleParticipacion";
            this.RentaDetalleParticipacion.ReadOnly = true;
            this.RentaDetalleParticipacion.Visible = false;
            this.RentaDetalleParticipacion.Width = 40;
            // 
            // RentaDetalleMontoAlDia
            // 
            this.RentaDetalleMontoAlDia.DataPropertyName = "RentaDetalleMontoAlDia";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RentaDetalleMontoAlDia.DefaultCellStyle = dataGridViewCellStyle3;
            this.RentaDetalleMontoAlDia.HeaderText = "Monto al dia";
            this.RentaDetalleMontoAlDia.Name = "RentaDetalleMontoAlDia";
            this.RentaDetalleMontoAlDia.ReadOnly = true;
            this.RentaDetalleMontoAlDia.Visible = false;
            this.RentaDetalleMontoAlDia.Width = 90;
            // 
            // Accion
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Accion.DefaultCellStyle = dataGridViewCellStyle4;
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Text = "Consulta Renta PFuva";
            this.Accion.UseColumnTextForButtonValue = true;
            this.Accion.Visible = false;
            this.Accion.Width = 46;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TotalesGroupBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.FechatextBox);
            this.panel1.Controls.Add(this.ConsultarRentaClientebutton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1236, 68);
            this.panel1.TabIndex = 7;
            // 
            // TotalesGroupBox
            // 
            this.TotalesGroupBox.Controls.Add(this.groupBox3);
            this.TotalesGroupBox.Controls.Add(this.groupBox2);
            this.TotalesGroupBox.Location = new System.Drawing.Point(601, 0);
            this.TotalesGroupBox.Name = "TotalesGroupBox";
            this.TotalesGroupBox.Size = new System.Drawing.Size(389, 68);
            this.TotalesGroupBox.TabIndex = 61;
            this.TotalesGroupBox.TabStop = false;
            this.TotalesGroupBox.Text = "TOTALES (rentabilidad último día)";
            this.TotalesGroupBox.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ParticipacionARSTextBox);
            this.groupBox2.Controls.Add(this.ImporteARSTextBox);
            this.groupBox2.Location = new System.Drawing.Point(19, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 44);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ARS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Fecha";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FechatextBox
            // 
            this.FechatextBox.Location = new System.Drawing.Point(55, 22);
            this.FechatextBox.Name = "FechatextBox";
            this.FechatextBox.Size = new System.Drawing.Size(67, 20);
            this.FechatextBox.TabIndex = 59;
            // 
            // ConsultarRentaClientebutton
            // 
            this.ConsultarRentaClientebutton.Location = new System.Drawing.Point(271, 21);
            this.ConsultarRentaClientebutton.Name = "ConsultarRentaClientebutton";
            this.ConsultarRentaClientebutton.Size = new System.Drawing.Size(150, 20);
            this.ConsultarRentaClientebutton.TabIndex = 7;
            this.ConsultarRentaClientebutton.Text = "Consultar Renta Cliente";
            this.ConsultarRentaClientebutton.UseVisualStyleBackColor = true;
            this.ConsultarRentaClientebutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // ImporteARSTextBox
            // 
            this.ImporteARSTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ImporteARSTextBox.Location = new System.Drawing.Point(10, 16);
            this.ImporteARSTextBox.Name = "ImporteARSTextBox";
            this.ImporteARSTextBox.Size = new System.Drawing.Size(84, 20);
            this.ImporteARSTextBox.TabIndex = 0;
            // 
            // ParticipacionARSTextBox
            // 
            this.ParticipacionARSTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ParticipacionARSTextBox.Location = new System.Drawing.Point(100, 16);
            this.ParticipacionARSTextBox.Name = "ParticipacionARSTextBox";
            this.ParticipacionARSTextBox.Size = new System.Drawing.Size(40, 20);
            this.ParticipacionARSTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "%";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.ParticipacionUSDTextBox);
            this.groupBox3.Controls.Add(this.ImporteUSDTextBox);
            this.groupBox3.Location = new System.Drawing.Point(198, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 44);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "USD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // ParticipacionUSDTextBox
            // 
            this.ParticipacionUSDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ParticipacionUSDTextBox.Location = new System.Drawing.Point(100, 16);
            this.ParticipacionUSDTextBox.Name = "ParticipacionUSDTextBox";
            this.ParticipacionUSDTextBox.Size = new System.Drawing.Size(40, 20);
            this.ParticipacionUSDTextBox.TabIndex = 1;
            // 
            // ImporteUSDTextBox
            // 
            this.ImporteUSDTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ImporteUSDTextBox.Location = new System.Drawing.Point(10, 16);
            this.ImporteUSDTextBox.Name = "ImporteUSDTextBox";
            this.ImporteUSDTextBox.Size = new System.Drawing.Size(84, 20);
            this.ImporteUSDTextBox.TabIndex = 0;
            // 
            // CedRentPFtesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CedRentPFtesterForm";
            this.Text = "Rentabilidad PF Tester";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TotalesGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ConsultarRentaClientebutton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox FechatextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCertif;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonedaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capital;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaConst;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVto;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentaDetalleImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentaDetalleParticipacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn RentaDetalleMontoAlDia;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.GroupBox TotalesGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ParticipacionUSDTextBox;
        private System.Windows.Forms.TextBox ImporteUSDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ParticipacionARSTextBox;
        private System.Windows.Forms.TextBox ImporteARSTextBox;
    }
}

