<서브 쿼리 - 다중 행, 다중 열>
a) 다중 행 : 여러 개 행이 검색
   단일 행 서브쿼리와 구조는 같으나 사용 연산자가 다르다
   단일 행은 =, != 를 사용한다
   다중 행은 IN  : 검색된 값중에 하나가 일치하면 참
            ANY : 검색된 값중에 조건이 하나 이상 맞으면 참
            ALL : 검색된 값들과 모두 조건에 맞으면 참
            
--1) 20번 부서원들과 동일한 관리자로부터 관리받는 사원을 검색하세요
SELECT *
FROM emp
WHERE mgr IN (SELECT mgr
              FROM emp
              WHERE dno='20')
AND dno!='20';

--2) 10번 부서원들보다 급여가 낮은 사원을 검색하세요
SELECT eno, ename, dno
FROM emp
WHERE sal < ALL(SELECT sal
                FROM emp
                WHERE dno='10')
AND dno!='10';

SELECT eno, ename, dno
FROM emp
WHERE sal < (SELECT MIN(sal)
                FROM emp
                WHERE dno='10')
AND dno!='10';

--3) 20번 부서원들과 보너스가 같은 사원을 검색하세요
SELECT eno, ename, dno, comm
FROM emp
WHERE comm IN (SELECT comm
               FROM emp
               WHERE dno='20')
AND dno!='20';

SELECT eno, comm
FROM emp
WHERE dno='20';

--null 이 포함된 경우는 0으로 치환할지 결정하자
SELECT eno, ename, dno, comm
FROM emp
WHERE NVL(comm, 0) IN (SELECT NVL(comm, 0)
               FROM emp
               WHERE dno='20')
AND dno!='20';


<다중 열 서브쿼리>
; 여러 개 컬럼 항목이 검색되는 것
; IN 연산자를 사용한다

--4)손하늘과 동일한 관리자의 관리를 받으면서 업무도 같은 사원을 검색하세요
--다중열일 경우 IN을 사용하면 모든 열이 만족되는 경우를 찾는다
SELECT eno, ename, mgr, job
FROM emp
WHERE (mgr, job) IN (SELECT mgr, job
                     FROM emp
                     WHERE ename='손하늘');

SELECT eno, ename, mgr, job
FROM emp
WHERE (mgr, job) IN (SELECT mgr, job
                     FROM emp
                     WHERE ename='손하늘')
AND ename!='손하늘';

--아래는 위 문제의 답은 아니다
SELECT eno, ename, mgr, job
FROM emp
WHERE mgr IN (SELECT mgr
              FROM emp
              WHERE ename='손하늘')
AND job IN (SELECT job
            FROM emp
            WHERE ename='손하늘');

SELECT eno, ename, mgr, job
FROM emp
WHERE mgr IN (SELECT mgr
              FROM emp
              WHERE ename='손하늘')
AND job IN (SELECT job
            FROM emp
            WHERE ename='손하늘')
AND ename!='손하늘';


--5) 각 부서별로 최소 급여를 받는 사원의 정보를 검색하세요
--   (이름, 급여)
SELECT dno, ename, sal
FROM emp
WHERE (dno, sal) IN (SELECT dno, MIN(sal)
                     FROM emp
                     GROUP BY dno)
ORDER BY dno;







