
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
}