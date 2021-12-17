using System;

namespace NSS.Services.Contract
{
    public interface IDateTimeProvider
    {
        public DateTime Now();

        public DateTime UtcNow();
    }
}