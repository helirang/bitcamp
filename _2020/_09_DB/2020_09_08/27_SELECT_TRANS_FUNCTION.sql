<단일 행 함수 - 변환 함수>
a) 날짜 출력 형식
년   YYYY   : 4자리로 표현된 년도 (2020, 1999)
     YY     : 2자리로 표현된 년도 (20, 99)
              앞의 2자리는 자동으로 현재 년도를 이용한다
              그러므로 99는 2099년을 의미한다              
     RR     : 2자리로 표현된 년도(99, 20)
              앞의 2자리는 현재 년도와 가까운 년도를 이용한다
              그러므로 99는 1999년을 의미한다
              
월   MM : 2자리 숫자로 표현된 월(03, 09)
    MONTH : 영문이나 한글로 표현된 월 (MARCH, APRIL, 3월, 4월)
    MON : 약자로 표현된 영문 및 한글 월(MAR, APR, 3월, 4월)
          한글인 경우 MONTH 와 동일하다
          
일   DD : 2자리 숫자로 표현된 일자(01, 02)
     DAY : 영문이나 한글 요일(SUNDAY, MONDAY, 일요일, 월요일)
     DY : 약자로 표현된 요일 (SUN, MON, 일, 월)

시   HH24 : 1시에서 24시까지 표현
     HH   : 1시에서 12시까지 표현
            정확한 표현을 위해 AM/PM을 추가하는 것이 좋다
분   MI : 2자리 분 표시
초   SS  : 2자리 초 표시
    SSSSSS : 하루를 초로 환산한 다음 표현(0-86399)
오전/오후 AM/PM : 오전 오후 표시
                 형식 지정시에는 둘이 똑같다
                 
b) 숫자 출력 형식
  9   : 숫자의 출력 폭지정, (자리수가 부족하면 생략한다)
  0   : 선행 0 표기(자리수를 반드시 맞춘다)
  $   : 화폐 표기(달러)
  L   : 지역 화폐 표기(각 국가 코드에 따라 다르다)
  ,   : 쉼표 지정위치
  .   : 마침표 지정위치
  MI  : 음수의 -기호를 오른쪽에 표기
  EEEE : 실수 표현법을 이용
  
C) 변환 함수
  TO_CHAR : 날짜나 숫자를 문자로 변환한다
            출력 데이터의 형식을 지정한다
            TO_CHAR(날짜, 출력형식), TO_CHAR(숫자, 출력형식)
  TO_DATE : 데이터를 날짜형으로 해석한다
            TO_DATE(문자, 해석형식)
  TO_NUMBER : 데이터를 숫자로 해석한다
              대부분의 경우 오라클의 자동 형 변환에 의해 숫자로
              읽을 수 있는 문자는 숫자로 자동 변환됨으로 사용
              빈도가 낮다.
              SQL보다는 PLSQL등에서 쓰인다.
              
--1) 현재 날짜를 다양한 형식으로 출력하세요
SELECT TO_CHAR(sysdate, 'YYYY/MM/DD') 날짜,
       TO_CHAR(sysdate, 'YYYY/MM/DD:HH24:MI:SS') 날짜,
       TO_CHAR(sysdate, 'YY/MM/DD:HH:MI:SS AM') 날짜
FROM dual;

SELECT TO_CHAR(sysdate, 'DD Month YYYY') toDay 
FROM dual;

SELECT TO_CHAR(sysdate, 'DAY Mon YY') toDay
FROM dual;

SELECT TO_CHAR(sysdate, 'DY Mon YY') toDay
FROM dual;

SELECT TO_CHAR(sysdate, '"오늘은 "YYYY"년 "MM"월 "DD"일 입니다."')
FROM dual;

--2) 10번 부서 사원의 입사일을 다음의 형식으로 검색하세요
--'OOO사원의 입사일은 OOOO년 OO월 OO일입니다.'
SELECT ename||' 사원의 입사일은 '||
      TO_CHAR(hdate, 'YYYY"년 "MM"월 "DD"일 입니다."') Hdate
FROM emp
WHERE dno='10';

--3) 숫자 출력 형식
SELECT TO_CHAR(12345.678, '999,999.99999') num
FROM dual;

SELECT TO_CHAR(12345.678, '099,999.999') num
FROM dual;

SELECT TO_CHAR(12345.678, '9,9999.9') num
FROM dual;

--소수점 앞쪽 형식이 원래 값보다 작으면 출력장애가 발생
SELECT TO_CHAR(12345.678, '9,999.9') num
FROM dual;

SELECT TO_CHAR(1234, '$999,999') num
FROM dual;

SELECT TO_CHAR(1234, 'L999,999') num
FROM dual;

SELECT TO_CHAR(-1234, '999,999MI') num
FROM dual;

SELECT TO_CHAR(123456789, '9.99EEEE') num
FROM dual;

--4) 10번 부서 사원의 보너스가 급여의 몇 퍼센트인지 검색하세요
--  급여는 월간 급여이고 보너스는 연간 보너스입니다
--  보너스가 null 인 경우는 0으로 환원해서 검색하세요
SELECT eno 사번, ename 이름,
      TO_CHAR(NVL(comm,0)/(sal*12)*100, '99')||'%' 급여비율
FROM emp
WHERE dno='10';

--5) 1992년 이전에 입사한 사원의 정보를 검색하세요
--오라클의 날짜 형식이 데이터베이스 설정에 따라 전혀 달라질 수 있다
--그러면 일반적인 문자열 날짜 비교로는 에러가 발생할 수 있다
--그러므로 아래처럼 TO_DATE를 사용하면 다른 형식설정에도
--동일하게 성공적으로 처리할 수 있다
SELECT eno 사번, ename 이름, hdate 입사일
FROM emp
WHERE hdate < TO_DATE('1992/01/01', 'YYYY/MM/DD');

SELECT eno 사번, ename 이름, hdate 입사일
FROM emp
WHERE hdate < '1992/01/01';

              
              
              
              
              
              
              
              
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  






    
    
    
    
    
    
    
    
            
            
            
            
            
            
     
     
     
     
     
     
     
     
          