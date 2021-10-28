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
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Metodo que se encarga de instanciar los dos operandos recibidos por parametros y de 
        /// realizar la operacion acorde dependiendo del <paramref name="operador"/> recibido
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <param name="operador"></param>
        /// <returns> retorna el resultado de la operacion aritmetica correspondiente</returns>
        private static double Operar(string op1, string op2, string operador)
        {
            Operando operando1 = new Operando(op1);
            Operando operando2 = new Operando(op2);
            
            return Calculadora.Operar(operando1, operando2, operador[0]);
        }

        /// <summary>
        /// Metodo que valida que los caracteres ingresados en <paramref name="txtNumero"/> sean 
        /// de caracter numerico
        /// </summary>
        /// <param name="txtNumero"></param>
        /// <returns></returns>
        private bool EsInputValido(TextBox txtNumero)
        {
            char[] cadenaCaracteres = txtNumero.Text.ToCharArray();
            bool retorno = true;
            foreach(char c in cadenaCaracteres)
            {
                retorno = char.IsDigit(c);
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que se encarga de limpiar <seealso cref="txtNumero1"/>, 
        /// <seealso cref="txtNumero2"/>, 
        /// <seealso cref="lstOperaciones"/> y 
        /// <seealso cref="cmbOperador"/>
        /// </summary>
        private void Limpiar()
        {
            lstOperaciones.Items.Clear();
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
        }

        /// <summary>
        /// Al momento del click, valida que los TextBox tengan un valor ingresado y realiza la operacion
        /// aritmetica. En caso de que haya valores invalidos, muestra un componente MessageBox con un mensaje
        /// de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero1.Text) || string.IsNullOrWhiteSpace(txtNumero2.Text))
            {
                MessageBox.Show($"Debe ingresar ambos operandos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string operador = string.IsNullOrWhiteSpace(cmbOperador.Text) ? "+" : cmbOperador.Text;
               
                double resultado = Operar(txtNumero1.Text, txtNumero2.Text, operador);
                lblResultado.Text = resultado.ToString();
                cmbOperador.Text = operador;
                lstOperaciones.Items.Add(GetTextoOperacion());
            }
        }

        /// <summary>
        /// Metodo que maneja el evento TextChanged de <seealso cref="txtNumero1"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            if (!EsInputValido(txtNumero1))
            {
                txtNumero1.Text = "";
            }
        }

        /// <summary>
        /// Metodo que maneja el evento TextChanged de <seealso cref="txtNumero2"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            if (!EsInputValido(txtNumero2))
            {
                txtNumero2.Text = "";
            }
        }

        /// <summary>
        /// Maneja el evento que convierte el resultado de la operacion a binario, validando que haya previamente
        /// una operacion realizada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            if (ValidarLblResultado())
            {
                MessageBox.Show($"Debe operar antes de intentar convertir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string resultado = Operando.DecimalBinario(lblResultado.Text);
                this.SetResultadoConversion(lblResultado.Text, " en binario = ", resultado);
            }
        }

        /// <summary>
        /// Metodo que se encarga de manejar el evento de click para convertir el resultado de la operacion
        /// en decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (ValidarLblResultado())
            {
                MessageBox.Show($"Debe operar antes de intentar convertir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string resultado = Operando.BinarioDecimal(lblResultado.Text);
                if(resultado == "Valor Invalido")
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.SetResultadoConversion(lblResultado.Text, " en decimal = ", resultado);
                }
            }
        }

        /// <summary>
        /// Maneja el evento que limpia <seealso cref="txtNumero1"/>, 
        /// <seealso cref="txtNumero2"/>, 
        /// <seealso cref="lstOperaciones"/> y 
        /// <seealso cref="cmbOperador"/>, llamando a <seealso cref="Limpiar"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Boton que cierra el formulario, mostrando previamente un MessageBox para validar la eleccion
        /// del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show($"Seguro de querer salir?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == resultado)
            {
                this.Close();
            }
        }


        /// <summary>
        /// Metodo que se encarga de llamar a <seealso cref="Limpiar"/>, poner focus en 
        /// el TextBox de <seealso cref="txtNumero1"/> y setear los operadores en 
        /// <seealso cref="cmbOperador"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.ActiveControl = txtNumero1;
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
        }

        /// <summary>
        /// Construye y devuelve dinamicamente el string que va a mostrarse en <seealso cref="lstOperaciones"/>
        /// </summary>
        /// <returns></returns>
        private string GetTextoOperacion()
        {
            return txtNumero1.Text + " " + cmbOperador.Text + " " + txtNumero2.Text + " = " + lblResultado.Text;
        }

        /// <summary>
        /// Valida el valor de <seealso cref="lblResultado"/>
        /// </summary>
        /// <returns></returns>
        private bool ValidarLblResultado()
        {
            return string.IsNullOrWhiteSpace(lblResultado.Text);
        }

        /// <summary>
        /// Setea el resultado correspondiente de la conversion realizada en los metodos 
        /// <seealso cref="btnConvertirABinario_Click(object, EventArgs)"/> & 
        /// <seealso cref="btnConvertirADecimal_Click(object, EventArgs)"/>
        /// </summary>
        /// <param name="numeroAConvertir"></param>
        /// <param name="tipoConversion"></param>
        /// <param name="numeroConvertido"></param>
        private void SetResultadoConversion(string numeroAConvertir, string tipoConversion, string numeroConvertido)
        {
            string resultado = numeroAConvertir + tipoConversion + numeroConvertido;
            lblResultado.Text = numeroConvertido;
            lstOperaciones.Items.Add(resultado);
        }
    }
}
