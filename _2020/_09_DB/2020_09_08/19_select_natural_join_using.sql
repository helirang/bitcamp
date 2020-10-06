<자연 조인(Natural Join)>
SELECT 컬럼, ...
FROM 테이블1
NATURAL JOIN 테이블2
WHERE 검색조건;
a) 동일한 이름/타입의 컬럼이 존재할 때 
   조인조건을 명시하지 않아도
   자동으로 찾아서 조인을 해준다
b) 공통 컬럼이 반드시 하나 존재해야 한다
   둘 이상인 경우는 사용할 수 없다
   이럴 경우는 USING 절을 사용할 수 있다.
  
--1) 자연 조인으로 각 사원의 근무 부서를 검색하라
SELECT eno 사번, ename 이름, dno 부서번호, dname 부서명
FROM emp
NATURAL JOIN dept;

SELECT eno 사번, ename 이름, d.dno 부서번호, dname 부서명
FROM emp e, dept d
WHERE e.dno=d.dno;

--2) '광주'에서 근무하는 직원의 명단을 검색하라(부서번호와 부서명도 검색)
SELECT loc 근무처, dno 부서번호, dname 부서명,
       eno 사번, ename 이름
FROM emp
NATURAL JOIN dept
WHERE loc='광주';

SELECT loc 근무처, dno 부서번호, dname 부서명,
       eno 사번, ename 이름
FROM dept
NATURAL JOIN emp
WHERE loc='광주';
   
<USING 절>
SELECT 컬럼, 컬럼, ...
FROM 테이블1
JOIN 테이블2 USING (조인 컬럼)
WHERE 검색조건;
   
--3) 자연 조인으로 각 사원의 근무 부서를 검색하라
SELECT eno 사번, ename 이름, dno 부서번호, dname 부서명
FROM emp
JOIN dept USING (dno);

--4)'서울'에서 근무하는 직원의 명단을 검색하라(부서번호와 부서명도 검색)
SELECT loc 근무처, dno 부서번호, dname 부서명,
       eno 사번, ename 이름
FROM dept
JOIN emp USING(dno)
WHERE loc='서울';

--5) 화학과 1학년 학생들의 유기화학 점수를 검색하라
SELECT sno, sname, cname, result
FROM student
JOIN SCORE USING (SNO)
JOIN course USING (CNO)
WHERE major='화학'
AND syear = 1
AND cname = '유기화학'
ORDER BY result;

SELECT sno, sname, cname, result
FROM student
NATURAL JOIN SCORE
NATURAL JOIN course
WHERE major='화학'
AND syear = 1
AND cname = '유기화학'
ORDER BY result;

SELECT s.sno, sname, cname, result
FROM student s, course c, score r
WHERE s.sno=r.sno 
AND c.cno=r.cno
AND major='화학'
AND syear = 1
AND cname = '유기화학'
ORDER BY result;
   
   
   
   
   
   
   
   
   
   
   
   
   