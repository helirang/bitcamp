--연결 연산자의 사용
--SELECT 컬럼 || '리터럴' ||...
--FROM 테이블;

1) 사원의 이름을 급여 또는 업무와 함께 검색하라
SELECT ename||sal
FROM emp;

SELECT ename||' '||sal "이름 급여"
FROM emp;

SELECT ename||'의 업무는 '|| job||'입니다.' 담당업무
FROM emp;

--2) 주의해야 할 연산자 // 연결 연산자가 +보다 우선순위가 높다.
SELECT ename|| ' ' || sal+100
FROM emp;

SELECT ename|| ' ' || (sal+100)
FROM emp;

--중복제거
--SELECT [DITINCT | ALL] 컬럼, 컬럼, ...
--FROM 테이블

3) 직원들의 업무에는 어떤 것이 있을지 검색(업무의 종류를 검색하라)
SELECT job 업무
FROM emp;

SELECT ALL job 업무
FROM emp;

SELECT DISTINCT job 업무
FROM emp;