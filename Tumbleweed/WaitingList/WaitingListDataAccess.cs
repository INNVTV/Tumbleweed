using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tumbleweed.Models;
using Tumbleweed.WaitingList.TableEntities;

namespace Tumbleweed.WaitingList
{
    public class WaitingListDataAccess
    {
        public bool AddToWaitingList(string email)
        {
            
            CloudTableClient cloudTableClient = EnvironmentSettings.AzureCloudStorageAccount.CreateCloudTableClient();

            //Create one table to store entries by alphabetical, and another by time:
            CloudTable table_alpha = cloudTableClient.GetTableReference("waitinglistalphabetical");
            CloudTable table_time = cloudTableClient.GetTableReference("waitinglisttime");
            
            table_alpha.CreateIfNotExists();
            table_time.CreateIfNotExists();

            WaitingListTableEntity_ByAlphabet waitingListEntity_alpha = new WaitingListTableEntity_ByAlphabet(email);
            WaitingListTableEntity_ByTime waitingListEntity_time = new WaitingListTableEntity_ByTime(email);

            TableOperation insertOperation_alpha = TableOperation.Insert(waitingListEntity_alpha);
            TableOperation insertOperation_time = TableOperation.Insert(waitingListEntity_time);

            try
            {
                table_alpha.Execute(insertOperation_alpha);
                table_time.Execute(insertOperation_time);
            }
            catch(Exception e)
            {

            }

            return true;
        }

        public List<WaitingListModel> GetWaitingListAlphabetical()
        {
            List<WaitingListModel> result = new List<WaitingListModel>();

            CloudTableClient cloudTableClient = EnvironmentSettings.AzureCloudStorageAccount.CreateCloudTableClient();
            CloudTable table = cloudTableClient.GetTableReference("waitinglistalphabetical");
            table.CreateIfNotExists();

            TableQuery<WaitingListTableEntity_ByAlphabet> query = new TableQuery<WaitingListTableEntity_ByAlphabet>();

            foreach (WaitingListTableEntity_ByAlphabet entity in table.ExecuteQuery(query))
            {
                WaitingListModel waitingList = new WaitingListModel();
                waitingList.Email = entity.PartitionKey;
                waitingList.SignUpDate = entity.Timestamp.ToLocalTime();

                result.Add(waitingList);
            }
            return result;
        }


        public List<WaitingListModel> GetWaitingListByTime()
        {
            List<WaitingListModel> result = new List<WaitingListModel>();

            CloudTableClient cloudTableClient = EnvironmentSettings.AzureCloudStorageAccount.CreateCloudTableClient();
            CloudTable table = cloudTableClient.GetTableReference("waitinglisttime");
            table.CreateIfNotExists();

            TableQuery<WaitingListTableEntity_ByTime> query = new TableQuery<WaitingListTableEntity_ByTime>();

            foreach (WaitingListTableEntity_ByTime entity in table.ExecuteQuery(query))
            {
                WaitingListModel waitingList = new WaitingListModel();
                waitingList.Email = entity.RowKey;
                waitingList.SignUpDate = entity.Timestamp.ToLocalTime();

                result.Add(waitingList);
            }
            return result;
        }
        


    }
}