# Asp.net Core Web API sample

## overview
.net6 web api 개발 샘플

## goals
* api versioning
* logging 적용
## detail
restful api maturity model 적용
### endpoints
|endpoint|method|http status code|description|
|---|---|---|---|
|/v1/user|POST|201 or 400|유저 추가|
|/v1/user|PUT|200|유저 수정|
|/v1/user/\{userid}|GET|200|유저 조회|
|/v1/user/\{userid}|DELETE|204|유저 삭제|

* /v1/user
  * 201 → location header로 조회 정보 전달
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
