using Microsoft.SqlServer.Server;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;

namespace csharp
{
    public partial class systemform : Form
    {
        public systemform()
        {
            InitializeComponent();
            
        }

        public systemform(Panel panel2)
        {
            this.panel2 = panel2;
        }

        private void getdatafromdatabase()
        {
            
            OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
            cn.Open();
            OdbcCommand cmd = new OdbcCommand("Select * from Defination_table1 where FormID   = '" + textBox1.Text +"' ", cn);
            
            var Reader  = cmd.ExecuteReader();
            DataSet dt = new DataSet();
            while (Reader.Read())
            {
                dataGridView1.Rows.Add(Reader["FormID"], Reader ["ID"], Reader["sortorder"], Reader["fieldname"], Reader["type"], Reader["length"], Reader["required"], Reader["pk"], Reader["fk"]);
            }
            
            cn.Close();
            
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                string combo = txtType.Text;
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                string text3 = textBox3.Text;
                string combo2 = comboBox2.Text;
                OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
                cn.Open();
                OdbcCommand cmd = new OdbcCommand("INSERT INTO setting values (?, ?, ?, ?, ?)", cn);
                cmd.Parameters.AddWithValue(combo, txtType.Text);
                cmd.Parameters.AddWithValue(text1, textBox1.Text);
                cmd.Parameters.AddWithValue(text2, textBox2.Text);
                cmd.Parameters.AddWithValue(text3, textBox3.Text);
                cmd.Parameters.AddWithValue(combo2, comboBox2.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed" , ex.Message);
            }
           
        }
        double val = 0;
        private void add_Click(object sender, EventArgs e)
        {
            OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
            cn.Open();
            OdbcCommand command = new OdbcCommand("Select (FormID)from setting ", cn);
            int i = Convert.ToInt32(command.ExecuteScalar());
            cn.Close();
            i++;
            textBox1.Text = val + i.ToString();
            this.dataGridView3.Rows.Clear();
            DataGridVieww();
            

        }

        private void update_Click(object sender, EventArgs e)
        {
            string combo = txtType.Text;
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            string text3 = textBox3.Text;
            string combo2 = comboBox2.Text;
            OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
            cn.Open();
            OdbcCommand cmd = new OdbcCommand("update setting SET type=?,code=?,title=?,statuss=? where FormID =? ", cn) ;
           
            cmd.Parameters.AddWithValue("@type", txtType.Text);
            cmd.Parameters.AddWithValue("@code", textBox2.Text);
            cmd.Parameters.AddWithValue("@title", textBox3.Text);
            cmd.Parameters.AddWithValue("@statuss", comboBox2.Text);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void del_Click(object sender, EventArgs e)
        {
          
            OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
            cn.Open();
            OdbcCommand cmd = new OdbcCommand("DELETE FROM setting  WHERE FormID   = '" + textBox1.Text +"'", cn);
            cmd.ExecuteNonQuery ();
            MessageBox.Show("deleted") ;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string text1 = textBox1.Text;
                string text4 = textBox4.Text;
                string text5 = textBox5.Text;
                string text6 = textBox6.Text;
                string text7 = textBox7.Text; 
                string text8 = textBox8.Text;
                string text9 = textBox9.Text;
                string text10 = textBox10.Text;
                string text11 = textBox11.Text;
                OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
                cn.Open();
                OdbcCommand cmd = new OdbcCommand("INSERT INTO Defination_table1 values (?, ?, ?, ?, ?, ?, ?, ?, ?)", cn);
                cmd.Parameters.AddWithValue(text1, textBox1.Text);
                cmd.Parameters.AddWithValue(text4, textBox4.Text);
                cmd.Parameters.AddWithValue(text5, textBox5.Text);
                cmd.Parameters.AddWithValue(text6, textBox6.Text);
                cmd.Parameters.AddWithValue(text7, textBox7.Text);
                cmd.Parameters.AddWithValue(text8, textBox8.Text);
                cmd.Parameters.AddWithValue(text9, textBox9.Text);
                cmd.Parameters.AddWithValue(text10, textBox10.Text);
                cmd.Parameters.AddWithValue(text11, textBox11.Text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
        }

        public void DataGridVieww ()
        {
            OdbcConnection cn = new OdbcConnection("Dsn=AB;trusted_connection=Yes;app=Microsoft® Visual Studio®;wsid=LAPTOP-6CH9N870;database=employeeedb");
            cn.Open();
            OdbcCommand cmd = new OdbcCommand("Select * from setting", cn);

            var Reader = cmd.ExecuteReader();
            DataSet dt = new DataSet();
            while (Reader.Read())
            {
                dataGridView3.Rows.Add(Reader["type"], Reader["FormID"], Reader["code"], Reader["title"], Reader["statuss"]);
            }
            cn.Close();
            

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if ( e.RowIndex == null)
            {
                return;
            }
            else 
            {
                dataGridView3.CurrentRow.Selected = true;
                txtType.Text = dataGridView3.Rows[e.RowIndex].Cells["Column9"].FormattedValue.ToString();
                textBox1.Text = dataGridView3.Rows[e.RowIndex].Cells["FormID"].FormattedValue.ToString();
                textBox2.Text = dataGridView3.Rows[e.RowIndex].Cells["Code"].FormattedValue.ToString();
                textBox3.Text = dataGridView3.Rows[e.RowIndex].Cells["Title"].FormattedValue.ToString();
                comboBox2.Text = dataGridView3.Rows[e.RowIndex].Cells["Status"].FormattedValue.ToString();
            }
            

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            getdatafromdatabase();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
 

        private void Refresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            getdatafromdatabase();
        }

        private void systemform_Load(object sender, EventArgs e)
        {

        }
      
        public void button1_Click_1(object sender, EventArgs e)
        {
            string text3 = textBox3.Text;
            if (txtType.Text == "Defination ")
            {
                double h = 50;
               
               Form titleform = new Form();
                titleform = new Form();
                
                Label LblName = new Label();
                LblName.Text = "wwwwwwwwwwww";
                LblName.Dock = DockStyle.Left;
                LblName.Location = Location;
                
                
                Label lblFather = new Label();
                lblFather.Text = "";
                Label lblAGE = new Label();
                lblAGE.Text = "";
                TextBox txtName = new TextBox();
                TextBox txtFathername = new TextBox();
                TextBox txtAge = new TextBox();
                titleform.TopLevel = false;
                panel2.Controls.Add(titleform);

                titleform.Show();




            }
            else 
            {
                MessageBox.Show("fail");
            }
             
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
