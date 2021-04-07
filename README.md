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

#### initialize following variable and keep in web.config for essay access application 

```csharp string root = ConfigurationManager.AppSettings["root"].ToString();
string Client_code = ConfigurationManager.AppSettings["Client_code"].ToString();
string Password = ConfigurationManager.AppSettings["Password"].ToString();
string UserType = ConfigurationManager.AppSettings["UserType"].ToString();
string SourceID = ConfigurationManager.AppSettings["SourceID"].ToString();
string ClientLocalIP = ConfigurationManager.AppSettings["ClientLocalIP"].ToString();
string ClientPublicIP = ConfigurationManager.AppSettings["ClientPublicIP"].ToString();
string MACAddress = ConfigurationManager.AppSettings["MACAddress"].ToString();
string PrivateKey = ConfigurationManager.AppSettings["PrivateKey"].ToString();
```
//create a class object of DLL to call any method of DLL
```csharp 
AngelBroking a = new AngelBroking(root, UserType, SourceID, ClientLocalIP, ClientPublicIP, MACAddress, PrivateKey);
```
//OutputBaseClass is common class to hold output across all application Methods.

//Login Call
```csharp 
OutputBaseClass obj = a.GenerateSession(Client_code, Password);
```

//create object to hold token, generated after login and that will be use for all next methods

//you can save this token response in SQL table or hold in hidden field or somewhere in application

```csharp 
AngelTokenResponse agr = (AngelTokenResponse)obj.response_data;
```

//Object to hold Actual Token with following data

//string jwtToken , string refreshToken ,string feedToken

```csharp 
AngelToken token = agr.data;
```

// token re-generate
```csharp 
OutputBaseClass obj = a.GenerateToken(token);
```

// method call to get profile data
```csharp 
OutputBaseClass obj = a.GetProfile(token);
```

/** Place order. */

//create object to hold order information which will be as input to place order
// This method will return orderid in case successful order place

```csharp 
OrderInfo ord = new OrderInfo();
ord.variety = "NORMAL";
ord.variety = Constants.VARIETY_NORMAL;
ord.tradingsymbol = "SBIN-EQ";
ord.symboltoken = "3045";
ord.transactiontype = Constants.TRANSACTION_TYPE_BUY;
ord.exchange = Constants.EXCHANGE_NSE;
ord.ordertype = Constants.ORDER_TYPE_LIMIT;
ord.producttype = Constants.PRODUCT_TYPE_DELIVERY;
ord.duration = Constants.VALIDITY_DAY;
ord.price = "370.00";
ord.squareoff = "0";
ord.stoploss = "0";
ord.quantity = "10";

OutputBaseClass obj = a.placeOrder(ord, token);
```

/** Modify order. */

// Order modify request will return orderid in case successful order update
```csharp 
OrderInfo ord = new OrderInfo();
ord.orderid = "210323000000313";
ord.variety = Constants.VARIETY_NORMAL;
ord.tradingsymbol = "SBIN-EQ";
ord.symboltoken = "3045";
ord.transactiontype = Constants.TRANSACTION_TYPE_BUY;
ord.exchange = Constants.EXCHANGE_NSE;
ord.ordertype = Constants.ORDER_TYPE_LIMIT;
ord.producttype = Constants.PRODUCT_TYPE_DELIVERY;
ord.duration = Constants.VALIDITY_DAY;
ord.price = "357.00";
ord.squareoff = "0";
ord.stoploss = "0";
ord.quantity = "20";

OutputBaseClass obj = a.modifyOrder(ord, token);
```

/** Cancel an order */

// Cancel order will return orderid in case successfull order cancel
```csharp 
OrderInfo ord = new OrderInfo();
ord.orderid = "210406000000127";
ord.variety = Constants.VARIETY_NORMAL;
OutputBaseClass obj = a.cancelOrder(ord, token);
```

/** Get order book details */
```csharp 
OutputBaseClass obj = a.getOrderBook(Client_code, token);
```

/** Get tradebook */
```csharp 
OutputBaseClass  obj = a.getTradeBook(token);
```

/** Get RMS */
```csharp 
OutputBaseClass  obj = a.getRMS(token);
```

/** Get Holdings */
```csharp 
OutputBaseClass  obj = a.getHolding(token);
```

/** Get Position */
```csharp 
OutputBaseClass  obj = a.getPosition(token);
```

/** convert Position */
// initialize object for conversion request and input it to method with token 
```csharp 
ConvertPositionRequest req = new ConvertPositionRequest();
req.exchange = Constants.EXCHANGE_NSE;
req.oldproducttype =Constants.PRODUCT_CNC;
req.newproducttype = Constants.PRODUCT_MIS;
req.tradingsymbol = "SBIN-EQ";
req.transactiontype = Constants.TRANSACTION_TYPE_BUY;
req.quantity = 1;
req.type = Constants.VALIDITY_DAY;

OutputBaseClass obj = a.convertPosition(req, token);
```

/** Create Gtt Rule*/
```csharp 
CreateRuleRequest req = new CreateRuleRequest();
req.tradingsymbol = "SBIN-EQ";
req.symboltoken = "3045";
req.exchange = Constants.EXCHANGE_NSE;
req.transactiontype = Constants.TRANSACTION_TYPE_BUY;
req.producttype = Constants.PRODUCT_TYPE_MARGIN;
req.price = "350";
req.qty = "10";
req.triggerprice = "370";
req.disclosedqty = "10";
req.timeperiod = "20";

OutputBaseClass obj = a.CreateRule(req, token);
```


/** Gtt Rule Details */
```csharp 
string RuleID ="1000067"
OutputBaseClass obj = a.ruleDetails(RuleID, token);
```

/** Modify Gtt Rule */
```csharp 
CreateRuleRequest req = new CreateRuleRequest();
req.id = "1000118";
req.tradingsymbol = "SBIN-EQ";
req.symboltoken = "3045";
req.exchange = Constants.EXCHANGE_NSE;
req.transactiontype = Constants.TRANSACTION_TYPE_BUY;
req.producttype = Constants.PRODUCT_TYPE_MARGIN;
req.price = "350";
req.qty = "10";
req.triggerprice = "360";
req.disclosedqty = "10";
req.timeperiod = "20";

OutputBaseClass obj = a.modifyRule(req, token);
```

/** Cancel Gtt Rule */
```csharp 
CancelRuleRequest req = new CancelRuleRequest();
req.id = "1000117";
req.symboltoken = "3045";
req.exchange = Constants.EXCHANGE_NSE;

OutputBaseClass obj = a.cancelRule(req, token);
```

/** Gtt Rule Details */
```csharp 
RuleListRequest req = new RuleListRequest();
req.status = new List<string>();
req.status.Add("NEW");
req.status.Add("CANCELLED");
req.status.Add("ACTIVE");
req.status.Add("SENTTOEXCHANGE");
req.status.Add("FORALL");
req.page = 1;
req.count = 10;

OutputBaseClass obj = a.ruleList(req, token);
```

/** Historic Data */
```csharp 
CandleRequest req = new CandleRequest();
req.exchange =Constants.EXCHANGE_NSE;
req.symboltoken = "3045";
req.interval = Constants.INTERVAL_MINUTE;
req.fromdate = "2021-02-08 09:00";
req.todate = "2021-02-08 09:16";

OutputBaseClass obj = a.GetCandleData(req, token);
```


/** Logout user. */
```csharp 
OutputBaseClass obj = a.LogOut(Client_code,token);
```

