using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.IO;

namespace Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            Upload();
            Get();

        }

        private static void Get()
        {
            CloudStorageAccount sta =
                            CloudStorageAccount
                            .Parse(ConfigurationManager.AppSettings["cCon"]);

            CloudBlobClient clientBlob = sta.CreateCloudBlobClient();

            CloudBlobContainer containerBlob = clientBlob
                .GetContainerReference("carros1");

            foreach (var item in containerBlob.ListBlobs(null, false))
            {
                CloudBlockBlob blobBlock = item as CloudBlockBlob;

                string path = @"c:\temp\Download\{0}";

                //blobBlock.DownloadToFile(string.Format(path, blobBlock.Name), FileMode.CreateNew);
            }
        }

        private static void Upload()
        {
            CloudStorageAccount sta =
                            CloudStorageAccount
                            .Parse(ConfigurationManager.AppSettings["cCon"]);

            CloudBlobClient clientBlob = sta.CreateCloudBlobClient();

            CloudBlobContainer containerBlob = clientBlob
                .GetContainerReference("carros1");

            containerBlob.CreateIfNotExists();

            containerBlob.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });



            foreach (var item in Directory.GetFiles(@"c:\Temp\"))
            {
                FileInfo info = new FileInfo(item);

                CloudBlockBlob blockBlob = containerBlob.GetBlockBlobReference(info.Name);

                string url = blockBlob.StorageUri.PrimaryUri.AbsoluteUri;

                blockBlob.Properties.ContentType = info.Extension;

                blockBlob.UploadFromFile(item);

                //using (var fileStream = File.OpenRead(item))
                //{
                //    blockBlob.UploadFromStream(fileStream);
                //}
            }
        }
    }
}
