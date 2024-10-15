
namespace sandwich_api.Repositories;

// NOTE all database logic should take place in the repository level
public class SandwichesRepository
{
  public SandwichesRepository(IDbConnection db)
  {
    _db = db;
  }
  // NOTE allows us to use Dapper (ORM) methods to interact with our database
  private readonly IDbConnection _db;


  internal List<Sandwich> GetSandwiches()
  {
    // NOTE the sql statement that we want to run on our database
    string sql = "SELECT * FROM sandwiches;";

    // dbContext.Cars.find()
    // NOTE Query is the Dapper method that we will use to execute a query on our sql database
    // NOTE Query takes in a type argument. It will cats each row returned from the query into this type  
    // NOTE Query takes in the sql string you want to execute on the database as an argument
    // NOTE ToList converts the IEnumerable returned from Dapper into a List
    List<Sandwich> sandwiches = _db.Query<Sandwich>(sql).ToList();
    return sandwiches;
  }

  internal Sandwich GetSandwichById(int sandwichId)
  {
    // NOTE the @ sign signifies that Dapper will be passed an object with a matching key of sandwichId. Dapper will pull the value out at this key and SAFELY insert it into the SQL statement for us.
    string sql = "SELECT * FROM sandwiches WHERE id = @sandwichId;";

    // NOTE new {} creates an anonymous object (object with any type).
    // NOTE new {sandwichId} creates an object structured like: { sandwichId: 7 }
    // NOTE FirstOrDefault returns the first element from a collection or null if no elements are present
    Sandwich sandwich = _db.Query<Sandwich>(sql, new { sandwichId }).FirstOrDefault();
    return sandwich;
  }

  internal Sandwich CreateSandwich(Sandwich sandwichData)
  {
    // NOTE Dapper will pull all of the values out of our sandwichData object and parameterize them for us.
    // NOTE after the insert, we select the newly created Sandwich out of the database
    // NOTE Dapper is capable of running multiple SQL statements
    string sql = @"
    INSERT INTO
    sandwiches (meat, bread, name, price, cheese, isToasted, condiment, calories)
    VALUES(@Meat, @Bread, @Name, @Price, @Cheese, @IsToasted, @Condiment, @Calories);
    
    SELECT * FROM sandwiches WHERE id = LAST_INSERT_ID()";

    Sandwich sandwich = _db.Query<Sandwich>(sql, sandwichData).FirstOrDefault();
    return sandwich;
  }

  internal void DeleteSandwich(int sandwichId)
  {
    string sql = "DELETE FROM sandwiches WHERE id = @sandwichId LIMIT 1;";

    int affectedRows = _db.Execute(sql, new { sandwichId });

    if (affectedRows == 0)
    {
      throw new Exception("No sandwiches were deleted, delete failed");
    }

    if (affectedRows > 1)
    {
      throw new Exception("More than one sandwich was deleted, that is not good");
    }
  }
}