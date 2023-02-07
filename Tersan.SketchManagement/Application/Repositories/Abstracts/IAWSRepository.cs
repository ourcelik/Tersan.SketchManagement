using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace Tersan.SketchManagement.Application.Repositories.Abstracts
{
    public interface IAWSRepository
    {
        public Task CreateBucketAsync(string bucketName);
        public Task<bool> IsBucketExistAsync(string bucketName);
        public Task<ListBucketsResponse> GetBucketListAsync();

        public Task UploadAsync(string bucketName, string keyName, IFormFile file);

        public Task DeleteAsync(string bucketName, string keyName);

        public Task<Stream> GetAsync(string bucketName, string keyName);
    }
}