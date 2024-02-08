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
    internal class IncomeService : IIncomeService
    {
        internal readonly IIncomeRepository _incomeRepository;

        public IncomeService()
        {
            _incomeRepository = InstanceFactory.GetInstance<IIncomeRepository>(new DataAccessModule());
        }

        public Income Add(Income income)
        {
            Validate(income);

            var data = _incomeRepository.Add(income);

            return data;
        }

        public void Delete(int id)
        {
            _incomeRepository.Delete(new Income { Id = id });
        }

        public Income Get(int id)
        {
            return _incomeRepository.Get(i => i.Id == id);
        }

        public List<Income> GetAll()
        {
            return _incomeRepository.GetAll();
        }

        public Income Update(Income income)
        {
            Validate(income);

            var data = _incomeRepository.Update(income);

            return data;
        }

        private void Validate(Income income)
        {
            if (!income.IsValid())
                throw new Exception(Messages.InvalidData);

            var alikes = _incomeRepository.GetAll(i => i.Name == income.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);
        }
    }
}
