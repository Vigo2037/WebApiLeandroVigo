using App.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApi.Models
{
    public class Analistas
    {
       

        public int id { get; set; }
        public string nome { get; set; }
        public int cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
       
        public string data { get; set; }
        public int idade { get; set; }


        public List<Analistas> ListarAnalista(int? id = null)
        {
            try
            {
                var analistaBD = new AnalistaDAO();
                return analistaBD.ListarAnalistaDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Analista:  Erro => {ex.Message}");
            }
        }

        public void Inserir(Analistas analista)
        {
            try
            {
                var analistaBD = new AnalistaDAO();
                analistaBD.InserirAnalistaDB(analista);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Inserir Analista: Erro => {ex.Message}");
            }
        }

        public void Atualizar(Analistas analista)
        {
            try
            {
                var analistaBD = new AnalistaDAO();
                analistaBD.AtualizarAnalistaDB(analista);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Atualizar Analista: Erro => {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var analistaBD = new AnalistaDAO();
                analistaBD.DeletarAnalistaDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Deletar Analista: Erro => {ex.Message}");
            }
        }

    }


}   
