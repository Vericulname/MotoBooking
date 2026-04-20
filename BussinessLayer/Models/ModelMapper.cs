using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Models
{
    public class ModelMapper<Tsource, Tdestination>
    {
        Tsource source;
        Tdestination destination;
        public static Mapper createMap()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
            });
            MapperConfiguration config = new(static cfg => cfg.CreateMap<Tsource, Tdestination>().ReverseMap(), loggerFactory);
            Mapper mapper = new Mapper(config);
            return mapper;
        }

    }
}
