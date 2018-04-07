using Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao
{
    public class LinguagemDB
    {
        private DB db;

        public bool insert(Linguagem linguagem)
        {
            try
            {
                string sql = "INSERT INTO TableLinguagem (NOME, DESCRICAO)" +
                         " VALUES ('" + linguagem.Nome + "', '" + linguagem.Descricao + "')";
                using (db = new DB())
                {
                    db.ExecutaComando(sql);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Linguagem> ListarLinguagem()
        {
            using (db = new DB())// Instancia a classe DB delimitando o inicio e fim
                                 // Inicio construtor da classe e abre conexão com o banco
                                 // A base de dados 
                                 // Fim Chama o metodo Dispose()
                                 //da interface IDisposable e fecha conexão com o banco de dados.
            {
                var sql = "SELECT id, descricao FROM TableLinguagem";
                var retorno = db.ExecutaComandoRetorno(sql);
                return TransformaSQLReaderEmList(retorno);
            }
        }

        private List<Linguagem> TransformaSQLReaderEmList(SqlDataReader retorno)
        {
            var listLinguagem = new List<Linguagem>();

            while (retorno.Read())
            {
                var item = new Linguagem()
                {
                    Id = Convert.ToInt32(retorno["id"]),
                    Nome = retorno["nome"].ToString(),
                    Descricao = retorno["descricao"].ToString(),
                };

                listLinguagem.Add(item);
            }
            return listLinguagem;
        }
    }
}
