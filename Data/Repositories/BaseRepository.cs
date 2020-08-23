namespace Data.Repositories
{
    public class BaseRepository<TEntity>
    {
        protected readonly HogwartsContext _dbContext;

        public BaseRepository(HogwartsContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
