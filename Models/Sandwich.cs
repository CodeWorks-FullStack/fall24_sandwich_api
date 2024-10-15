namespace sandwich_api.Models;

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