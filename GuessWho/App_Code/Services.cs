using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using GuessWho.Models;
using System.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace GuessWho
{
    public class Services
    {
        public Game Game { get; set; }
        public Character Character { get; set; }
        
        private CloudTable cloudTable(string name)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(name);
            table.CreateIfNotExists();
            return table;
        }

        public void SaveMessage(SmsMessage smsMessage)
        {
            CloudTable table = cloudTable("messages");
            smsMessage.PartitionKey = smsMessage.From;
            smsMessage.RowKey = smsMessage.SmsSid;
            TableOperation insertOperation = TableOperation.InsertOrMerge(smsMessage);
            table.Execute(insertOperation);
        }                

        public void Update()
        {
            CloudTable table = cloudTable("games");            
            TableOperation insertOperation = TableOperation.InsertOrMerge(Game);
            table.Execute(insertOperation);
        }

        public Services(SmsMessage smsMessage)
        {
            if (smsMessage != null)
            {
                CloudTable table = cloudTable("games");
                table.CreateIfNotExists();
                TableQuery<Game> query = new TableQuery<Game>()
                    .Where(TableQuery.CombineFilters(
                        TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, smsMessage.From),
                        "and",
                        TableQuery.GenerateFilterCondition("Status", QueryComparisons.Equal, "Live"))
                    );
                IEnumerable<Game> games = table.ExecuteQuery(query);
                if (games.Count() > 0)
                {
                    Game = games.First();
                    table = cloudTable("characters");
                    TableQuery<Character> characterQuery = new TableQuery<Character>()
                                .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, Game.Character));
                    IEnumerable<Character> characters = table.ExecuteQuery(characterQuery);
                    if (characters.Count() > 0)
                        Character = characters.First();
                }
            }
        }

        public void CreateGame(SmsMessage smsMessage)
        {
            CloudTable table = cloudTable("characters");
            TableQuery<Character> query = new TableQuery<Character>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Default"));
            IEnumerable<Character> characters = table.ExecuteQuery(query);
            var randomCharacter = characters.ElementAt((new Random()).Next(0, characters.Count()));
            table = cloudTable("games");
            Game = new Game()
            {
                PartitionKey = smsMessage.From,
                RowKey = Guid.NewGuid().ToString(),
                Character = randomCharacter.RowKey,
                Turns = 0,
                Status = "Live"
            };
            TableOperation insertOperation = TableOperation.InsertOrMerge(Game);
            table.Execute(insertOperation);            
        }

        public bool gender(Gender gender)
        {
            Game.Turns = Game.Turns + 1;
            return Character.Gender == (int)gender;
        }

        public bool hair(string hair)
        {
            Game.Turns = Game.Turns + 1;
            return Character.HairColour.ToLower().Replace(" ","") == hair.ToLower();
        }

        public bool eyes(string eyes)
        {
            Game.Turns = Game.Turns + 1;
            return Character.EyeColour.ToLower().Replace(" ", "") == eyes.ToLower();
        }

        public bool hat()
        {
            Game.Turns = Game.Turns + 1;
            return Character.Hat;
        }

        public bool beard()
        {
            Game.Turns = Game.Turns + 1;
            return Character.Beard;
        }

        public bool glasses()
        {
            Game.Turns = Game.Turns + 1;
            return Character.Glasses;
        }

        public bool moustache()
        {
            Game.Turns = Game.Turns + 1;            
            return Character.Moustache;
        }

        public bool bald()
        {
            Game.Turns = Game.Turns + 1;
            return Character.Bald;
        }

        public bool guess(string name)
        {
            bool result = Character.RowKey.ToLower().Replace(" ", "") == name.ToLower();            
            Game.Status = result ? "Won" : "Lost";
            return result;
        }               

        public static IEnumerable<Character> characters()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("characters");
            table.CreateIfNotExists();
            IEnumerable<Character> model = new List<Character>();                        
            TableQuery<Character> query = new TableQuery<Character>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Default"));
            return table.ExecuteQuery(query);
        }

        public static CloudBlockBlob characterImage(string name){
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("characters");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(name.ToLower());
            blockBlob.FetchAttributes();
            return blockBlob;
        }
    }
}