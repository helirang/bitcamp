--1) 학생중에 동명이인을 검색한다
SELECT st1.sno, st1.sname 학생1
FROM student st1, student st2
WHERE st1.sno != st2.sno and st1.sname = st2.sname
order by st1.sname;

--2) 전체 교수 명단과 교수가 담당하는 과목의 이름을 학과 순으로 검색한다
SELECT pname, p.SECTION, cname
FROM professor p , course c
WHERE p.pno = c.pno(+)
ORDER BY p.SECTION;

--3) 이번 학기 등록된 모든 과목과 담당 교수의 학점 순으로 검색한다 // 먼 소리지
SELECT pname, p.SECTION, cname, st_num
FROM professor p , course c
WHERE p.pno(+) = c.pno
ORDER BY c.ST_NUM desc;
