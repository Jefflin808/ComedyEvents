﻿using AutoMapper;
using ComedyEvents.Dto;
using ComedyEvents.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public GigsController(IEventRepository eventsRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _eventRepository = eventsRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{gigId}")]
        public async Task<ActionResult<GigDto>> Get(int gigId, bool includeComedian = false)
        {
            try
            {
                var result = await _eventRepository.GetGig(gigId, includeComedian);
                if (result == null) return NotFound($"Could not find gig with id {gigId}");

                var mappedEntity = _mapper.Map<GigDto>(result);

                return Ok(mappedEntity);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByEvent")]
        public async Task<ActionResult<GigDto[]>> GetGigsByEvent(int eventId, bool includeComedian = false)
        {
            try
            {
                var results = await _eventRepository.GetGigsByEvent(eventId, includeComedian);

                if (!results.Any()) return NotFound();

                var mappedEntities = _mapper.Map<GigDto[]>(results);

                return Ok(mappedEntities);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("searchByVenue")]
        public async Task<ActionResult<GigDto[]>> GetGigsByVenue(int venueId, bool includeComedian = false)
        {
            try
            {
                var results = await _eventRepository.GetGigsByVenue(venueId, includeComedian);

                if (!results.Any()) return NotFound();

                var mappedEntities = _mapper.Map<GigDto[]>(results);

                return Ok(mappedEntities);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}