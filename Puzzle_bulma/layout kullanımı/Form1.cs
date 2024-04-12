using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace layout_kullanımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int koltuksayisi;


        int boyut1;


        ArrayList deger = new ArrayList();
        ArrayList indeks = new ArrayList();
        ArrayList button = new ArrayList();
        int[] ronaldo;
        int[,] gametile;
        int[] gokhan;
        Random rnd = new Random();
        static Button[] butonlari_tut;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Enabled = true;
            dogrusayisi = 0;
            int boyut;


            zaman = Convert.ToDateTime("00:00:00");
            saat = zaman.Hour;
            dakika = zaman.Minute;
            saniye = zaman.Second;

            timer1.Start();


            timer1.Enabled = true;
            boyut1 = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            boyut = Convert.ToInt32(Math.Sqrt(boyut1));



            butonlari_tut = new Button[boyut1];
            gokhan = new int[boyut1]; // sayılar
            ronaldo = new int[boyut1]; // buton yerleri



            gametile = new int[boyut, boyut];


            List<int> indexarray = new List<int>();

            int upper = boyut * boyut - 1;

            //for (int i = 0; i < boyut1; i++)
            //{
            //   butonlari_tut[i]=i; //0..15
            //    // button.Add(0);

            //}

            for (int i = 0; i < boyut * boyut; i++)
            {
                indexarray.Add(i); //0..15
                // button.Add(0);

            }
            for (int i = 1; i <= boyut1 / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int index = rnd.Next(0, upper--);
                    gametile[indexarray[index] / (boyut), indexarray[index] % (boyut)] = i;
                    indexarray.RemoveAt(index);

                }

            }

            int ayse = 0;
            int tayfun = 0;

            for (int x = 0; x < boyut; x++)
            {
                for (int y = 0; y < boyut; y++)
                {
                    gokhan[ayse] = gametile[x, y];
                    ronaldo[ayse] = tayfun;
                    tayfun++;
                    ayse++;
                }
            }



            flowLayoutPanel1.Controls.Clear();

            toplam = 0;

            label8.Text = "";
            label9.Text = "";
            int say = 0;
            for (int i = 0; i < boyut1; i++)
            {
                Button btn = new Button();
                btn.Text = Convert.ToString(gokhan[i]);
                butonlari_tut[say] = new Button();
                butonlari_tut[say].Text = Convert.ToString(gokhan[i]);
                say++;
                int b = rnd.Next(1, boyut / 2 + 1); // 4 lü için eleman üretme

                //  btn.Text=deger[i];




                if (boyut1 == 4)
                {
                    butonlari_tut[i].Width = 175;
                    butonlari_tut[i].Height = 175;
                    groupBox1.Text = "   2  *  2  ";

                }
                else  if (boyut1 == 16)
                {
                    butonlari_tut[i].Width = 86;
                    butonlari_tut[i].Height = 86;
                    groupBox1.Text = "   4  *  4  ";
                }

            else    if (boyut1 == 36)
                {
                    butonlari_tut[i].Width = 60;
                    butonlari_tut[i].Height = 60;
                    groupBox1.Text = "   6  *  6  ";
                }

                else      if (boyut1 == 64)
                {
                    butonlari_tut[i].Width = 45;
                    butonlari_tut[i].Height = 45;
                    groupBox1.Text = "   8  *  8  ";
                }
                else if(boyut1 == 100)
                    
                {
                    butonlari_tut[i].Width = 35;
                    butonlari_tut[i].Height = 35;
                    groupBox1.Text = "   10  *  10  ";
                }







                flowLayoutPanel1.Controls.Add(butonlari_tut[i]);
                int m = flowLayoutPanel1.Controls.IndexOf(butonlari_tut[i]);


                flowLayoutPanel1.AutoScroll = true;


                butonlari_tut[i].Click += new EventHandler(btn_Click);

                butonlari_tut[i].BackColor = Color.WhiteSmoke;
                // renk = btn.BackColor; 

                butonlari_tut[i].Text = "";
            }


            kesisim = new int[2];

        }

        int tus = 0;
        int[] kesisim;
        int dogrusayisi = 0;
        int saat, dakika, saniye;
        DateTime zaman;


        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int dede = flowLayoutPanel1.Controls.IndexOf(btn); // basılı butonun indeksi
            label8.Text = dede.ToString();

            kesisim[tus] = dede;

            label9.Text = gokhan[dede].ToString();

            btn.Text = gokhan[dede].ToString();
            tus++;
            label11.Text = tus.ToString();

            if (tus == 2)
            {
                if (gokhan[kesisim[tus - 1]] == gokhan[kesisim[tus - 2]]&&kesisim[tus-1]!=kesisim[tus-2])
                {
                    butonlari_tut[kesisim[tus - 1]].Enabled = false;
                    butonlari_tut[kesisim[tus - 2]].Enabled = false;

                    MessageBox.Show("doğru");
                    dogrusayisi++;

                    if (dogrusayisi == (boyut1 / 2))
                    {
                        flowLayoutPanel1.Enabled = false;
                        timer1.Enabled = false;
                        zaman = Convert.ToDateTime("00:00:00");
                    }
                    tus = 0;
                }
                else
                {
                    MessageBox.Show("yanlış");



                    butonlari_tut[kesisim[tus - 1]].Text = "";
                    butonlari_tut[kesisim[tus - 2]].Text = "";
                    tus = 0;




                }
            }

            if (tus > 2)
                tus = 0;



        }
        public int toplam;


        public int b;
        public int c;
        public int d;

        public Color White { get; set; }

        public Color Pink { get; set; }

        public Color Blue { get; set; }





        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
                foreach (Control btn in flowLayoutPanel1.Controls)
                {

                    btn.Font = new Font(btn.Font.Name,
                        btn.Font.Size, btn.Font.Style ^ FontStyle.Bold);
                }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                foreach (Control btn in flowLayoutPanel1.Controls)
                {

                    btn.Font = new Font(btn.Font.Name,
                        btn.Font.Size, btn.Font.Style ^ FontStyle.Italic);
                }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked == true)
                foreach (Control btn in flowLayoutPanel1.Controls)
                {

                    btn.Font = new Font(btn.Font.Name,
                        btn.Font.Size, btn.Font.Style ^ FontStyle.Underline);
                }

            else
                foreach (Control btn in flowLayoutPanel1.Controls)
                {

                    btn.Font = new Font(btn.Font.Name,
                        btn.Font.Size, btn.Font.Style ^ FontStyle.Regular);
                }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label13.Text = ((Convert.ToString(saat) + ":") + (Convert.ToString(dakika) + ":") + Convert.ToString(saniye));

            saniye = saniye + 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
