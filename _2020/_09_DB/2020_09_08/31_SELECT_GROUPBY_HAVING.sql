<그룹함수와 Having 절>
; 그룹함수를 포함한 조건은 WHERE 절을 사용할 수 없다
  그래서 HAVING 절을 사용해야 한다
  일반 컬럼은 WHERE 절을 사용한다

1) 테이블의 sal 접근 이전에 WHERE sal >= 3000을 먼저 연산한다
 WHERE절 -> sal 접근
SELECT sal
FROM emp
WHERE sal >= 3000;

--2) 부서별 평균
--GROUP BY -> ROUND(AVG(sal)) -> ROUND(AVG(sal)) >= 3000
SELECT ROUND(AVG(sal))
FROM emp
GROUP BY dno;

--3) 업무별 평균
SELECT ROUND(AVG(sal))
FROM emp
GROUP BY job;

--4) 부서별 급여 평균이 3천 미만인 부서의 부서번호와 평균 급여를 검색하라
SELECT dno, ROUND(AVG(sal))
FROM emp
GROUP BY dno
HAVING AVG(sal) < 3000;

--5) 부서별 인원수를 출력하세요(단, 업무가 개발이 아닌 인원만)
--job 은 일반 컬럼 조건이므로 HAVING 절을 사용할 수 없다
SELECT dno, COUNT(*)
FROM emp
GROUP BY dno
HAVING job!='개발';

--job 은 WHERE 절에 조건을 부여해야 한다
SELECT dno, COUNT(*)
FROM emp
WHERE job!='개발'
GROUP BY dno;

--dno는 일반 컬럼이지만 GROUP BY dno에 의해
--그룹함수와 묶이는 일반컬럼이므로
--이때는 HAVING 절에 dno를 사용할 수 있다.
--그러나 dno도 WHERE 절에 조건을 주는 것을
--원칙으로 한다

SELECT dno, COUNT(*)
FROM emp
GROUP BY dno
HAVING dno!='10';

SELECT dno, COUNT(*)
FROM emp
WHERE dno!='10'
GROUP BY dno;

--6) 그룹 대상 컬럼과 검색
--dno별로 그룹이 묶이게 된다
SELECT dno, COUNT(*) 인원수
FROM emp
GROUP BY dno;

--GROUP BY dno, job 은
--dno별로 묶이되 세부적으로 dno내의 job 그룹으로 묶여서 출력
SELECT dno, job, COUNT(*) 인원수
FROM emp
GROUP BY dno, job
HAVING job!='개발';

--그룹으로 묶어놓고 컬럼 출력을 안하면 해석하기 어려운 결과가 된다
--주의할 것
SELECT dno, COUNT(*) 인원수
FROM emp
GROUP BY dno, job
HAVING job!='개발';









