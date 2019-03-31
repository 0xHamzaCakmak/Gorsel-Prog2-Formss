using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ticari.stok' table. You can move, or remove it, as needed.
            this.stokTableAdapter.Fill(this.ticari.stok);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //buton clik oldugunda yeni form acılarak kayıt ekleme işlemi yapmaya olanak saglar
            Form2 frm = new Form2();
            frm.yeni = true;
            frm.r = ticari.stok.NewstokRow();
            
            if (frm.ShowDialog()==DialogResult.OK)
            {
                ticari.stok.AddstokRow(frm.r);
                stokTableAdapter.Update(frm.r);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {  //buton clik oldugunda datagridde secili olan bilgiyi tablodan silme işlemi yapar  
            //Ticari.stokRow r = ticari.stok.FindBystok_id(5);
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Ticari.stokRow r = ticari.stok.FindBystok_id(id);        
            r.Delete();
            stokTableAdapter.Update(r);
        }
        private void button5_Click(object sender, EventArgs e)
        {   //datagridde secili olan bilgiyi yeni form ekranında güncelleme imkanı sunar
            Form2 frm = new Form2();
            frm.yeni = false;
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            frm.r= ticari.stok.FindBystok_id(id);
            if(frm.ShowDialog()== DialogResult.OK)
            stokTableAdapter.Update(frm.r);         
        }
        private void button9_Click(object sender, EventArgs e)
        {   //buton clik oldugunda datagridin hepsini silme işlemi yapıyor ve tabloda güncelliyor
            foreach (Ticari.stokRow item in ticari.stok.Rows)
            {
                item.Delete();
            }
            stokTableAdapter.Update(ticari.stok);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //secili olanları datagridden siliyor ve tabloyu güncelliyor
            foreach (DataGridViewRow  item in dataGridView1.SelectedRows)
            {
                int id = (int)item.Cells[0].Value;
             Ticari.stokRow   r=  ticari.stok.FindBystok_id(id);
             r.Delete();
            }
            stokTableAdapter.Update(ticari.stok);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //en başa gönderir
            stokBindingSource.MoveFirst();
        }
        private void button2_Click(object sender, EventArgs e)
        {   //bir ileri gider
            stokBindingSource.MoveNext();
        }
        private void button4_Click(object sender, EventArgs e)
        {   //bir geri gelir
            stokBindingSource.MovePrevious();
        }
        private void button3_Click(object sender, EventArgs e)
        {   //en sona gider
            stokBindingSource.MoveLast();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {   //textbox1 de yazan metni data griddeki stok tablosunda filtreleyerek arama yapar
            string filtre_cumlesi = "stok_name like'" + textBox1.Text + "%'";
            // stokBindingSource.Filter = filtre_cumlesi;  //  kayıtları gridde filtreler
            DataRow[] sec = ticari.stok.Select(filtre_cumlesi);
            object id = sec[0]["stok_id"];
            stokBindingSource.Position = stokBindingSource.Find("stok_id", id);
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                stokBindingSource.MoveNext();
            if (e.KeyCode == Keys.Up)
                stokBindingSource.MovePrevious();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                button6_Click(sender, e);
            if (e.KeyCode == Keys.F2)
                button5_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
