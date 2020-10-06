--<ON 절을 이용한 조인>
--SELECT 테이블1.컬럼, ..., 테이블2.컬럼, ...
--FROM 테이블1
--JOIN 테이블2 ON 조인조건
--WHERE 검색조건;
--a) 모든 형태의 조인을 표현할 수 있다
--  (등가/비등가 조인)
  
--1) 각 사원의 근무부서를 검색한다
SELECT eno 사번, ename 이름, d.dno 부서번호, dname 부서명
FROM emp e
JOIN dept d ON e.dno=d.dno;

SELECT eno, ename, d.dno, dname
FROM emp e, dept d
WHERE e.dno=d.dno;

SELECT eno, ename, dno, dname
FROM emp
NATURAL JOIN dept;

SELECT eno, ename, dno, dname
FROM emp
JOIN dept USING(dno);

SELECT PNO, PNAME FROM PROFESSOR JOIN COURSE USING(PNO);

SELECT eno, ename, d.dno, dname
FROM emp e
JOIN dept d ON e.dno=d.dno;


--2) 지원 업무를 담당하는 사원의 급여 등급을 검색한다.
SELECT eno 사번, ename 이름, job 업무, grade 급여등급
FROM emp
JOIN salgrade ON sal BETWEEN losal AND hisal
WHERE job='지원';

--3) 직원의 부서명과 급여 등급을 검색한다
SELECT eno 사번, ename 이름, dname 부서명, grade 급여등급
FROM emp
JOIN dept USING(dno)
JOIN salgrade ON sal BETWEEN losal AND hisal;

SELECT eno 사번, ename 이름, dname 부서명, grade 급여등급
FROM emp e
JOIN dept d ON e.dno=d.dno
JOIN salgrade ON sal BETWEEN losal AND hisal;

<좌우 외부 조인(Left Right Outer Join)>
+ 기호를 이용하는 외부조인의 다른 표현법
이전의 외부조인은 한쪽에만 +를 붙이는데
여기에서는 모두 +를 추가한 것과 동일한 표현이 가능하다
SELECT 테이블1.컬럼, ... 테이블2.컬럼, ...
FROM 테이블1
[LEFT|RIGHT|FULL] [OUTER] JOIN 테이블2 [ON 조인조건| USING(조인컬럼)]
WHERE 검색조건;
a) LEFT : '테이블1'을 왼쪽 테이블이라 부르고 왼쪽 테이블에 조인조건과
          일치하지 않은 행도 검색에 포함한다.
b) RIGHT : '테이블2'를 오른쪽 테이블이라 부르고 오른쪽 테이블에 조인조건과
          일치하지 않은 행도 검색에 포함한다.
C) FULL : 양쪽 테이블 모두에서 조인 조건에 일치하지 않은 행을 검색에
          포함한다. 이전 (+)기호를 이용한 외부조인으로는 불가능한 표현이다
d) ON 절이나 USING 절을 모두 사용할 수 있다.

4) 사원의 이름과 소속 부서를 검색하라
SELECT eno 사번, ename 이름, dno 부서번호, dname 부서명
FROM emp
RIGHT JOIN dept USING(dno);

SELECT eno 사번, ename 이름, dno 부서번호, dname 부서명
FROM emp
RIGHT OUTER JOIN dept USING(dno);

SELECT eno 사번, ename 이름, dno 부서번호, dname 부서명
FROM emp
LEFT JOIN dept USING(dno);

SELECT eno 사번, ename 이름, dno 부서번호, dname 부서명
FROM emp
FULL JOIN dept USING(dno);















