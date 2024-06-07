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

        // POST: api/Conta
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta) {

            // Verifica se a conta ou algum dos parâmetros obrigatórios é nulo ou vazio
            if (conta == null || string.IsNullOrEmpty(conta.Nome) || conta.ValorOriginal == 0 || conta.DataVencimento == DateTime.MinValue || conta.DataPagamento == DateTime.MinValue) {
                return BadRequest("Todos os parâmetros obrigatórios devem ser fornecidos.");
            }

            // Verifica se já existe uma conta cadastrada com a mesma data de pagamento
            if (_context.Contas.Any(c => c.DataPagamento == conta.DataPagamento)) {
                return Conflict("Já existe uma conta cadastrada com essa data de pagamento.");
            }

            conta.DiasAtraso = (conta.DataPagamento - conta.DataVencimento).Days;
            
            // Busca no banco a regra de negócio apropriada
            var regra = _context.RegrasNegocio
                .Where(r => conta.DiasAtraso >= r.DiasEmAtraso)
                .OrderByDescending(r => r.DiasEmAtraso)
                .FirstOrDefault();

            // Aplica os cálculos da regra de negócio
            if (regra != null) {
                conta.ValorCorrigido = conta.ValorOriginal 
                                    + conta.ValorOriginal * regra.Multa 
                                    + conta.ValorOriginal * regra.JurosPorDia * conta.DiasAtraso;
            }
            else {
                conta.ValorCorrigido = conta.ValorOriginal;
            }

            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConta), new { id = conta.Id }, conta);
        }

        // GET: api/Conta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetContas() {
            return await _context.Contas.ToListAsync();
        }

        // GET: api/Conta/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id) {
            var conta = await _context.Contas.FindAsync(id);

            if (conta == null) {
                return NotFound();
            }

            return conta;
        }
    }
}
