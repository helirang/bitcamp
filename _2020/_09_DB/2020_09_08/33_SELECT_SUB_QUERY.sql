<서브 쿼리 - 단일 행 서브 쿼리>

a) 서브 쿼리의 종류
  a-1) 단일 행 서브쿼리
     ; 서브쿼리가 하나의 컬럼에서 하나의 행을 검색한다
  a-2) 다중 행 서브쿼리
     ; 서브쿼리가 하나의 컬럼에서 여러 개의 행을 검색한다
  a-3) 다중 열 서브쿼리
     ; 서브쿼리가 여러 개의 컬럼을 검색한다
     

--1) 김연아보다 급여를 많이 받는 사원을 검색하세요
SELECT eno, ename
FROM emp
WHERE sal > (SELECT sal
            FROM emp
            WHERE ename='김연아');
            
--2) '노육'과 평점이 동일한 학생의 정보를 검색하세요
SELECT *
FROM student
WHERE avr = (SELECT avr
             FROM student
             WHERE sname='노육');
             
SELECT *
FROM student
WHERE avr IN (SELECT avr
             FROM student
             WHERE sname='노육');
             
--3) 김연아와 부서가 다르고 동일한 업무를 하는 사원의 정보를 검색하세요
SELECT *
FROM emp
WHERE dno!=(SELECT dno
            FROM emp
            WHERE ename='김연아')
AND job=(SELECT job
         FROM emp
         WHERE ename='김연아');
         
--4) 부서 중 가장 급여를 많이 받는 부서를 검색하세요
SELECT dno "급여MAX부서", ROUND(AVG(sal))
FROM emp
GROUP BY dno
HAVING AVG(sal) = (SELECT MAX(AVG(sal))
                   FROM emp
                   GROUP BY dno);

--5) 부서 중 가장 급여를 적게 받는 부서를 검색하세요
SELECT e.dno "급여MIN부서", dname, ROUND(AVG(sal))
FROM emp e, dept d
WHERE e.dno=d.dno
GROUP BY e.dno, dname
HAVING AVG(sal) = (SELECT MIN(AVG(sal))
                   FROM emp
                   GROUP BY dno);
                   
--6) 부산에서 근무하는 사원의 정보를 검색하세요
SELECT *
FROM emp
WHERE dno = (SELECT dno
             FROM dept
             WHERE loc='부산');
             
SELECT *
FROM emp e, dept d
WHERE e.dno=d.dno
AND loc='부산';




















