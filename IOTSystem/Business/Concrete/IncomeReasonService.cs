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
    internal class IncomeReasonService : IIncomeReasonService
    {
        private readonly IIncomeReasonRepository _incomeReasonRepository;

        public IncomeReasonService()
        {
            _incomeReasonRepository = InstanceFactory.GetInstance<IIncomeReasonRepository>(new DataAccessModule());   
        }

        public IncomeReason Add(IncomeReason incomeReason)
        {
            Validate(incomeReason);

            var data = _incomeReasonRepository.Add(incomeReason);

            return data;
        }

        public void Delete(int id)
        {
            _incomeReasonRepository.Delete(new IncomeReason { Id = id });
        }

        public IncomeReason Get(int id)
        {
            return _incomeReasonRepository.Get(i => i.Id == id);
        }

        public List<IncomeReason> GetAll()
        {
            return _incomeReasonRepository.GetAll();
        }

        public List<IncomeReason> GetByname(string name)
        {
            return _incomeReasonRepository.GetAll(i => i.Name.Contains(name));
        }

        public IncomeReason Update(IncomeReason incomeReason)
        {
            Validate(incomeReason);

            var data = _incomeReasonRepository.Update(incomeReason);

            return data;
        }

        private void Validate(IncomeReason incomeReason)
        {
            if (!incomeReason.IsValid())
                throw new Exception(Messages.InvalidData);

            var alikes = _incomeReasonRepository.GetAll(i => i.Name == incomeReason.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.InvalidData);
        }
    }
}
