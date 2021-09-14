using MMS.Core;
using MMS.Domain.Distributors;
using MMS.Domain.Distributors.Repositories;
using MMS.Domain.Distributors.Requests;
using MMS.Domain.Sales;
using System.Collections.Generic;
using System.Linq;

namespace MMS.Domain.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IDistributorRepository _distributorRepository;

        public DistributorService(IDistributorRepository distributorRepository)
        {
            _distributorRepository = distributorRepository;
        }

        public HttpResult Register(RegisterDistributorRequest request)
        {
            if (request.RecommenderId.HasValue)
            {
                var canBeRecommender = _distributorRepository.CanBeRecommender(request.RecommenderId.Value);
                if (!canBeRecommender)
                {
                    return HttpResult.Error("");
                }
            }
            var distributor = new Distributor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                ImageUrl = request.ImageUrl,
                RecommenderId = request.RecommenderId,
                Addresses = request.Addresses,
                ContactInfos = request.ContactInfos,
                Documents = request.Documents
            };

            _distributorRepository.Insert(distributor);
            return HttpResult.Success("Distributor registered succesfully");
        }

        public HttpResult CalculateBonus(CalculateBonusRequest request)
        {
            var result = new HttpResult();

            // Level 1
            var distributor = _distributorRepository.GetById(request.DistributorId);
            var sales = _distributorRepository.GetSales(new int[] { request.DistributorId }, distributor.LastBonusSaleId, request.StartDate, request.EndDate);
            var maxSalesId = sales.Max(s => s.Id);
            var bonus = sales.Sum(s => s.TotalPrice * 0.1M);

            // Level 2
            var distributors = _distributorRepository.GetRecommendedDistributors(request.DistributorId);
            var distributorIds = distributors.Select(d => d.Id).ToArray();
            var distributorSales = _distributorRepository.GetSales(distributorIds, distributor.LastBonusSaleId, request.StartDate, request.EndDate);
            bonus += distributorSales.Sum(s => s.TotalPrice * 0.05M);
            var maxDistributorSalesId = distributorSales.Max(s => s.Id);
            if (maxDistributorSalesId > maxSalesId)
            {
                maxSalesId = maxDistributorSalesId;
            }

            // Level 3
            distributors = _distributorRepository.GetRecommendedDistributors(distributorIds);
            distributorIds = distributors.Select(d => d.Id).ToArray();
            distributorSales = _distributorRepository.GetSales(distributorIds, distributor.LastBonusSaleId, request.StartDate, request.EndDate);
            bonus += distributorSales.Sum(s => s.TotalPrice * 0.01M);
            maxDistributorSalesId = distributorSales.Max(s => s.Id);
            if (maxDistributorSalesId > maxSalesId)
            {
                maxSalesId = maxDistributorSalesId;
            }

            _distributorRepository.UpdateBonus(request.DistributorId, distributor.Bonus + bonus, maxSalesId);

            result.Payload.Add("bonus", bonus);

            return result;
        }

        public HttpResult GetBonus(int distributorId)
        {
            var distributor = _distributorRepository.GetById(distributorId);
            var result = new HttpResult();
            result.Payload.Add("bonus", distributor.Bonus);
            return result;
        }

        public HttpResult Search(SearchDistributorRequest request)
        {
            var searchResult = _distributorRepository.Search(request.FirstName, request.LastName, request.MinBonus, request.MaxBonus);
            var result = new HttpResult();
            result.Payload.Add("data", searchResult);
            return result;
        }

        public HttpResult Edit(EditDistributorRequest request)
        {
            if (request.RecommenderId.HasValue)
            {
                var canBeRecommender = _distributorRepository.CanBeRecommender(request.RecommenderId.Value);
                if (!canBeRecommender)
                {
                    return HttpResult.Error("");
                }
            }
            var distributor = new Distributor
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Gender = request.Gender,
                ImageUrl = request.ImageUrl,
                RecommenderId = request.RecommenderId,
                Addresses = request.Addresses,
                ContactInfos = request.ContactInfos,
                Documents = request.Documents 
            };
            _distributorRepository.Edit(distributor);
            return HttpResult.Success("Distributor Updated succesfully");
        }

        public HttpResult Delete(DeleteDistributorRequest request)
        {
            if (request.Id == 0)
            {
                return HttpResult.Error("");
            }
            _distributorRepository.DeleteDistributor(request.Id);
            return HttpResult.Success("Distributor Deleted succesfully");
        }
    }
}
