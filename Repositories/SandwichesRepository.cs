


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

  internal Sandwich GetSandwichById(int sandwichId)
  {
    string sql = "SELECT * FROM sandwiches WHERE id = @sandwichId";
    //                                                  {sandwichId: 1}
    // Sandwich sandwich = _db.Query<Sandwich>(sql, new { sandwichId = sandwichId }).FirstOrDefault();
    Sandwich sandwich = _db.Query<Sandwich>(sql, new { sandwichId }).FirstOrDefault();
    return sandwich;
  }

  internal Sandwich CreateSandwich(Sandwich sandwichData)
  {
    string sql = @"
    INSERT INTO
    sandwiches (meat, bread, name, price, cheese, isToasted, condiment, calories)
    VALUES(@Meat, @Bread, @Name, @Price, @Cheese, @IsToasted, @Condiment, @Calories);
    
    SELECT * FROM sandwiches WHERE id = LAST_INSERT_ID()";

    Sandwich sandwich = _db.Query<Sandwich>(sql, sandwichData).FirstOrDefault();
    return sandwich;
  }
}