--1) 유공과와 생물과, 식영과 학생을 검색하라
select *
from student
where major = '생물' or major = '식영';

--2) 화학과가 아닌 학생중에 1학년 학생을 검색하라
select *
from student
where major != '생물' 
and syear = '1';

--3) 물리학과 3학년 학생을 검색하라
select *
from student
where major = '물리' 
and syear = '3';

--4) 평점이 2.0에서 3.0사이인 학생을 검색하라
select *
from student
where avr >= '2.0' 
and avr <= '3.0'
order by avr desc;

--5) 교수가 지정되지 않은 과목중에 학점이 3학점인 과목을 검색하라
select *
from COURSE;

SELECT * 
FROM course
where st_num = 3;

--6) 화학과 관련된 과목중 평점이 2학점 이하인 과목을 검색하라
SELECT * 
FROM course
where (cname like '%화학' or cname like '화학%')
and st_num <= 2;

--7) 화학과 정교수를 검색하라
select *
from professor;

SELECT * 
FROM professor
where section = '화학'
and orders = '정교수';

--8) 물리학과 학생중에 성이 사마씨인 학생을 검색하라
select *
from student;

select *
from student
where major = '물리'
and sname like '사마%';

--9) 부임일이 1995년 이전인 정교수를 검색하라
select *
from professor
where orders = '정교수'
and hiredate < '1995/01/01';


--10) 성과 이름이 각각 1글자인 교수를 검색하라
select *
from professor
where pname like '__';