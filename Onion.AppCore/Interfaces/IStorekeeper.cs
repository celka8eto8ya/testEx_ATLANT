using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IStorekeeper
    {
        IEnumerable<StorekeeperDTO> GetList();
        void Create(StorekeeperDTO storekeeperDTO);
        void Delete(int id);
        bool IsUnique(StorekeeperDTO torekeeperDTO);
    }
}
