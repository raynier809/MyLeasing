﻿using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper)
        {
            _dataContext = dataContext;
            _combosHelper = combosHelper;
        }

        public async Task<Contract> ToContractAsync(ContractViewModel model, bool IsNew)
        {
            return new Contract
            {
                EndtDate = model.EndtDate.ToUniversalTime(),
                IsActive = model.IsActive,
                Id = IsNew ? 0 : model.Id,
                Lesse = await _dataContext.Lesses.FindAsync(model.LesseeId),
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                Price = model.Price,
                Property = await _dataContext.Properties.FindAsync(model.PropertyId),
                Remarks = model.Remarks,
                StartDate = model.StartDate.ToUniversalTime()
                
            };

        }

        public  ContractViewModel ToContractViewModel(Contract contract)
        {
            return new ContractViewModel
            {
                EndtDate = contract.EndDateLocal,
                IsActive = contract.IsActive,
                Id = contract.Id,
                Lesse = contract.Lesse,
                Owner = contract.Owner,
                Price = contract.Price,
                Property = contract.Property,
                Remarks = contract.Remarks,
                StartDate = contract.StartDateLocal,
                LesseeId = contract.Lesse.Id,
                Lessees = _combosHelper.GetComboLessees(),
                OwnerId = contract.Owner.Id,
                PropertyId = contract.Property.Id
            };
        }

        public async Task<Property> ToPropertyAsync(PropertyViewModel model, bool IsNew)
        {
            return new Property
            {
                Address = model.Address,
                Contracts = IsNew ? new List<Contract>() : model.Contracts,
                HasParkingLot = model.HasParkingLot,
                Id = IsNew ? 0 : model.Id,
                IsAvalible = model.IsAvalible,
                Neighborhood = model.Neighborhood,
                Owner = await _dataContext.Owners.FindAsync(model.OwnerId),
                Price = model.Price,
                PropertyImages = IsNew ? new List<PropertyImage>() : model.PropertyImages,
                PropertyType = await _dataContext.PropertyTypes.FindAsync(model.PropertyTypeId),
                Remarks = model.Remarks,
                Rooms = model.Rooms,
                SquareMeters = model.SquareMeters,
                Stratum = model.Stratum
            };
        }

        public PropertyViewModel ToPropertyViewModel(Property property)
        {
            return new PropertyViewModel
            {
                Address = property.Address,
                Contracts =  property.Contracts,
                HasParkingLot = property.HasParkingLot,
                Id =  property.Id,
                IsAvalible = property.IsAvalible,
                Neighborhood = property.Neighborhood,
                Owner = property.Owner,
                Price = property.Price,
                PropertyImages =  property.PropertyImages,
                PropertyType = property.PropertyType,
                Remarks = property.Remarks,
                Rooms = property.Rooms,
                SquareMeters = property.SquareMeters,
                Stratum = property.Stratum,
                OwnerId = property.Owner.Id,
                PropertyTypeId = property.PropertyType.Id,
                PropertyTypes = _combosHelper.GetComboPropertyTypes()
            };
        }
    }
}
