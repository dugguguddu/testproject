using SalesMakert.Data.Model;
using SalesMarket.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesMarket.Serv
{
    public class PartiesService:IPartiesService
    {
        private IBaseRepository<Parties> baseRepository;
        
        public PartiesService(IBaseRepository<Parties> repository)
        {
            baseRepository = repository;
        }
        public IEnumerable<Parties> GetAll()
        {
            return baseRepository.GetAll();
        }

        public Parties GetParty(int id)
        {
            return baseRepository.GetDataById(id);
        }

        public void Insert(Parties parties)
        {
            if(parties!=null)
            {
                baseRepository.Insert(parties);
            }
            baseRepository.Commit();
        }

        public void Update(Parties parties)
        {
            if (parties != null)
            {
                baseRepository.Update(parties);
            }
            baseRepository.Commit();
        }

        public void Delete(int id)
        {
            if (id >= 0)
            {
                var parties = GetParty(id);
                baseRepository.Delete(parties);
            }
            baseRepository.Commit();
        }
    }
}
