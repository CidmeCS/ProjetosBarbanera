using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque.Views
{
    public partial class frmCalculo : Form
    {

        //barra
        Double larguraBarra, espessuraBarra, comprimentoBarra, kgBarra;
        //tarugo
        Double diametroTarugo, comprimentoTarugo, kgTarugo;
        //tubo
        Double espessuraTubo, espessuraTubo2, comprimentoTubo, comprimentoTubo2, kgTubo_Externo, kgTubo_Interno, kgTubo, diametroInternoTubo, diametroExternoTubo;
        //Sextavado
        Double diametroSextavado, comprimentoSextavado, KgSextavado;

        public frmCalculo()
        {
            InitializeComponent();
        }


        //Radio Buttons
        public void rbBarQuadRet_AcoInox_CheckedChanged(object sender, EventArgs e)
        {
            CalculoBarra(); CalculoTarugo(); CalculoTubo();
        }

        public void rbBarQuadRet_Latao_CheckedChanged(object sender, EventArgs e)
        {
            CalculoBarra(); CalculoTarugo(); CalculoTubo();
        }

        public void rbBarQuadRet_Cobre_CheckedChanged(object sender, EventArgs e)
        {
            CalculoBarra(); CalculoTarugo(); CalculoTubo();
        }

        public void rbBarQuadRet_Bronze_CheckedChanged(object sender, EventArgs e)
        {
            CalculoBarra(); CalculoTarugo(); CalculoTubo();
        }

        public void rbBarQuadRet_Aluminio_CheckedChanged(object sender, EventArgs e)
        {
            CalculoBarra(); CalculoTarugo(); CalculoTubo();
        }


        //Barra
        public void txtLargura_TextChanged(object sender, EventArgs e)
        {
            CalculoBarra();
        }

        public void txtEspessura_TextChanged(object sender, EventArgs e)
        {
            CalculoBarra();
        }



        public void txtComprimento_TextChanged(object sender, EventArgs e)
        {
            CalculoBarra();
        }

        //Sextavado
        private void txtSextavado_TextChanged(object sender, EventArgs e)
        {
            CalculoSextavado();
        }


        private void txtComprimentoS_TextChanged(object sender, EventArgs e)
        {
            CalculoSextavado();
        }


        //Tarugos
        public void txtDiametro_TextChanged(object sender, EventArgs e)
        {
            CalculoTarugo();

        }

        public void txtComprimentoR_TextChanged(object sender, EventArgs e)
        {
            CalculoTarugo();
        }


        //Tubos
        public void txtDiametroExterno_TextChanged(object sender, EventArgs e)
        {
            CalculoTubo();

        }
        public void txtEspessuraTubo_TextChanged(object sender, EventArgs e)
        {
            CalculoTubo();

        }

        private void frmCalculos_Load(object sender, EventArgs e)
        {

        }



        public void txtComprimentoTubo_TextChanged(object sender, EventArgs e)
        {
            CalculoTubo();
        }

        public void txtDiametroInterno_TextChanged(object sender, EventArgs e)
        {
            CalculoTubo();


        }
        public void txtEspessuraTubo2_TextChanged(object sender, EventArgs e)
        {
            CalculoTubo();
        }

        private void rbBarQuadRet_Cobre_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CalculoTubo();
        }





        //Extras- Suporte
        public void txtLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        public void limpar()

        {

            txtEspessura.Clear();
            txtComprimento.Clear();
            txtLargura.Clear();

            txtDiametro.Clear();
            txtComprimentoR.Clear();

            txtDiametroExterno.Clear();
            txtDiametroInterno.Clear();
            txtEspessuraTubo.Clear();
            txtEspessuraTubo2.Clear();
            txtComprimentoTubo.Clear();
            txtComprimentoTubo2.Clear();


            rbBarQuadRet_AcoInox.Checked = false;
            rbBarQuadRet_Bronze.Checked = false;
            rbBarQuadRet_Aluminio.Checked = false;
            rbBarQuadRet_Cobre.Checked = false;
            rbBarQuadRet_Latao.Checked = false;

            lblKg.Text = "Kg = ";

            lblKgR.Text = "Kg = ";

            lblKg1Tubo.Text = "Kg = ";
            lblKg2Tubo.Text = "Kg = ";
            lblKgTubo.Text = "Kg = ";
        }



        //Calculos
        public void CalculoBarra()
        {

            try
            {
                larguraBarra = Double.Parse(txtLargura.Text);
                espessuraBarra = Double.Parse(txtEspessura.Text);
                comprimentoBarra = Double.Parse(txtComprimento.Text);
                // Aço Inox
                if (rbBarQuadRet_AcoInox.Checked == true)
                {
                    kgBarra = larguraBarra * espessuraBarra * comprimentoBarra * 0.0080227612;

                }
                // Latão
                else if (rbBarQuadRet_Latao.Checked == true)
                {
                    kgBarra = larguraBarra * espessuraBarra * comprimentoBarra * 0.0085;
                }
                // Cobre
                else if (rbBarQuadRet_Cobre.Checked == true)
                {
                    kgBarra = larguraBarra * espessuraBarra * comprimentoBarra * 0.0089;
                }
                // Bronze
                else if (rbBarQuadRet_Bronze.Checked == true)
                {
                    kgBarra = larguraBarra * espessuraBarra * comprimentoBarra * 0.0088;
                }
                // Alumínio
                else if (rbBarQuadRet_Aluminio.Checked == true)
                {
                    kgBarra = larguraBarra * espessuraBarra * comprimentoBarra * 0.002725;
                }
                lblKg.Text = "Kg = " + kgBarra.ToString("N3");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); =(9,81*(0,80227612*(((A5)*(B5))/1000)*C5))
            }

        }
        public void CalculoTarugo()
        {

            try
            {
                diametroTarugo = Double.Parse(txtDiametro.Text);
                comprimentoTarugo = Double.Parse(txtComprimentoR.Text);
                // Aço Inox
                if (rbBarQuadRet_AcoInox.Checked == true)
                {
                    kgTarugo = ((9.81 * (0.80227612 * ((Math.PI * ((diametroTarugo * diametroTarugo))) / 4) * comprimentoTarugo))) / 1000;
                }
                // Latão
                else if (rbBarQuadRet_Latao.Checked == true)
                {

                    kgTarugo = 0.0085 * ((Math.PI * ((diametroTarugo * diametroTarugo))) / 4) * comprimentoTarugo;
                }
                // Cobre
                else if (rbBarQuadRet_Cobre.Checked == true)
                {
                    kgTarugo = 0.0089 * ((Math.PI * ((diametroTarugo * diametroTarugo))) / 4) * comprimentoTarugo;
                }
                // Bronze
                else if (rbBarQuadRet_Bronze.Checked == true)
                {
                    kgTarugo = 0.0088 * ((Math.PI * ((diametroTarugo * diametroTarugo))) / 4) * comprimentoTarugo;
                }
                // Alumínio
                else if (rbBarQuadRet_Aluminio.Checked == true)
                {
                    kgTarugo = 0.002725 * ((Math.PI * ((diametroTarugo * diametroTarugo))) / 4) * comprimentoTarugo;
                }
                lblKgR.Text = "Kg = " + kgTarugo.ToString("N3");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); =(9,81*(0,80227612*(((A5)*(B5))/1000)*C5))
            }

        }
        public void CalculoSextavado()
        {

            try
            {
                diametroSextavado = Double.Parse(txtSextavado.Text);
                comprimentoSextavado = Double.Parse(txtComprimentoS.Text);
                // Aço Inox
                if (rbBarQuadRet_AcoInox.Checked == true)
                {
                    //KgSextavado
                }
                // Latão
                else if (rbBarQuadRet_Latao.Checked == true)
                {

                    //KgSextavado
                }
                // Cobre
                else if (rbBarQuadRet_Cobre.Checked == true)
                {
                    //KgSextavado
                }
                // Bronze
                else if (rbBarQuadRet_Bronze.Checked == true)
                {
                    //KgSextavado
                }
                // Alumínio
                else if (rbBarQuadRet_Aluminio.Checked == true)
                {
                    //KgSextavado
                }
                lblKgSextavado.Text = "Kg = " + KgSextavado.ToString("N3");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message)
            }

        }
        public void CalculoTubo()
        {
            //externo =((9,81*(0,909105336*((3,141592654*((E27)^2))/4)*F27)))/1000
            //interno =((9,81*(0,909105336*((3,141592654*((E32)^2))/4)*F32)))/1000

            if (rbBarQuadRet_Cobre.Checked == true)
            {

                try
                {
                    if (txtDiametroExterno.Text != "" && txtEspessuraTubo.Text != "" && txtComprimentoTubo.Text != "")
                    {
                        diametroExternoTubo = Double.Parse(txtDiametroExterno.Text);
                        espessuraTubo = Double.Parse(txtEspessuraTubo.Text);
                        comprimentoTubo = Double.Parse(txtComprimentoTubo.Text);

                        kgTubo_Externo = 0.0089 * ((Math.PI * ((diametroExternoTubo * diametroExternoTubo))) / 4) * comprimentoTubo;
                        lblKg1Tubo.Text = "Kg = " + kgTubo_Externo.ToString("N3");

                        diametroInternoTubo = diametroExternoTubo - (2 * espessuraTubo);
                        kgTubo_Interno = 0.0089 * ((Math.PI * ((diametroInternoTubo * diametroInternoTubo))) / 4) * comprimentoTubo;
                        kgTubo = kgTubo_Externo - kgTubo_Interno;
                        lblKgTubo.Text = "Kg = " + kgTubo.ToString("N3");
                    }

                    if (txtDiametroInterno.Text != "" && txtEspessuraTubo2.Text != "" && txtComprimentoTubo2.Text != "")
                    {
                        diametroInternoTubo = Double.Parse(txtDiametroInterno.Text);
                        espessuraTubo2 = Double.Parse(txtEspessuraTubo2.Text);
                        comprimentoTubo2 = Double.Parse(txtComprimentoTubo2.Text);

                        kgTubo_Interno = 0.0089 * ((Math.PI * ((diametroInternoTubo * diametroInternoTubo))) / 4) * comprimentoTubo2;
                        lblKg2Tubo.Text = "Kg = " + kgTubo_Interno.ToString("N3");
                        diametroExternoTubo = diametroInternoTubo + (2 * espessuraTubo2);
                        kgTubo_Externo = 0.0089 * ((Math.PI * ((diametroExternoTubo * diametroExternoTubo))) / 4) * comprimentoTubo2;
                        kgTubo = kgTubo_Externo - kgTubo_Interno;
                        lblKgTubo.Text = "Kg = " + kgTubo.ToString("N3");
                    }

                }
                catch (Exception e)
                {

                }
            }
            else if (rbBarQuadRet_Bronze.Checked == true)
            {
            }
            else if (rbBarQuadRet_Latao.Checked == true)
            {
                if (txtDiametroExterno.Text != "" && txtEspessuraTubo.Text != "" && txtComprimentoTubo.Text != "")
                {
                    diametroExternoTubo = Double.Parse(txtDiametroExterno.Text);
                    espessuraTubo = Double.Parse(txtEspessuraTubo.Text);
                    comprimentoTubo = Double.Parse(txtComprimentoTubo.Text);

                    kgTubo_Externo = 0.0085 * ((Math.PI * ((diametroExternoTubo * diametroExternoTubo))) / 4) * comprimentoTubo;
                    lblKg1Tubo.Text = "Kg = " + kgTubo_Externo.ToString("N3");

                    diametroInternoTubo = diametroExternoTubo - (2 * espessuraTubo);
                    kgTubo_Interno = 0.0085 * ((Math.PI * ((diametroInternoTubo * diametroInternoTubo))) / 4) * comprimentoTubo;
                    kgTubo = kgTubo_Externo - kgTubo_Interno;
                    lblKgTubo.Text = "Kg = " + kgTubo.ToString("N3");
                }
            }
            else if (rbBarQuadRet_AcoInox.Checked == true)
            {
            }
            else if (rbBarQuadRet_Aluminio.Checked == true)
            {
                if (txtDiametroExterno.Text != "" && txtEspessuraTubo.Text != "" && txtComprimentoTubo.Text != "")
                {
                    diametroExternoTubo = Double.Parse(txtDiametroExterno.Text);
                    espessuraTubo = Double.Parse(txtEspessuraTubo.Text);
                    comprimentoTubo = Double.Parse(txtComprimentoTubo.Text);

                    kgTubo_Externo = 0.002725 * ((Math.PI * ((diametroExternoTubo * diametroExternoTubo))) / 4) * comprimentoTubo;
                    lblKg1Tubo.Text = "Kg = " + kgTubo_Externo.ToString("N3");

                    diametroInternoTubo = diametroExternoTubo - (2 * espessuraTubo);
                    kgTubo_Interno = 0.002725 * ((Math.PI * ((diametroInternoTubo * diametroInternoTubo))) / 4) * comprimentoTubo;
                    kgTubo = kgTubo_Externo - kgTubo_Interno;
                    lblKgTubo.Text = "Kg = " + kgTubo.ToString("N3");
                }
            }


        }

        String um = "";
        String dois = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dois = comboBox1.Text;
            pol_x_mm();
            txtLargura.Text = um;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dois = comboBox2.Text;
            pol_x_mm();
            txtEspessura.Text = um;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dois = comboBox3.Text;
            pol_x_mm();
            txtDiametro.Text = um;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dois = comboBox4.Text;
            pol_x_mm();
            txtDiametroExterno.Text = um;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dois = comboBox5.Text;
            pol_x_mm();
            txtEspessuraTubo.Text = um;
        }



        public void pol_x_mm()
        {
            um = "";
            switch (dois)
            {
                case "1/32": um = "0,79"; break;
                case "1/16": um = "1,58"; break;
                case "3/32": um = "2,38"; break;
                case "1/8": um = "3,18"; break;
                case "5/32": um = "3,97"; break;
                case "3/16": um = "4,76"; break;
                case "7/32": um = "5,56"; break;
                case "1/4": um = "6,35"; break;
                case "9/32": um = "7,14"; break;
                case "5/16": um = "7,98"; break;
                case "11/32": um = "8,73"; break;
                case "3/8": um = "9,53"; break;
                case "13/32": um = "10,32"; break;
                case "7/16": um = "11,11"; break;
                case "15/32": um = "11,91"; break;
                case "1/2": um = "12,70"; break;
                case "17/32": um = "13,49"; break;
                case "9/16": um = "14,29"; break;
                case "19/32": um = "15,08"; break;
                case "5/8": um = "15,87"; break;
                case "21/32": um = "16,67"; break;
                case "11/16": um = "17,46"; break;
                case "23/32": um = "18,26"; break;
                case "3/4": um = "19,05"; break;
                case "25/32": um = "19,84"; break;
                case "13/16": um = "20,64"; break;
                case "27/32": um = "21,43"; break;
                case "7/8": um = "22,22"; break;
                case "29/32": um = "23,02"; break;
                case "15/16": um = "23,81"; break;
                case "31/32": um = "24,61"; break;
                case "1'": um = "25,40"; break;
                case "1.1/32": um = "26,19"; break;
                case "1.1/16": um = "26,99"; break;
                case "1.3/32": um = "27,78"; break;
                case "1.1/8": um = "28,57"; break;
                case "1.5/32": um = "29,37"; break;
                case "1.3/16": um = "30,16"; break;
                case "1.7/32": um = "30,95"; break;
                case "1.1/4": um = "31,75"; break;
                case "1.9/32": um = "32,54"; break;
                case "1.5/16": um = "33,34"; break;
                case "1.11/32": um = "34,13"; break;
                case "1.3/8": um = "34,92"; break;
                case "1.13/32": um = "35,72"; break;
                case "1.7/16": um = "36,51"; break;
                case "1.15/32": um = "37,30"; break;
                case "1.1/2": um = "38,1"; break;
                case "1.17/32": um = "38,89"; break;
                case "1.9/16": um = "39,69"; break;
                case "1.19/32": um = "40,48"; break;
                case "1.5/8": um = "41,27"; break;
                case "1.21/32": um = "42,07"; break;
                case "1.11/16": um = "42,86"; break;
                case "1.23/32": um = "43,65"; break;
                case "1.3/4": um = "44,45"; break;
                case "1.25/32": um = "45,24"; break;
                case "1.13/16": um = "46,04"; break;
                case "1.27/32": um = "46,83"; break;
                case "1.7/8": um = "47,62"; break;
                case "1.29/32": um = "48,42"; break;
                case "1.15/16": um = "49,21"; break;
                case "1.31/32": um = "50"; break;
                case "2'": um = "50,8"; break;
                case "2.1/16": um = "52,39"; break;
                case "2.1/8": um = "53,97"; break;
                case "2.3/16": um = "55,56"; break;
                case "2.1/4": um = "57,15"; break;
                case "2.5/16": um = "58,74"; break;
                case "2.3/8": um = "60,32"; break;
                case "2.7/16": um = "61,91"; break;
                case "2.1/2": um = "63,5"; break;
                case "2.9/16": um = "65,09"; break;
                case "2.5/8": um = "66,67"; break;
                case "2.11/16": um = "68,26"; break;
                case "2.3/4": um = "69,85"; break;
                case "2.13/16": um = "71,44"; break;
                case "2.7/8": um = "73,02"; break;
                case "2.15/16": um = "74,61"; break;
                case "3'": um = "76,2"; break;
                case "3.1/8": um = "79,38"; break;
                case "3.1/4": um = "82,55"; break;
                case "3.3/8": um = "85,73"; break;
                case "3.1/2": um = "88,9"; break;
                case "3.5/8": um = "92,08"; break;
                case "3.3/4": um = "95,25"; break;
                case "3.7/8": um = "98,43"; break;
                case "4'": um = "101,6"; break;
                case "4.1/4": um = "107,95"; break;
                case "4.1/2": um = "114,3"; break;
                case "4.3/4": um = "120,65"; break;
                case "5'": um = "127"; break;
                case "5.1/4": um = "133,35"; break;
                case "5.1/2": um = "139,7"; break;
                case "5.3/4": um = "146,05"; break;
                case "6'": um = "152,4"; break;
                case "6.1/4": um = "158,75"; break;
                case "6.1/2": um = "165,1"; break;
                case "6.3/4": um = "171,45"; break;
                case "7'": um = "177,8"; break;
                case "7.1/4": um = "184,15"; break;
                case "7.1/2": um = "190,5"; break;
                case "7.3/4": um = "196,85"; break;
                case "8'": um = "203,2"; break;
                case "8.1/4": um = "209,55"; break;
                case "8.1/2": um = "215,9"; break;
                case "8.3/4": um = "222,25"; break;
                case "9'": um = "228,6"; break;
                case "9.1/4": um = "234,95"; break;
                case "9.1/2": um = "241,3"; break;
                case "9.3/4": um = "247,65"; break;
                case "10'": um = "254"; break;
                case "10.1/4": um = "260,35"; break;
                case "10.1/2": um = "266,7"; break;
                case "10.3/4": um = "273,05"; break;
                case "11'": um = "279,4"; break;
                case "11.1/4": um = "285,75"; break;
                case "11.1/2": um = "292,1"; break;
                case "11.3/4": um = "298,45"; break;
                case "12'": um = "304,8"; break;
                case "12.1/4": um = "311,15"; break;
                case "12.1/2": um = "317,5"; break;
                case "12.3/4": um = "323,85"; break;
                case "13'": um = "330,2"; break;
                case "13.1/4": um = "336,55"; break;
                case "13.1/2": um = "342,9"; break;
                case "13.3/4": um = "349,25"; break;
                case "14'": um = "355,6"; break;
                case "14.1/4": um = "361,95"; break;
                case "14.1/2": um = "368,3"; break;
                case "14.3/4": um = "374,65"; break;
                case "15'": um = "381"; break;
                case "15.1/4": um = "387,35"; break;
                case "15.1/2": um = "393,7"; break;
                case "15.3/4": um = "400,05"; break;
                case "16'": um = "406,4"; break;
                case "16.1/4": um = "412,75"; break;
                case "16.1/2": um = "419,1"; break;
                case "16.3/4": um = "425,45"; break;
                case "17'": um = "431,8"; break;
                case "17.1/4": um = "438,15"; break;
                case "17.1/2": um = "444,5"; break;
                case "17.3/4": um = "450,85"; break;
                case "18'": um = "457,2"; break;
                case "18.1/4": um = "463,55"; break;
                case "18.1/2": um = "469,9"; break;
                case "18.3/4": um = "476,25"; break;
                case "19'": um = "482,6"; break;
                case "19.1/4": um = "488,95"; break;
                case "19.1/2": um = "495,3"; break;
                case "19.3/4": um = "501,65"; break;
                case "20'": um = "508"; break;
                case "20.1/4": um = "514,35"; break;
                case "20.1/2": um = "520,7"; break;
                case "20.3/4": um = "527,05"; break;
                case "21'": um = "533,4"; break;
                case "21.1/4": um = "539,75"; break;
                case "21.1/2": um = "546,1"; break;
                case "21.3/4": um = "552,45"; break;
                case "22'": um = "558,8"; break;
                case "22.1/4": um = "565,15"; break;
                case "22.1/2": um = "571,5"; break;
                case "22.3/4": um = "577,85"; break;
                case "23'": um = "584,2"; break;



            }
        }


    }
}
