--1) dept 테이블의 모든 데이터를 삭제한 다음 ROLLBACK 과 COMMIT 를 
--수행하고 결과를 확인하세요
SELECT *
FROM dept;

DELETE FROM dept;

SELECT *
FROM dept;

ROLLBACK;

SELECT *
FROM dept;

--2) emp 와 dept 테이블의 모든 데이터를 삭제완료하세요
SELECT * FROM emp;
SELECT * FROM dept;
DELETE FROM emp;
DELETE FROM dept;
SELECT * FROM emp;
SELECT * FROM dept;
COMMIT;
ROLLBACK;

--3) emp 테이블에 값들을 입력하세요
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1001','김연아','개발',NULL,'1991-02-01',4500,520,10);
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1002','임꺽정','회계',NULL,'1992-03-03',4100,720,20);
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1003','이만기','씨름',NULL,'1999-12-12',5500,820,30);
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1004','강호동','예능',NULL,'1991-11-09',5500,620,40);
--SELECT * FROM emp;
--ROLLBACK;
COMMIT;
SELECT * FROM emp;

--4) emp 테이블에 데이터를 입력하되 입사일에 날짜와 시간도 입력하세요
SELECT sysdate
FROM dual;
--date 는 날짜 형식이 일치해야 입력된다
INSERT INTO emp (eno, ename, hdate)
VALUES ('5001', '홍길동', '1991-01-03:07:15:25');

ALTER SESSION SET nls_date_format='YYYY-MM-DD:HH24:MI:SS';
INSERT INTO emp (eno, ename, hdate)
VALUES ('5001', '홍길동', '1991-01-03:07:15:25');

SELECT * FROM emp;

--5) 날짜 형식을 확인하고 TO_DATE() 를 사용해서 입력하라
ALTER SESSION SET nls_date_format='YYYY-MM-DD';
SELECT sysdate FROM dual;
ALTER SESSION SET nls_date_format='YY-MM-DD';
SELECT sysdate FROM dual;
ALTER SESSION SET nls_date_format='YY/MM/DD';
SELECT sysdate FROM dual;

INSERT INTO emp (eno, ename, hdate)
VALUES ('5002', '장나라', 
        TO_DATE('1992-02-03:07:07:07', 'YYYY-MM-DD:HH24:MI:SS'));
SELECT * FROM emp;

SELECT eno, ename, TO_CHAR(hdate, 'YYYY-MM-DD:HH24:MI:SS')
FROM emp;

--6) 날짜에 적용되는 디폴트 값을 확인한다
ALTER SESSION SET nls_date_format='YYYY-MM-DD:HH24:MI:SS';
INSERT INTO emp (eno, hdate)
VALUES ('1', TO_DATE('2000', 'YYYY'));
INSERT INTO emp (eno, hdate)
VALUES ('3', TO_DATE('99', 'YY'));
INSERT INTO emp (eno, hdate)
VALUES ('4', TO_DATE('99', 'RR'));
COMMIT;
SELECT * FROM emp;

--7) 김연아의 부서번호를 10번으로 수정하고 급여를 10%인상하세요
SELECT * FROM emp;
UPDATE emp SET dno='10', sal=sal*1.1
WHERE ename='김연아';

















