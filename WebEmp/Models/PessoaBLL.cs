using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using WebEmp.Services;

namespace WebEmp.Models
{
    public class PessoaBLL : IPessoaBLL
    {
        public void AtualizarPessoa(Pessoa pessoa)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("AtualizarPessoa", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "Id";
                    paramId.Value = pessoa.Id;
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "Nome";
                    paramNome.Value = pessoa.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "Sexo";
                    paramSexo.Value = pessoa.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "Email";
                    paramEmail.Value = pessoa.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramNascimento = new SqlParameter();
                    paramNascimento.ParameterName = "Nascimento";
                    paramNascimento.Value = Convert.ToDateTime(pessoa.Nascimento);
                    cmd.Parameters.Add(paramNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Pessoa> GetPessoas()
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefaultConnection");

            List<Pessoa> pessoas = new List<Pessoa>();
            try
            {
                using (SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("GetPessoas", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Pessoa pessoa = new Pessoa();
                        pessoa.Id = Convert.ToInt32(rdr["Id"]);
                        pessoa.Nome = rdr["Nome"].ToString();
                        pessoa.Sexo = rdr["Sexo"].ToString();
                        pessoa.Email = rdr["Email"].ToString();
                        pessoa.Nascimento = Convert.ToDateTime(rdr["Nascimento"]);
                        pessoas.Add(pessoa);
                    }
                }
                return pessoas;
            }
            catch
            {
                throw;
            }
        }
        public void IncluirPessoa(Pessoa pessoa)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("IncluirPessoa", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = pessoa.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = pessoa.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = pessoa.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramNascimento = new SqlParameter();
                    paramNascimento.ParameterName = "@Nascimento";
                    paramNascimento.Value = pessoa.Nascimento;
                    cmd.Parameters.Add(paramNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
