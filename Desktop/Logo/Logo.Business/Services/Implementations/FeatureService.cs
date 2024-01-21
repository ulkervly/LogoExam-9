using Logo.Business.Exceptions;
using Logo.Business.Services.Interfaces;
using Logo.Core.Models;
using Logo.Core.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Business.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task CreateAsync(Feature feature)
        {
            if (feature is null)
            {
                throw new FeatureNullReference("Feature","Feature cannot be null");
            }
            await _featureRepository.CreatedAsync(feature);
            feature.UpdatedDate = DateTime.UtcNow;
            feature.CreatedDate = DateTime.UtcNow;
            await _featureRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
           if(id<0)  throw new IdBelowZeroException() ;
            var exist = await _featureRepository.GetByIdAsync(x=>x.Id==id);
            _featureRepository.Delete(exist);
            await _featureRepository.CommitAsync();
          
        }

        public Task<List<Feature>> GetAllAsync()
        {
            return _featureRepository.GetAllAsync();
        }

        public Task<Feature> GetAsync(int id)
        {
            return _featureRepository.GetByIdAsync(x=>x.Id==id);
        }

        public  async Task Updateasync(Feature feature)
        {
            
            if (feature is null)
            {
                throw new FeatureNullReference("Feature", "Feature cannot be null");
            }
            var exist = await _featureRepository.GetByIdAsync(x=>x.Id==x.Id);
            
            exist.Name= feature.Name;
            exist.Description= feature.Description;
            exist.UpdatedDate = DateTime.UtcNow;
            await _featureRepository.CreatedAsync(feature);
            await _featureRepository.CommitAsync();
        }
    }
}
