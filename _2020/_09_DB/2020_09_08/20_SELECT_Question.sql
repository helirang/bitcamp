--1) 송강 교수가 강의하는 과목을 검색한다
SELECT pname, cname
FROM course
NATURAL JOIN professor
where professor.pname = '송강';

--2) 화학 관련 과목을 강의하는 교수의 명단을 검색한다
SELECT pname, cname
FROM professor
NATURAL JOIN course
where cname LIKE '%화학%';

--3) 학점이 2학점인 과목과 이를 강의하는 교수를 검색한다
SELECT pname, cname, course.ST_NUM
FROM professor
NATURAL JOIN course
where st_num =2;

--4) 화학과 교수가 강의하는 과목을 검색한다
SELECT pname, section,cname
FROM professor
NATURAL JOIN course
where professor.SECTION = '화학';

--5) 화학과 1학년 학생의 기말고사 성적을 검색한다
SELECT sname, syear, major , cname,result
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
where syear = 1
AND major = '화학';

--6) 일반화학 과목의 기말고사 점수를 검색한다
SELECT sno, cname,result
FROM score
JOIN course USING (cno)
where cname = '일반화학'
order by sno;

--7) 화학과 1학년 학생의 일반화학 기말고사 점수를 검색한다
SELECT sname, syear, major , cname,result
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
where syear = 1
AND major = '화학'
AND cname = '일반화학';

SELECT *
FROM course, student, score;

--8) 화학과 1학년 학생이 수강하는 과목을 검색한다
SELECT DISTINCT cname, syear, major
FROM course
JOIN score USING (cno)
JOIN student USING (sno)
where syear = 1
AND major = '화학';