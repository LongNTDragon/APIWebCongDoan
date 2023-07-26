﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCongDoan_API.Interfaces;
using WebCongDoan_API.Models;
using WebCongDoan_API.ViewModels;

namespace WebCongDoan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CompetitionsExamsController : ControllerBase
    {
        private readonly ICompetitionsExamRepository _comERepo;

        public CompetitionsExamsController(ICompetitionsExamRepository repo) 
        { 
            _comERepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _comERepo.GetAllCompetitionsExams());
        }

        [HttpGet("GetAllByComID")]
        public async Task<IActionResult> Get(int id)
        {
            var comE = await _comERepo.GetCompetitionsExamByComId(id);
            if (comE == null)
                return NotFound();

            return Ok(await _comERepo.GetAllCompetitionsExamsByComID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompetitionsExamVM comEVM)
        {
            await _comERepo.AddCompetitionsExam(comEVM);
            return StatusCode(StatusCodes.Status201Created, comEVM);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompetitionsExamVM comEVM)
        {
            var comE = await _comERepo.GetCompetitionsExamById(comEVM.Ceid);
            if (comE == null)
                return NotFound();

            await _comERepo.UpdateCompetitionsExam(comEVM);
            return Ok(comEVM);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var comE = await _comERepo.GetCompetitionsExamById(id);
            if (comE == null)
                return NotFound();

            await _comERepo.DeleteCompetitionExam(id);
            return Ok();
        }
    }
}
