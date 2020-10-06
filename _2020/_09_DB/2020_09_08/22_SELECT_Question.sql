--1) 각 과목의 과목명과 담당 교수의 교수명을 검색하라
SELECT pname, cname
FROM course
RIGHT JOIN professor USING(pno);

--2) 화학과 학생의 기말고사 성적을 모두 검색하라
SELECT sname, cno, result
FROM student
RIGHT JOIN score USING(sno)
order by sname;

--3) 유기화학과목 수강생의 기말고사 시험점수를 검색하라
SELECT sno, sname,cname, result
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
WHERE cname = '유기화학';

--4) 화학과 학생이 수강하는 과목을 담당하는 교수의 명단을 검색하라
SELECT DISTINCT pname, cname
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
JOIN professor USING (pno)
WHERE major = '화학';

--5) 모든 교수의 명단과 담당 과목을 검색한다
SELECT pname, cname
FROM professor
LEFT JOIN course USING (pno);

--6) 모든 교수의 명단과 담당 과목을 검색한다(단 모든 과목도 같이 검색한다)
SELECT pname, cname
FROM professor
FULL JOIN course USING (pno);