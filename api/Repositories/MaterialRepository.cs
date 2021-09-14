using Dapper;
using Npgsql;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;

namespace Api.Repositories
{
  public interface IMaterialRepository
  {
    Task<IEnumerable<Material>> GetByProjectId(int projectId);
    Task<Material> Create(Material category);
    Task<Material> Update(Material category);
    Task Delete(int id);
  }
  public class MaterialRepository : CoreRepository, IMaterialRepository
  {
    private const string RETURN_OBJECT = "id, project_id as ProjectId, name, cost, quantity, sort_order as SortOrder";

    public async Task<IEnumerable<Material>> GetByProjectId(int projectId)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = $"SELECT {RETURN_OBJECT} FROM materials WHERE project_id = @projectId";
        return await connection.QueryAsync<Material>(sql, new { projectId });
      }
    }

    public async Task<Material> Create(Material material)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = $@"INSERT INTO materials (project_id, name, cost, quantity, sort_order) 
        VALUES (@ProjectId, @Name, @Cost, @Quantity, @SortOrder)
        RETURNING {RETURN_OBJECT}";
        return await connection.QueryFirstOrDefaultAsync<Material>(sql, material);
      }
    }

    public async Task<Material> Update(Material material)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = $@"UPDATE materials
        SET name = @Name, cost = @Cost, quantity = @Quantity, sort_order = @SortOrder
        WHERE id = @Id
        RETURNING {RETURN_OBJECT}";
        return await connection.QueryFirstOrDefaultAsync<Material>(sql, material);
      }
    }

    public async Task Delete(int id)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = @"DELETE FROM materials WHERE id = @id";
        await connection.ExecuteAsync(sql, new { id });
      }
    }
  }
}