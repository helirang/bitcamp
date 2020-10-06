--BETWEEN..AND 연산자
--SELECT 컬럼, 컬럼...
--FROM 테이블
--WHERE 컬럼 BETWEEN 값1 AND 값2;
--; 컬럼 >= 값1 AND 컬럼 <= 값2; 컬럼 중 값1과 값2사이의 데이터를 추출한다;

--1) 급여가 1000에서 2000이내인 사원
SELECT *
FROM emp
WHERE sal BETWEEN 1000 AND 2000;

--2) 10번, 20번 부서 사원

SELECT *
FROM emp
WHERE dno BETWEEN 10 AND 20;

--3) 1992년에서 1996년 사이에 입사한 사원을 검색하라
SELECT *
FROM emp
WHERE hdate BETWEEN '1992/01/01' AND '1996/12/31'
ORDER BY hdate;

ALTER SESSION SET nls_date_format='YYYY/MM/DD:HH24:MI:SS';

SELECT *
FROM emp
WHERE hdate BETWEEN '1992/01/01:00:00:00' 
AND '1996/12/31:23:59:59'
ORDER BY hdate;

--4) 급여가 1000에서 2000 사이인 사원을 검색하라 // between은 작은 숫자가 앞에 와야한다.
SELECT *
FROM emp
WHERE sal BETWEEN 1000
AND 2000;

--[IN 연산자]
--SELECT 컬럼, 컬럼
--FROM 테이블
--WHERE 컬럼 IN (값1, 값2, ...)
--ORDER BY 컬럼, ...;
--지정된 값중에 일치하는 것이 하나라도 있으면 검색

--5) 개발이나 회계 업무를 담당하는 사원
SELECT *
FROM emp
WHERE job IN ('개발', '관리')
ORDER BY job;

--6) 10, 20번 부서사원
SELECT *
FROM emp
WHERE dno IN ('10','20')
ORDER BY  dno;