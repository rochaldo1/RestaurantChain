using RestaurantChain.Domain.Models;
using RestaurantChain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Domain.Services.Services
{
    internal sealed class NomenclatureService : ServiceBase, INomenclarureService
    {
        public NomenclatureService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public NomenclatureDomain Get()
        {
            throw new NotImplementedException();
        }
    }
}
