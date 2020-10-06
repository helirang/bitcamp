--조건 검색
--select 컬럼, 컬럼, ...
--FROM 테이블
--WHERE 조건
--ODRER BY 컬럼;

--1) 사원중에 급여가 4000이상인 사원을 검색하라
SELECT eno 사번, ename 이름, sal 급여
FROM emp
WHERE sal >= 4000;

--2) 이름이 '김연아'인 사원의 정보를 검색하라
SELECT *
FROM emp
WHERE ename = '김연아';

--3) 10번 부서를 제외한 사원의 명단을 검색하라
--dno는 타입이 varchar2 이므로
--검색을 할 때 '10'으로 검색해야 한다
--그렇지 않고 숫자로 검색하게 되면
--1행마다 형번환이 이루어진 후 비교연산이 이루어지게 된다
--만일 대기업의 대용량 테이블일 경우
--검색속도가 크게 차이나게 된다
SELECT *
FROM emp
WHERE dno != '10';

--4) 연봉이 30,000 이상인 사원의 이름을 검색하라
SELECT eno 사번, ename 이름, sal*12+NVL(comm,0) 연봉
FROM emp
WHERE sal*12+NVL(comm,0) >= 30000;

--조건비교는 별명이 안된다 / 정렬은 별명이 된다.
--SELECT eno 사번, ename 이름, sal*12+NVL(comm,0) 연봉
--FROM emp
--WHERE 연봉 >= 30000;

--5) 보너스가 200 이하인 사원을 검색하라
SELECT eno 사번, ename 이름, comm 보너스
FROM emp
WHERE comm <= 200;

SELECT eno 사번, ename 이름, comm 보너스
FROM emp
WHERE NVL(comm,0) <= 200;

--6) 입사일이 1996년 이후인 사원의 정보를 검색하라
SELECT *
FROM emp
WHERE hdate > '1995/12/31'
ORDER BY hdate;

ALTER SESSION SET nls_date_format='YYYY/MM/DD';
ALTER SESSION SET nls_date_format='YY/MM/DD';

--7) 보너스 컬럼이 널 값이 사원을 검색하라
SELECT *
FROM emp
WHERE comm IS null;

--8)  보너스 컬럼이 널 값이 아닌 사원을 검색하라
SELECT *
FROM emp
WHERE comm IS NOT null;