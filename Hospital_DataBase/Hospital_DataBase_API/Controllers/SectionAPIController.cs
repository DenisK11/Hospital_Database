using AutoMapper;
using Azure;
using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;
using Hospital_DataBase_API.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Hospital_DataBase_API.Controllers
{
    [Route("api/SectionAPI")]
    [ApiController]
    public class SectionAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ISectionRepository _dbSection;
        private readonly IMapper _mapper;
        public SectionAPIController(ISectionRepository dbSection, IMapper mapper)
        {
            _dbSection = dbSection;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetSections()
        {
            try
            {

                IEnumerable<Section> sectionList = await _dbSection.GetAllAsync();
                _response.Result = _mapper.Map<List<SectionDTO>>(sectionList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}", Name = "GetSection")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> GetSection(string id)
        {
            try
            {
                if (id == "")
                {
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var section = await _dbSection.GetAsync(u => u.Name == id);
                if (section == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<SectionDTO>(section);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<APIResponse>> CreateSection([FromBody] SectionCreateDTO createDTO)
        {
            try
            {
                if (await _dbSection.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Section already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Section section = _mapper.Map<Section>(createDTO);

                await _dbSection.CreateAsync(section);
                _response.Result = _mapper.Map<SectionDTO>(section);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetSection", new { id = section.Name }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}", Name = "DeleteSection")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> DeleteSection(string id)
        {
            try
            {
                if (id == "")
                {
                    return BadRequest();
                }
                var section = await _dbSection.GetAsync(u => u.Name == id);
                if (section == null)
                {
                    return NotFound();
                }
                await _dbSection.RemoveAsync(section);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut("{id}", Name = "UpdateSection")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> UpdateSection(string id, [FromBody] SectionUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Name)
                {
                    return BadRequest();
                }
                Section model = _mapper.Map<Section>(updateDTO);

                await _dbSection.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
