using CruiseManagement.Models;
using CruiseManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CruiseManagement.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IDataRepository _dataRepository;
        public PassengerController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Passenger
        public IList<Passenger> Get()
        {
            return _dataRepository.getUsersList();
        }

        // GET: api/Passenger/5
        public IHttpActionResult Get(int id)
        {
            var obj = _dataRepository.GetById(id);
            return Ok(obj);
        }

        // POST: api/Passenger
        public Passenger Post([FromBody] Passenger user)
        {
            return _dataRepository.AddPassenger(user);
        }

        

        // PUT: api/User/5
        public Passenger Put([FromBody] Passenger User)
        {
            return _dataRepository.Update(User);
        }

        // DELETE: api/Passenger/5
        public bool Delete(int id)
        {
            var obj = _dataRepository.Delete(id);
            return obj;
        }
    }
}
