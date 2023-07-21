using Dapper;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace blazor_project.Data;

public class WeatherForecastService
{
    private readonly IConfiguration _configuration;
    public WeatherForecastService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Casa> BuscaCasas()
    {
        using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
        {
            List<Casa> retorno = new List<Casa>();

            // DynamicParameters _parametros = new DynamicParameters();
            // _parametros.Add("@UrlCliente", parametros.urlCliente);
            // _parametros.Add("@finalidade", parametros.finalidade);
            // _parametros.Add("@cidade", parametros.cidade);
            // _parametros.Add("@endereco", parametros.endereco);

            con.Open();

            var sql = @"SELECT idCasa          
                              ,titulo 
                        FROM Casas";

            var resultado = con.Query(sql: sql,
                                      commandType: CommandType.Text);

            foreach (var _resultado in resultado)
            {
                retorno.Add(new Casa()
                {
                    idCasa           = _resultado.idCasa,
                    titulo           = _resultado.titulo,
                });
            }
                
            return retorno;
        }
    }

    public void InserirCasa()
    {
        using (var con = new SqlConnection(_configuration.GetSection("conexao").Value))
        {
            List<Casa> retorno = new List<Casa>();

            // DynamicParameters _parametros = new DynamicParameters();
            // _parametros.Add("@UrlCliente", parametros.urlCliente);
            // _parametros.Add("@finalidade", parametros.finalidade);
            // _parametros.Add("@cidade", parametros.cidade);
            // _parametros.Add("@endereco", parametros.endereco);

            con.Open();

            var sql = @"INSERT INTO CASAS (idCliente, titulo, pequenaDescricao, valor, cidade, descricao, endereco, oculto ,tipo, destaque)
                        SELECT idCliente, 'GABRIELx', pequenaDescricao, valor, cidade, descricao, endereco, oculto ,tipo, destaque FROM Casas WHERE idCasa = 2019";

            var resultado = con.Execute(sql: sql,
                                        commandType: CommandType.Text);
  
        }
    }
}