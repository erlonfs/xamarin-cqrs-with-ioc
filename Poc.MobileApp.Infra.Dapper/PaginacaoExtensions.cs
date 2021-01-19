using Dapper;
using Microsoft.Data.Sqlite;
using Poc.MobileApp.Shared.Data;
using System.Data;
using System.Data.SqlClient;

namespace Poc.MobileApp.Infra.Dapper
{
	public static class PaginacaoExtensions
    {
        public static QueryPaginada<T> Query<T>(this IDbConnection cnn, string sql, object parametros, PaginacaoInfo paginacao)
        {
            var query = new QueryPaginada<T>();
            var sqlPaginado = string.Empty;

            if (cnn is SqliteConnection)
            {
                sqlPaginado = $@"SELECT *
                                  FROM (
                                       SELECT DENSE_RANK() over (order by {paginacao.OrderBy ?? "rownum"}) ""RowNumber"", queryResult.*
                                         FROM (
                                              {sql}
                                         ) queryResult
                                  )
                                 WHERE ""RowNumber"" BETWEEN {(paginacao.PageNumber - 1) * paginacao.PageSize + 1} AND {paginacao.PageNumber * paginacao.PageSize}";

            }

            if (cnn is SqlConnection)
            {
                sqlPaginado = $@"SELECT *
                                  FROM (
                                     SELECT ROW_NUMBER() over (order by queryResult.{paginacao.OrderBy}) as ""RowNumber"", *
                                       FROM (
                                              {sql}
                                         ) queryResult
                                  ) queryPaginada
                                 WHERE queryPaginada.""RowNumber"" BETWEEN {(paginacao.PageNumber - 1) * paginacao.PageSize + 1} AND {paginacao.PageNumber * paginacao.PageSize} ";

            }

            query.TotalRegistros = cnn.ExecuteScalar<int>($"SELECT COUNT(1) FROM ({sql}) t_paginacao", parametros);
            query.Resultado = cnn.Query<T>(sqlPaginado, parametros);

            return query;
        }
    }
}
