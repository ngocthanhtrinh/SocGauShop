namespace SocGauShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SocGauShopDbContext dbContext;

        public SocGauShopDbContext Init()
        {
            return dbContext ?? (dbContext = new SocGauShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}