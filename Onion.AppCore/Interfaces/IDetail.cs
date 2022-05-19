using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IDetail
    {
        IEnumerable<DetailDTO> GetList();
        void Create(DetailDTO detailDTO);
        void Delete(int id);
        bool IsUnique(DetailDTO detailDTO);
    }
}
