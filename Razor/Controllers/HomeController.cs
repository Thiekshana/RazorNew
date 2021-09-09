using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System.Threading.Tasks;
using System.Text.Json;

namespace Razor.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IViewRenderService _viewRenderService;
        public HomeController(IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }



        //ProjectModel model = new ProjectModel
        //{
        //    Id = 1,
        //    ProjectName = "Project 1",
        //    ProjectNumber = 167843,
        //    ElementName = "Element1",
        //    ElementNumber = 167
        //};

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string content = @"{
          ""Id"": 1,
          ""ProjectNumber"": ""5"",
          ""ProjectName"": ""fdsfjhgjhkre"",
          ""ElementNumber"": 45,
          ""ElementName"":""Element 1""}";
            var options = new JsonSerializerOptions();
            options.Converters.Add(new CustomJsonConverter());
            ProjectModel model = JsonSerializer.Deserialize<ProjectModel>(content, options);
            //Outgoing outgoingModel = new Outgoing(model.Id,model.ProjectNumber,model.ProjectName,model.ElementNumber, model.ElementName);

            //string json = JsonSerializer.Serialize(outgoingModel);

            var result = await _viewRenderService.RenderToStringAsync("Home/Index", model);
            var Renderer = new HtmlToPdf();
            Renderer.RenderHtmlAsPdf(result).SaveAs("test.pdf");
            //var pdf = Renderer.RenderHtmlAsPdf(result);
            //return Content(result);
            return Ok(result);
        }

    }
}
