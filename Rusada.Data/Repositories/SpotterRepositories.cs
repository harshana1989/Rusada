using Microsoft.EntityFrameworkCore;
using Rusada.Common.Entities;
using Rusada.Common.Interfases;
using Rusada.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Data.Repositories
{
    public class SpotterRepositories : ISpotterRepositories
    {
        private readonly RsadaDbContext entities;

        private readonly IEntityMapper entityMapper;

        public SpotterRepositories(IEntityMapper entityMapper, RsadaDbContext entities)
        {
            this.entities = entities;
            this.entityMapper = entityMapper;
        }
        public async Task<List<MakeEntity>> GetMake()
        {
            try
            {
                var makeList = this.entities.Make.AsNoTracking().ToList();
                return this.entityMapper.Map<List<Make>, List<MakeEntity>>(makeList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ModelEntity>> GetModel()
        {
            try
            {

                var modelList = this.entities.AirlineModel.AsNoTracking().ToList();
                return this.entityMapper.Map<List<AirlineModel>, List<ModelEntity>>(modelList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SpotterEntity>> GetSpotters()
        {
            try
            {
                var spotterList = this.entities.Spotter.Include(z => z.Make).Include(z => z.Model).Where(z=>z.IsActive==true).AsNoTracking().ToList();
                return this.entityMapper.Map<List<Spotter>, List<SpotterEntity>>(spotterList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SpotterEntity> GetSpottersById(int SpotterId)
        {
            try
            {
                var spotter = this.entities.Spotter.Where(z=>z.Id== SpotterId).AsNoTracking().FirstOrDefault();
                return this.entityMapper.Map<Spotter,SpotterEntity>(spotter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  async Task<SpotterEntity> Save(SpotterEntity clientNote)
        {
            try
            {
                var spotter=entityMapper.Map<SpotterEntity,Spotter>(clientNote);
                if (clientNote.Id != 0)
                {
                    if (spotter.IsActive == false)
                    {
                        var spotterItem = this.entities.Spotter.FirstOrDefault(a => a.Id == spotter.Id);
                        if (spotterItem != null)
                        {
                            spotterItem.IsActive = spotter.IsActive;
                            this.entities.SaveChanges();
                        }
                    }
                    else
                    {
                        var spotterItem = this.entities.Spotter.FirstOrDefault(a => a.Id == spotter.Id);
                        if (spotterItem != null)
                        {
                            spotterItem.Location = spotter.Location;
                            spotterItem.MakeId = spotter.MakeId;
                            spotterItem.ModelId = spotter.ModelId;
                            spotterItem.Registration = spotter.Registration;
                            this.entities.SaveChanges();
                        }
                    }
                }
                else
                {
                    spotter.Id= this.entities.Spotter.Max(a => a.Id)+1;
                    this.entities.Spotter.Add(spotter);
                    this.entities.SaveChanges();
                }
                return entityMapper.Map<Spotter, SpotterEntity > (spotter);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
