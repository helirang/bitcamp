--정렬된 데이터 검색
--SELECT [DISTINCT | ALL] 컬럼, 컬럼, ...
--FROM 테이블
--ORDER BY 컬럼 [ASC/DESC], 컬럼 [ASC/DESC] ...,

--1) 사원의 이름을 급여 순으로 검색하라
SELECT eno 사번, ename 이름, sal 급여
FROM emp
ORDER BY sal DESC;

--2) 사원의 사번과 이름을 연봉 순으로 검색하라
SELECT eno 사번, ename 이름
FROM emp
ORDER BY sal*12+NVL(comm,0) DESC;

SELECT eno 사번, ename 이름, sal*12+NVL(comm,0) 연봉
FROM emp
ORDER BY 연봉 DESC;

SELECT eno 사번, ename 이름, sal*12+NVL(comm,0) 연봉
FROM emp
ORDER BY 3 DESC;

--정렬을 이용한 묶음 검색
--3) 업무별로 사원의 연봉을 검색한다
SELECT job 업무, eno 사번, ename 이름, sal 급여
FROM emp
ORDER BY 업무;

--4) 각 부서별로 사원의 급여를 검색한다.
--  단 급여를 많이 받는 사람부터 검색한다.
  
SELECT dno 부서번호, eno 사번, ename 이름, sal 급여
FROM emp
ORDER BY 부서번호, 급여 DESC;

SELECT dno 부서번호, eno 사번, ename 이름, sal 급여
FROM emp
ORDER BY 부서번호 ASC, 급여 DESC;
