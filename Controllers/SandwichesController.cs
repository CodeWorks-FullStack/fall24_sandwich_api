namespace sandwich_api.Controllers;

// data annotations are descriptors for data types in c#
[ApiController]
[Route("api/sandwiches")] // super('api/sandwiches')
public class SandwichesController : ControllerBase // extends BaseController
{
  [HttpGet]
  public string TestGet()
  {
    return "API is working!";
  }
}