--<단일 행 함수를 이용하세요>
--1) 교수들이 부임한 달에 근무한 일수는 몇 일인지 검색하세요
SELECT pno, pname, LAST_DAY(HIREDATE)-HIREDATE+1 "부임월 근무일"
FROM professor;

--2) 교수들의 오늘까지 근무한 주가 몇 주인지 검색하세요
SELECT * FROM PROFESSOR;

SELECT PNO, PNAME, trunc((trunc(sysdate, 'DD') - trunc(HIREDATE, 'DD')+1)/7) "오늘까지 일한 주" FROM PROFESSOR;

--3) 1991년에서 1995년 사이에 부임한 교수를 검색하세요
SELECT * FROM professor where HIREDATE >= '91/01/01' and HIREDATE < '96/01/01';

SELECT * FROM professor where trunc(HIREDATE,'yy') >= '91/01/01' and  trunc(HIREDATE,'yy') < '96/01/01';

--4) 학생들의 4.5 환산 평점을 검색하세요(단 소수 이하 둘째자리까지)
SELECT * FROM student;

select sno, sname, syear, major, round(avr*(9/8),2) from student;