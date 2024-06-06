using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContasAPI.Data;
using ContasAPI.Models;

namespace ContasAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase {
        private readonly DataBaseContext _context;

        public ContaController(DataBaseContext context) {
            _context = context;
        }

        // POST: api/Contas
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta) {

            if (conta == null || string.IsNullOrEmpty(conta.Nome) || conta.ValorOriginal == 0 || conta.DataVencimento == DateTime.MinValue || conta.DataPagamento == DateTime.MinValue) {
                return BadRequest("Todos os parâmetros obrigatórios devem ser fornecidos.");
            }

            if (_context.Contas.Any(c => c.DataPagamento == conta.DataPagamento)) {
                return Conflict("Já existe uma conta cadastrada com essa data de pagamento.");
            }

            conta.DiasAtraso = (conta.DataPagamento - conta.DataVencimento).Days;
            conta.ValorCorrigido = CalcularValorCorrigido(conta);

            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConta), new { id = conta.Id }, conta);
        }

        // GET: api/Contas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetContas() {
            return await _context.Contas.ToListAsync();
        }

        // GET: api/Contas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id) {
            var conta = await _context.Contas.FindAsync(id);

            if (conta == null) {
                return NotFound();
            }

            return conta;
        }

        private decimal CalcularValorCorrigido(Conta conta) {
            decimal valorCorrigido = conta.ValorOriginal;
            int diasAtraso = conta.DiasAtraso;

            if (diasAtraso > 0) {
                if (diasAtraso <= 3) {
                    valorCorrigido += conta.ValorOriginal * 0.02m;
                    valorCorrigido += conta.ValorOriginal * 0.001m * diasAtraso;
                }
                else if (diasAtraso <= 10) {
                    valorCorrigido += conta.ValorOriginal * 0.03m;
                    valorCorrigido += conta.ValorOriginal * 0.002m * diasAtraso;
                }
                else {
                    valorCorrigido += conta.ValorOriginal * 0.05m;
                    valorCorrigido += conta.ValorOriginal * 0.003m * diasAtraso;
                }
            }

            return valorCorrigido;
        }
    }
}
