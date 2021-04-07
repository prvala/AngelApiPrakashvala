using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace smartapi_dotnet
{
    #region Constants

    public class Constants
    {

        // Products
        public const string PRODUCT_MIS = "MIS";
        public const string PRODUCT_CNC = "CNC";
        public const string PRODUCT_NRML = "NRML";

        public const string PRODUCT_TYPE_DELIVERY = "DELIVERY";
        public const string PRODUCT_TYPE_MARGIN = "MARGIN";
        public const string PRODUCT_TYPE_INTRADAY = "INTRADAY";
        public const string PRODUCT_TYPE_BO = "BO";
        // Order types
        public const string ORDER_TYPE_MARKET = "MARKET";
        public const string ORDER_TYPE_LIMIT = "LIMIT";
        public const string ORDER_TYPE_SLM = "SL-M";
        public const string ORDER_TYPE_SL = "SL";

        // Order status
        public const string ORDER_STATUS_COMPLETE = "COMPLETE";
        public const string ORDER_STATUS_CANCELLED = "CANCELLED";
        public const string ORDER_STATUS_REJECTED = "REJECTED";

        // Varities
        public const string VARIETY_NORMAL = "NORMAL";
        public const string VARIETY_STOPLOSS = "STOPLOSS";
        public const string VARIETY_ROBO= "ROBO";
        public const string VARIETY_AMO = "amo";

        // Transaction type
        public const string TRANSACTION_TYPE_BUY = "BUY";
        public const string TRANSACTION_TYPE_SELL = "SELL";

        // Validity
        public const string VALIDITY_DAY = "DAY";
        public const string VALIDITY_IOC = "IOC";

        // Exchanges
        public const string EXCHANGE_NSE = "NSE";
        public const string EXCHANGE_BSE = "BSE";
        public const string EXCHANGE_NFO = "NFO";
        public const string EXCHANGE_CDS = "CDS";
        public const string EXCHANGE_BFO = "BFO";
        public const string EXCHANGE_MCX = "MCX";

        // Margins segments
        public const string MARGIN_EQUITY = "equity";
        public const string MARGIN_COMMODITY = "commodity";

        // Ticker modes
        public const string MODE_FULL = "full";
        public const string MODE_QUOTE = "quote";
        public const string MODE_LTP = "ltp";

        // Positions
        public const string POSITION_DAY = "day";
        public const string POSITION_OVERNIGHT = "overnight";

        // Historical intervals
        public const string INTERVAL_MINUTE = "minute";
        public const string INTERVAL_3MINUTE = "3minute";
        public const string INTERVAL_5MINUTE = "5minute";
        public const string INTERVAL_10MINUTE = "10minute";
        public const string INTERVAL_15MINUTE = "15minute";
        public const string INTERVAL_30MINUTE = "30minute";
        public const string INTERVAL_60MINUTE = "60minute";
        public const string INTERVAL_DAY = "day";

        // GTT status
        public const string GTT_ACTIVE = "active";
        public const string GTT_TRIGGERED = "triggered";
        public const string GTT_DISABLED = "disabled";
        public const string GTT_EXPIRED = "expired";
        public const string GTT_CANCELLED = "cancelled";
        public const string GTT_REJECTED = "rejected";
        public const string GTT_DELETED = "deleted";


        // GTT trigger type
        public const string GTT_TRIGGER_OCO = "two-leg";
        public const string GTT_TRIGGER_SINGLE = "single";
    }
    //public enum ProductTypes
    //{
    //    MIS,
    //    CNC,
    //    NRML
    //}    
    //public enum ProductDelivery
    //{
    //    DELIVERY,
    //    INTRADAY
    //}
    //public enum OrderTypes
    //{
    //    MARKET,
    //    LIMIT,
    //    SL,
    //    SLM
    //}
    //public enum VarietyTypes
    //{
    //    NORMAL,
    //    BO,
    //    CO,
    //    AMO
    //}
    //public enum TransactionTypes
    //{
    //    Buy,
    //    Sell
    //}
    //public enum PositionTypes
    //{
    //    Day,
    //    Overnight
    //}
    //public enum Exchanges
    //{
    //    NSE,
    //    BSE,
    //    NFO,
    //    CDS,
    //    MCX
    //}
    //public enum Segments
    //{
    //    Equity,
    //    Commodity,
    //    Futures,
    //    Currency
    //}
    //public enum GTTStatus
    //{
    //    active,
    //    triggered,
    //    disabled,
    //    expired,
    //    cancelled,
    //    rejected,
    //    deleted
    //}
    //public enum GTTTriggerType
    //{
    //    twoleg,
    //    single
    //}
    //public enum TickerModes
    //{
    //    Full,
    //    Quote,
    //    LTP
    //}
    //public enum ValidityTypes
    //{
    //    DAY,
    //    IOC,
    //    AMO
    //}
    //public enum CandleIntervals
    //{
    //    Minute,
    //    ThreeMinute,
    //    FiveMinute,
    //    TenMinute,
    //    FifteenMinute,
    //    ThirtyMinute,
    //    SixtyMinute,
    //    Day
    //}
    //public enum SIPFrequency
    //{
    //    Weekly,
    //    Monthly,
    //    Quarterly
    //}
    //public enum SIPStatus
    //{
    //    Active,
    //    Paused
    //}


    #endregion

    #region  AngelBrokingModel
    public class AngelToken
    {
        public string jwtToken { get; set; }
        public string refreshToken { get; set; }
        public string feedToken { get; set; }
    }
    public class AngelTokenResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string errorcode { get; set; }
        public AngelToken data { get; set; }
    }

    public class OutputBaseClass
    {
        public bool status { get; set; }
        public Int32 http_code { get; set; }
        public string http_error { get; set; }
        public object response_data { get; set; }

    }


    public class OrderInfo
    {
        public string orderid { get; set; }
        public string variety { get; set; }
        public string tradingsymbol { get; set; }
        public string symboltoken { get; set; }
        public string transactiontype { get; set; }
        public string exchange { get; set; }
        public string ordertype { get; set; }
        public string producttype { get; set; }
        public string duration { get; set; }
        public string price { get; set; }
        public string squareoff { get; set; }
        public string stoploss { get; set; }
        public string quantity { get; set; }
    }

    public class ConvertPositionRequest
    {
        public string exchange { get; set; }
        public string oldproducttype { get; set; }
        public string newproducttype { get; set; }
        public string tradingsymbol { get; set; }
        public string transactiontype { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        //public string symboltoken { get; set; }
        //public string producttype { get; set; }
        //public string symbolname { get; set; }
        //public string instrumenttype { get; set; }
        //public string priceden { get; set; }
        //public string pricenum { get; set; }
        //public string genden { get; set; }
        //public string gennum { get; set; }
        //public string precision { get; set; }
        //public string multiplier { get; set; }
        //public string boardlotsize { get; set; }
        //public string buyqty { get; set; }
        //public string sellqty { get; set; }
        //public string buyamount { get; set; }
        //public string sellamount { get; set; }
    }

    public class CreateRuleRequest
    {
        public string id { get; set; }
        public string tradingsymbol { get; set; }
        public string symboltoken { get; set; }
        public string exchange { get; set; }
        public string transactiontype { get; set; }
        public string producttype { get; set; }
        public string price { get; set; }
        public string qty { get; set; }
        public string triggerprice { get; set; }
        public string disclosedqty { get; set; }
        public string timeperiod { get; set; }
    }
    public class CancelRuleRequest
    {
        public string id { get; set; }
        public string symboltoken { get; set; }
        public string exchange { get; set; }
    }
    public class RuleListRequest
    {
        public List<string> status { get; set; }
        public int page { get; set; }
        public int count { get; set; }
    }

    public class CandleRequest
    {
        public string symboltoken { get; set; }
        public string exchange { get; set; }
        public string interval { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
    #endregion

    public class AngelBroking
    {
        protected string APIURL = "", USER = "", SourceID = "", ClientLocalIP = "", ClientPublicIP = "", MACAddress = "", PrivateKey = "";

        public AngelBroking(string URL, string U, string S, string CL, string CP, string MA, string PK)
        {
            APIURL = URL;
            USER = U;
            SourceID = S;
            ClientLocalIP = CL;
            ClientPublicIP = CP;
            MACAddress = MA;
            PrivateKey = PK;
        }

        public string POSTWebRequest(AngelToken agr, string URL, string Data)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                HttpWebRequest httpWebRequest = null;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                if (agr != null)
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + agr.jwtToken);
                //httpWebRequest = addHeaders(httpWebRequest);
                httpWebRequest.Headers.Add("X-Content-Type-Options", "nosniff");
                httpWebRequest.Headers.Add("X-UserType", USER);
                httpWebRequest.Headers.Add("X-SourceID", SourceID);
                httpWebRequest.Headers.Add("X-ClientLocalIP", ClientLocalIP);
                httpWebRequest.Headers.Add("X-ClientPublicIP", ClientPublicIP);
                httpWebRequest.Headers.Add("X-MACAddress", MACAddress);
                httpWebRequest.Headers.Add("X-PrivateKey", PrivateKey);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";

                byte[] byteArray = Encoding.UTF8.GetBytes(Data);
                httpWebRequest.ContentLength = byteArray.Length;
                string Json = "";

                Stream dataStream = httpWebRequest.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                WebResponse response = httpWebRequest.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    Json = reader.ReadToEnd();
                }
                return Json;
            }
            catch (Exception ex)
            {
                return "PostError:" + ex.Message;
            }
        }
        public string GETWebRequest(AngelToken agr, string URL)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                HttpWebRequest httpWebRequest = null;
                httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
                if (agr != null)
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + agr.jwtToken);
                //httpWebRequest = addHeaders(httpWebRequest);
                httpWebRequest.Headers.Add("X-Content-Type-Options", "nosniff");
                httpWebRequest.Headers.Add("X-UserType", USER);
                httpWebRequest.Headers.Add("X-SourceID", SourceID);
                httpWebRequest.Headers.Add("X-ClientLocalIP", ClientLocalIP);
                httpWebRequest.Headers.Add("X-ClientPublicIP", ClientPublicIP);
                httpWebRequest.Headers.Add("X-MACAddress", MACAddress);
                httpWebRequest.Headers.Add("X-PrivateKey", PrivateKey);
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = "application/json";

                string Json = "";
                WebResponse response = httpWebRequest.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (Stream dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    Json = reader.ReadToEnd();
                }
                return Json;
            }
            catch (Exception ex)
            {
                return "GetError:" + ex.Message;
            }
        }
        private bool ValidateToken(AngelToken token)
        {
            bool result = false;
            if (token != null)
            {
                if (token.jwtToken != "" && token.refreshToken != "")
                {
                    result = true;
                }
            }
            else
                result = false;

            return result;
        }

        public OutputBaseClass GenerateSession(string clientcode, string password)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                AngelTokenResponse agr = new AngelTokenResponse();

                string URL = APIURL + "/rest/auth/angelbroking/user/v1/loginByPassword";

                string PostData = "{\"clientcode\":\"" + clientcode + "\",\"password\":\"" + password + "\"}";

                string json = POSTWebRequest(null, URL, PostData);
                if (!json.Contains("PostError:"))
                {
                    agr = JsonConvert.DeserializeObject<AngelTokenResponse>(json);
                    res.response_data = agr;
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = json.Replace("PostError:", "");
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass GenerateToken(AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            AngelTokenResponse restoken = new AngelTokenResponse();
            try
            {
                if (Token != null)
                {                    
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/auth/angelbroking/jwt/v1/generateTokens";

                        string PostData = "{\"refreshToken\":\"" + Token.refreshToken + "\"}";

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            restoken = JsonConvert.DeserializeObject<AngelTokenResponse>(json);
                            res.response_data = restoken;
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass GetProfile(AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/user/v1/getProfile";

                        string json = GETWebRequest(Token, URL);
                        if (!json.Contains("GetError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("GetError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass LogOut(string clientcode, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {                    
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/user/v1/logout";

                        string PostData = "{\"clientcode\":\"" + clientcode + "\"}";

                        string Json = POSTWebRequest(Token, URL, PostData);
                        if (!Json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }

        public OutputBaseClass placeOrder(OrderInfo order, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {                   
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/placeOrder";

                        string PostData = JsonConvert.SerializeObject(order);

                        string Json = POSTWebRequest(Token, URL, PostData);
                        if (!Json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;

        }
        public OutputBaseClass modifyOrder(OrderInfo order, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/modifyOrder";

                        string PostData = JsonConvert.SerializeObject(order);

                        string Json = POSTWebRequest(Token, URL, PostData);
                        if (!Json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass cancelOrder(OrderInfo order, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/cancelOrder";

                        string PostData = "{\"variety\":\"" + order.variety + "\",\"orderid\":\"" + order.orderid + "\"}";

                        string Json = POSTWebRequest(Token, URL, PostData);
                        if (!Json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }

        public OutputBaseClass getOrderBook(AngelToken Token)
        {

            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/getOrderBook";

                        string Json = GETWebRequest(Token, URL);
                        if (!Json.Contains("GetError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("GetError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;

        }
        public OutputBaseClass getTradeBook(AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/getTradeBook";


                        string Json = GETWebRequest(Token, URL);
                        if (!Json.Contains("GetError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("GetError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass getHolding(AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                  
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/portfolio/v1/getHolding";

                        string Json = GETWebRequest(Token, URL);
                        if (!Json.Contains("GetError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("GetError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass getPosition(AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                  
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/getPosition";

                        string Json = GETWebRequest(Token, URL);
                        if (!Json.Contains("GetError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("GetError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass getRMS(AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/user/v1/getRMS";

                        string Json = GETWebRequest(Token, URL);
                        if (!Json.Contains("GetError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(Json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = Json.Replace("GetError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass convertPosition(ConvertPositionRequest Request, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/order/v1/convertPosition";

                        string PostData = JsonConvert.SerializeObject(Request);

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        /* Create GTT Rule*/
        public OutputBaseClass CreateRule(CreateRuleRequest ruleRequest, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/gtt/v1/createRule";

                        string PostData = JsonConvert.SerializeObject(ruleRequest);

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass modifyRule(CreateRuleRequest ruleRequest, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/gtt/v1/modifyRule";

                        string PostData = JsonConvert.SerializeObject(ruleRequest);

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass cancelRule(CancelRuleRequest ruleRequest, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/gtt/v1/cancelRule";

                        string PostData = JsonConvert.SerializeObject(ruleRequest);

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass ruleDetails(string RuleID, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            
            try
            {
                if (Token != null)
                {
                  
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/gtt/v1/ruleDetails";

                        string PostData = "{\"id\":\"" + RuleID + "\"}";

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
        public OutputBaseClass ruleList(RuleListRequest request, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/gtt/v1/ruleList";

                        string PostData = JsonConvert.SerializeObject(request);

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }

        public OutputBaseClass GetCandleData(CandleRequest Request, AngelToken Token)
        {
            OutputBaseClass res = new OutputBaseClass();
            res.status = true;
            res.http_code = 200;            
            try
            {
                if (Token != null)
                {
                    if (ValidateToken(Token))
                    {
                        string URL = APIURL + "/rest/secure/angelbroking/historical/v1/getCandleData";

                        string PostData = JsonConvert.SerializeObject(Request);

                        string json = POSTWebRequest(Token, URL, PostData);
                        if (!json.Contains("PostError:"))
                        {
                            res.response_data = JsonConvert.DeserializeObject<object>(json);
                        }
                        else
                        {
                            res.status = false;
                            res.http_code = 404;
                            res.http_error = json.Replace("PostError:", "");
                        }
                    }
                    else
                    {
                        res.status = false;
                        res.http_code = 404;
                        res.http_error = "The token is invalid";
                    }
                }
                else
                {
                    res.status = false;
                    res.http_code = 404;
                    res.http_error = "The token is invalid";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.http_code = 404;
                res.http_error = ex.Message;
            }
            return res;
        }
    }
}
