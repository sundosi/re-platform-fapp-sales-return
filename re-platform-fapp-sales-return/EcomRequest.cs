using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace re_platform_fapp_sales_return
{

    public class Response
    {
        public bool success { get; set; }
        public string msg { get; set; }
     
        public string sap_return_id { get; set; }
        public string awb_no { get; set; }
        public string carrier_name { get; set; }
        public string carrier_code { get; set; }
    }





    public class ADDITIONALINFORMATION
    {
        public object SELLER_TIN { get; set; }
        public object INVOICE_NUMBER { get; set; }
        public object INVOICE_DATE { get; set; }
        public object ESUGAM_NUMBER { get; set; }
        public object ITEM_CATEGORY { get; set; }
        public object PACKING_TYPE { get; set; }
        public object PICKUP_TYPE { get; set; }
        public object RETURN_TYPE { get; set; }
        public string PICKUP_LOCATION_CODE { get; set; }
        public object SELLER_GSTIN { get; set; }
        public object GST_HSN { get; set; }
        public object GST_ERN { get; set; }
        public string GST_TAX_NAME { get; set; }
        public int GST_TAX_BASE { get; set; }
        public double GST_TAX_RATE_CGSTN { get; set; }
        public double GST_TAX_RATE_SGSTN { get; set; }
        public int GST_TAX_RATE_IGSTN { get; set; }
        public int GST_TAX_TOTAL { get; set; }
        public object GST_TAX_CGSTN { get; set; }
        public object GST_TAX_SGSTN { get; set; }
        public object GST_TAX_IGSTN { get; set; }
        public object DISCOUNT { get; set; }
    }

    public class SHIPMENT
    {
        public string AWB_NUMBER { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string PRODUCT { get; set; }
        public string REVPICKUP_NAME { get; set; }
        public string REVPICKUP_ADDRESS1 { get; set; }
        public string REVPICKUP_ADDRESS2 { get; set; }
        public string REVPICKUP_ADDRESS3 { get; set; }
        public string REVPICKUP_CITY { get; set; }
        public string REVPICKUP_PINCODE { get; set; }
        public string REVPICKUP_STATE { get; set; }
        public string REVPICKUP_MOBILE { get; set; }
        public string REVPICKUP_TELEPHONE { get; set; }
        public string PIECES { get; set; }
        public string COLLECTABLE_VALUE { get; set; }
        public string DECLARED_VALUE { get; set; }
        public string ACTUAL_WEIGHT { get; set; }
        public string VOLUMETRIC_WEIGHT { get; set; }
        public string LENGTH { get; set; }
        public string BREADTH { get; set; }
        public string HEIGHT { get; set; }
        public string VENDOR_ID { get; set; }
        public string DROP_NAME { get; set; }
        public string DROP_ADDRESS_LINE1 { get; set; }
        public string DROP_ADDRESS_LINE2 { get; set; }
        public string DROP_PINCODE { get; set; }
        public string DROP_MOBILE { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public string DROP_PHONE { get; set; }
        public string EXTRA_INFORMATION { get; set; }
        public string DG_SHIPMENT { get; set; }
        public ADDITIONALINFORMATION ADDITIONAL_INFORMATION { get; set; }
    }

    public class ECOMEXPRESSOBJECTS
    {
        public SHIPMENT SHIPMENT { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("ECOMEXPRESS-OBJECTS")]
        public ECOMEXPRESSOBJECTS ECOMEXPRESSOBJECTS { get; set; }
}


    public class SapRequest
    {
        public string MAGENTO_UNIQ_NO { get; set; }
        public string MAGENTO_ORDER_NO { get; set; }
        public string SAP_SALE_ORDER_NO { get; set; }
        public string SAP_INVOICE_NO { get; set; }
  
            
    }

    public class SalesReturnRequest
    {


        public string issuccess { get; set; }
        public string ORDER_NUMBER { get; set; }
        public string PRODUCT { get; set; }
        public string REVPICKUP_NAME { get; set; }
        public string REVPICKUP_ADDRESS1 { get; set; }
        public string REVPICKUP_ADDRESS2 { get; set; }
        public string REVPICKUP_ADDRESS3 { get; set; }
        public string REVPICKUP_CITY { get; set; }
        public string REVPICKUP_PINCODE { get; set; }
        public string REVPICKUP_STATE { get; set; }
        public string REVPICKUP_MOBILE { get; set; }
        public string REVPICKUP_TELEPHONE { get; set; }
        public string PIECES { get; set; }
        public string COLLECTABLE_VALUE { get; set; }
        public string DECLARED_VALUE { get; set; }
        public string ACTUAL_WEIGHT { get; set; }
        public string VOLUMETRIC_WEIGHT { get; set; }
        public string LENGTH { get; set; }
        public string BREADTH { get; set; }
        public string HEIGHT { get; set; }
        public string VENDOR_ID { get; set; }
        public string DROP_NAME { get; set; }
        public string DROP_ADDRESS_LINE1 { get; set; }
        public string DROP_ADDRESS_LINE2 { get; set; }
        public string DROP_PINCODE { get; set; }
        public string DROP_MOBILE { get; set; }
        public string ITEM_DESCRIPTION { get; set; }
        public string DROP_PHONE { get; set; }
        public string EXTRA_INFORMATION { get; set; }
        public string DG_SHIPMENT { get; set; }
        public object SELLER_TIN { get; set; }
        public object INVOICE_NUMBER { get; set; }
        public object INVOICE_DATE { get; set; }
        public object ESUGAM_NUMBER { get; set; }
        public object ITEM_CATEGORY { get; set; }
        public object PACKING_TYPE { get; set; }
        public object PICKUP_TYPE { get; set; }
        public object RETURN_TYPE { get; set; }
        public string PICKUP_LOCATION_CODE { get; set; }
        public object SELLER_GSTIN { get; set; }
        public object GST_HSN { get; set; }
        public object GST_ERN { get; set; }
        public string GST_TAX_NAME { get; set; }
        public int GST_TAX_BASE { get; set; }
        public double GST_TAX_RATE_CGSTN { get; set; }
        public double GST_TAX_RATE_SGSTN { get; set; }
        public int GST_TAX_RATE_IGSTN { get; set; }
        public int GST_TAX_TOTAL { get; set; }
        public object GST_TAX_CGSTN { get; set; }
        public object GST_TAX_SGSTN { get; set; }
        public object GST_TAX_IGSTN { get; set; }
        public object DISCOUNT { get; set; }
        public string MAGENTO_UNIQ_NO { get; set; }
        public string MAGENTO_ORDER_NO { get; set; }
        public string SAP_SALE_ORDER_NO { get; set; }
        public string SAP_INVOICE_NO { get; set; }
    }

}
