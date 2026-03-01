using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadImageFromAsp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BucketController : ControllerBase
{
    private readonly IAmazonS3 _s3Client;

    public BucketController(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    [HttpPost("create-bucket")]
    public async Task<IActionResult> CreateBucket(string bucketName)
    {
        try
        {
            var response = await _s3Client.PutBucketAsync(bucketName);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-all-bucket")]
    public async Task<IActionResult> ListBuckets()
    {
        try
        {
            var response = await _s3Client.ListBucketsAsync();
            return Ok(response.Buckets);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete-bucket")]
    public async Task<IActionResult> DeleteBucket(string bucketName)
    {
        try
        {
            var response = await _s3Client.DeleteBucketAsync(bucketName);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(string bucketName, IFormFile file)
    {
        try
        {
            var key = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                var response = await _s3Client.PutObjectAsync(new Amazon.S3.Model.PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    InputStream = stream,
                    ContentType = file.ContentType
                });
                return Ok(response);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}