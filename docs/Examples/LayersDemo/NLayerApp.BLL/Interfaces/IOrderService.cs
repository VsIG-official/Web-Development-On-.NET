using NLayerApp.BLL.DTO;
using System.Collections.Generic;

namespace NLayerApp.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        PhoneDTO GetPhone(int? id);
        IEnumerable<PhoneDTO> GetPhones();
        void Dispose();
    }
}
