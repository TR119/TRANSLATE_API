using Google.Api.Gax.Grpc.Rest;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translate.V3;
using Grpc.Auth;
using Microsoft.AspNetCore.Mvc;
using TRANSLATE_API.Request;
using static Google.Rpc.Context.AttributeContext.Types;

namespace TRANSLATE_API.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class TranslationController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public TranslationController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("translate")]
        public async Task<IActionResult> Get(TranslateRequest request)
        {
            var rootPath = Path.Combine(_environment.ContentRootPath, "AccountServiceJson","serviceAccount.json");
            TranslateService _service = new TranslateService();
            var response = await _service.TranslateText(request, rootPath);
            return Ok(response.Translations[0]);
        }
    }

}
