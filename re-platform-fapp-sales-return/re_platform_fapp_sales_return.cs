using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace re_platform_fapp_sales_return
{
    public static class re_platform_fapp_sales_return
    {

        public static string mysqlconnectionstring { get; set; }


        [FunctionName("salesreturn")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            mysqlconnectionstring = Environment.GetEnvironmentVariable("mysqlconnectionstring");

            string name = req.Query["name"];

            string res = string.Empty;
            //SAP_POST_SalesReturn();

            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                string connectionstring = Environment.GetEnvironmentVariable("connectionstring");

                LogTable logTable = new LogTable();
                TableManager.CreateTable(connectionstring, "", requestBody, "", "", "", "", "", "", "", "", "");
                TableManager.CreateTable(connectionstring, "", requestBody, "", "", "", "", "", "", "", "", "");
                var salesreturnrequestobj = JsonConvert.DeserializeObject<SalesReturnRequest>(requestBody);
                log.LogInformation("get awb number.");
                //fetch awb from mysql
                string waybillid;
                string awbnumber;
                GetAWBnumber(out waybillid, out awbnumber);
                log.LogInformation("after - get awb number.");
                SapRequest saprequest = new SapRequest();
                // sap request param
                saprequest.MAGENTO_ORDER_NO = salesreturnrequestobj.MAGENTO_ORDER_NO;
                saprequest.MAGENTO_UNIQ_NO = salesreturnrequestobj.MAGENTO_UNIQ_NO;
                saprequest.SAP_INVOICE_NO = salesreturnrequestobj.SAP_INVOICE_NO;
                saprequest.SAP_SALE_ORDER_NO = salesreturnrequestobj.SAP_SALE_ORDER_NO;
                
                
                
                // End sap request param
                //ECOM request param
                RootObject rootobj = new RootObject();
                ECOMEXPRESSOBJECTS ECOMEXPRESSOBJECTS = new ECOMEXPRESSOBJECTS();
                SHIPMENT SHIPMENT = new SHIPMENT();
                ADDITIONALINFORMATION ADDITIONALINFORMATION = new ADDITIONALINFORMATION();
                rootobj.ECOMEXPRESSOBJECTS = ECOMEXPRESSOBJECTS;
                ECOMEXPRESSOBJECTS.SHIPMENT = SHIPMENT;




                ADDITIONALINFORMATION.SELLER_TIN = salesreturnrequestobj.SELLER_TIN;
                ADDITIONALINFORMATION.INVOICE_NUMBER = salesreturnrequestobj.INVOICE_NUMBER;
                ADDITIONALINFORMATION.INVOICE_DATE = salesreturnrequestobj.INVOICE_DATE;
                ADDITIONALINFORMATION.ESUGAM_NUMBER = salesreturnrequestobj.ESUGAM_NUMBER;
                ADDITIONALINFORMATION.ITEM_CATEGORY = salesreturnrequestobj.ITEM_CATEGORY;
                ADDITIONALINFORMATION.PACKING_TYPE = salesreturnrequestobj.PACKING_TYPE;
                ADDITIONALINFORMATION.PICKUP_TYPE = salesreturnrequestobj.PICKUP_TYPE;
                ADDITIONALINFORMATION.RETURN_TYPE = salesreturnrequestobj.RETURN_TYPE;
                ADDITIONALINFORMATION.PICKUP_LOCATION_CODE = salesreturnrequestobj.PICKUP_LOCATION_CODE;
                ADDITIONALINFORMATION.SELLER_GSTIN = salesreturnrequestobj.SELLER_GSTIN;
                ADDITIONALINFORMATION.GST_HSN = salesreturnrequestobj.GST_HSN;
                ADDITIONALINFORMATION.GST_ERN = salesreturnrequestobj.GST_ERN;
                ADDITIONALINFORMATION.GST_TAX_NAME = salesreturnrequestobj.GST_TAX_NAME;
                ADDITIONALINFORMATION.GST_TAX_BASE = salesreturnrequestobj.GST_TAX_BASE;
                ADDITIONALINFORMATION.GST_TAX_RATE_CGSTN = salesreturnrequestobj.GST_TAX_RATE_CGSTN;
                ADDITIONALINFORMATION.GST_TAX_RATE_SGSTN = salesreturnrequestobj.GST_TAX_RATE_SGSTN;
                ADDITIONALINFORMATION.GST_TAX_RATE_IGSTN = salesreturnrequestobj.GST_TAX_RATE_IGSTN;
                ADDITIONALINFORMATION.GST_TAX_TOTAL = salesreturnrequestobj.GST_TAX_TOTAL;
                ADDITIONALINFORMATION.GST_TAX_CGSTN = salesreturnrequestobj.GST_TAX_CGSTN;
                ADDITIONALINFORMATION.GST_TAX_SGSTN = salesreturnrequestobj.GST_TAX_SGSTN;
                ADDITIONALINFORMATION.GST_TAX_IGSTN = salesreturnrequestobj.GST_TAX_IGSTN;
                ADDITIONALINFORMATION.DISCOUNT = salesreturnrequestobj.DISCOUNT;



                SHIPMENT.AWB_NUMBER = awbnumber;
                SHIPMENT.ORDER_NUMBER = salesreturnrequestobj.ORDER_NUMBER;
                SHIPMENT.PRODUCT = salesreturnrequestobj.PRODUCT;
                SHIPMENT.REVPICKUP_NAME = salesreturnrequestobj.REVPICKUP_NAME;
                SHIPMENT.REVPICKUP_ADDRESS1 = salesreturnrequestobj.REVPICKUP_ADDRESS1;
                SHIPMENT.REVPICKUP_ADDRESS2 = salesreturnrequestobj.REVPICKUP_ADDRESS2;
                SHIPMENT.REVPICKUP_ADDRESS3 = salesreturnrequestobj.REVPICKUP_ADDRESS3;
                SHIPMENT.REVPICKUP_CITY = salesreturnrequestobj.REVPICKUP_CITY;
                SHIPMENT.REVPICKUP_PINCODE = salesreturnrequestobj.REVPICKUP_PINCODE;
                SHIPMENT.REVPICKUP_STATE = salesreturnrequestobj.REVPICKUP_STATE;
                SHIPMENT.REVPICKUP_MOBILE = salesreturnrequestobj.REVPICKUP_MOBILE;
                SHIPMENT.REVPICKUP_TELEPHONE = salesreturnrequestobj.REVPICKUP_TELEPHONE;
                SHIPMENT.PIECES = salesreturnrequestobj.PIECES;
                SHIPMENT.COLLECTABLE_VALUE = salesreturnrequestobj.COLLECTABLE_VALUE;
                SHIPMENT.DECLARED_VALUE = salesreturnrequestobj.DECLARED_VALUE;
                SHIPMENT.ACTUAL_WEIGHT = salesreturnrequestobj.ACTUAL_WEIGHT;
                SHIPMENT.VOLUMETRIC_WEIGHT = salesreturnrequestobj.VOLUMETRIC_WEIGHT;
                SHIPMENT.LENGTH = salesreturnrequestobj.LENGTH;
                SHIPMENT.BREADTH = salesreturnrequestobj.BREADTH;
                SHIPMENT.HEIGHT = salesreturnrequestobj.HEIGHT;
                SHIPMENT.VENDOR_ID = salesreturnrequestobj.VENDOR_ID;
                SHIPMENT.DROP_NAME = salesreturnrequestobj.DROP_NAME;
                SHIPMENT.DROP_ADDRESS_LINE1 = salesreturnrequestobj.DROP_ADDRESS_LINE1;
                SHIPMENT.DROP_ADDRESS_LINE2 = salesreturnrequestobj.DROP_ADDRESS_LINE2;
                SHIPMENT.DROP_PINCODE = salesreturnrequestobj.DROP_PINCODE;
                SHIPMENT.DROP_MOBILE = salesreturnrequestobj.DROP_MOBILE;
                SHIPMENT.ITEM_DESCRIPTION = salesreturnrequestobj.ITEM_DESCRIPTION;
                SHIPMENT.DROP_PHONE = salesreturnrequestobj.DROP_PHONE;
                SHIPMENT.EXTRA_INFORMATION = salesreturnrequestobj.EXTRA_INFORMATION;
                SHIPMENT.DG_SHIPMENT = salesreturnrequestobj.DG_SHIPMENT;

                //ECOM request param
                log.LogInformation("sap post sales return.");
                SAP_POST_SalesReturn(saprequest);
                log.LogInformation("after sap post sales return.");
                log.LogInformation("ECOM_POST_ReverseManifest.");
                res = ECOM_POST_ReverseManifest(rootobj);
                log.LogInformation(" after ECOM_POST_ReverseManifest.");
                log.LogInformation(" update my sql isstatus.");
                updateawbstatus(waybillid);
                log.LogInformation(" after update my sql isstatus.");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

            return res != null
                ? (ActionResult)new OkObjectResult(JsonConvert.SerializeObject(res))
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }


        public static void GetAWBnumber(out string waybillid, out string awbnumber)
        {
            waybillid = string.Empty;
            awbnumber = string.Empty;
            var tbawbnumber = GetPreAllocatedAWB();

            if (tbawbnumber.Rows.Count < 6)
            {

                ECOM_GET_AWB();

                var tbawbnumbernew = GetPreAllocatedAWB();

                if (tbawbnumbernew.Rows.Count < 6)
                {
                    string result = "error in fetching awb number";
                }
                else
                {
                    awbnumber = tbawbnumbernew.Rows[0]["awbnumber"].ToString();
                    waybillid = tbawbnumbernew.Rows[0]["waybillid"].ToString();

                }

            }
            else if (tbawbnumber.Rows.Count >= 6)
            {
                awbnumber = tbawbnumber.Rows[0]["awbnumber"].ToString();
                waybillid = tbawbnumber.Rows[0]["waybillid"].ToString();

            }

        }

        public static void updateawbstatus(string waybillid)
        {
            //string connetionString = Environment.GetEnvironmentVariable("mysqlconnectionstring");

            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(mysqlconnectionstring);
                connection.Close();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "update waybillnumber set isused=@isused, updatedate =@updatedate where waybillid = @waybillid";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@waybillid", waybillid);
                cmd.Parameters.AddWithValue("@isused", "1");
                cmd.Parameters.AddWithValue("@updatedate", DateTime.Now);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }

        }

        public static bool SAP_POST_SalesReturn(SapRequest sapRequest)
        {

            var sss = new StringBuilder("<?xml version='1.0' encoding='UTF-8'?>");
            sss.Append("<ZBAPI_MGN_SALES_RETURN xmlns='http://Microsoft.LobServices.Sap/2007/03/Rfc/'><IT_TABLE1><ZSTR_MGN_SALES_RETURN_IT xmlns='http://Microsoft.LobServices.Sap/2007/03/Types/Rfc/'><MAGENTO_UNIQ_NO>" + sapRequest.MAGENTO_UNIQ_NO + "</MAGENTO_UNIQ_NO><MAGENTO_ORDER_NO>" + sapRequest.MAGENTO_ORDER_NO + "</MAGENTO_ORDER_NO><SAP_SALE_ORDER_NO>" + sapRequest.SAP_SALE_ORDER_NO + "</SAP_SALE_ORDER_NO><SAP_INVOICE_NO>" + sapRequest.SAP_INVOICE_NO + "</SAP_INVOICE_NO></ZSTR_MGN_SALES_RETURN_IT></IT_TABLE1></ZBAPI_MGN_SALES_RETURN>");


            var lapp_salesreturnurl = Environment.GetEnvironmentVariable("lapp_salesreturnurl");

            var content = new StringContent(sss.ToString());

            using (var client = new HttpClient())
            {


                var result = client.PostAsync(lapp_salesreturnurl, content).Result;

                return result.IsSuccessStatusCode ? true : false;

            }
        }

        public static string ECOM_POST_ReverseManifest(RootObject rootObject)
        {

            var ECOM_Reversemenifesturl = Environment.GetEnvironmentVariable("ECOM_Reversemenifesturl");

            var jsonserialize = JsonConvert.SerializeObject(rootObject);

            string ecomapiusername = Environment.GetEnvironmentVariable("ecomapiusername");
            string ecomapipassword = Environment.GetEnvironmentVariable("ecomapipassword");
            using (var client = new HttpClient())
            {
                var formContent = new MultipartFormDataContent
    {

        {new StringContent(System.Net.WebUtility.UrlEncode(ecomapiusername)),"username"},
        {new StringContent(System.Net.WebUtility.UrlEncode(ecomapipassword)),"password" },
         {new StringContent(jsonserialize),"json_input" }

    };
                var result = client.PostAsync(ECOM_Reversemenifesturl, formContent).Result;

                return result.Content.ReadAsStringAsync().Result;
            }
        }

        public static DataTable GetPreAllocatedAWB()
        {

            // string mysqlconnectionstring = Environment.GetEnvironmentVariable("mysqlconnectionstring");
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection connection = new MySqlConnection(mysqlconnectionstring);
            connection.Close();
            connection.Open();
            var command = connection.CreateCommand();

            command.CommandText = "SELECT *,DATEDIFF(CURDATE(),insertdate) FROM waybillnumber WHERE isused = 0 AND DATEDIFF(CURDATE(),insertdate) < 90";
            var reader = command.ExecuteNonQuery();

            DataTable _dataTable = new DataTable();

            var _da = new MySqlDataAdapter(command);
            _da.Fill(_dataTable);

            return _dataTable;

        }

        public static async void ECOM_GET_AWB()
        {
            MySqlConnection connection = null;
            string awbnumber = string.Empty;
            DateTime insertdate = DateTime.Now;
            DateTime updatedate = DateTime.Now;
            string ecomapiusername = Environment.GetEnvironmentVariable("ecomapiusername");
            string ecomapipassword = Environment.GetEnvironmentVariable("ecomapipassword");
            string count = Environment.GetEnvironmentVariable("count");
            string fetchawburl = Environment.GetEnvironmentVariable("fetchawburl");
            try
            {
                using (var client = new HttpClient())
                {

                    var formContent = new MultipartFormDataContent
    {

        {new StringContent(System.Net.WebUtility.UrlEncode(ecomapiusername)),"username"},
        {new StringContent(System.Net.WebUtility.UrlEncode(ecomapipassword)),"password" },
         {new StringContent(count),"count" },
          {new StringContent("rev"),"type" },

    };

                    var result = client.PostAsync(fetchawburl, formContent).Result;
                    MySqlCommand cmd = new MySqlCommand();
                    var resultContent = await result.Content.ReadAsAsync<waybillresponse>();
                    List<string> Rows = new List<string>();
                    string currentdate = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
                    StringBuilder sCommand = new StringBuilder("INSERT INTO waybillnumber(awbnumber, isused, insertdate, updatedate, isdeleted,reference_id) VALUES ");
                    for (int i = 0; i < resultContent.awb.Count; i++)
                    {
                        Rows.Add(string.Format("('{0}','{1}','{2}','{3}','{4}','{5}')", MySqlHelper.EscapeString(resultContent.awb[i].ToString()), MySqlHelper.EscapeString("0"), MySqlHelper.EscapeString(currentdate), MySqlHelper.EscapeString(currentdate), MySqlHelper.EscapeString("0"), MySqlHelper.EscapeString(resultContent.reference_id.ToString())));
                    }
                    sCommand.Append(string.Join(",", Rows));
                    sCommand.Append(";");
                    connection = new MySqlConnection(mysqlconnectionstring);
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = sCommand.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }


    public class waybillresponse
    {
        public int reference_id { get; set; }
        public string success { get; set; }
        public List<int> awb { get; set; }
    }
}
