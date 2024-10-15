namespace sandwich_api.Controllers;

// data annotations are descriptors for data types in c#
[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // extends BaseController
{
  // constructor
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
}