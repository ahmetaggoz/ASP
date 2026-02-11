using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClothService> _clothService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger) 
        { 
            _clothService = new Lazy<IClothService>(() => new ClothesManager(repositoryManager, logger));
        }
        public IClothService ClothService => _clothService.Value;
    }
}
