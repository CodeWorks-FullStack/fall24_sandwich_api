namespace sandwich_api.Controllers;

// data annotations are descriptors for data types in c#
[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // extends BaseController
{
  // constructor
  // Startup.cs will pass a service object through the constructor of this class
  // Do not forget to register any dependencies in Startup.cs
  // Dependency injection
  public SandwichesController(SandwichesService sandwichesService)
  {
    _sandwichesService = sandwichesService;
  }
  private readonly SandwichesService _sandwichesService;


  [HttpGet("test")] // .get('/test', this.testGet)
  public string TestGet()
  {
    return "API is working!";
  }

  // ActionResult type is an HTTP response type
  [HttpGet]
  public ActionResult<List<Sandwich>> GetSandwiches()
  {
    try
    {
      List<Sandwich> sandwiches = _sandwichesService.GetSandwiches();
      return Ok(sandwiches);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }

  }

  [HttpGet("{sandwichId}")] // .get(/:sandwichId, getById)
  public ActionResult<Sandwich> GetSandwichById(int sandwichId) // req.params.sandwichId
  {
    try
    {
      Sandwich sandwich = _sandwichesService.GetSandwichById(sandwichId);
      return Ok(sandwich);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPost]
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
}