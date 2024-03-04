using IOTSystem.Entities.Concrete;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IOutcomeService
    {
        Outcome Add(Outcome outcome);

        Outcome Update(Outcome outcome);

        void Delete(int id);

        Outcome Get(int id);

        List<Outcome> GetAll();

        List<Outcome> GetAlternativeOutcomes();
    }
}
