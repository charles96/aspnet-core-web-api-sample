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
## reference
