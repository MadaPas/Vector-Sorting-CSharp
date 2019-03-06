using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortare_vectori_animat
{
    public partial class Form1 : Form
    {
        TextBox[] t1 = new TextBox[200];
        TextBox[] t2 = new TextBox[200];
         int[] v = new int[200];
         int[] v1 = new int[200];
        int n,i,j,ii,jj;
        Random r = new Random(); int ww,nr,alina,nrr,aux,nrmm,wew;
        Font fontnou = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      

        private void button1_Click(object sender, EventArgs e)// genereaza si afiseaza vector
        {
            n = Convert.ToInt32(textBox1.Text);
            int i;
            for (i = 1; i <= n; i++)// bule[1]
            {
                t1[i] = new TextBox();
                t1[i].Width = t1[i].Height = 55;
                t1[i].Multiline = true;
                t1[i].Top = 100;
                t1[i].Left = 160 + (i - 1) * 57;
                v[i] = r.Next(1, 10);
                v1[i] = v[i];
                t1[i].Text = Convert.ToString(v[i]);
                t1[i].Font = fontnou;
                t1[i].TextAlign = HorizontalAlignment.Center;
                this.Controls.Add(t1[i]);
            }


            for ( i=1; i<= n; i++)// inserare[2]
            {
                t2[i] = new TextBox();
                t2[i].Width = t2[i].Height = 55;
                t2[i].Multiline = true;
                t2[i].Top = 300;
                t2[i].Left = 160 + (i - 1) * 57;
                t2[i].Text = Convert.ToString(v[i]);
                t2[i].Font = fontnou;
                t2[i].TextAlign = HorizontalAlignment.Center;
                this.Controls.Add(t2[i]);
            }


        }
                 
        private void button2_Click(object sender, EventArgs e)
        {

           nr = 0; i = 1; j = 2;
           timer1.Start(); 


        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v[i] > v[j])
            {
                if (nr == 0)
                { t1[i].Top--; t1[j].Top++; if (t1[i].Top == 42) nr = 1; }
                if (nr == 1)
                { t1[i].Left++; t1[j].Left--; if (t1[i].Left == 160 + (j - 1) * 57) nr = 2; }
                if (nr == 2)
                {
                    t1[i].Top++; t1[j].Top--;
                    if (t1[i].Top == 100)
                    {
                        int aux = v[i];
                        v[i] = v[j];
                        v[j] = aux;
                        nr = 3;
                        TextBox aux1 = t1[i];
                        t1[i] = t1[j]; t1[j] = aux1;
                    }
                }
            }
            if (v[i]<=v[j] || nr == 3)
                {
                    nr = 0;
                    if (j < n) { j++; }
                    else
                        if (i < n - 1) { i++; j = i + 1; }
                        else
                        {
                            for (int fin = 1; fin <= n; fin++)
                                t1[fin].BackColor = Color.LightGreen;
                            timer1.Stop();
                        }
                }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int ii=1;ii<=n;ii++)
               this.Controls.Remove(t1[ii]);
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int ii = 1; ii <= n; ii++)
                this.Controls.Remove(t2[ii]);
            timer2.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int ii = 1; ii <= n; ii++)
            {
                this.Controls.Remove(t2[ii]);
                this.Controls.Remove(t1[ii]);  
            }
            timer1.Stop();
            timer2.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //v1
            nrr = 0;
            ii = 2;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (nrr == 0)//pas 1
            {
                nrmm = 0;//numarul de numere mai mari din v1 fata de v[ii] de pe pozitii mai mici(in stanga)
                for (int robert = 1; robert < ii; robert++)// se gaseste valoare variabilei nrmm
                {
                    if (v1[robert] > v1[ii])
                        nrmm++;
                }
                if (nrmm > 0)//daca sunt numere mai mari decat v1[ii] in stanga lui se insereaza dupa nrmm numere valoare din v1[ii] (in stanga)
                {
                    alina = v1[ii];
                    for (int h = ii; h >= ii - nrmm + 1; h--)
                    {
                        v1[h] = v1[h - 1];
                    }
                    v1[ii - nrmm] = alina;
                    nrr = 1;
                }
                else//daca nrmm==0 atunci mergem la urmatoare valoade din vector
                {
                    if(ii<n)
                    ii++;
                    else
                    {

                        for (int fin = 1; fin <= n; fin++)
                            t2[fin].BackColor = Color.LightGreen;
                        timer2.Stop();
                    }
                }
            }
            
                if (nrr == 1)//pas 2
            {
                if (t2[ii].Top > 243)
                {
                    t2[ii].Top--;//v1[ii]urca
                    for(int mama=ii-nrmm;mama<ii;mama++)
                        t2[mama].Left++;// cele nrmm numere mai mari decat v1[ii] din stanga acestuia se deplaseaza cu o patratica catre dreapta
                }
                else
                    nrr = 2;//t2[ii] a ajuns la pozitia dorita deci mergem la pasul urmator
            }
            if (nrr == 2)//pas 3
            {
                if (t2[ii].Left > 160 + (ii - nrmm - 1) * 57)
                    t2[ii].Left--;// se deplaseaza catre stanga t2[ii] pana la locul corect in vector 
                else
                    nrr=3;//pasul urmator
            }
            if (nrr == 3)//pas 4
            {
                if (t2[ii].Top < 300)
                    t2[ii].Top++;// coboara t2[ii]
                else { nrr = 4;  }
            }
            if (nrr == 4)//pas 5
            {
                // sortarea vectorului de tip textbox, t2 
                TextBox aalina = t2[ii];
                for (int h = ii; h >= ii - nrmm + 1; h--)
                {
                    t2[h] = t2[h - 1];
                }
                t2[ii-nrmm] = aalina;


                if (ii == n)
                {

                    for (int fin = 1; fin <= n; fin++)
                        t2[fin].BackColor = Color.LightGreen;
                    timer2.Stop();
                }
                if(ii<n)
                ii++;
                nrr = 0;
               
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            nrr = 0;
            ii = 2;
            nr = 0; i = 1; j = 2;
            timer1.Start();
            timer2.Start();
        }

      }
    }

