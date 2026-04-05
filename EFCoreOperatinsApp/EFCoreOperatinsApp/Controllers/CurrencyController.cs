using EFCoreOperatinsApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperatinsApp.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await _appDbContext.Currencies.AsNoTracking().ToListAsync();
            return Ok(currencies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencybyIdAsync([FromRoute] int id)
        {
            var currencies = await _appDbContext.Currencies.FindAsync(id);
            return Ok(currencies);
        }

        /*[HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencybyNameAsync([FromRoute] string name)
        {
            var currencies = await _appDbContext.Currencies.FirstOrDefaultAsync(x => name.Equals(x.Title));
            currencies = await _appDbContext.Currencies.FirstAsync(x => name.Equals(x.Title));
            currencies = await _appDbContext.Currencies.SingleOrDefaultAsync(x => name.Equals(x.Title));
            currencies = await _appDbContext.Currencies.SingleAsync(x => name.Equals(x.Title));
            return Ok(currencies);
        }*/

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencybyNameAsync([FromRoute] string name, [FromQuery] string? desc)
        {
            /*//To get single record
            var currencies = await _appDbContext.Currencies.FirstOrDefaultAsync(
                x => name.Equals(x.Title)
                && string.IsNullOrWhiteSpace(desc) || desc.Equals(x.Description)
            );*/

            var currencies = await _appDbContext.Currencies.Where(
                x => name.Equals(x.Title)
                && string.IsNullOrWhiteSpace(desc) || desc.Equals(x.Description)
            ).AsNoTracking().ToListAsync();

            return Ok(currencies);
        }

        [HttpPost("FromList")]
        public async Task<IActionResult> GetCurrencyFromListAsync([FromBody] List<int> ids)
        {
            var currencies = await _appDbContext.Currencies.Where(
                x => ids.Contains(x.Id)
            ).AsNoTracking().ToListAsync();

            return Ok(currencies);
        }
    }
}
