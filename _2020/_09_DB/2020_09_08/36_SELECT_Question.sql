--1) 화학과 학생과 평점이 동일한 학생들을 검색하세요
SELECT * FROM STUDENT;

SELECT sname, major, avr
FROM student
where major != '화학'
and avr in ( SELECT avr FROM student where major = '화학')
order by avr;

--2) 화학과 교수와 부임일이 같은 직원을 검색하세요
SELECT * FROM professor;

SELECT pno, pname, section, hiredate 
FROM professor
where section != '화학'
and hiredate in (SELECT hiredate FROM professor where section = '화학');

--3) 화학과 학생과 같은 학년에서 평점이 동일한 학생들을 검색하세요
SELECT sname, major, syear, avr
FROM student
where major != '화학'
and (avr, syear) in ( SELECT avr, syear FROM student where major = '화학')
order by avr;