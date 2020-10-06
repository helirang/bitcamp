--1) 성적순으로 학생의 이름을 검색하라
SELECT avr 성적, sname 이름
FROM student
ORDER BY 성적 DESC;

--2) 학과별 성적순으로 학생의 정보를 검색하라
SELECT *
FROM student
ORDER BY major,avr DESC;

--3) 학년별 성적순으로 학생의 정보를 검색하라
SELECT syear 학년, avr 성적
FROM student
ORDER BY 학년 DESC,성적 DESC;

--4) 학과별 학년별로 학생의 정보를 성적순으로 검색하라
SELECT *
FROM student
ORDER BY  major , syear  DESC, avr  DESC;

SELECT major 학과, syear 학년, avr 성적
FROM student
ORDER BY major, 학년 DESC,성적 DESC;

--5) 학점순으로 과목 이름을 검색하라
SELECT st_num 학점, cname "과목 이름"
FROM course
ORDER BY 학점 DESC;

--6) 각 학과별로 교수의 정보를 검색하라
select *
from PROFESSOR;

SELECT section 학과, pname 교수
FROM professor
ORDER BY 학과 DESC;

--7) 지위별로 교수의 정보를 검색하라
SELECT orders 지위, pname 교수
FROM professor
ORDER BY 지위 desc;

--8) 각 학과별로 교수의 정보를 부임일자 순으로 검색하라
SELECT *
FROM professor
ORDER BY section, hiredate;
