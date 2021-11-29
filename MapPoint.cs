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

namespace SAAD_PROJECT
{
    public partial class MapPoint : Form
    {
        public MapPoint()
        {
            InitializeComponent();
        }

        private void MapPoint_Load(object sender, EventArgs e)
        {
            cboJudet.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select distinct judet from persoane";
            cmd.ExecuteNonQuery();
            System.Data.DataTable dt = new System.Data.DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cboJudet.Items.Add(dr["judet"]);
            }
            con.Close();
        }
        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=mariana12;Database=Clinica_stomatologica");
        NpgsqlCommand cmd;
        NpgsqlDataAdapter da;
        NpgsqlDataReader dr;
        NpgsqlDataReader dr1;
        string npgsql;
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            string judet = cboJudet.Text;
            string adresa_clinica = txtClinica.Text;
            try
            {
                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("https://maps.google.com/maps?q=");

                if (judet != string.Empty)
                {
                    queryAddress.Append(judet );
                }

                if (adresa_clinica != string.Empty)
                {
                    queryAddress.Append(adresa_clinica );
                }

                webBrowser1.Navigate(queryAddress.ToString());
                webBrowser1.ScriptErrorsSuppressed = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void txtClinica_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
