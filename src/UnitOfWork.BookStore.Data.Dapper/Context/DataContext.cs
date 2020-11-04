using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Dommel.Mapping;
using Microsoft.Extensions.Configuration;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;
using RepositoryHelpers.Mapping;

namespace UnitOfWork.BookStore.Data.Dapper.Context
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        public Connection Connection;
        public CustomTransaction Transaction;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = CreateConnection();
            Transaction = CreateTransaction();
            RegisterMappings();
        }

        private Connection CreateConnection()
        {
            return new Connection()
            {
                Database = RepositoryHelpers.Utils.DataBaseType.SqlServer,
                ConnectionString = _configuration.GetConnectionString($"DefaultConnection")
            };
        }

        private CustomTransaction CreateTransaction() =>
            new CustomTransaction(Connection);

        private void RegisterMappings()
        {
            if (Mapper.IsEmptyMapping())
            {
                Mapper.Initialize(c =>
                {
                    // Identify automatically the mapping classes (which inherit from DommelEntityMap)
                    // Records all mappings in Dapper.FluentMap
                    foreach (var type in GetMappingTypes())
                    {
                        var addMapMethod = typeof(FluentMapConfiguration).GetMethod("AddMap");
                        var target = addMapMethod.MakeGenericMethod(type.BaseType.GenericTypeArguments[0]);
                        var mapping = Activator.CreateInstance(type);
                        target.Invoke(c, new[] { mapping });
                    }
                });
            }
        }

        private IEnumerable<Type> GetMappingTypes() =>
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType != null && 
                            t.BaseType.GetInterfaces().Contains(typeof(IDommelEntityMap)));

        public void Dispose()
        {
            Transaction = null;
            Connection = null;
        }
    }
}