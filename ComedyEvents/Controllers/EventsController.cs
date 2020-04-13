using AutoMapper;
using ComedyEvents.Dto;
using ComedyEvents.Models;
using ComedyEvents.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EventDto[]>> Get(bool includeGigs = false)
        {
            try
            {
                var results = await _eventRepository.GetEvents(includeGigs);

                var mappedEntities = _mapper.Map<EventDto[]>(results);

                return Ok(mappedEntities);
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventDto>> Get(int eventId, bool includeGigs = false)
        {
            try
            {
                var result = await _eventRepository.GetEvent(eventId, includeGigs);

                if (result == null) return NotFound();

                var mappedEntity = _mapper.Map<EventDto>(result);

                return Ok(mappedEntity);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<EventDto>> SearchByDate(DateTime date, bool includeGigs = false)
        {
            try
            {
                var results = await _eventRepository.GetEventsByDate(date, includeGigs);

                if (!results.Any()) return NotFound();

                var mappedEntities = _mapper.Map<EventDto[]>(results);

                return Ok(mappedEntities);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }


    }
}
