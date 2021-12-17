using System;

namespace NSS.Infrastructure.Providers
{
    public interface IDateTimeProvider
    {
        public DateTime Now();

        public DateTime UtcNow();
    }
}