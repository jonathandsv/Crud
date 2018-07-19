using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ListaDeOrcamento.Models
{
    public class TdPecas
    {
        public List<Peca> Mostrando_o_Banco()
        {

            //definir string de conexão com o banco de dados 
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LISTA_ORC;Integrated Security=True;MultipleActiveResultSets=True";

            //Criação de um novo objeto do tipo SqlConnection object
            SqlConnection sqlConn = new SqlConnection(connectionString);

            //Abrindo Conexão
            sqlConn.Open();

            //Define o Objeto SqlCommand e a instrução Sql
            SqlCommand leitor = new SqlCommand("SELECT * FROM PECAS", sqlConn);
            SqlDataReader dr = leitor.ExecuteReader();

            List<Peca> pecas = new List<Peca>();

            

            while (dr.Read())
            {
                Peca peca = new Peca();
                peca.CodPeca = Convert.ToInt32(dr["CODPECA"]);
                peca.Nome = dr["NOME"].ToString();
                peca.Descricao = dr["DESCRICAO"].ToString();
                pecas.Add(peca);

            }

            return pecas;
           
        }

        public List<Peca> Pesquisar_varias_pecas(string nome)
        {

            //definir string de conexão com o banco de dados 
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LISTA_ORC;Integrated Security=True;MultipleActiveResultSets=True";

            //Criação de um novo objeto do tipo SqlConnection object
            SqlConnection sqlConn = new SqlConnection(connectionString);

            //Abrindo Conexão
            sqlConn.Open();

            //Define o Objeto SqlCommand e a instrução Sql
            List<Peca> pecas = new List<Peca>();

            using (SqlCommand leitor = new SqlCommand("SELECT * FROM PECAS WHERE NOME LIKE '%' + @NOME + '%';", sqlConn))
            {
                leitor.Parameters.Add("@NOME", SqlDbType.VarChar, 50).Value = nome;
                SqlDataReader dr = leitor.ExecuteReader();
                while (dr.Read())
                {
                    Peca peca = new Peca();
                    peca.CodPeca = Convert.ToInt32(dr["CODPECA"]);
                    peca.Nome = dr["NOME"].ToString();
                    peca.Descricao = dr["DESCRICAO"].ToString();
                    pecas.Add(peca);

                }

            }
            return pecas;

        }

        public Peca Inserir(int CODPECA, string NOME, string DESCRICAO)
        {

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LISTA_ORC;Integrated Security=True;MultipleActiveResultSets=True";
            string inserirValores = "INSERT INTO PECAS (CODPECA, NOME, DESCRICAO)" + "VALUES (@CODPECA, @NOME, @DESCRICAO)";

            //Criação de um novo objeto do tipo SqlConnection object
            SqlConnection sqlConn = new SqlConnection(connectionString);
            using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
            {
                comm.Parameters.Add("@CODPECA", SqlDbType.Int).Value = CODPECA;
                comm.Parameters.Add("@NOME", SqlDbType.VarChar, 50).Value = NOME;
                comm.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 50).Value = DESCRICAO;

                sqlConn.Open();
                comm.ExecuteNonQuery();
                sqlConn.Close();
            }

            Peca peca = new Peca();

            return peca;
        }

        public Peca Pesquisar_uma_peca(int CODPECA)
        {

            //definir string de conexão com o banco de dados 
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LISTA_ORC;Integrated Security=True;MultipleActiveResultSets=True";

            //Criação de um novo objeto do tipo SqlConnection object
            SqlConnection sqlConn = new SqlConnection(connectionString);

            //Abrindo Conexão
            sqlConn.Open();

            //Define o Objeto SqlCommand e a instrução Sql
            Peca peca = new Peca();

            using (SqlCommand leitor = new SqlCommand("SELECT * FROM PECAS WHERE CODPECA = @CODPECA", sqlConn))
            {
                leitor.Parameters.Add("@CODPECA", SqlDbType.Int).Value = CODPECA;
                SqlDataReader dr = leitor.ExecuteReader();
                while (dr.Read())
                {
                    Peca pc = new Peca();
                    peca.CodPeca = Convert.ToInt32(dr["CODPECA"]);
                    peca.Nome = dr["NOME"].ToString();
                    peca.Descricao = dr["DESCRICAO"].ToString();
                   
                }
                 
            }
            

            return peca;

        }

        public int deletar_peca(int CODPECA)
        {

            //definir string de conexão com o banco de dados 
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LISTA_ORC;Integrated Security=True;MultipleActiveResultSets=True";

            //Criação de um novo objeto do tipo SqlConnection object
            SqlConnection sqlConn = new SqlConnection(connectionString);

            //Define o Objeto SqlCommand e a instrução Sql
            using (SqlCommand apagador = new SqlCommand("DELETE FROM PECAS WHERE CODPECA = @CODPECA", sqlConn))
            {
                apagador.Parameters.Add("@CODPECA", SqlDbType.Int).Value = CODPECA;
                sqlConn.Open();
                apagador.ExecuteNonQuery();
                sqlConn.Close();

            }
                



            return 0; 
        }

        public Peca Editar(int CODPECA, string NOME, string DESCRICAO)
        {

            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=LISTA_ORC;Integrated Security=True;MultipleActiveResultSets=True";
            string inserirValores = "UPDATE PECAS SET NOME = @NOME,DESCRICAO = @DESCRICAO WHERE CODPECA = @CODPECA";

            //Criação de um novo objeto do tipo SqlConnection object
            SqlConnection sqlConn = new SqlConnection(connectionString);
            using (SqlCommand comm = new SqlCommand(inserirValores, sqlConn))
            {
                comm.Parameters.Add("@CODPECA", SqlDbType.Int).Value = CODPECA;
                comm.Parameters.Add("@NOME", SqlDbType.VarChar, 50).Value = NOME;
                comm.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 50).Value = DESCRICAO;

                sqlConn.Open();
                comm.ExecuteNonQuery();
                sqlConn.Close();
            }

            Peca peca = new Peca();

            return peca;
        }






    }



    

}