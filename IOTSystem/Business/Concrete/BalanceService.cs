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
    internal class BalanceService : BaseService, IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceService()
        {
            _balanceRepository = InstanceFactory.GetInstance<IBalanceRepository>(new DataAccessModule());
        }

        public BalanceDto Add(BalanceDto balance)
        {
            Validate(balance, true);

            var data = _balanceRepository.Add(Map<BalanceDto, Balance>(balance));

            return Map<Balance, BalanceDto>(data);
        }

        public void Delete(int id)
        {
            _balanceRepository.Delete(new Balance { Id = id });
        }

        public BalanceDto Get(int id)
        {
            return Map<Balance, BalanceDto>(_balanceRepository.Get(b => b.Id == id));
        }

        public List<BalanceDto> GetAll()
        {
            return Map<Balance, BalanceDto>(_balanceRepository.GetAll());
        }

        public BalanceDto Update(BalanceDto balance)
        {
            Validate(balance, false);

            var data = _balanceRepository.Update(Map<BalanceDto, Balance>(balance));

            return Map<Balance, BalanceDto>(data);
        }

        private void Validate(BalanceDto balance, bool isAdd)
        {
            if (!balance.IsValid())
                throw new Exception(Messages.InvalidData);

            if (!isAdd)
                return;

            var alikes = _balanceRepository.GetAll(i => i.Name == balance.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);
        }
    }
}
