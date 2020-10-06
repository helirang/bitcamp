--1)student 테이블 구조를 검색해라(김근동)
DESC student;

--2)course 테이블 구조를 검색해라
DESC course;

--3)professor 테이블 구조를 검색해라
DESC professor;

--4)score 테이블 구조를 검색해라
Desc score;

--5) 모든 학생의 정보를 검색해라
SELECT * FROM student;

--7) 모든 과목의 정보를 검색해라
SELECT * FROM course;

--8) 기말고사 시험점수를 검색해라
SELECT sno,result FROM score;

--9) 학생들의 학과와 학년을 검색해라
SELECT sno, major, syear FROM student;

--10) 각 과목의 이름과 학점을 검색해라
SELECT cname, st_num FROM course;

--11) 모든 교수의 직위를 검색해라
SELECT pno, orders FROM PROFESSOR;
