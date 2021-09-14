using Microsoft.EntityFrameworkCore;
using MMS.Domain.Distributors;
using MMS.Domain.Distributors.Repositories;
using MMS.Domain.Sales;
using MMS.Infrastructure.Db;
using MMS.Infrastructure.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMS.Infrastructure.Repositories
{
    public class DistributorRepository : IDistributorRepository
    {
        private readonly AppDbContext _db;

        public DistributorRepository(AppDbContext db)
        {
            _db = db;
        }

        public bool CanBeRecommender(int distributorId)
        {
            var recommender = _db.Distributors.FirstOrDefault(d => d.Id == distributorId);
            if (recommender == null)
            {
                throw new ArgumentException("Recommender distributor does not exists.");
            }

            var recommendedDistributors = _db.Distributors
                    .Where(d => d.RecommenderId == distributorId)
                    .Select(d => d.Id)
                    .ToList();

            if (recommendedDistributors.Count >= 3)
            {
                throw new ArgumentException("Recommender distributor can only be used maximum 3 times.");
            }

            var depth = 0;
            var maxDepth = 5;
            var recommenderId = recommender.Id;

            while (depth < maxDepth)
            {
                var parentRecommender = _db.Distributors.FirstOrDefault(d => d.Id == recommenderId);
                if (parentRecommender == null || !parentRecommender.RecommenderId.HasValue)
                {
                    return true;
                }
                recommenderId = parentRecommender.RecommenderId.Value;
                depth++;
            }

            throw new ArgumentException("Recommender distributor hierarchy depth limit reached.");
        }

        public Distributor GetById(int distributorId)
        {
            var entity = _db.Distributors
                 .AsNoTracking()
                 .Include(d => d.Addresses)
                 .Include(d => d.ContactInfos)
                 .Include(d => d.Documents)
                 //.Include(d => d.Sales)
                 .Include(d => d.Recommender)
                 .FirstOrDefault(d => d.Id == distributorId);
            return entity.ToDomainModel();
        }

        public List<Distributor> GetRecommendedDistributors(params int[] distributorIds)
        {

            var entities = _db.Distributors
                 .AsNoTracking()
                 .Where(d => d.RecommenderId.HasValue && distributorIds.Any(dId => d.RecommenderId.Value == dId))
                 .AsEnumerable()
                 .Select(d => d.ToDomainModel())
                 .ToList();
            return entities;
        }

        public List<Sale> GetSales(int[] distributorIds,long maxSaleId, DateTime startDate, DateTime endDate)
        {
            var sales =  _db.Sales
                .Where(s => distributorIds.Any(dId => dId == s.DistributorId))
                .Where(s => s.Id > maxSaleId)
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .Select(s => s.ToDomainModel())
                .ToList();

            return sales;
        }

        public void UpdateBonus(int distributorId, decimal bonus, long lastBonusSaleId)
        {
            var distributor = _db.Distributors.FirstOrDefault(d => d.Id == distributorId);
            distributor.Bonus = bonus;
            distributor.LastBonusSaleId = lastBonusSaleId;
            _db.SaveChanges();
        }

        public int Insert(Distributor distributor)
        {
            var entity = new DistributorEntity(distributor);
            _db.Distributors.Add(entity);
            _db.SaveChanges();
            return entity.Id;
        }

        public List<Distributor> Search(string firstName, string lastName, decimal minBonus, decimal maxBonus)
        {
            var entities = _db.Distributors
               .AsNoTracking()
               .Where(d => d.FirstName.Contains(firstName))
               .Where(d => d.FirstName.Contains(lastName))
               .Where(d => d.Bonus >= minBonus && d.Bonus <= maxBonus)
               .Select(d => d.ToDomainModel())
               .ToList();
            return entities;
        }

        public Distributor Edit(Distributor distributor)
        {
            var dist = _db.Distributors.Where(d => d.Id == distributor.Id).FirstOrDefault();
            if (dist != null)
            {
                dist.FirstName = distributor.FirstName;
                dist.LastName = distributor.LastName;
                dist.BirthDate = distributor.BirthDate;
                dist.Gender = distributor.Gender;
                dist.ImageUrl = distributor.ImageUrl;
                dist.RecommenderId = distributor.RecommenderId;
                dist.Documents = distributor.Documents.Select(s => new DocumentEntity(s)).ToList();
                dist.Addresses = distributor.Addresses.Select(s => new AddressEntity(s)).ToList();
                dist.ContactInfos = distributor.ContactInfos.Select(s => new ContactInfoEntity(s)).ToList();

                _db.SaveChanges();
            }
            else
            {
                return null;
            }

            return dist.ToDomainModel();

        }

        public void DeleteDistributor(int id)
        {
            var dist = _db.Distributors.Where(d => d.Id == id).FirstOrDefault();
            _db.Distributors.Remove(dist);
            _db.SaveChanges();
        }
    }
}
