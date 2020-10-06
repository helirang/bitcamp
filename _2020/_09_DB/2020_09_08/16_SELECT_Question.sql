--1) 송강 교수가 강의하는 과목을 검색한다
SELECT pname, cname, course.pno
FROM professor p, course
WHERE p.PNO = course.pno AND p.PNAME = '송강';

--2) 화학 관련 과목을 강의하는 교수의 명단을 검색한다
SELECT c.pno, pname, cname
FROM professor p, course c
WHERE p.pno = c.pno AND cname like '%화학%'; 

--3) 학점이 2학점인 과목과 이를 강의하는 교수를 검색한다
SELECT c.pno, pname, cname, st_num
FROM professor p, course c
WHERE p.pno = c.pno and st_num = '2';

--4) 화학과 교수가 강의하는 과목을 검색한다
SELECT  c.pno, pname, section ,cname
FROM professor p, course c
WHERE p.pno = c.pno and section = '화학';

--5) 화학과 1학년 학생의 기말고사 성적을 검색한다
SELECT sc.sno,st.SNAME, sc.CNO, result
FROM student st, score sc
WHERE st.sno = sc.sno AND st.syear = '1';

--6) 일반화학 과목의 기말고사 점수를 검색한다
select sno, cname, result
FROM course c, score s
WHERE c.cno = s.cno AND cname = '일반화학';

--7) 화학과 1학년 학생의 일반화학 기말고사 점수를 검색한다
SELECT st.SNO, st.SNAME,st.SYEAR, st.MAJOR,cname, sc.RESULT
FROM student st, score sc, course c
WHERE st.sno = sc.sno AND c.CNO = sc.CNO and st.syear = '1' and c.CNAME = '일반화학' and major = '화학';

--8) 화학과 1학년 학생이 수강하는 과목을 검색한다
SELECT DISTINCT cname
FROM student st, score sc, course c
WHERE st.sno = sc.sno and st.syear = '1' and major = '화학'  and c.CNO = sc.CNO;

--9) 유기화학 과목의 평가점수가 F인 학생의 명단을 검색한다
SELECT st.sname, c.cname, sc.result
FROM student st, score sc, course c
WHERE st.sno = sc.sno AND c.CNO = sc.CNO and cname = '유기화학' and  sc.RESULT < 40
ORDER BY result desc;
