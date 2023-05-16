using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        IceShopContext _dbContext;
        public RatingRepository(IceShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Rating> AddRating(Rating newRating)
        {
            await _dbContext.Rating.AddAsync(newRating);
            await _dbContext.SaveChangesAsync();
            return newRating;
        }
    }
}
