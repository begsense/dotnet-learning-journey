using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S3_Bucket_Training.Helpers;

namespace S3_Bucket_Training.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly S3Service _s3Service;

    public TestController(S3Service s3Service)
    {
        _s3Service = s3Service;
    }

    [HttpPost("upload-test")]
    public async Task<IActionResult> UploadTest(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }
        
        var imageUrl = await _s3Service.UploadFileAsync(file);

        return Ok(new { Url = imageUrl });
    }
}
