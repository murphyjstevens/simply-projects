using Dapper;
using Npgsql;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;

namespace Api.Repositories
{
  public interface IProjectRepository
  {
    Task<IEnumerable<Project>> Get();
    Task<IEnumerable<Project>> GetCalculated();
    Task<Project> Create(Project category);
    Task<Project> Update(Project category);
    Task Delete(int id);
  }

  public class ProjectRepository : CoreRepository, IProjectRepository
  {
    private const string RETURN_OBJECT = "id, name, description";

    public async Task<IEnumerable<Project>> Get()
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        return await connection.QueryAsync<Project>($"SELECT {RETURN_OBJECT} FROM projects");
      }
    }

    public async Task<IEnumerable<Project>> GetCalculated()
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = $@"SELECT p.id, p.name, p.description, SUM(m.cost * m.quantity) as TotalCost FROM projects p
LEFT JOIN materials m ON m.project_id = p.id
GROUP BY p.id, p.name, p.description";
        return await connection.QueryAsync<Project>(sql);
      }
    }

    public async Task<Project> Create(Project project)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = $@"INSERT INTO projects (name, description) 
        VALUES (@Name, @description)
        RETURNING {RETURN_OBJECT}";
        return await connection.QueryFirstOrDefaultAsync<Project>(sql, project);
      }
    }

    public async Task<Project> Update(Project project)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = $@"UPDATE projects
        SET name = @Name, description = @Description
        WHERE id = @Id
        RETURNING {RETURN_OBJECT}";
        return await connection.QueryFirstOrDefaultAsync<Project>(sql, project);
      }
    }

    public async Task Delete(int id)
    {
      using (var connection = new NpgsqlConnection(ConnectionString))
      {
        connection.Open();
        string sql = @"DELETE FROM projects WHERE id = @Id";
        await connection.ExecuteAsync(sql, new { Id = id });
      }
    }
  }
}