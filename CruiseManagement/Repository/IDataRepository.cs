using CruiseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseManagement.Repository
{
    public interface IDataRepository
    {
        Passenger AddPassenger(Passenger user);
        bool Delete(int Id);
        Passenger GetById(int id);
        IList<Passenger> getUsersList();
        Passenger Update(Passenger user);
    }
}