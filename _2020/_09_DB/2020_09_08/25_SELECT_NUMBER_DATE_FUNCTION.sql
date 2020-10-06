--<단일 행 함수 - 숫자, 날짜형 함수>
--a) ROUND : n자리까지 반올림한다
--           ROUND(m, n)
--           ROUND(123.4567, 3) -> 123.457
--   
--   TRUNC : n자리미만을 절삭한다
--           TRUNC(m, n)
--           TRUNC(123.4567, 3) -> 123.456
--  
--   MOD : m을 n으로 나눈 나머지 계산한다
--           MOD(m, n)
--           MOD(10, 4) -> 2
--         
--   POWER : m의 n승을 계산한다
--           POWER(m, n)
--           POWER(2, 4) -> 16
--           
--   CEIL : m보다 큰 가장 작은 정수를 찾는다
--          CEIL(m)
--          CEIL(2.34) -> 3
--          
--   FLOOR : m보다 작은 가장 큰 정수를 찾는다
--          FLOOR(m)
--          FLOOR(2.34) -> 2
--          
--   ABS : m의 절대값을 계산한다
--         ABS(m)
--         ABS(-4) -> 4
--         
--   SQRT : m의 제곱근을 계산한다(루트)
--          SQRT(m)
--          SQRT(9) -> 3
--          
--   SIGN : m이 음수일 때 -1, 양수일 때 1, 0이면 0을 반환한다(부호)
--          SIGN(m)
--          SIGN(-3) -> -1
           
           
--1) ROUND 함수를 사용
SELECT ROUND(98.765), TRUNC(98.765),
       ROUND(98.765, 2), TRUNC(98.765, 2)
FROM dual;

--2) MOD 함수를 사용
SELECT MOD(19, 3), MOD(-19, 3)
FROM dual;

--3) 10번 부서의 연봉을 계산한다. 단 100 단위 미만은 절삭한다
SELECT eno, ename, TRUNC(sal*12+NVL(comm,0), -2) 연봉
FROM emp
WHERE dno='10';

--<날짜 함수>
--4) 현재 날짜를 검색하고 날짜 출력 양식을 수정하세요
SELECT sysdate
FROM dual;

ALTER SESSION SET nls_date_format='YYYY/MM/DD:HH24:MI:SS';

ALTER SESSION SET nls_date_format='YYYY/MM/DD';

ALTER SESSION SET nls_date_format='YY/MM/DD';

--5) 오늘 날짜, 입사 일자, 임사일로부터 오늘까지 기간, 입사일 이후
--  100일이 지난날 등을 검색하세요
SELECT sysdate, hdate, sysdate-hdate, hdate+100
FROM emp
WHERE ename='김연아';

<날짜 함수>
; 사용빈도가 높다
YYYY : 년도
MM : 월
DD : 날짜
HH : 시간
MI : 분
SS : 초

ROUND : 형식에 맞추어 반올림한 날짜를 반환한다
        ROUND(날짜, 형식)
        ROUND(sysdate, 'DD') -> 2020/09/11
TRUNC : 형식에 맞추어 절삭한 날짜를 반환한다
        TRUNC(날짜, 형식)
        TRUNC(sysdate, 'DD') -> 2020/09/10
        TRUNC(sysdate, 'YYYY') -> 2020/01/01
MONTHS_BETWEEN : 두 날짜간의 기간을 월 수로 계산한다
        MONTHS_BETWEEN(날짜1, 날짜2)
        MONTHS_BETWEEN('2020/06/01', '2020/09/10')
ADD_MONTHS : 날짜에 n달을 더한 날짜를 계산한다
        ADD_MONTHS(날짜, n)
        ADD_MONTHS('2020/06/01', 5)
NEXT_DAY : 날짜 이후 지정된 요일에 해당하는 날짜를 계산한다
        NEXT_DAY(날짜, 요일)
        요일 표현은 'sun'/'일요일', 1 과 같이 다양한 표현이 가능하다
        NEXT_DAY('2020/09/10', '일요일')
LAST_DAY : 날짜를 포함한 달의 마지막 날짜를 계산한다
        LAST_DAY(날짜)
        LAST_DAY('2020/09/10') -> 2020/09/30
        
--6) 숫자와 날짜를 반올림하거나 절삭하여 출력하세요
SELECT sysdate, ROUND(sysdate, 'YY') 년,
                ROUND(sysdate, 'MM') 월,
                ROUND(sysdate, 'DD') 일
FROM dual;

SELECT sysdate, TRUNC(sysdate, 'YY') 년,
                TRUNC(sysdate, 'MM') 월,
                TRUNC(sysdate, 'DD') 일
FROM dual;

--7) 김연아가 오늘까지 일한 일수를 검색하세요
--홍길동이 1일 ~ 10일까지 일했을 때 일한 일수는?
--(10-1)+1 = 10일 일함
SELECT TRUNC(sysdate, 'DD') - TRUNC(hdate, 'DD') + 1 "일한 일수"
FROM emp
WHERE ename='김연아';

--8) 20번 부서 사원들이 현재까지 근무한 개월 수를 검색하세요
SELECT eno, ename, TRUNC(MONTHS_BETWEEN(sysdate,hdate)) 근무개월
FROM emp
WHERE dno='20';

--9) 20번 부서 사원들이 입사 100일째 되는 날과 10년째 되는 날을 구하세요
SELECT eno, ename, hdate 입사일,
      hdate+99 "100일", ADD_MONTHS(hdate,120) "10년"
FROM emp
WHERE dno='20';

--10) 20번 부서원들이 입사한 이후 첫 번째 일요일을 검색하세요
SELECT eno, ename, hdate, NEXT_DAY(hdate, '일요일') Sunday
FROM emp
WHERE dno='20';

--11) 10번 부서원들의 입사한 달의 마지막 날짜와
--   입사한 달의 근무 일수를 검색하세요
--   (단, 입사일은 근무일에서 제외합니다)
SELECT eno, ename, hdate, LAST_DAY(hdate) 마지막날,
       LAST_DAY(TRUNC(hdate))-TRUNC(hdate) "마지막달 근무일수"
FROM emp
WHERE dno='20';










           
           
           