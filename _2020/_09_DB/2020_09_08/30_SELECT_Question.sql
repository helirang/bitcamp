--1) 3학년 학생의 학과별 평점 평균과 분산 및 편차를 검색하세요
SELECT major 학과, round(avg(avr),2) "평점 평균", round(VARIANCE(avr)) 분산,round(STDDEV(avr),2) 편차
FROM STUDENT
GROUP BY MAJOR;

SELECT * FROM student;
--2) 화학과 학년별 평균 평점을 검색하세요
SELECT syear, major,  round(avg(avr),2) "평점 평균"
FROM STUDENT
where major = '화학'
GROUP BY syear, major
order by syear;

--3) 각 학생별 기말고사 평균을 검색하세요
SELECT * FROM score;

SELECT sno, round(avg(result),2) "평점 평균"
FROM score
GROUP BY sno
order by sno;

--4) 각 학과별 학생 수를 검색하세요
SELECT * FROM student;

SELECT MAJOR, COUNT(MAJOR) 학생수
FROM student
GROUP BY MAJOR;

--5) 화학과와 생물학과 학생 4.5 환산 평점의 평균을 각각 검색하세요
SELECT major,  round(avg(avr)*9/8,2) "4.5 평점 평균"
FROM STUDENT
where major = '화학' or major = '생물'
GROUP BY major
order by major;

--6) 부임일이 10년 이상 된 직급별(정교수, 조교수, 부교수) 교수의 수를 
--   검색하세요
ALTER SESSION SET nls_date_format='YYYY/MM/DD';
SELECT * FROM professor;

SELECT ORDERS, COUNT(ORDERS) "부임 10년 이상 교수"
FROM PROFESSOR
WHERE trunc(MONTHS_BETWEEN(sysdate, hiredate)/12+1) > 9
GROUP BY ORDERS;

--7) 과목명에 화학이 포함된 과목의 학점수 총합을 검색하세요
SELECT * FROM COURSE;

SELECT count(cname) "화학 과목", SUM(ST_NUM) "총합 학점"
FROM COURSE
WHERE CNAME LIKE '%화학%';

--8) 화학과 학생들의 기말고사 성적을 성적순으로 검색하세요
SELECT * FROM student;
SELECT * FROM score;

SELECT * 
FROM score
JOIN student using(sno);

--9) 학과별 기말고사 평균을 성적순으로 검색하세요