using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbKhachhangsController : ControllerBase
    {
        private readonly MotoBookingContext _context;

        public TbKhachhangsController(MotoBookingContext context)
        {
            _context = context;
        }

        // GET: api/TbKhachhangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKhachhang>>> GetTbKhachhangs()
        {
            return await _context.TbKhachhangs.ToListAsync();
        }

        // GET: api/TbKhachhangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKhachhang>> GetTbKhachhang(int id)
        {
            var tbKhachhang = await _context.TbKhachhangs.FindAsync(id);

            if (tbKhachhang == null)
            {
                return NotFound();
            }

            return tbKhachhang;
        }

        // PUT: api/TbKhachhangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKhachhang(int id, TbKhachhang tbKhachhang)
        {
            if (id != tbKhachhang.PkIKhachhang)
            {
                return BadRequest();
            }

            _context.Entry(tbKhachhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKhachhangExists(id))
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

        // POST: api/TbKhachhangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbKhachhang>> PostTbKhachhang(TbKhachhang tbKhachhang)
        {
            _context.TbKhachhangs.Add(tbKhachhang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbKhachhang", new { id = tbKhachhang.PkIKhachhang }, tbKhachhang);
        }

        // DELETE: api/TbKhachhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKhachhang(int id)
        {
            var tbKhachhang = await _context.TbKhachhangs.FindAsync(id);
            if (tbKhachhang == null)
            {
                return NotFound();
            }

            _context.TbKhachhangs.Remove(tbKhachhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKhachhangExists(int id)
        {
            return _context.TbKhachhangs.Any(e => e.PkIKhachhang == id);
        }
    }
}
