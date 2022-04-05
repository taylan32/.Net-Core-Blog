using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private IWriterService _writerService;
        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _writerService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _writerService.GetById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAllWritersDetails")]
        public IActionResult GetWritersDetails()
        {
            var result = _writerService.GetWritersDetails();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getWriterDetailById")]
        public IActionResult GetWriterDetailById(int id)
        {
            var result = _writerService.GetWriterDetailById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Writer writer)
        {
            var result = _writerService.Add(writer);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Writer writer)
        {
            var result = _writerService.Delete(writer);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Writer writer)
        {
            var result = _writerService.Update(writer);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
