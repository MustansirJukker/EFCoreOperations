using EFCoreOperatinsApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreOperatinsApp.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var Languages = await (from languages in _appDbContext.Languages
                              select languages).ToListAsync();

            // Explicit loading
            /*foreach(var language in Languages)
            {
                await _appDbContext.Entry(language).Collection(x => x.Books).LoadAsync();

            }*/

            return Ok(Languages);
        }
    }
}
