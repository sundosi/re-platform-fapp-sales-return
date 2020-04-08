using System;
using System.Collections.Generic;
using System.Text;

namespace re_platform_fapp_sales_return
{


    public class AIRWAYBILL
    {
        public string success { get; set; }
        public string order_id { get; set; }
        public string airwaybill_number { get; set; }
    }

    public class AIRWAYBILLOBJECTS
    {
        public AIRWAYBILL AIRWAYBILL { get; set; }
    }

    public class RESPONSEOBJECTS
    {
        public AIRWAYBILLOBJECTS AIRWAYBILL_OBJECTS { get; set; }
        public string RESPONSE_COMMENT { get; set; }
    }

    public class Ecom_Response
    {
        public RESPONSEOBJECTS RESPONSE_OBJECTS { get; set; }
    }




}
