using System;
using System.Collections.Generic;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(OrderDTO order);
        void UpdateOrder(OrderDTO order);
        OrderDTO GetOrderById(int id);
        void DeleteOrderById(int id);
        IEnumerable<RoomDTO> GetRooms();
        decimal GetSumById(int id);
        DateTime GetStartDateById(int id);
        DateTime GetEndDateById(int id);
    }
}
