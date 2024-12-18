﻿using RestaurantChain.Domain.Models;
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
    internal class BanksService : IBanksService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BanksService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(Banks bank)
        {
            var existBank = _unitOfWork.BanksRepository.Get(bank.BankName);
            if (existBank != null)
            {
                return 0;
            }
            return _unitOfWork.BanksRepository.Create(bank);
        }

        public void Update(Banks bank)
        {
            var existBank = _unitOfWork.BanksRepository.Get(bank.Id);
            if (existBank == null)
            {
                throw new Exception($"Банка с Id {bank.Id} не найдено");
            }
            _unitOfWork.BanksRepository.Update(bank);
        }
    }
}