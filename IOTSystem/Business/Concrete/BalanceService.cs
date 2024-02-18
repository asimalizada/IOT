using IOTSystem.Business.Abstract;
using IOTSystem.DataAccess;
using IOTSystem.DataAccess.Abstract;
using IOTSystem.DataAccess.Concrete;
using IOTSystem.Entities.Concrete;
using IOTSystem.Helpers;
using IOTSystem.IoC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOTSystem.Business.Concrete
{
    internal class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceService()
        {
            _balanceRepository = InstanceFactory.GetInstance<IBalanceRepository>(new DataAccessModule());
        }

        public Balance Add(Balance balance)
        {
            Validate(balance);

            var data = _balanceRepository.Add(balance);

            return data;
        }

        public void Delete(int id)
        {
            _balanceRepository.Delete(new Balance { Id = id });
        }

        public Balance Get(int id)
        {
            return _balanceRepository.Get(b => b.Id == id);
        }

        public List<Balance> GetAll()
        {
            return _balanceRepository.GetAll();
        }

        public Balance Update(Balance balance)
        {
            Validate(balance);

            var data = _balanceRepository.Update(balance);

            return data;
        }
        
        private void Validate(Balance balance)
        {
            if (!balance.IsValid())
                throw new Exception(Messages.InvalidData);

            var alikes = _balanceRepository.GetAll(i => i.Name == balance.Name);

            if (alikes != null && alikes.Any())
                throw new Exception(Messages.DataExists);
        }
    }
}
