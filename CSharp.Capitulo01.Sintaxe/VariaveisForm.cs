using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.Capitulo01.Sintaxe
{
    public partial class VariaveisForm : Form
    {
        int x = 32;
        int y = 16;
        int w = 45;
        int z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void VariaveisForm_Load(object sender, EventArgs e)
        {

        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tipos de dados: página 25
            /*
             
             */

            int x = 42; 
            int X = 10;

            long populacao = 2344545465654545455;

            string nome = "Vítor", sobrenome = "Avelino";

            x = 5;
            //x = "14"; // estaticamente tipada;

            char letra = 'a';
            bool aprovado = true; //false
            var dataNascimento = new DateTime(2000, 1, 1);
            
            decimal valor = 13.6m;
            double outroValor = 2.2d;
            float distancia = 100.32f;
            decimal media = 8.0M;
            decimal bim1 = 5.6m;

            object camaleao = "Erik";
            camaleao = 5;
            camaleao = DateTime.Now;

            int a = 2;
            var b = 6;
            var c = 10;
            var d = 13;

            //var e = 12;
            //var nomeCanção = "Baile de Favela";

            var @class = "3D";

            var f = 5.6m;

            //let y = 0;

            var outroNome = "Teste";

            decimal preco = 14;
            //preco = 25;

            resultadoListBox.Items.Add("a = " + a/*.ToString()*/); // Shift + Ctrl + barra de espaço;
            resultadoListBox.Items.Add(string.Concat("b = ", b)); 
            //resultadoListBox.Items.Add(string.Format("c = {0} - d = {1}", c, d)); 
            resultadoListBox.Items.Add(string.Format("c = {0}", c)); 
            resultadoListBox.Items.Add($"d = {d}");

            resultadoListBox.Items.Add($"c * d = {c * d}");
            resultadoListBox.Items.Add($"d / a = {d / a}");
            resultadoListBox.Items.Add($"d % a = {d % a}");

            //var y = d ^ a;
            //var potencia = Math.Pow();
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            var x = 5;
            resultadoListBox.Items.Add($"x = {x}");

            resultadoListBox.Items.Add("---------------------------------");

            //x = x - 3;
            x -= 3;
            resultadoListBox.Items.Add($"x = {x}");
        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadoListBox.Items.Clear();

            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pré-incremental");
            resultadoListBox.Items.Add($"a = {a}");
            resultadoListBox.Items.Add($"2 + ++a = {2 + ++a}"); //8
            resultadoListBox.Items.Add($"a = {a}");

            resultadoListBox.Items.Add(new string('-', 50));

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós-incremental");
            resultadoListBox.Items.Add($"a = {a}");
            resultadoListBox.Items.Add($"2 + a++ = {2 + a++}"); 
            resultadoListBox.Items.Add($"a = {a}");
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValores();

            resultadoListBox.Items.Add($"w <= x = {w <= x}");
            resultadoListBox.Items.Add($"x == z = {x == z}");
            resultadoListBox.Items.Add($"x != z = {x != z}");
        }

        private void ExibirValores()
        {
            resultadoListBox.Items.Clear();

            resultadoListBox.Items.Add($"x = {x}");
            resultadoListBox.Items.Add($"y = {y}");
            resultadoListBox.Items.Add($"w = {w}");
            resultadoListBox.Items.Add($"z = {z}");

            resultadoListBox.Items.Add(new string('-', 50));
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (true)
            //{
            //    var x = 10;
            //}

            //x = 5;

            resultadoListBox.Items.Add($"w <= x || y == 16 = {w <= x || y == 16}");
            resultadoListBox.Items.Add($"x == z && x != z = {x == z && x != z}");
            resultadoListBox.Items.Add($"!(y > w) = {!(y > w)}");

        }
    }
}
