

namespace sandwich_api.Services;

// service will talk to repository level and perform business logic
public class SandwichesService
{
  public SandwichesService(SandwichesRepository sandwichesRepository)
  {
    _sandwichesRepository = sandwichesRepository;
  }
  private readonly SandwichesRepository _sandwichesRepository;


  internal List<Sandwich> GetSandwiches()
  {
    List<Sandwich> sandwiches = _sandwichesRepository.GetSandwiches();
    return sandwiches;
  }

  internal Sandwich GetSandwichById(int sandwichId)
  {
    Sandwich sandwich = _sandwichesRepository.GetSandwichById(sandwichId);

    if (sandwich == null)
    {
      throw new Exception($"Invalid id: {sandwichId}");
    }

    return sandwich;
  }

  internal Sandwich CreateSandwich(Sandwich sandwichData)
  {
    Sandwich sandwich = _sandwichesRepository.CreateSandwich(sandwichData);
    return sandwich;
  }
}