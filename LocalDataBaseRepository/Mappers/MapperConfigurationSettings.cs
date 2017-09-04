using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDataBaseRepository.Mappers.Entities;
using AutoMapper;

namespace LocalDataBaseRepository.Mappers
{
    public class MapperConfigurationSettings
    {
        public static MapperConfigurationExpression MappingConfiguration;

        public static void InitializeMaps()
        {
            if (mapperIsNotInitialized)
            {
                InitializeMapperGlobalConfigurations();
                ProductMapper.Configure();
                Mapper.Initialize(MappingConfiguration);
            }
        }

        private static MapperConfigurationExpression getMapperGlobalSettings()
        {
            return new MapperConfigurationExpression
            {
                AllowNullDestinationValues = false
            };
        }

        private static void InitializeMapperGlobalConfigurations()
        {
            MapperConfigurationSettings.MappingConfiguration = getMapperGlobalSettings();
        }


        static private bool mapperIsNotInitialized {
            get
            {
                return MappingConfiguration == null;
            }
        } 

    }
}
