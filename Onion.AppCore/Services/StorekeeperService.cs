using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.AppCore.Services
{
    public class StorekeeperService : IStorekeeper
    {
        private readonly IGenericRepository<Storekeeper> _storekeeperRepository;
        private readonly IGenericRepository<Detail> _detailRepository;

        public StorekeeperService(IGenericRepository<Storekeeper> storekeeperRepository,
            IGenericRepository<Detail> detailRepository)
        {
            _storekeeperRepository = storekeeperRepository;
            _detailRepository = detailRepository;

        }


        public void Create(StorekeeperDTO storekeeperDTO)
            => _storekeeperRepository.Create(new Storekeeper()
            {
                FullName = storekeeperDTO.FullName
            });


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StorekeeperDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StorekeeperDTO> GetList()
            => _storekeeperRepository.GetList().Select(x => new StorekeeperDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                DetailAmount = _detailRepository.GetList().Where(y => y.StorekeeperId == x.Id && y.DeleteDate.Year > 2).
                    ToList().Count
            });

        public bool IsUnique(StorekeeperDTO storekeeperDTO)
            => _storekeeperRepository.GetList().Any(x => x.FullName == storekeeperDTO.FullName);

        public void Update(StorekeeperDTO storekeeperDTO)
        {
            throw new NotImplementedException();
        }
    }
}
