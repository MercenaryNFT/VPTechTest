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
        public Task<int> InsertOrder(OrderDTO order);
        public Task<bool> CheckIfOrderImportedExists(string customerRef, string customerName);
    }
}
