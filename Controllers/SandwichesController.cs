namespace sandwich_api.Controllers;

// data annotations are descriptors for data types in c#
[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // extends BaseController
{
  // constructor
  // Dependency injection 💉
  // Startup.cs will pass a service object through the constructor of this class
  // Do not forget to register any dependencies in Startup.cs
  public SandwichesController(SandwichesService sandwichesService)
  {
    _sandwichesService = sandwichesService;
  }
  // NOTE private denotes that only members of Class have access to this property (cannot directly call sandwichesController._sandwichesService)
  // NOTE readonly makes this property immutable
  private readonly SandwichesService _sandwichesService;


  [HttpGet("test")] // .get('/test', this.testGet)
  public string TestGet()
  {
    return "API is working!";
  }

  // ActionResult type is an HTTP response type
  [HttpGet] // .get('', this.getSandwiches)
  public ActionResult<List<Sandwich>> GetSandwiches()
  {
    try
    {
      List<Sandwich> sandwiches = _sandwichesService.GetSandwiches();
      // NOTE Ok returns a 200 response with the passed argument as the response body
      return Ok(sandwiches);
    }
    catch (Exception error)
    {
      // NOTE BadRequest returns a 400 reponse with the provided error message
      return BadRequest(error.Message);
    }

  }

  [HttpGet("{sandwichId}")] // .get('/:sandwichId', this.getById)
  public ActionResult<Sandwich> GetSandwichById(int sandwichId) // req.params.sandwichId
  {
    try
    {
      Sandwich sandwich = _sandwichesService.GetSandwichById(sandwichId);
      return Ok(sandwich);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPost] // .post('', this.createSandwich)
  public ActionResult<Sandwich> CreateSandwich([FromBody] Sandwich sandwichData) // req.body
  {
    try
    {
      Sandwich sandwich = _sandwichesService.CreateSandwich(sandwichData);
      return Ok(sandwich);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpDelete("{sandwichId}")] // .delete('/:sandwichId', this.deleteSandwich)
  public ActionResult<string> DeleteSandwich(int sandwichId)
  {
    try
    {
      string message = _sandwichesService.DeleteSandwich(sandwichId);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}