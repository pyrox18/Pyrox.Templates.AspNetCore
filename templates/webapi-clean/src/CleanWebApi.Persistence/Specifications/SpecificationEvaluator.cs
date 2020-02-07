using CleanWebApi.Application.Interfaces;
using CleanWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanWebApi.Persistence.Specifications
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (!(specification.Criteria is null))
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if (!(specification.OrderBy is null))
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (!(specification.OrderByDescending is null))
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                    .Take(specification.Take);
            }

            return query;
        }
    }
}
