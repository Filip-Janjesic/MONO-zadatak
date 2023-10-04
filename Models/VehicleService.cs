using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mono.Models;
using Mono.Data;

namespace Mono.Services
{
    public class VehicleService
    {
        private VehicledbContext _dbContext;

        public VehicleService(DbContextOptions<VehicledbContext> dbContextOptions)
        {
            _dbContext = new VehicledbContext(dbContextOptions);
        }

        public List<VehicleMake> GetAllMakes()
        {
            return _dbContext.VehicleMakes.ToList();
        }

        public List<VehicleModel> GetAllModels()
        {
            return _dbContext.VehicleModels.ToList();
        }

        public void ChangeOilFilter(int vehicleId)
        {
           //treba popuniti
        }

       
        public void ServiceVehicle(int vehicleId)
        {
            //treba popuniti
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
