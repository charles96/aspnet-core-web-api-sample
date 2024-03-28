# Asp.net Core Web API sample

## overview
.net web api 개발 샘플

## sample goals
* api versioning
* logging 적용
* x-trace-id를 log와 응답 header에 포함
* restful api maturity model 적용
## sample detail
### endpoints
|feature|endpoint|method|http status code|description|
|---|---|---|---|---|
|유저 추가|/v1/user|POST|201 or 400|201 → location header로 조회 정보 전달|
|유저 수정|/v1/user|PUT|200||
|유저 조회|/v1/user/\{userid}|GET|200||
|유저 삭제|/v1/user/\{userid}|DELETE|204||

### model annotations
* Required
* Min / MaxLength
* Range
### json serialization
* null일 경우 json 직렬화 시 제외 
* .net6 미지원 DateOnly 직렬화 적용
  * DateOnly → yyyy-MM-dd
  * swagger sample에도 반영 됨
### logging
[datetime] [log level] [server name] [class name] [method name] [x-trace-id] : message 
```console
[2022-08-19 19:06:31.7418] [Debug] [CHARLES-NOTEBOO] [User] [Create] [cb47d0d6-ea0e-45c9-9ce9-f5599db32e78] : create 
[2022-08-19 19:06:31.7911] [Info] [CHARLES-NOTEBOO] [User] [Create] [4f518b49-4e0e-4b05-aa8a-831ad7f1df1a] : create 
[2022-08-19 19:06:31.7911] [Warn] [CHARLES-NOTEBOO] [User] [Create] [42f3fc9f-2edc-4431-857c-9f42befba193] : create 
[2022-08-19 19:06:31.7911] [Fatal] [CHARLES-NOTEBOO] [User] [Create] [b98dcb30-0dca-4de0-9958-5f3f0cae6eb2] : create 
[2022-08-19 19:06:51.3471] [Debug] [CHARLES-NOTEBOO] [User] [Create] [d49e54e8-0ed0-4bf5-9316-f3b0b360f55b] : create 
[2022-08-19 19:06:51.3471] [Info] [CHARLES-NOTEBOO] [User] [Create] [0f6c0dc6-c518-4776-bf3c-c1294eb0c3ac] : create 
[2022-08-19 19:06:51.3471] [Warn] [CHARLES-NOTEBOO] [User] [Create] [2b6d5438-8306-4050-a714-1698baef09f5] : create 
[2022-08-19 19:06:51.3471] [Fatal] [CHARLES-NOTEBOO] [User] [Create] [b810f0f2-be94-478d-97af-52d269d08d9f] : create
```
### x-trace-id
x-trace-id를 GUID로 생성하여 log 기록 및 응답 헤더를 통해 전달하게 하여
api 실행 주체자와 api개발자간에 x-trace-id 하나를 통해 트랜젝션 추적이 가능하도록 구현
```log
[2024-03-27 16:15:12.8030] [Debug] [D21] [User] [Create] [a2a10634-7168-4357-b1b8-d63b1131190e] : create 
```
```response header
 api-supported-versions: 1.0 
 content-type: application/json; charset=utf-8; ver=1 
 date: Wed,27 Mar 2024 07:15:12 GMT 
 location: /v1/user 
 server: Kestrel 
 x-trace-id: a2a10634-7168-4357-b1b8-d63b1131190e 
```
## reference
* [NLog with ILogger in .Net 6.0 Web API](https://medium.com/projectwt/nlog-with-ilogger-in-net-6-0-web-api-fb7072d8ac6c)
* [why ${aspnet-TraceIdentifier} be different from HttpContext.TraceIdentifier
](https://github.com/NLog/NLog.Web/issues/590)
* [Use GUID as TraceIdentifier in ASP.NET Core Web API](https://www.codeproject.com/Tips/5337613/Use-GUID-as-TraceIdentifier-in-ASP-NET-Core-Web-AP)
* [How to modify response headers in ASP.NET Core middleware](https://blog.elmah.io/how-to-modify-response-headers-in-asp-net-core-middleware/)