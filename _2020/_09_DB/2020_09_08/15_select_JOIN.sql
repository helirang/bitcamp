--<등가조인과 비등가조인>
--SELECT 테이블1.컬럼, 테이블2.컬럼, ...
--FROM 테이블1, 테이블 2,...
--WHERE 조인조건
--AND 일반조건;
--  a) 조인조건에 '='를 사용하는 것을 등가조인
--     부등호를 사용하는 것을 비등가조인이라 한다.

--1) 각 사원의 근무 부서를 검색한다
SELECT emp.eno 사번, emp.ename 이름, 
      dept.dno 부서번호, dept.dname 부서명
FROM emp, dept
WHERE dept.dno = emp.dno;

--2) 부산에서 근무하는 직원의 명단을 검색한다(부서번호와 부서명도 검색)
SELECT ename,dname, loc, dept.dno
FROM emp, dept
WHERE emp.dno = dept.dno;

SELECT d.dno,ename,dname, loc
FROM emp e, dept d
WHERE e.dno = d.dno;

--3) 각 직원의 급여 등급을 검색하라 
-- 비등가 조인 // 다른 테이블의 값을 수식을 통해 추출해서 가져오는 조인 방법
SELECT eno 사번, ename 이름, sal 급여, grade 등급
FROM emp, salgrade
WHERE sal BETWEEN losal AND hisal;

SELECT eno 사번, ename 이름, sal 급여, grade 등급
FROM emp, salgrade
WHERE sal>= losal AND sal <= hisal
ORDER BY 등급;

--4) 각 직원의 급여를 10% 인상하는 경우 급여 등급을 검색한다
SELECT eno 사번, ename 이름, sal*1.1 "인상된 급여", grade 등급
FROM emp, salgrade
WHERE sal*1.1 BETWEEN losal AND hisal
ORDER BY 등급;

--5) 잘못된 조인 문장
--조인조건이 없게되거나 잘못 조건을 기술하면
--모든 행이 1:1로 대응된 잘못된 결과값(Catersian Product)를 얻게 된다.
--교차 조인(Cross Join)은 일반적으로 잘못된 결과이다.
--dept의 7개 행과
--emp의 15개 행이 모두 1:1 대응된 것이다

SELECT d.dno, dname, e.eno, ename
FROM dept d, emp e;