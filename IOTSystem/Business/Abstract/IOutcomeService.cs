using IOTSystem.Entities.Dto;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IOutcomeService
    {
        OutcomeDto Add(OutcomeDto outcome);

        OutcomeDto Update(OutcomeDto outcome);

        void Delete(int id);

        OutcomeDto Get(int id);

        List<OutcomeDto> GetAll();

        List<OutcomeDto> GetAlternativeOutcomes();
    }
}
