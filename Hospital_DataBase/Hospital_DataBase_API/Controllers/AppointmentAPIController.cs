using AutoMapper;
using Azure;
using Hospital_DataBase_API.Data;
using Hospital_DataBase_API.Models;
using Hospital_DataBase_API.Models.Dto;
using Hospital_DataBase_API.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Hospital_DataBase_API.Controllers
{
    [Route("api/AppointmentAPI")]
    [ApiController]
    public class AppointmentAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IAppointmentRepository _dbAppointment;
        private readonly IProcedureRepository _dbProcedure;
        private readonly ISectionRepository _dbSection;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _contextAppointment;
        public AppointmentAPIController(IAppointmentRepository dbAppointment, IMapper mapper,IProcedureRepository dbProcedure, ISectionRepository dbSection, ApplicationDbContext contextAppointment)
        {
            _dbAppointment = dbAppointment;
            _mapper = mapper;
            this._response = new();
            _dbProcedure = dbProcedure;
            _dbSection = dbSection;
            _contextAppointment = contextAppointment;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<APIResponse>> GetAppointments()
        {
            try
            {

                IEnumerable<Appointment> appointmentList = await _dbAppointment.GetAllAsync();
                _response.Result = _mapper.Map<List<AppointmentDTO>>(appointmentList);
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

        [HttpGet("{id:int}", Name = "GetAppointment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> GetAppointment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var appointment = await _dbAppointment.GetAsync(u => u.Id == id);
                if (appointment == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<AppointmentDTO>(appointment);
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
        public async Task<ActionResult<APIResponse>> CreateAppointment([FromBody] AppointmentCreateDTO createDTO)
        {
            try
            {
                //if(await _dbAppointment.GetAsync(u => u.Date.Date == createDTO.Date.Date && u.ProcedureName == createDTO.ProcedureName) != null && _dbProcedure.GetAsync(u => u.Name == createDTO.ProcedureName))
                //{
                //    ModelState.AddModelError("CustomError", "Appointment time is Invalid!");
                //    return BadRequest(ModelState);
                //}

                if(await _dbProcedure.GetAsync(u => u.Name.ToLower() == createDTO.ProcedureName.ToLower()) == null)
                {
                    ModelState.AddModelError("CustomError", "Procedure Name is Invalid!");
                    return BadRequest(ModelState);
                }

                if(await _dbSection.GetAsync(u => u.Name.ToLower() == createDTO.SectionName.ToLower()) == null)
                {
                    ModelState.AddModelError("CustomError", "Section Name is Invalid!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Appointment appointment = _mapper.Map<Appointment>(createDTO);

                await _dbAppointment.CreateAsync(appointment);
                _response.Result = _mapper.Map<AppointmentDTO>(appointment);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetAppointment", new { id = appointment.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleAppointment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> DeleteAppointment(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var appointment = await _dbAppointment.GetAsync(u => u.Id == id);
                if (appointment == null)
                {
                    return NotFound();
                }
                await _dbAppointment.RemoveAsync(appointment);
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

        [HttpPut("{id:int}", Name = "UpdateAppointment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<APIResponse>> UpdateAppointment(int id, [FromBody] AppointmentUpdateDTO updateDTO)
        {
            try
            {
                if (await _dbProcedure.GetAsync(u => u.Name == updateDTO.ProcedureName) == null)
                {
                    ModelState.AddModelError("CustomError", "Procedure Name is Invalid!");
                    return BadRequest(ModelState);
                }

                if (await _dbSection.GetAsync(u => u.Name.ToLower() == updateDTO.SectionName.ToLower()) == null)
                {
                    ModelState.AddModelError("CustomError", "Section Name is Invalid!");
                    return BadRequest(ModelState);
                }

                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }
                Appointment model = _mapper.Map<Appointment>(updateDTO);

                await _dbAppointment.UpdateAsync(model);
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


        [HttpPatch("{id:int}", Name = "UpdatePartialAppointment")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatePartialAppointment(int id, JsonPatchDocument<AppointmentUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var appointment = await _dbAppointment.GetAsync(u => u.Id == id, tracked: false);
            AppointmentUpdateDTO appointmentDTO = _mapper.Map<AppointmentUpdateDTO>(appointment);

            if (appointment == null)
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(appointmentDTO, ModelState);
            Appointment model = _mapper.Map<Appointment>(appointmentDTO);

            await _dbAppointment.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
