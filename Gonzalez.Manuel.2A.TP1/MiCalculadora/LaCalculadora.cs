using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        Calculadora _miCalculadora = new Calculadora();
        Numero n1;
        Numero n2;
        bool esDecimal = true;

        public LaCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            esDecimal = true;
            this.lblResultado.Text = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, cmbOperador.Text)).ToString("#,0.########");
        }

        public double Operar(string num1, string num2, string operador)
        {
            n1 = new Numero(num1);
            n2 = new Numero(num2);
            if (operador.Length == 0 || operador != "-" && operador != "*" && operador != "/")
                cmbOperador.Text = "+";
            return _miCalculadora.Operar(n1, n2, operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (esDecimal)
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
                esDecimal = false;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!esDecimal)
            {
                if (this.lblResultado.Text == "Valor inválido.")
                    this.lblResultado.Text = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, cmbOperador.Text)).ToString("#,0.########");
                else
                    this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
                esDecimal = true;
            }
        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            lblResultado.Text = "0";
            txtNumero1.Text = txtNumero2.Text = cmbOperador.Text = "";
        }
    }
}
