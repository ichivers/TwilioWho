using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Web.Hosting;
using System.Configuration;
using GuessWho.Models;

namespace GuessWho
{
    public partial class Startup 
    {        
        public void SeedAzureStorage()
        {
            Character character = null;
            TableBatchOperation tableBatchOperation = new TableBatchOperation();
            CloudBlockBlob blockBlob = null;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("characters");
            container.CreateIfNotExists();
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("characters");
            table.CreateIfNotExists();

            blockBlob = container.GetBlockBlobReference("sam");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\sam.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Sam",
                Bald = true,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = true,
                HairColour = "White",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("joe");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\joe.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Joe",   
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = true,
                HairColour = "Blonde",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("paul");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\paul.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Paul",             
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = true,
                HairColour = "White",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("george");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\george.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "George",       
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "White",
                Moustache = false ,
                Hat = true
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("philip");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\philip.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Philip",  
                Bald = false,
                Beard = true,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Black",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("claire");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\claire.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Claire", 
                Bald = false,
                Beard = false,
                Gender = (int)Gender.female,
                EyeColour = "Brown",
                Glasses = true,
                HairColour = "Ginger",
                Moustache = false,
                Hat = true
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("anita");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\anita.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Anita",             
                Bald = false,
                Beard = false,
                Gender = (int)Gender.female,
                EyeColour = "Blue",
                Glasses = false,
                HairColour = "Blonde",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("alfred");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\alfred.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Alfred",     
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Blue",
                Glasses = false,
                HairColour = "Ginger",
                Moustache = true,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("susan");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\susan.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Susan", 
                Bald = false,
                Beard = false,
                Gender = (int)Gender.female,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "White",
                Moustache = false,
                Hat = false                
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("richard");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\richard.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Richard",             
                Bald = true,
                Beard = true,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Brown",
                Moustache = true,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("frans");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\frans.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Frans",  
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Ginger",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("max");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\max.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Max",             
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Brown",
                Moustache = true,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("herman");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\herman.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Herman",  
                Bald = true,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Ginger",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("david");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\david.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "David",  
                Bald = false,
                Beard = true,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Blonde",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("bernard");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\bernard.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Bernard",   
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Brown",
                Moustache = false,
                Hat = true
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("alex");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\alex.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Alex",   
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Black",
                Moustache = true,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("tom");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\tom.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Tom",    
                Bald = true,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Blue",
                Glasses = true,
                HairColour = "Black",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("robert");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\robert.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Robert",
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Blue",
                Glasses = false,
                HairColour = "Brown",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("peter");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\peter.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Peter", 
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Blue",
                Glasses = false,
                HairColour = "White",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("maria");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\maria.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Maria",             
                Bald = false,
                Beard = false,
                Gender = (int)Gender.female,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Brown",
                Moustache = false,
                Hat = true
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("bill");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\bill.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Bill",             
                Bald = true,
                Beard = true,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Ginger",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("eric");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\eric.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Eric",   
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Blonde",
                Moustache = false,
                Hat = true
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("charles");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\charles.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character(){
                PartitionKey = "Default",
                RowKey =  "Charles", 
                Bald = false,
                Beard = false,
                Gender = (int)Gender.male,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Blonde",
                Moustache = true,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            blockBlob = container.GetBlockBlobReference("anne");
            blockBlob.Properties.ContentType = "image/png";
            using (var fileStream = System.IO.File.OpenRead(HostingEnvironment.MapPath(@"~\Content\Images\anne.png")))
            {
                blockBlob.UploadFromStream(fileStream);
            } 
            character = new Character()
            {
                PartitionKey = "Default",
                RowKey = "Anne",
                Bald = false,
                Beard = false,
                Gender = (int)Gender.female,
                EyeColour = "Brown",
                Glasses = false,
                HairColour = "Black",
                Moustache = false,
                Hat = false
            };
            tableBatchOperation.InsertOrMerge(character);

            table.ExecuteBatch(tableBatchOperation);
        }
    }
}