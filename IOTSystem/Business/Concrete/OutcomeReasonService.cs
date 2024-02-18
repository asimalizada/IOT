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
    internal class OutcomeReasonService : IOutcomeReasonService
    {
        private readonly IOutcomeReasonRepository _outcomeReasonRepository;

        public OutcomeReasonService()
        {
            _outcomeReasonRepository = InstanceFactory.GetInstance<IOutcomeReasonRepository>(new DataAccessModule());   
        }

        public OutcomeReason Add(OutcomeReason outcomeReason)
        {
            Validate(outcomeReason);

            var data = _outcomeReasonRepository.Add(outcomeReason);

            return data;
        }

        public void Delete(int id)
        {
            _outcomeReasonRepository.Delete(new OutcomeReason { Id = id });
        }

        public OutcomeReason Get(int id)
        {
            return _outcomeReasonRepository.Get(i => i.Id == id);
        }

        public List<OutcomeReason> GetAll()
        {
            return _outcomeReasonRepository.GetAll();
        }

        public List<OutcomeReason> GetByName(string name)
        {
            return _outcomeReasonRepository.GetAll(o => o.Name.ToLower().Contains(name.ToLower()));
        }

        public OutcomeReason Update(OutcomeReason outcomeReason)
        {
            Validate(outcomeReason);

            var data = _outcomeReasonRepository.Update(outcomeReason);

            return data;
        }

        private void Validate(OutcomeReason outcomeReason)
        {
            if (!outcomeReason.IsValid())
                throw new Exception(Messages.InvalidData);

            var alikes = _outcomeReasonRepository.GetAll(i => i.Name == outcomeReason.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);

            if (outcomeReason.Amount == -1)
                outcomeReason.Amount = null;
        }
    }
}
