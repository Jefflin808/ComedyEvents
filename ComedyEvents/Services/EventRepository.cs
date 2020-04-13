using ComedyEvents.Context;
using ComedyEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Services
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _eventContext;
        private readonly ILogger<EventRepository> _logger;

        public EventRepository(EventContext eventContext, ILogger<EventRepository> logger)
        {
            _eventContext = eventContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _eventContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _eventContext.Remove(entity);
        }

        public async Task<Comedian> GetComedian(int comedianId)
        {
            _logger.LogInformation($"Getting comedian for id {comedianId}");

            var query = _eventContext.Comdians
                        .Where(c => c.ComedianId == comedianId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Comedian[]> GetComedians()
        {
            _logger.LogInformation("Getting all comedians");

            var query = _eventContext.Comdians
                        .OrderBy(c => c.LastName);

            return await query.ToArrayAsync();
        }

        public async Task<Comedian[]> GetComediansByEvent(int eventId)
        {
            _logger.LogInformation($"Getting all comedians for event for eventId {eventId}");

            IQueryable<Comedian> query = _eventContext.Gigs
                                        .Where(g => g.Event.EventId == eventId)
                                        .Select(g => g.Comedian)
                                        .OrderBy(c => c.LastName);

            return await query.ToArrayAsync();
        }

        public Task<Event> GetEvent(int eventId, bool includeGigs = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetEvents(bool includeGigs = false)
        {
            throw new NotImplementedException();
        }

        public Task<Event[]> GetEventsByDate(DateTime date, bool includeGigs = false)
        {
            throw new NotImplementedException();
        }

        public Task<Gig> GetGigByEvent(int gigId, int eventId, bool includeComedians = false)
        {
            throw new NotImplementedException();
        }

        public Task<Gig[]> GetGigsByEvent(int eventId, bool includeComedians = false)
        {
            throw new NotImplementedException();
        }

        public Task<Gig[]> GetGigsByVenue(int venueId, bool includeComedians = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _eventContext.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _eventContext.Update(entity);
        }
    }
}
