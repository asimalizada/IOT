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
    internal class IncomeService : BaseService, IIncomeService
    {
        internal readonly IIncomeRepository _incomeRepository;
        internal readonly IBalanceRepository _balanceRepository;

        public IncomeService()
        {
            _incomeRepository = InstanceFactory.GetInstance<IIncomeRepository>(new DataAccessModule());
            _balanceRepository = InstanceFactory.GetInstance<IBalanceRepository>(new DataAccessModule());
        }

        public IncomeDto Add(IncomeDto income)
        {
            Validate(income, true);

            var data = _incomeRepository.Add(Map<IncomeDto, Income>(income));

            var balance = _balanceRepository.Get(b => b.Id == income.BalanceId);

            balance.Amount += income.Amount;

            _balanceRepository.Update(balance);

            return Map<Income, IncomeDto>(data);
        }

        public void Delete(int id)
        {
            var data = _incomeRepository.Get(i => i.Id == id);

            _incomeRepository.Delete(new Income { Id = id });

            var balance = _balanceRepository.Get(b => b.Id == data.BalanceId);

            balance.Amount -= data.Amount;

            _balanceRepository.Update(balance);
        }

        public IncomeDto Get(int id)
        {
            return Map<Income, IncomeDto>(_incomeRepository.Get(i => i.Id == id));
        }

        public List<IncomeDto> GetAll()
        {
            return _incomeRepository.GetAllIncomes();
        }

        public IncomeDto Update(IncomeDto income)
        {
            Validate(income, false);

            var previousData = _incomeRepository.Get(i => i.Id == income.Id);

            var data = _incomeRepository.Update(Map<IncomeDto, Income>(income));

            var balance = _balanceRepository.Get(b => b.Id == income.BalanceId);

            balance.Amount += (income.Amount - previousData.Amount);

            _balanceRepository.Update(balance);

            return Map<Income, IncomeDto>(data);
        }

        private void Validate(IncomeDto income, bool isAdd)
        {
            if (!income.IsValid())
                throw new Exception(Messages.InvalidData);

            if (!isAdd)
                return;

            var alikes = _incomeRepository.GetAll(i => i.Name == income.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);
        }
    }
}
