using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager.Models;

namespace ConfigurationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureFlagsController : ControllerBase
    {
        private readonly FeatureFlagContext _context;

        public FeatureFlagsController(FeatureFlagContext context)
        {
            _context = context;
        }

        // GET: api/FeatureFlags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeatureFlag>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/FeatureFlags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureFlag>> GetFeatureFlag(long id)
        {
            var featureFlag = await _context.TodoItems.FindAsync(id);

            if (featureFlag == null)
            {
                return NotFound();
            }

            return featureFlag;
        }

        // PUT: api/FeatureFlags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeatureFlag(long id, FeatureFlag featureFlag)
        {
            if (id != featureFlag.FeatureId)
            {
                return BadRequest();
            }

            _context.Entry(featureFlag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureFlagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FeatureFlags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FeatureFlag>> PostFeatureFlag(FeatureFlag featureFlag)
        {
            _context.TodoItems.Add(featureFlag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeatureFlag), new { id = featureFlag.FeatureId }, featureFlag);
        }

        // DELETE: api/FeatureFlags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeatureFlag>> DeleteFeatureFlag(long id)
        {
            var featureFlag = await _context.TodoItems.FindAsync(id);
            if (featureFlag == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(featureFlag);
            await _context.SaveChangesAsync();

            return featureFlag;
        }

        private bool FeatureFlagExists(long id)
        {
            return _context.TodoItems.Any(e => e.FeatureId == id);
        }
    }
}
