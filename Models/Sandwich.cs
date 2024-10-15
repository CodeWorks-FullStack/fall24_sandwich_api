namespace sandwich_api.Models;

// NOTE model to support data being stored in database. Should have all columns present from the table that you want to send to the client
public class Sandwich
{
  public int Id { get; set; }
  public string Meat { get; set; }
  public string Bread { get; set; }
  public string Name { get; set; }
  public double Price { get; set; }
  public string Cheese { get; set; }
  public bool IsToasted { get; set; }
  public string Condiment { get; set; }
  public int Calories { get; set; }
}