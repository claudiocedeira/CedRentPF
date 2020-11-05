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
			pF.Producto.Id = 1000007;
			pF.Capital = 8484;
			pF.Tasa = 33.06;
			pF.Plazo = 90;
			pF.FechaConst = new DateTime(2020, 10, 21);
			pF.FechaVto = new DateTime(2021, 1, 19);
			pF.Moneda.Id = "ARS";
			pFs.Add(pF);
			pF = new CedRentPFtester.PF();
			pF.NroCertif = 809390210258;
			pF.Producto.Id = 1000042;
			pF.Capital = 131;
			pF.Tasa = 1;
			pF.Plazo = 90;
			pF.FechaConst = new DateTime(2020, 6, 15);
			pF.FechaVto = new DateTime(2020, 12, 12);
			pF.Moneda.Id = "ARS";
			pFs.Add(pF);
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
                    pF.Producto.Id = pFs[i].Producto.Id;
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
					if (dataGridView.Rows[i].Cells["ProductoId"].Value.ToString() != "1000042")
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
                        case "Consulta Renta PFuva":
                            //switch (tarifarioFiltrado.Minimo[e.RowIndex].Estado.Id)
                            //{
                            //    case "Vigente":
                            //    case "AltaPteAutoriz":
                            //    case "ModifPteAutoriz":
                            //        using (ElementoTarifarioMinimoForm elementoForm = new ElementoTarifarioMinimoForm(fechaTarifario, tarifarioFiltrado.Minimo[e.RowIndex], Enum.ModoElementoTarifario.Modificacion))
                            //        {
                            //            if (elementoForm.ShowDialog(this) == DialogResult.OK)
                            //            {
                            //                actualizarGrilla = true;
                            //            }
                            //        }
                            //        break;
                            //    default:
                            //        MessageBox.Show("Opción inválida", "ATENCIÓN");
                            //        break;
                            //}
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