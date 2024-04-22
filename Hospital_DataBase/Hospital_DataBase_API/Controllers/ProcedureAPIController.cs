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
    [Route("api/ProcedureAPI")]
    [ApiController]
    public class ProcedureAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IProcedureRepository _dbProcedure;
        private readonly IMapper _mapper;
        public ProcedureAPIController(IProcedureRepository dbProcedure, IMapper mapper)
        {
            _dbProcedure = dbProcedure;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetProcedures()
        {
            try
            {

                IEnumerable<Procedure> procedureList = await _dbProcedure.GetAllAsync();
                _response.Result = _mapper.Map<List<ProcedureDTO>>(procedureList);
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

        [HttpGet("{id}", Name = "GetProcedure")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> GetProcedure(string id)
        {
            try
            {
                if (id == "")
                {
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var procedure = await _dbProcedure.GetAsync(u => u.Name == id);
                if (procedure == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ProcedureDTO>(procedure);
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
        public async Task<ActionResult<APIResponse>> CreateProcedure([FromBody] ProcedureCreateDTO createDTO)
        {
            try
            {
                if (await _dbProcedure.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Procedure already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Procedure procedure = _mapper.Map<Procedure>(createDTO);

                await _dbProcedure.CreateAsync(procedure);
                _response.Result = _mapper.Map<ProcedureDTO>(procedure);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetProcedure", new { id = procedure.Name }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}", Name = "DeleteProcedure")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> DeleteProcedure(string id)
        {
            try
            {
                if (id == "")
                {
                    return BadRequest();
                }
                var procedure = await _dbProcedure.GetAsync(u => u.Name == id);
                if (procedure == null)
                {
                    return NotFound();
                }
                await _dbProcedure.RemoveAsync(procedure);
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

        [HttpPut("{id}", Name = "UpdateProcedure")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> UpdateProcedure(string id, [FromBody] ProcedureUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Name)
                {
                    return BadRequest();
                }
                Procedure model = _mapper.Map<Procedure>(updateDTO);

                await _dbProcedure.UpdateAsync(model);
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
