using CruiseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseManagement.Repository
{
    public class DataRepository : IDataRepository
    {
        readonly Dictionary<int, Passenger> _user = new Dictionary<int, Passenger>();
        public DataRepository()
        {
            _user.Add(1, new Passenger() { PassengerNumber = 1, FName = "xyz", LName = "abc", phoneNumber="9825114484" });
            _user.Add(2, new Passenger() { PassengerNumber = 2, FName = "rst", LName = "pqr", phoneNumber = "9123456789" });
            _user.Add(1, new Passenger() { PassengerNumber = 3, FName = "mno", LName = "ghi", phoneNumber = "9236541225" });

        }
        public Passenger AddPassenger(Passenger user)
        {
            int newId = !getUsersList().Any() ? 1 : getUsersList().Max(x => x.PassengerNumber) + 1;
            user.PassengerNumber = newId;
            _user.Add(newId, user);
            return user;
        }

        public bool Delete(int Id)
        {
            var result = _user.Remove(Id);
            return result;
        }

        public Passenger GetById(int id)
        {
            return _user.FirstOrDefault(x => x.Key == id).Value;
        }

        public IList<Passenger> getUsersList()
        {
            return _user.Select(x => x.Value).ToList();
        }

        public Passenger Update(Passenger user)
        {
            Passenger obj = GetById(user.PassengerNumber);
            if (obj == null)
                return null;
            _user[obj.PassengerNumber] = user;
            return user;
        }
    }
}