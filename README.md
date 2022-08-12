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
## reference
