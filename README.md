# Asp.net Core Web API sample

## overview
.net6 web api ���� ����

## sample goals
* api versioning
* logging ����
* restful api maturity model ����
## sample detail
### endpoints
|feature|endpoint|method|http status code|description|
|---|---|---|---|---|
|���� �߰�|/v1/user|POST|201 or 400|201 �� location header�� ��ȸ ���� ����|
|���� ����|/v1/user|PUT|200||
|���� ��ȸ|/v1/user/\{userid}|GET|200||
|���� ����|/v1/user/\{userid}|DELETE|204||

### model annotations
* Required
* Min / MaxLength
* Range
### json serialization
* null�� ��� json ����ȭ �� ���� 
* .net6 ������ DateOnly ����ȭ ����
  * DateOnly �� yyyy-MM-dd
  * swagger sample���� �ݿ� ��
### logging
[datetime] [log level] [server name] [class name] [method name] [trace id] : message 
```console
[2022-08-19 19:06:31.7418] [Debug] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BP:00000009] : create 
[2022-08-19 19:06:31.7911] [Info] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BP:00000009] : create 
[2022-08-19 19:06:31.7911] [Warn] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BP:00000009] : create 
[2022-08-19 19:06:31.7911] [Fatal] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BP:00000009] : create 
[2022-08-19 19:06:51.3471] [Debug] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BQ:00000001] : create 
[2022-08-19 19:06:51.3471] [Info] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BQ:00000001] : create 
[2022-08-19 19:06:51.3471] [Warn] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BQ:00000001] : create 
[2022-08-19 19:06:51.3471] [Fatal] [CHARLES-NOTEBOO] [User] [Create] [0HMK1P9RSS8BQ:00000001] : create
```
## reference
* [NLog with ILogger in .Net 6.0 Web API](https://medium.com/projectwt/nlog-with-ilogger-in-net-6-0-web-api-fb7072d8ac6c)
* [why ${aspnet-TraceIdentifier} be different from HttpContext.TraceIdentifier
](https://github.com/NLog/NLog.Web/issues/590)
* [Use GUID as TraceIdentifier in ASP.NET Core Web API](https://www.codeproject.com/Tips/5337613/Use-GUID-as-TraceIdentifier-in-ASP-NET-Core-Web-AP)