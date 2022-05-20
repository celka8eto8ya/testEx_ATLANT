using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class DetailService : IDetail
    {
        private readonly IGenericRepository<Detail> _detailRepository;
        private readonly IGenericRepository<Storekeeper> _storekeeperRepository;

        public DetailService(IGenericRepository<Detail> detailRepository,
            IGenericRepository<Storekeeper> storekeeperRepository)
        {
            _detailRepository = detailRepository;
            _storekeeperRepository = storekeeperRepository;
        }


        public void Create(DetailDTO detailDTO)
            => _detailRepository.Create(new Detail()
            {
                Code = detailDTO.Code,
                Name = detailDTO.Name,
                Amount = detailDTO.Amount,
                CreateDate = detailDTO.CreateDate,
                DeleteDate = System.DateTime.MinValue,

                StorekeeperId = detailDTO.StorekeeperId
            });


        public void Delete(int id)
        {
            var detail = _detailRepository.GetList().First(x => x.Id == id);
            _detailRepository.Update(new Detail
            {
                Id = detail.Id,
                Code = detail.Code,
                Name = detail.Name,
                Amount = detail.Amount,
                CreateDate = detail.CreateDate,
                DeleteDate = System.DateTime.Now,

                StorekeeperId = detail.StorekeeperId
            });
        }


        public IEnumerable<DetailDTO> GetList()
            => _detailRepository.GetList().Select(x => new DetailDTO
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Amount = x.Amount,
                CreateDate = x.CreateDate,
                DeleteDate = x.DeleteDate,
                SK_FullName = _storekeeperRepository.GetById(x.StorekeeperId).FullName,

                StorekeeperId = x.StorekeeperId
            });

        public bool IsUnique(DetailDTO detailDTO)
            => _detailRepository.GetList().Any(x => x.Name == detailDTO.Name);

    }
}
