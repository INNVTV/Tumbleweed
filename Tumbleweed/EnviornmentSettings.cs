using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace Tumbleweed
{
    public static class EnvironmentSettings
    {
        /// <summary>
        /// The name of the current enviornent
        /// </summary>
        public static class Environment
        {
            public static string Current = ConfigurationManager.AppSettings["Environment"];
        }

        /// <summary>
        /// Azure Storage Account
        /// </summary>
        public static class AzureCloudStorageAccountLogin
        {
            public static string Name = ConfigurationManager.AppSettings["CloudStorage_AccountName"];
            public static string Key = ConfigurationManager.AppSettings["CloudStorage_AccountKey"];
        }

        /// <summary>
        /// Azure Storage Connection String
        /// </summary>
        public static CloudStorageAccount AzureCloudStorageAccount
        {
            get
            {
                CloudStorageAccount _storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + AzureCloudStorageAccountLogin.Name + ";AccountKey=" + AzureCloudStorageAccountLogin.Key);

                return _storageAccount;
            }
        }


    }
}