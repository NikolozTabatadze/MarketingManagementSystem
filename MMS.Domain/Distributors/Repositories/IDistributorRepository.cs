using MMS.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Domain.Distributors.Repositories
{
    public interface IDistributorRepository
    {
        bool CanBeRecommender(int distributorId);
        int Insert(Distributor distributor);
        Distributor GetById(int distributorId);
        Distributor Edit(Distributor distributor);
        void DeleteDistributor(int id);
        List<Sale> GetSales(int[] distributorIds, long maxSaleId, DateTime startDate, DateTime endDate);
        List<Distributor> GetRecommendedDistributors(params int[] distributorIds);
        void UpdateBonus(int distributorId, decimal bonus, long lastBonusSaleId);
        List<Distributor> Search(string firstName, string lastName, decimal minBonus, decimal maxBonus);
    }
}
