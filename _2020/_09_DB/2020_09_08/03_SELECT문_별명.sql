--별명을 이용한 검색
--SELECT 컬럼 as "별명,컬럼 as "별명,...
--FROM 테이블;

1) 각 사원의 이름과 담당업무를 검색하라
SELECT eno 사번, ename 이름, job 업무
FROM emp;

SELECT eno as 사번, ename as 이름, job as 업무
FROM emp;

SELECT eno as "사번", ename as "이름", job as "업무"
FROM emp;

SELECT eno "사 번", ename "이 름", job "업 무"
FROM emp;

--2) 각 사원의 급여와 1년간 수급하는 급여를 검색하라
SELECT eno 사번, ename 이름, sal*12 "년간 급여"
FROM emp;

--3)각 사원의 연봉을 검색하라(12개월 급여 + 보너스(comm))
SELECT eno 사번, ename 이름, sal 급여, comm 보너스, sal*12+comm 연봉
FROM emp;

--데이터베이스에서는 0과 null은 전혀 다르다
--0은 값이 0인 것
--null은 값을 알 수 없다/ 값이 정해지지 않았다의 의미이다.
--이 경우 2가지로 결과를 선택해야 한다
--  a) sal*12+comm으로 연산해서 null 컬럼이 포함되었을때,
--   결과를 null로 나오게 할지
--  b) sal*12+NVL(comm,0)으로 연산해서 null을 0으로 치환한후 연산을 할지

--4) 사원의 연봉을 검색한다 (단, null은 0으로 치환한다)

SELECT eno 사번, ename 이름, sal 급여, comm 보너스, sal*12+NVL(comm,0) 연봉
FROM emp;