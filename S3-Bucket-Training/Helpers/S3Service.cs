using Amazon.S3;
using Amazon.S3.Model;

namespace S3_Bucket_Training.Helpers;

public class S3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;
    private readonly string _region;

    public S3Service(IConfiguration config)
    {
        _bucketName = config["AWS:BucketName"];
        _region = config["AWS:Region"];
        var accessKey = config["AWS:AccessKey"];
        var secretKey = config["AWS:SecretKey"];
        _s3Client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.GetBySystemName(_region));
    }

    public async Task<string> UploadFileAsync(IFormFile file, string folder = "uploads")
    {
        var fileName = $"{folder}/{Guid.NewGuid()}-{Path.GetExtension(file.FileName)}";

        using var stream = file.OpenReadStream();

        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            InputStream = stream,
            ContentType = file.ContentType,
            CannedACL = S3CannedACL.PublicRead
        };

        await _s3Client.PutObjectAsync(request);

        var url = $"https://{_bucketName}.s3.{_region}.amazonaws.com/{fileName}";

        return url;
    }
}
