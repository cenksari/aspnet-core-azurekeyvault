namespace aspnet_core_azurekeyvault.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IConfiguration Configuration;

		public ValuesController(IConfiguration configuration) => Configuration = configuration;

		[HttpGet("api/values")]
		public IActionResult Index() => Ok(Configuration["SqlConnectionString"].ToString());
	}
}