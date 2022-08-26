using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testConsole.ViewModel;

namespace testConsole.DataAccess
{
    public  class ReadDataManager
    {

        

        public IQueryable<MapViewModel> ReadData()
        {
           

            WorkDbContext workDbContext = new WorkDbContext();
            //Work2DbContext work2DbContext = new Work2DbContext();

            var maps = workDbContext.Maps;
            var mapSources = workDbContext.mapSource;

            IQueryable<MapViewModel> data = from map in maps
                       join source in mapSources on map.Id equals source.MapId

                       select new MapViewModel
                       {
                           MapId = source.MapId,
                           Id = map.Id,
                           Code = source.Code,
                           MapSourceId = source.Id,
                           NodeId = map.NodeId,
                           CreatedByCategoryId = map.CreatedByCategoryId,
                           SubstituteNodeId = map.SubstituteNodeId,
                           TreeId = map.TreeId
                       };

            return data;

           

        }


      

    }
}
