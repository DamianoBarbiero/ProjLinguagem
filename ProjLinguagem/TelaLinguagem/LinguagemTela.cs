using Conexao;
using Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaLinguagem
{
    public partial class LinguagemTela : Form
    {
        public LinguagemTela()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Linguagem linguagem = new Linguagem();
            linguagem.Id = Convert.ToInt32(textId.Text);
            linguagem.Nome = textNome.Text;
            linguagem.Descricao = textDescricao.Text;

            if (new LinguagemDB().insert(linguagem))
            {
                MessageBox.Show("Registro inserido!");
            }
            else
            {
                MessageBox.Show("Erro ao inserir registro!");
            }
        }

        private void TelaLinguagem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new LinguagemDB().ListarLinguagem();
        }
    }
}
