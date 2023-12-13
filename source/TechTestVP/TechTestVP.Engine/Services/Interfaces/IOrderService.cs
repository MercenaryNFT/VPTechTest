using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestVP.Lib.DTOs;
using TechTestVP.Lib.Models;
using TechTestVP.Lib.Response;

namespace TechTestVP.Engine.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ReponseDTO> InsertOrder(OrderDTO order);
        public Task<bool> CheckIfOrderImportedExists(string customerRef, string customerId);

    }
}
