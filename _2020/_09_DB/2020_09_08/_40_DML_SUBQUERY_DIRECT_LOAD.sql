<서브쿼리를 이용한 DML 문>
INSERT INTO [/*+ APPEND */] 테이블 [NOLOGGING] [(컬럼, 컬럼, ...)]
SELECT 문;
1) SELECT 문에 의해 검색된 행을 입력값으로 사용한다
2) 한 번에 많은 행을 입력할 수 있다
3) 컬럼 리스트와 SELECT 문의 컬럼이 1:1로 대응되어야 한다
4) SELECT 문에 사용한 서브 쿼리 문과는 달리 괄호를 쓰지 않는다
5) /*+ APPEND */ : 다이렉트 로드(대량 작업의 속도 향상)
6) [NOLOGGING] : 로그 정보를 남기지 않음으로 입력작업이 빨라진다
                 그러나 장애 발생시 복구할 수 없다.