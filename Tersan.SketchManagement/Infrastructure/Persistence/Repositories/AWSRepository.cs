using Amazon.S3;
using Amazon.S3.Model;
using Tersan.SketchManagement.Application.Repositories.Abstracts;

namespace Tersan.SketchManagement.Infrastructure.Persistence.Repositories
{
    public class AWSRepository : IAWSRepository
    {
        IAmazonS3 _s3Client;
        public AWSRepository(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task CreateBucketAsync(string bucketName)
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true,
            };

            await _s3Client.PutBucketAsync(putBucketRequest);
        }

        public async Task<bool> IsBucketExistAsync(string bucketName)
        {
            var response = await _s3Client.ListBucketsAsync();
            return response.Buckets.Exists(x => x.BucketName == bucketName);
        }

        public async Task<ListBucketsResponse> GetBucketListAsync()
        {
            var response = await _s3Client.ListBucketsAsync();
            return response;
        }


        public async Task UploadAsync(string bucketName, string keyName, IFormFile file)
        {
            
             var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = keyName,
                InputStream = file.OpenReadStream(),
            };
            request.Metadata.Add("Content-Type", file.ContentType);


            await _s3Client.PutObjectAsync(request);
        }

        public async Task DeleteAsync(string bucketName, string keyName)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            await _s3Client.DeleteObjectAsync(deleteObjectRequest);
        }

        public async Task<Stream> GetAsync(string bucketName, string keyName)
        {
            var getRequest = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = keyName
            };

            var response = await _s3Client.GetObjectAsync(getRequest);
            return response.ResponseStream;
        }
        
        
        


    }

   

        
}
