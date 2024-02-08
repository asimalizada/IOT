using IOTSystem.Business.Abstract;
using IOTSystem.DataAccess;
using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOTSystem.Business.Concrete
{
    internal class OutcomeService : IOutcomeService
    {
        internal readonly IOutcomeRepository _outcomeRepository;

        public OutcomeService()
        {
            _outcomeRepository = InstanceFactory.GetInstance<IOutcomeRepository>(new DataAccessModule());
        }

        public Outcome Add(Outcome outcome)
        {
            Validate(outcome);

            var data = _outcomeRepository.Add(outcome);

            return data;
        }

        public void Delete(int id)
        {
            _outcomeRepository.Delete(new Outcome { Id = id });
        }

        public Outcome Get(int id)
        {
            return _outcomeRepository.Get(i => i.Id == id);
        }

        public List<Outcome> GetAll()
        {
            return _outcomeRepository.GetAll();
        }

        public Outcome Update(Outcome outcome)
        {
            Validate(outcome);

            var data = _outcomeRepository.Update(outcome);

            return data;
        }

        private void Validate(Outcome outcome)
        {
            if (!outcome.IsValid())
                throw new Exception(Messages.InvalidData);

            var alikes = _outcomeRepository.GetAll(o => o.Name == outcome.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);
        }
    }
}
