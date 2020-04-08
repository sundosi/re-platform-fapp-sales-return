using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace re_platform_fapp_sales_return
{
    public static class TableManager
    {
        /// <summary>
        /// test
        /// </summary>
        /// <param name="_CloudTableName"></param>
        /// <param name="status"></param>
        /// <param name="processcode"></param>
        /// <param name="processfilename"></param>
        /// <param name="log"></param>
        /// <returns>sunay testing</returns>
        public static String CreateTable(string connectionstring, string _CloudTableName, string magentorequest
            , string magentoresponse, string sapreuest, string sapresponse, string AWBnumber, string updatedate, string error,
            string status = "", string message = "", string comment = "")
        {


            _CloudTableName = "ReverseLogisticsLog";
            CloudTable cloudTable;
            if (string.IsNullOrEmpty(_CloudTableName))
            {
                throw new ArgumentNullException("Table", "Table Name can't be empty");
            }
            try
            {
                // string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=replatformdev;AccountKey=IOyvWlXPYcJDjiEl3arfYTp6Hc3whpSuCJMRRv5s8yyeSlm3A07UQO3bzozhoVaRhYtCLOT7NmW17yYanKnqKg==;EndpointSuffix=core.windows.net";
                string storageConnectionString = connectionstring;
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                cloudTable = tableClient.GetTableReference(_CloudTableName);
                var result = cloudTable.CreateIfNotExistsAsync().Result;
                LogTable logtable = new LogTable();
                logtable.magentorequest = magentorequest;
                logtable.magentoresponse = magentoresponse;
                logtable.sapreuest = sapreuest;
                logtable.sapresponse = sapresponse;
                logtable.AWBnumber = AWBnumber;
                logtable.insertdate = DateTime.Now.ToString();
                logtable.updatedate = updatedate;
                logtable.status = status;
                logtable.error = error;
                logtable.status = status;
                logtable.message = message;
                logtable.comment = comment;
                string key = Guid.NewGuid().ToString();
                logtable.PartitionKey = key;
                logtable.RowKey = key;
                var insertOperation = TableOperation.Insert(logtable);
                var ss = cloudTable.ExecuteAsync(insertOperation).Result;
                return ss.Result.ToString();
            }
            catch (StorageException StorageExceptionObj)
            {
                throw StorageExceptionObj;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public static String CreateTable(LogTable objlogTable,string connectionstring, string _CloudTableName)
        {


            _CloudTableName = "ReverseLogisticsLog";
            CloudTable cloudTable;
            if (string.IsNullOrEmpty(_CloudTableName))
            {
                throw new ArgumentNullException("Table", "Table Name can't be empty");
            }
            try
            {
                // string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=replatformdev;AccountKey=IOyvWlXPYcJDjiEl3arfYTp6Hc3whpSuCJMRRv5s8yyeSlm3A07UQO3bzozhoVaRhYtCLOT7NmW17yYanKnqKg==;EndpointSuffix=core.windows.net";
                string storageConnectionString = connectionstring;
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                cloudTable = tableClient.GetTableReference(_CloudTableName);
                var result = cloudTable.CreateIfNotExistsAsync().Result;
                LogTable logtable = new LogTable();
                logtable.magentorequest = objlogTable.magentorequest;
                logtable.magentoresponse = objlogTable.magentoresponse;
                logtable.sapreuest = objlogTable.sapreuest;
                logtable.sapresponse = objlogTable.sapresponse;
                logtable.AWBnumber = objlogTable.AWBnumber;
                logtable.insertdate = DateTime.Now.ToString();
               // logtable.updatedate = updatedate;
                logtable.status = objlogTable.status;
                logtable.error = objlogTable.error;
                logtable.status = objlogTable.status;
                logtable.message = objlogTable.message;
                logtable.comment = objlogTable.comment;
               
                logtable.PartitionKey = objlogTable.PartitionKey;
                logtable.RowKey = objlogTable.RowKey;
                var insertOperation = TableOperation.Insert(logtable);
                var ss = cloudTable.ExecuteAsync(insertOperation).Result;
                return ss.Result.ToString();
            }
            catch (StorageException StorageExceptionObj)
            {
                throw StorageExceptionObj;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
        //public static void GetTable(string connectionstring
        //{

        //    string _CloudTableName = "ReverseLogisticsLog";
        //    CloudTable cloudTable;
        //    string storageConnectionString = connectionstring;
        //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
        //    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        //    cloudTable = tableClient.GetTableReference(_CloudTableName);
        //    var result = cloudTable.CreateIfNotExistsAsync().Result;

        //    var insertOperation = TableOperation.Insert(logtable);
        //    var ss = cloudTable.ExecuteAsync(insertOperation).Result;
        //    return ss.Result.ToString();

        //}



    }

    public class LogTable : TableEntity
    {
        public string magentorequest { get; set; }
        public string magentoresponse { get; set; }
        public string sapreuest { get; set; }
        public string sapresponse { get; set; }
        public string AWBnumber { get; set; }
        public string insertdate { get; set; }
        public string updatedate { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public string comment { get; set; }
    }

}
