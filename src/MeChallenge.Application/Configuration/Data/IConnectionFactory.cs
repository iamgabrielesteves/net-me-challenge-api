namespace MeChallenge.Application.Configuration.Data
{
    using System.Data;

    public interface IConnectionFactory
    {
        IDbConnection GetOpenSqlConnection();
    }
}