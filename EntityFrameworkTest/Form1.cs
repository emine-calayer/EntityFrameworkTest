using EntityFrameworkTest.Data;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace EntityFrameworkTest
{
    public partial class Form1 : Form
    {
        IOgrenciRepository _ogrenciRepo;

        public Form1()
        {
            InitializeComponent();
            _ogrenciRepo = new OgrenciRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var kayit = new Ogrenci
            {
                Adi = textBox1.Text,
                Soyadi = textBox2.Text

            };
            _ogrenciRepo.Create(kayit);
            this.kayitgetir();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitgetir();
        }

        private void kayitgetir()
        {
            dataGridViewOgr.Columns.Clear();
            dataGridViewOgr.DataSource = _ogrenciRepo.GetAll();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridViewOgr.Columns.Add(btn);
            btn.HeaderText = "Sil";
            btn.Text = "Sil";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnGuncelle = new DataGridViewButtonColumn();
            dataGridViewOgr.Columns.Add(btnGuncelle);
            btnGuncelle.HeaderText = "Guncelle";
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.UseColumnTextForButtonValue = true;
        }

        private void dataGridViewOgr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Kayýt silinecek Eminmisiniz", "Onay", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _ogrenciRepo.Delete((int)dataGridViewOgr.Rows[e.RowIndex].Cells[0].Value);
                    MessageBox.Show("Baþarýyla silindi");
                    kayitgetir();
                }
            }
            else if (e.ColumnIndex == 4)
            {
                textBox3.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox4.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox5.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[2].Value.ToString();
                groupBox1.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var guncelle = new Ogrenci
            {
                Id = Convert.ToInt32(textBox3.Text),
                Adi = textBox4.Text,
                Soyadi = textBox5.Text

            };
            _ogrenciRepo.Update(guncelle);
            groupBox1.Visible = false;
            kayitgetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
    }
}