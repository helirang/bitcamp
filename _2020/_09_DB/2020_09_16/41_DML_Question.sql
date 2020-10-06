--1) 일반 화학 과목을 수강하는 학생의 성적을 4.5만점 기준으로 수정하세요
SELECT * FROM student;
SELECT * FROM score;


UPDATE student
 set avr = avr*1.25
 where sno in (select sno from student join score using(sno) join course using(cno) where cname = '일반화학');
-- 100개 바뀜 

select sno, cname from student join score using(sno) join course using(cno) where cname = '일반화학';

UPDATE emp
 SET sal = (SELECT sal FROM emp WHERE ename='김연아'),
     comm = (SELECT comm FROM emp WHERE ename='안영숙')
 WHERE ename='윤고은';

--2) 화학과 교수의 과목 중에 학점이 3학점 미만인 과목을 모두 3학점으로
--   수정한 다음 이를 확인하세요
SELECT * FROM course;
SELECT * FROM professor;

UPDATE course
 set st_num = 3
 where pno in (SELECT pno from professor join course using (pno) where section = '화학');
 
 SELECT pno,cname,st_num from professor join course using (pno) where section = '화학';

--3) 학생의 기말고사 성적을 모두 st_score 테이블에 저장하세요.
--  st_score테이블 구조는 직접 파악해 보세요
SELECT * FROM st_score ORDER BY SNO;
SELECT DISTINCT CNO FROM score ORDER BY CNO;
SELECT * FROM COURSE;
DESC st_score;

DELETE from st_score;

INSERT INTO st_score (sno, cno,result)
 SELECT sno, cno, result
 FROM score;
 
 INSERT INTO st_score(sno,sname,major,syear,cno,cname,result)
 SELECT sno,sname,major,syear,cno,cname,result
 FROM (score
 FULL JOIN student using(sno)
 FULL join course using(cno));
 
-- FULL JOIN dept USING(dno);