using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Softsige.Ideias.Domain.Entities.Models;
using Softsige.Ideias.Domain.Interfaces.Repository;
using Softsige.Ideias.Infrastructure.Context;

namespace Softsige.Ideias.Infrastructure.Repository
{
    public class ComiteRepository : Repository<AnalisesModel>, IComiteRepository
    {
        private readonly MarchesanIdeiasDbContext _context;

        public ComiteRepository(MarchesanIdeiasDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnalisesModel>> GetComiteIdeias()
        {
            var result = await _context.Analises
                .Include("Ideia")
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable> GetRelevanciaList()
        {
            return await _context.Relevancias.ToListAsync();
        }

        public async Task<int> CriaReuniaoComite(int ideiaId, DateTime dataHoraReuniao)
        {
            var param = new[] {
                        new SqlParameter {
                            ParameterName = "@ideiaId",
                            SqlDbType =  SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value = ideiaId
                        },
                        new SqlParameter {
                            ParameterName = "@dataHoraReuniao",
                            SqlDbType =  SqlDbType.DateTime,
                            Direction = ParameterDirection.Input,
                            Value = dataHoraReuniao
                        },
                        new SqlParameter {
                            ParameterName = "@isSucesso",
                            SqlDbType =  SqlDbType.Bit,
                            Direction = ParameterDirection.Output
                        }};

            await _context.Database.ExecuteSqlRawAsync("[dbo].[sp_CriaReuniaoComite] @ideiaId, @dataHoraReuniao, @isSucesso out", param);

            //Note: Parameter starts with index 0.Here there are total 3 parameters and the last one is the output parameter.
            var isSucesso = Convert.ToInt32(param[2].Value);

            return isSucesso;
        }

        public async Task<List<AvaliacoesModel>> GetListaAvaliacoes(int ideiaId)
        {
            var result = new List<AvaliacoesModel>();

            var param = new[] {
                        new SqlParameter {
                            ParameterName = "@ideiaId",
                            SqlDbType =  SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value = ideiaId
                        }};

            await using var connection = _context.Database.GetDbConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "[dbo].[sp_RetornaListaAvaliacoesFeitas]";
            command.Parameters.AddRange(param);
            command.Connection = connection;
            await connection.OpenAsync();

            var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var model = new AvaliacoesModel
                {
                    AvaliadorNome = Convert.ToString(reader["AvaliadorNome"]),
                    EmailPrimeiraAnalise = Convert.ToInt32(reader["QtEmailPrimAvaliacao"]),
                    EmailSegundaAnalise = Convert.ToInt32(reader["QtEmailSegAvaliacao"]),
                    PrimeiraAnalise = Convert.ToBoolean(reader["PrimAvaliacao"]),
                    SegundaAnalise = Convert.ToBoolean(reader["SegAvaliacao"]),
                };

                result.Add(model);
            }

            return result;
        }
    }
}