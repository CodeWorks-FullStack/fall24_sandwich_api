namespace sandwich_api.Controllers;

// data annotations are descriptors for data types in c#
[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // extends BaseController
{
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
      List<Sandwich> sandwiches = [];
      return Ok(sandwiches);
    }
    catch (System.Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}