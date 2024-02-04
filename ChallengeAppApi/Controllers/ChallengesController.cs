using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChallengeAppApi.Data;
using ChallengeAppApi.Models;

namespace ChallengeAppApi.Controllers
{
    [ApiController]
    [Route("challenges")]
    public class ChallengesController : Controller
    {
        private readonly ChallengeAppApiContext _context;

        public ChallengesController(ChallengeAppApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ChallengeEntity> Index()
        {
            return _context.Challenges.ToList();
        }
    
        [HttpGet, ActionName("Details")]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var challenge = await _context.Challenges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (challenge == null)
            {
                return NotFound();
            }

            return Ok(challenge);
        }

        
        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> Create(ChallengeModel challenge)
        {
            ChallengeEntity newChallenge = new ChallengeEntity(challenge.Name,
                            challenge.DifficultyLevel,
                            challenge.Description,
                            challenge.Duration,
                            challenge.StartedAt,
                            challenge.GithubLink);

            if (ModelState.IsValid)
            {
                _context.Add(newChallenge);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: "+ ex.ToString());
                }
            }
            return Ok(newChallenge);
        }

        
        [HttpPut, ActionName("Edit")]
        [Route("{id}")]
        public async Task<IActionResult> Edit(int id, ChallengeModel challenge)
        {
            if (id < 0)
            {
                return NotFound();
            }


            ChallengeEntity newChallenge = new ChallengeEntity(challenge.Name,
                            challenge.DifficultyLevel,
                            challenge.Description,
                            challenge.Duration,
                            challenge.StartedAt,
                            challenge.GithubLink);
            newChallenge.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newChallenge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChallengeExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(newChallenge);
            }
            //Error
            return NotFound();
        }
    

        [HttpDelete, ActionName("Delete")]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var challenge = await _context.Challenges.FindAsync(id);
            if (challenge != null)
            {
                _context.Challenges.Remove(challenge);
            }

            await _context.SaveChangesAsync();
            return Ok(challenge);
        }

        private bool ChallengeExists(int id)
        {
            return _context.Challenges.Any(e => e.Id == id);
        }
    }
}
