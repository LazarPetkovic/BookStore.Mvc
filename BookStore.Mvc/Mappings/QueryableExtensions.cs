using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Mvc.Mappings
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            //Mapper.Map<Source, Destination>(source, destination);
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}