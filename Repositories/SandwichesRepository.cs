
namespace sandwich_api.Repositories;

// NOTE all database logic should take place in the repository level
public class SandwichesRepository
{
  public SandwichesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal List<Sandwich> GetSandwiches()
  {
    string sql = "SELECT * FROM sandwiches;";

    // dbContext.Cars.find()
    List<Sandwich> sandwiches = _db.Query<Sandwich>(sql).ToList();
    return sandwiches;
  }
}