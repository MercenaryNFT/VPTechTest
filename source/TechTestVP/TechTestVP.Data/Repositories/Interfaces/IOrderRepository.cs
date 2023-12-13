using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.DTOs;
using TechTestVP.Lib.Models;

namespace TechTestVP.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<int> InsertOrder(Order order);
        public Task<bool> CheckIfOrderExists(string customerRef, string customerName);
    }
}
