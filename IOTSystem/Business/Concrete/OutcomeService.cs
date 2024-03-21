using IOTSystem.Business.Abstract;
using IOTSystem.DataAccess;
using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Entities.Dto;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOTSystem.Business.Concrete
{
    internal class OutcomeService : BaseService, IOutcomeService
    {
        internal readonly IOutcomeRepository _outcomeRepository;
        internal readonly IBalanceRepository _balanceRepository;

        public OutcomeService()
        {
            _outcomeRepository = InstanceFactory.GetInstance<IOutcomeRepository>(new DataAccessModule());
            _balanceRepository = InstanceFactory.GetInstance<IBalanceRepository>(new DataAccessModule());
        }

        public OutcomeDto Add(OutcomeDto outcome)
        {
            Validate(outcome, true);

            var data = _outcomeRepository.Add(Map<OutcomeDto, Outcome>(outcome));

            var balance = _balanceRepository.Get(b => b.Id == outcome.BalanceId);

            balance.Amount -= outcome.Amount;

            _balanceRepository.Update(balance);

            return Map<Outcome, OutcomeDto>(data);
        }

        public void Delete(int id)
        {
            var outcome = _outcomeRepository.Get(o => o.Id == id);

            _outcomeRepository.Delete(new Outcome { Id = id });

            var balance = _balanceRepository.Get(b => b.Id == outcome.BalanceId);

            balance.Amount += outcome.Amount;

            _balanceRepository.Update(balance);
        }

        public OutcomeDto Get(int id)
        {
            return Map<Outcome, OutcomeDto>(_outcomeRepository.Get(i => i.Id == id));
        }

        public List<OutcomeDto> GetAll()
        {
            return _outcomeRepository.GetAllOutcomes();
        }

        public List<OutcomeDto> GetAlternativeOutcomes()
        {
            return _outcomeRepository.GetAllOutcomes(o => o.IsAlternative);
        }

        public OutcomeDto Update(OutcomeDto outcome)
        {
            Validate(outcome, false);

            var previousData = _outcomeRepository.Get(o => o.Id == outcome.Id);

            var data = _outcomeRepository.Update(Map<OutcomeDto, Outcome>(outcome));

            var balance = _balanceRepository.Get(b => b.Id == outcome.BalanceId);

            balance.Amount -= (outcome.Amount - previousData.Amount);

            _balanceRepository.Update(balance);

            return Map<Outcome, OutcomeDto>(data);
        }

        private void Validate(OutcomeDto outcome, bool isAdd)
        {
            if (!outcome.IsValid())
                throw new Exception(Messages.InvalidData);

            if (!isAdd)
                return;

            var alikes = _outcomeRepository.GetAll(o => o.Name == outcome.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);
        }
    }
}
