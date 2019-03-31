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
    public partial class Form2 : Form
    {
        public Ticari.stokRow r;
        public bool yeni;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ticari.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.ticari.category);
             if (yeni)
                 temizle();
             else 
              db_to_src();


        }

        private void temizle()
        {
            textBox1.Text = "";
            textBox2.Text ="";
            comboBox1.SelectedIndex=0;
        }

        private void db_to_src()
        {
            textBox1.Text = r.stok_name;
            textBox2.Text = r.unit_price.ToString();
            comboBox1.SelectedValue = r.cat_id;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            src_to_db();
            this.DialogResult = DialogResult.OK;

        }

        private void src_to_db()
        {
            r.stok_name = textBox1.Text;
            r.unit_price = Convert.ToDouble(textBox2.Text);
            r.cat_id = (int)comboBox1.SelectedValue;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
