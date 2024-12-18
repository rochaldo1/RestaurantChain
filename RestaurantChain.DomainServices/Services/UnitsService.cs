using RestaurantChain.Domain.Models;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.DomainServices.Services
{
    internal class UnitsService : IUnitsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(Units unit)
        {
            var existUnit = _unitOfWork.UnitsRepository.Get(unit.UnitName);
            if (existUnit != null)
            {
                return 0;
            }
            
            return _unitOfWork.UnitsRepository.Create(unit);
        }

        public Units Get(int id)
        {
            return _unitOfWork.UnitsRepository.Get(id);
        }

        public void Update(Units unit)
        {
            var existUnit = _unitOfWork.UnitsRepository.Get(unit.Id);
            if (existUnit == null)
            {
                throw new Exception($"Единицы измерения с Id {unit.Id} не найдено");
            }
            _unitOfWork.UnitsRepository.Update(unit);
        }
    }
}
