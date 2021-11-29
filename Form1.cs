using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace SAAD_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cboPacienti.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select numepersoana from persoane, pacient where codpersoana=codpacient";
            cmd.ExecuteNonQuery();
            System.Data.DataTable dt = new System.Data.DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cboPacienti.Items.Add(dr["numepersoana"]);
            }
            con.Close();

            cboAfectiuni.Items.Clear();
            con.Open();
            cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select denumireafectiune from afectiuni";
            cmd2.ExecuteNonQuery();
            System.Data.DataTable dt2 = new System.Data.DataTable();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
            da2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
            {
                cboAfectiuni.Items.Add(dr2["denumireafectiune"]);
            }
            con.Close();







        }

        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=mariana12;Database=Clinica_stomatologica");
        NpgsqlCommand cmd;
        NpgsqlCommand cmd1;
        NpgsqlCommand cmd2;
        NpgsqlDataAdapter da;
        NpgsqlDataReader dr;
        NpgsqlDataReader dr1;
        string npgsql;

        private void chrAfectiuni_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {


        }

        private void cboPacienti_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            cmd = new NpgsqlCommand("select denumireserviciu from persoane inner join pacient on  persoane.codpersoana = pacient.codpacient inner join programare on pacient.codpacient = programare.codpacient inner join serviciiprestate on serviciiprestate.codprogramare = programare.codprogramare inner join serviciistomatologice on serviciistomatologice.codserviciustomatologic = serviciiprestate.codserviciustomatologic where numepersoana='" + cboPacienti.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr;
            int i = 0;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBox1.Items.Add(dr["denumireserviciu"]);


            }
            con.Close();

            listBox2.Items.Clear();
            cmd1 = new NpgsqlCommand(" select distinct denumireafectiune from persoane inner join pacient on persoane.codpersoana = pacient.codpacient inner join programare on pacient.codpacient = programare.codpacient inner join serviciiprestate on serviciiprestate.codprogramare = programare.codprogramare inner join diagnostice on diagnostice.idserviciuprestat = serviciiprestate.idserviciuprestat inner join afectiuni on afectiuni.codafectiune = diagnostice.codafectiune where numepersoana='" + cboPacienti.Text + "'", con);
            con.Open();
            cmd1.ExecuteNonQuery();
            NpgsqlDataReader dr1;
            dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                listBox2.Items.Add(dr1["denumireafectiune"]);


            }
            con.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {





        }

        private void button1_Click(object sender, EventArgs e)
        {


            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("select distinct to_char(serviciiprestate.dataserviciuprestat, 'Month') as month, count(pacient.codpacient) as nr_afectiuni from serviciiprestate join factura on factura.codfactura = serviciiprestate.codfactura join pacient on pacient.codpacient = factura.codpacient group by month");

            cmd.ExecuteNonQuery();
            NpgsqlDataReader dr;
            int i = 0;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                chart1.Series["NumarPacienti"].Points.AddXY(dr["month"].ToString(), dr["nr_afectiuni"].ToString());


            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            NpgsqlConnection conexiune;
            string sirConectare;
            sirConectare = "Host=localhost;Username=postgres;Password=mariana12;Database=Clinica_stomatologica";
            conexiune = new NpgsqlConnection();
            conexiune.ConnectionString = sirConectare;
            conexiune.Open();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter("select numepersoana, datanasterii, gen, adresa from persoane inner join pacient on persoane.codpersoana = pacient.codpacient", conexiune);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            conexiune.Close();
        }

        private void cboAfectiuni_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            cmd2 = new NpgsqlCommand("select tabel.month, sum(tabel.nrafectiune) as total from (select to_char(serviciiprestate.dataserviciuprestat, 'Month') as month, denumireafectiune, count(denumireafectiune) as nrafectiune from diagnostice inner join afectiuni on afectiuni.codafectiune=diagnostice.codafectiune inner join serviciiprestate on serviciiprestate.idserviciuprestat=diagnostice.idserviciuprestat group by serviciiprestate.dataserviciuprestat, denumireafectiune having afectiuni.denumireafectiune = '" + cboAfectiuni.Text + "') as tabel group by tabel.month", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            NpgsqlDataReader dr;
            dr = cmd2.ExecuteReader();

            while (dr.Read())
            {
                chart2.Series["NrAfectiuni"].Points.AddXY(dr["month"].ToString(), dr["total"].ToString());

            }
            con.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Save as Excel File";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                ExcelApp.Columns.ColumnWidth = 20;

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                MessageBox.Show("Raportul datelor despre pacienti a fost exportat");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pathImage = Environment.CurrentDirectory + "\\ chart2.png";
            chart2.SaveImage(pathImage, ChartImageFormat.Png);

            MessageBox.Show("Chart is saved");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathImage = Environment.CurrentDirectory + "\\ chart1.png";
            chart1.SaveImage(pathImage, ChartImageFormat.Png);

            MessageBox.Show("Chart is saved");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MapPoint fm = new MapPoint();
            fm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dtGridFacturi.ClearSelection();
            NpgsqlConnection conexiune;
            string sirConectare;
            sirConectare = "Host=localhost;Username=postgres;Password=mariana12;Database=Clinica_stomatologica";
            conexiune = new NpgsqlConnection();
            conexiune.ConnectionString = sirConectare;
            conexiune.Open();
            NpgsqlDataAdapter sda = new NpgsqlDataAdapter("select distinct numepersoana, COALESCE(lunaianuarie.valoaretotala1, 0) AS lunaianuarie, COALESCE(lunafebruarie.valoaretotala1, 0) AS lunafebruarie, COALESCE(lunamartie.valoaretotala1, 0) AS lunamartie FROM factura inner join pacient on pacient.codpacient = factura.codpacient inner join persoane on persoane.codpersoana = pacient.codpacient left join(select codpacient, SUM(valoaretotala) as valoaretotala1 from factura  where extract(month from datafactura) = 1 group by codpacient) lunaianuarie on factura.codpacient = lunaianuarie.codpacient left join(select codpacient, SUM(valoaretotala) as valoaretotala1 from factura where extract(month from datafactura) = 2 group by codpacient) lunafebruarie on factura.codpacient = lunafebruarie.codpacient left join(select codpacient, SUM(valoaretotala) as valoaretotala1  from factura  where extract(month from datafactura) = 3 group by codpacient) lunamartie on factura.codpacient = lunamartie.codpacient   order by 1", conexiune);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            dtGridFacturi.DataSource = data;
            conexiune.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            saveFileDialog2.InitialDirectory = "C:";
            saveFileDialog2.Title = "Save as Excel File";
            saveFileDialog2.FileName = "";
            saveFileDialog2.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            if (saveFileDialog2.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                ExcelApp.Columns.ColumnWidth = 20;

                for (int i = 1; i < dtGridFacturi.Columns.Count + 1; i++)
                {
                    ExcelApp.Cells[1, i] = dtGridFacturi.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dtGridFacturi.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dtGridFacturi.Columns.Count; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dtGridFacturi.Rows[i].Cells[j].Value.ToString();
                    }
                }
                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog2.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                MessageBox.Show("Raportul facturilor pe primele 3 luni a fost exportat");
            }
        }
    }
}
