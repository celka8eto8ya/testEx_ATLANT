using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

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


        private int GetDetailsAmount(int id)
        {
            int detailsAmount = 0;
            _detailRepository.GetList().Where(x => x.DeleteDate.Year < 3 && x.StorekeeperId == id).ToList().
                ForEach(y => detailsAmount += y.Amount);
            return detailsAmount;
        }


        public void Delete(int id)
            => _storekeeperRepository.Delete(id);


        public IEnumerable<StorekeeperDTO> GetList()
            => _storekeeperRepository.GetList().Select(x => new StorekeeperDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                DetailAmount = GetDetailsAmount(x.Id)
            });


        public bool IsUnique(StorekeeperDTO storekeeperDTO)
            => _storekeeperRepository.GetList().Any(x => x.FullName == storekeeperDTO.FullName);


    }
}
