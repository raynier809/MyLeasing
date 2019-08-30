﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Models;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController: ControllerBase
    {
        private readonly DataContext _dataContext;

        public OwnersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("GetOwnerByEmail")]
        public async Task<IActionResult> GetOwnerByEmailAsync(EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var owner = await _dataContext.Owners
                .Include(o => o.User)
                .Include(o => o.Properties)
                .ThenInclude(p => p.PropertyType)
                .Include(o => o.Properties)
                .ThenInclude(p => p.PropertyImages)
                .Include(o => o.Contracts)
                .ThenInclude(c => c.Lesse)
                .ThenInclude(l => l.User)
                .FirstOrDefaultAsync(o => o.User.Email.ToLower() == request.Email.ToLower());

            if (owner == null)
            {
                return NotFound();
            }

            var response = new OwnerResponse
            {
                Id = owner.Id,
                FirstName = owner.User.FirstName,
                LastName = owner.User.LastName,
                Address = owner.User.Address,
                Document = owner.User.Document,
                Email = owner.User.Email,
                PhoneNumber = owner.User.PhoneNumber,
                Properties = owner.Properties?.Select(p => new PropertyResponse
                {
                    Address = p.Address,
                    Contracts = p.Contracts?.Select(c => new ContractResponse
                    {
                        EndDate = c.EndtDate,
                        Id = c.Id,
                        IsActive = c.IsActive,
                        Lessee = ToLessesResponse(c.Lesse),
                        Price = c.Price,
                        Remarks = c.Remarks,
                        StartDate = c.StartDate
                    }).ToList(),
                    HasParkingLot = p.HasParkingLot,
                    Id = p.Id,
                    IsAvailable = p.IsAvalible,
                    Neighborhood = p.Neighborhood,
                    Price = p.Price,
                    PropertyImages = p.PropertyImages?.Select(pi => new PropertyImageResponse
                    {
                        Id = pi.Id,
                        ImageUrl = pi.ImageFullPath
                    }).ToList(),
                    PropertyType = p.PropertyType.Name,
                    Remarks = p.Remarks,
                    Rooms = p.Rooms,
                    SquareMeters = p.SquareMeters,
                    Stratum = p.Stratum
                }).ToList()
            };

            return Ok(response);
        }

        private LesseeResponse ToLessesResponse(Lesse lessee)
        {
            return new LesseeResponse
            {
                Id = lessee.Id,
                Address = lessee.User.Address,
                Document = lessee.User.Document,
                Email = lessee.User.Email,
                FirstName = lessee.User.FirstName,
                LastName = lessee.User.LastName,
                PhoneNumber = lessee.User.PhoneNumber
            };
        }
    }
}