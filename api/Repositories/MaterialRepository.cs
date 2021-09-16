using Dapper;
using Npgsql;
using System.Collections.Generic;
using Api.Models;
using System.Threading.Tasks;
using Api.Requests;
using static Dapper.SqlMapper;
using System.Linq;
using System;

namespace Api.Repositories
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetByProjectId(int projectId);
        Task<Material> Create(Material category);
        Task<Material> Update(Material category);
        Task<Tuple<Material, Material>> Reorder(MaterialReorderRequest request);
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

        public async Task<Tuple<Material, Material>> Reorder(MaterialReorderRequest request)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                string sql = $@"UPDATE materials
                    SET sort_order = @Item1SortOrder
                    WHERE id = @Item1Id
                    RETURNING {RETURN_OBJECT};
                    
                    UPDATE materials
                    SET sort_order = @Item2SortOrder
                    WHERE id = @Item2Id
                    RETURNING {RETURN_OBJECT};";

                GridReader gridReader = await connection.QueryMultipleAsync(sql, new {
                    Item1Id = request.Item1.Id,
                    Item1SortOrder = request.Item1.SortOrder,
                    Item2Id = request.Item2.Id,
                    Item2SortOrder = request.Item2.SortOrder
                });

                Material item1 = gridReader.Read<Material>().First();
                Material item2 = gridReader.Read<Material>().First();

                return new Tuple<Material, Material>(item1, item2);
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