using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MediCita.Web.Controllers
{
    public class PacienteController : Controller
    {
        // Conexión privada del controlador
        private readonly string _connectionString = @"Server=LAPTOP-1E2VL582\SQLEXPRESS;Database=BD_MediCita;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";

        // Página principal del paciente
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated != true)
                return RedirectToAction("Login", "Acceso");

            int idPaciente = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var estadisticas = await ObtenerEstadisticasPaciente(idPaciente);
            return View(estadisticas);
        }


        // Método privado para obtener estadísticas
        private async Task<dynamic> ObtenerEstadisticasPaciente(int idPaciente)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            using SqlCommand cmd = new SqlCommand("sp_EstadisticasPaciente", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new
                {
                    TotalCitas = reader.IsDBNull(reader.GetOrdinal("TotalCitas")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalCitas")),
                    Pendientes = reader.IsDBNull(reader.GetOrdinal("Pendientes")) ? 0 : reader.GetInt32(reader.GetOrdinal("Pendientes")),
                    Atendidas = reader.IsDBNull(reader.GetOrdinal("Atendidas")) ? 0 : reader.GetInt32(reader.GetOrdinal("Atendidas")),
                    Canceladas = reader.IsDBNull(reader.GetOrdinal("Canceladas")) ? 0 : reader.GetInt32(reader.GetOrdinal("Canceladas")),
                    ComprasRealizadas = reader.IsDBNull(reader.GetOrdinal("ComprasRealizadas")) ? 0 : reader.GetInt32(reader.GetOrdinal("ComprasRealizadas")),
                    TotalGastado = reader.IsDBNull(reader.GetOrdinal("TotalGastado")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TotalGastado"))
                };
            }

            // Retorno por defecto si no hay datos
            return new
            {
                TotalCitas = 0,
                Pendientes = 0,
                Atendidas = 0,
                Canceladas = 0,
                ComprasRealizadas = 0,
                TotalGastado = 0m
            };
        }
    }
}
