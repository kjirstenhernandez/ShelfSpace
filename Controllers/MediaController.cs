using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShelfSpace;
using ShelfSpace.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ShelfSpace;

[Route("media")]
[ApiController]
    public class MediaController : Controller
    {
        private readonly ShelfSpaceContext _context;

        public MediaController(ShelfSpaceContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetMediaByUserId(string userId)
        {
            var mediaItems = await _context.Media
                .Where(m => m.UserId == userId)
                .ToListAsync();

            return Ok(mediaItems);
        }

        [HttpGet("details/{SpecialId}")]
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(string? SpecialId)
        {
            if (SpecialId == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .FirstOrDefaultAsync(m => m.SpecialId == SpecialId);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("add")]
        public async Task<IActionResult> AddItem([Bind("SpecialId,UserId,Title,Genre,Year,Type")] MediaItem media)
        { Console.WriteLine("got to the Task");
            if (ModelState.IsValid)
            {
                _context.Media.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        [HttpGet("edit/{SpecialId}")]
        public async Task<IActionResult> Edit(string? SpecialId)
        {
            if (SpecialId == null)
            {
                return NotFound();
            }

            var media = await _context.Media.FindAsync(SpecialId);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("edit/{SpecialId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string SpecialId, [Bind("SpecialId,Title,Year,Genre,Type")] MediaItem media)
        {
            if (SpecialId != media.SpecialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.SpecialId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        [HttpDelete("delete/{SpecialId}")]
        public async Task<IActionResult> Delete(string? SpecialId)
        {
            if (SpecialId == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .FirstOrDefaultAsync(m => m.SpecialId == SpecialId);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int SpecialId)
        {
            var media = await _context.Media.FindAsync(SpecialId);
            if (media != null)
            {
                _context.Media.Remove(media);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(string SpecialId)
        {
            return _context.Media.Any(e => e.SpecialId == SpecialId);
        }

 

    }

