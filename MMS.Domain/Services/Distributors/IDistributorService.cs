using MMS.Core;
using MMS.Domain.Distributors.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Domain.Services
{
    public interface IDistributorService
    {
        HttpResult Register(RegisterDistributorRequest request);
        HttpResult CalculateBonus(CalculateBonusRequest request);
        HttpResult GetBonus(int distributorId);
        HttpResult Search(SearchDistributorRequest request);
        HttpResult Edit(EditDistributorRequest request);
        HttpResult Delete(DeleteDistributorRequest request);

    }
}
