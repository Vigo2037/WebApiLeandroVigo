using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace App.Repository
{
    public class AnalistaDAO
    {
        //private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private string stringConexa = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\WebApiLeandroVigo\WebApi\App_Data\Database.mdf;Integrated Security = True";
            
          
        
        //private string stringConexao1 = ConfigurationManager.AppSettings["ConnectionString"];

        private IDbConnection conexao;
        private string stringConexao;

        public AnalistaDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        public List<Analistas> ListarAnalistaDB(int? id = null)
        {
            var listaAnalista = new List<Analistas>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();

                if (id == null)
                    selectCmd.CommandText = "select * from Analista";
                else
                    selectCmd.CommandText = $"select * from Analista where id = {id}";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var ana = new Analistas();
                    
                        ana.id = Convert.ToInt32(resultado["Id"]);
                        ana.nome = Convert.ToString(resultado["nome"]);
                        ana.cpf = Convert.ToInt32(resultado["cpf"]);
                        ana.telefone = Convert.ToString(resultado["telefone"]);
                        ana.email = Convert.ToString(resultado["email"]);
                        ana.idade = Convert.ToInt32(resultado["idade"]);
                    

                    listaAnalista.Add(ana);
                }

                return listaAnalista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        internal void DeletarAnalistaDB(int id)
        {
            throw new NotImplementedException();
        }

        internal void AtualizarAnalistaDB(Analistas analista)
        {
            throw new NotImplementedException();
        }

        public void InserirAnalistaDB(Analistas analista)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Analista (nome, telefone, idade) values (@nome, @telefone, @idade)";

                IDbDataParameter paramNome = new SqlParameter("nome", analista.nome);
                insertCmd.Parameters.Add(paramNome);

                IDbDataParameter paramTelefone = new SqlParameter("telefone", analista.telefone);
                insertCmd.Parameters.Add(paramTelefone);

                IDbDataParameter paramIdade = new SqlParameter("idade", analista.idade);
                insertCmd.Parameters.Add(paramIdade);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void AtualizarAlunoDB(Analistas analista)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "update Analistas set nome = @nome,cpf = @cpf, telefone = @telefone, email = @email where id = @id";

                IDbDataParameter paramNome = new SqlParameter("nome", analista.nome);
                IDbDataParameter paramTelefone = new SqlParameter("telefone", analista.telefone);
                IDbDataParameter paramIdade = new SqlParameter("idade", analista.idade);

                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramTelefone);
                updateCmd.Parameters.Add(paramIdade);

                IDbDataParameter paramID = new SqlParameter("id", analista.id);
                updateCmd.Parameters.Add(paramID);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand DeleteCmd = conexao.CreateCommand();
                DeleteCmd.CommandText = "delete from Analista where id = @id";

                IDbDataParameter paramID = new SqlParameter("id", id);
                DeleteCmd.Parameters.Add(paramID);

                DeleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}