# smartapi-dotnet

## Smart API Using C# Asp. Net

Smart API is a set of REST-like APIs that expose many capabilities required to build a complete investment and trading platform. 
Execute orders in real time, manage user portfolio, stream live market data (WebSockets), and more, with the simple HTTP API collection.

## Prerequisite 

Download smartapi-dotnet.dll file and add reference to your desktop/web application 

Include Newtonsoft.Json.dll from Package manager console as follow

PM> Install-Package Newtonsoft.Json. 
For More details (https://www.nuget.org/packages/Newtonsoft.Json/)


## API Usage

#### Initialize Samart API using clientcode and password JWTToken and Refresh Token is optional if provided login is not necessory 

```
string Client_code = "";  //YOUR CLIENT CODE
string Password = ""; //YOUR PASSWORD
string api_key = "";
string JWTToken = "";  // optional
string RefreshToken = ""; // optional

SmartApi connect = new SmartApi(api_key, JWTToken, RefreshToken);

OutputBaseClass obj = new OutputBaseClass();

//Login by client code and password
obj = connect.GenerateSession(Client_code, Password);
AngelToken agr = obj.TokenResponse;


//Get Token
obj = connect.GenerateToken();
agr = obj.TokenResponse;


//Get Profile
obj = connect.GetProfile();
GetProfileResponse gp = obj.GetProfileResponse;


//Place Order
OrderInfo ord = new OrderInfo();
ord.variety = Constants.VARIETY_NORMAL;
ord.tradingsymbol = "SBIN-EQ";
ord.symboltoken = "3045";
ord.transactiontype = Constants.TRANSACTION_TYPE_BUY;
ord.exchange = Constants.EXCHANGE_NSE;
ord.ordertype = Constants.ORDER_TYPE_LIMIT;
ord.producttype = Constants.PRODUCT_TYPE_INTRADAY;
ord.duration = Constants.VALIDITY_DAY.ToString();
ord.price = "350.00";
ord.squareoff = "0";
ord.stoploss = "0";
ord.quantity = "10";

obj = connect.placeOrder(ord);
OrderResponse Ores = obj.PlaceOrderResponse;


//Modify Order
OrderInfo mord = new OrderInfo();
mord.orderid = "210419000000159";
mord.variety = Constants.VARIETY_NORMAL;
mord.tradingsymbol = "SBIN-EQ";
mord.symboltoken = "3045";
mord.transactiontype = Constants.TRANSACTION_TYPE_BUY;
mord.exchange = Constants.EXCHANGE_NSE;
mord.ordertype = Constants.ORDER_TYPE_LIMIT;
mord.producttype = Constants.PRODUCT_TYPE_DELIVERY;
mord.duration = Constants.VALIDITY_DAY.ToString();
mord.price = "357.00";
mord.squareoff = "0";
mord.stoploss = "0";
mord.quantity = "20";

obj = connect.modifyOrder(mord);
OrderResponse mOres = obj.ModifyOrderResponse;


//cancel Order
OrderInfo ord2 = new OrderInfo();
ord2.orderid = "210419000000159";
ord2.variety = Constants.VARIETY_NORMAL;

obj = connect.cancelOrder(ord2);
OrderResponse cOrs = obj.CancelOrderResponse;


//get Order Book
obj = connect.getOrderBook();
GetOrderBookResponse book = obj.GetOrderBookResponse;


//get Trade Book
obj = connect.getTradeBook();
GetTradeBookResponse trade = obj.GetTradeBookResponse;


// Get Get LTP Data 
LTPDataRequest lreq = new LTPDataRequest();
lreq.exchange = Constants.EXCHANGE_NSE;
lreq.symboltoken = "3045";
lreq.tradingsymbol = "SBIN-EQ";
obj = connect.GetLTPData(lreq);
GetLTPDataResponse ltp = obj.GetLTPDataResponse;


//get Holding
obj = connect.getHolding();
GetHoldingResponse holding = obj.GetHoldingResponse;


//get Position
obj = connect.getPosition();
GetPositionResponse position = obj.GetPositionResponse;
;

//Convert Position
ConvertPositionRequest req = new ConvertPositionRequest();
req.exchange = Constants.EXCHANGE_NSE.ToString();
req.oldproducttype = Constants.PRODUCT_TYPE_DELIVERY;
req.newproducttype = Constants.PRODUCT_TYPE_MARGIN;
req.tradingsymbol = "SBIN-EQ";
req.transactiontype = Constants.TRANSACTION_TYPE_BUY;
req.quantity = 1;
req.type = Constants.VALIDITY_DAY;

obj = connect.convertPosition(req);
PositionConversionResponse cc = obj.PositionConversionResponse;


//get RMS
obj = connect.getRMS();
GetRMSLimitResponse gmres = obj.GetRMSLimitResponse;


//Create Rule
CreateRuleRequest crreq = new CreateRuleRequest();
//crreq.id = 0;
crreq.tradingsymbol = "SBIN-EQ";
crreq.symboltoken = "3045";
crreq.exchange = Constants.EXCHANGE_NSE;
crreq.transactiontype = Constants.TRANSACTION_TYPE_BUY;
crreq.producttype = Constants.PRODUCT_TYPE_MARGIN;
crreq.price = "350";
crreq.qty = "10";
crreq.triggerprice = "370";
crreq.disclosedqty = "10";
crreq.timeperiod = "20";

obj = connect.CreateRule(crreq);
RuleResponse rr = obj.CreateRuleResponse;


//Rule Details
string RuleID = "1000118";
obj = connect.ruleDetails(RuleID);
RuleDetailsResponse rd = obj.RuleDetailsResponse;


//Modify Rule
CreateRuleRequest crreq2 = new CreateRuleRequest();
crreq2.id = "1000118";
crreq2.tradingsymbol = "SBIN-EQ";
crreq2.symboltoken = "3045";
crreq2.exchange = Constants.EXCHANGE_NSE;
crreq2.transactiontype = Constants.TRANSACTION_TYPE_BUY;
crreq2.producttype = Constants.PRODUCT_TYPE_MARGIN;
crreq2.price = "350";
crreq2.qty = "10";
crreq2.triggerprice = "360";
crreq2.disclosedqty = "10";
crreq2.timeperiod = "20";

obj = connect.modifyRule(crreq2);
RuleResponse rm = obj.ModifyRuleResponse;


//Cancel Rule
CancelRuleRequest creq = new CancelRuleRequest();
creq.id = "1000117";
creq.symboltoken = "3045";
creq.exchange = Constants.EXCHANGE_NSE;

obj = connect.cancelRule(creq);
RuleResponse rc = obj.CancelRuleResponse;


//Rule List
RuleListRequest rreq = new RuleListRequest();
rreq.status = new List<string>();
rreq.status.Add("NEW");
rreq.status.Add("CANCELLED");
rreq.status.Add("ACTIVE");
rreq.status.Add("SENTTOEXCHANGE");
rreq.status.Add("FORALL");
rreq.page = 1;
rreq.count = 10;

obj = connect.ruleList(rreq);
RuleListResponse rl = obj.RuleListResponse;


//Get Candle Data
CandleRequest cdreq = new CandleRequest();
cdreq.exchange = Constants.EXCHANGE_NSE;
cdreq.symboltoken = "3045";
cdreq.interval = Constants.INTERVAL_MINUTE;
cdreq.fromdate = "2021-02-08 09:00";
cdreq.todate = "2021-02-08 09:15";

obj = connect.GetCandleData(cdreq);
CandleDataResponse cd = obj.GetCandleDataResponse;


//LogOut
obj = connect.LogOut(Client_code);
LogOutResponse lg = obj.LogOutResponse;
```



