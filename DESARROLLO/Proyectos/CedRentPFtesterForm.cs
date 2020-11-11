using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CedRentPFtester
{
	public partial class CedRentPFtesterForm : Form
	{
		List<PF> pFs = new List<PF>();
		public CedRentPFtesterForm()
		{
			InitializeComponent();

			PF pF = new PF();
			pF.NroCertif = 809390225094;
			pF.ProductoComercial.Id = 1000007;
			pF.Capital = 8484;
			pF.Tasa = 33.06;
			pF.Plazo = 90;
			pF.FechaConst = new DateTime(2020, 10, 21);
			pF.FechaVto = new DateTime(2021, 1, 19);
			pF.Moneda.Id = "ARS";
			pFs.Add(pF);
			pF = new CedRentPFtester.PF();
			pF.NroCertif = 809390210258;
			pF.ProductoComercial.Id = 1000042;
			pF.Capital = 131;
			pF.Tasa = 1;
			pF.Plazo = 90;
			pF.FechaConst = new DateTime(2020, 6, 15);
			pF.FechaVto = new DateTime(2020, 12, 12);
			pF.Moneda.Id = "ARS";
			pFs.Add(pF);
			pF = new CedRentPFtester.PF();
			pF.NroCertif = 809390225666;
			pF.ProductoComercial.Id = 1000007;
			pF.Capital = 15000;
			pF.Tasa = 4;
			pF.Plazo = 30;
			pF.FechaConst = new DateTime(2020, 11, 1);
			pF.FechaVto = new DateTime(2020, 12, 1);
			pF.Moneda.Id = "USD";
			pFs.Add(pF);
			List<CedRentPF.Entidades.ProductoComercial> productosComerciales = CedRentPF.RN.ProductoComercial.Leer(Aplicacion.Sesion);
			for (int i=0; i<pFs.Count; i++)
            {
				CedRentPF.Entidades.ProductoComercial productoComercial = productosComerciales.Find(delegate (CedRentPF.Entidades.ProductoComercial p) { return (p.Id == pFs[i].ProductoComercial.Id); });
				if (productoComercial != null) pFs[i].ProductoComercial.Descr = productoComercial.Descr;
			}
			dataGridView.AutoGenerateColumns = false;
			dataGridView.DataSource = pFs;
			FechatextBox.Text = DateTime.Today.ToString("yyyyMMdd");
		}
		private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Buscarbutton_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				CedRentPF.Entidades.RentaClienteFiltro filtro = new CedRentPF.Entidades.RentaClienteFiltro();
				filtro.Fecha = DateTime.ParseExact(FechatextBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
				for (int i = 0; i < pFs.Count; i++)
				{
                    CedRentPF.Entidades.PF pF = new CedRentPF.Entidades.PF();
                    pF.NroCertif = pFs[i].NroCertif;
                    pF.ProductoComercial.Id = pFs[i].ProductoComercial.Id;
                    pF.Capital = pFs[i].Capital;
                    pF.Tasa = pFs[i].Tasa;
                    pF.Plazo = pFs[i].Plazo;
                    pF.FechaConst = pFs[i].FechaConst;
                    pF.FechaVto = pFs[i].FechaVto;
                    pF.Moneda.Id = pFs[i].Moneda.Id;
                    filtro.PFs.Add(pF);
                }
				CedRentPF.Entidades.RentaCliente rentaCliente = CedRentPF.RN.RentaCliente.Obtener(filtro, Aplicacion.Sesion);
				for (int i = 0; i < pFs.Count; i++)
				{
					pFs[i].Renta.Importe = rentaCliente.PFs[i].Renta.Importe;
					pFs[i].Renta.Participacion = rentaCliente.PFs[i].Renta.Participacion;
					pFs[i].Renta.InversionInicial = rentaCliente.PFs[i].Renta.InversionInicial;
				}
				//Visibilizar columnas de rentabilidad
				for (int i = 0; i < dataGridView.Rows.Count; i++)
				{
					if (!pFs[i].ProductoComercial.EsUVAprecancelable)
					{
						DataGridViewTextBoxCell oEmptyTextCell = new DataGridViewTextBoxCell();
						oEmptyTextCell.Value = String.Empty;
						dataGridView.Rows[i].Cells["Accion"] = oEmptyTextCell;
					}
				}
				dataGridView.Columns["RentaDetalleImporte"].Visible = true;
				dataGridView.Columns["RentaDetalleParticipacion"].Visible = true;
				dataGridView.Columns["RentaDetalleMontoAlDia"].Visible = true;
				dataGridView.Columns["Accion"].Visible = true;
				ImporteARSTextBox.Text = rentaCliente.RentaUltimoDia.Pesos.Importe.ToString();
				ParticipacionARSTextBox.Text = rentaCliente.RentaUltimoDia.Pesos.Participacion.ToString();
				ImporteUSDTextBox.Text = rentaCliente.RentaUltimoDia.Dolares.Importe.ToString();
				ParticipacionUSDTextBox.Text = rentaCliente.RentaUltimoDia.Dolares.Participacion.ToString();
				TotalesGroupBox.Visible = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(CedRentCOMUN.RN.Funciones.TextoCompletoExcepcion(ex), "AVISO DE EXCEPCIÓN");
			}
			finally
			{

				this.Cursor = Cursors.Default;

			}
		}
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    bool actualizarGrilla = false;
                    switch (((DataGridViewButtonColumn)senderGrid.Columns[e.ColumnIndex]).Text)
                    {
                        case "Consulta Renta UVA Precancel.":
							CedRentPF.Entidades.RentaPFUVAPrecancelableFiltro filtro = new CedRentPF.Entidades.RentaPFUVAPrecancelableFiltro();
							filtro.Fecha = DateTime.ParseExact(FechatextBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
							filtro.PF.NroCertif = pFs[e.RowIndex].NroCertif;
							filtro.PF.ProductoComercial.Id = pFs[e.RowIndex].ProductoComercial.Id;
							filtro.PF.Capital = pFs[e.RowIndex].Capital;
							filtro.PF.Tasa = pFs[e.RowIndex].Tasa;
							filtro.PF.Plazo = pFs[e.RowIndex].Plazo;
							filtro.PF.FechaConst = pFs[e.RowIndex].FechaConst;
							filtro.PF.FechaVto = pFs[e.RowIndex].FechaVto;
							filtro.PF.Moneda.Id = pFs[e.RowIndex].Moneda.Id;
							filtro.PF.TasaPrecancelacion = 20;
							CedRentPF.Entidades.RentaPFUVAPrecancelable pf = CedRentPF.RN.RentaPFUVAPrecancelable.Obtener(filtro, Aplicacion.Sesion);
							ImporteUVATextBox.Text = pf.UVA.Renta.Importe.ToString();
							ImportePrecancelacionTextBox.Text = pf.Precancelacion.Renta.Importe.ToString();
							ParticipacionUVATextBox.Text = pf.UVA.Renta.Participacion.ToString();
							ParticipacionPrecancelacionTextBox.Text = pf.Precancelacion.Renta.Participacion.ToString();
							MontoAlDiaUVATextBox.Text = pf.UVA.MontoAlDia.ToString();
							MontoAlDiaPrecancelacionTextBox.Text = pf.Precancelacion.MontoAlDia.ToString();

							RentaPFUVAPrecancelablegroupBox.Visible = true;
							break;
                        default:
                            break;
                    }
                    //if (actualizarGrilla) Buscarbutton_Click(Buscarbutton, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CedRentCOMUN.RN.Funciones.TextoCompletoExcepcion(ex), "AVISO DE EXCEPCIÓN");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void dataGridView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
			e.Cell.Selected = false;
		}
	}
}