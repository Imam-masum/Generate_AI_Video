using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PexelsDotNetSDK.Api;

namespace Ai_V.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AIVController : ControllerBase
    {
        [Route("GenerateAIV")]
        [HttpGet]
        public async Task<IActionResult> GenerateAIV(string promot)
        {
            List<string> ListVideos= new List<string>();
            var pexelsClient = new PexelsClient("6k5MvLXoLzVrKbhUdPpgzM9OFczGkMYIfHoNFLDxSRDXq504aFw6zBku");
            var result=await pexelsClient.SearchVideosAsync(promot);
            List<PexelsDotNetSDK.Models.Video> listvs = new List<PexelsDotNetSDK.Models.Video>();
            listvs=result.videos.ToList();
            foreach (var video in listvs)
            {
                string vedioLin = video.videoFiles.FirstOrDefault().link;
                ListVideos.Add(vedioLin);
            }
            return Ok(ListVideos);
        }
    }
}
