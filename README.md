# Asp.net Core Web API sample

## overview
.net6 web api ���� ����

## goals
* api versioning
* logging ����
## detail
restful api maturity model ����
### endpoints
|endpoint|method|http status code|description|
|---|---|---|---|
|/v1/user|POST|201 or 400|���� �߰�|
|/v1/user|PUT|200|���� ����|
|/v1/user/\{userid}|GET|200|���� ��ȸ|
|/v1/user/\{userid}|DELETE|204|���� ����|

* /v1/user
  * 201 �� location header�� ��ȸ ���� ����
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
