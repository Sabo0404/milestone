using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using F1Schedule.Data;
using F1Schedule.Models.SeasonRaces;
using F1Schedule.Models.Races;
using F1Schedule.Models.Seasons;

namespace F1Schedule.Controllers
{
    public class SeasonRacesController : Controller
    {
        private readonly MyContext _context;

        public SeasonRacesController(MyContext context)
        {
            _context = context;
        }

        // GET: SeasonRaces
        public async Task<IActionResult> Index()
        {
            var myContext = _context.SeasonRaces.Include(s => s.Race).Include(s => s.Season);
            return View(await myContext.ToListAsync());
        }

        // GET: SeasonRaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonRace = await _context.SeasonRaces
                .Include(s => s.Race)
                .Include(s => s.Season)
                .FirstOrDefaultAsync(m => m.SeasonId == id);
            if (seasonRace == null)
            {
                return NotFound();
            }

            return View(seasonRace);
        }

        // GET: SeasonRaces/Create
        public IActionResult Create()
        {
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Country");
            ViewData["SeasonId"] = new SelectList(_context.Seasons, "Id", "Year");
            return View();
        }

        // POST: SeasonRaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeasonId,RaceId")] SeasonRace seasonRace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seasonRace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Country", seasonRace.RaceId);
            ViewData["SeasonId"] = new SelectList(_context.Seasons, "Id", "Year", seasonRace.SeasonId);
            return View(seasonRace);
        }

        // GET: SeasonRaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonRace = await _context.SeasonRaces.FindAsync(id);
            if (seasonRace == null)
            {
                return NotFound();
            }
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Country", seasonRace.RaceId);
            ViewData["SeasonId"] = new SelectList(_context.Seasons, "Id", "Year", seasonRace.SeasonId);
            return View(seasonRace);
        }

        // POST: SeasonRaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeasonId,RaceId")] SeasonRace seasonRace)
        {
            if (id != seasonRace.SeasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seasonRace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonRaceExists(seasonRace.SeasonId))
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
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Country", seasonRace.RaceId);
            ViewData["SeasonId"] = new SelectList(_context.Seasons, "Id", "Year", seasonRace.SeasonId);
            return View(seasonRace);
        }

        // GET: SeasonRaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasonRace = await _context.SeasonRaces
                .Include(s => s.Race)
                .Include(s => s.Season)
                .FirstOrDefaultAsync(m => m.SeasonId == id);
            if (seasonRace == null)
            {
                return NotFound();
            }

            return View(seasonRace);
        }

        // POST: SeasonRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seasonRace = await _context.SeasonRaces.FindAsync(id);
            _context.SeasonRaces.Remove(seasonRace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonRaceExists(int id)
        {
            return _context.SeasonRaces.Any(e => e.SeasonId == id);
        }
    }
}
