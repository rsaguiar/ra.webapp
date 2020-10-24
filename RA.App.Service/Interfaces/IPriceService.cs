using RA.App.Domain;
using System.Collections.Generic;

namespace RA.App.Service.Interfaces {
    public interface IPriceService {
        Price Get(int id);
        IEnumerable<Price> GetAll();
        Price GetCalculatePrice(int sourceId, int destinationId);
        void Delete(Price entity);
        void Edit(Price entity);
        void Create(Price entity);
    }
}
