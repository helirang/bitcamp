--1) �Ϲ� ȭ�� ������ �����ϴ� �л��� ������ 4.5���� �������� �����ϼ���
SELECT * FROM student;
SELECT * FROM score;


UPDATE student
 set avr = avr*1.25
 where sno in (select sno from student join score using(sno) join course using(cno) where cname = '�Ϲ�ȭ��');
-- 100�� �ٲ� 

select sno, cname from student join score using(sno) join course using(cno) where cname = '�Ϲ�ȭ��';

UPDATE emp
 SET sal = (SELECT sal FROM emp WHERE ename='�迬��'),
     comm = (SELECT comm FROM emp WHERE ename='�ȿ���')
 WHERE ename='������';

--2) ȭ�а� ������ ���� �߿� ������ 3���� �̸��� ������ ��� 3��������
--   ������ ���� �̸� Ȯ���ϼ���
SELECT * FROM course;
SELECT * FROM professor;

UPDATE course
 set st_num = 3
 where pno in (SELECT pno from professor join course using (pno) where section = 'ȭ��');
 
 SELECT pno,cname,st_num from professor join course using (pno) where section = 'ȭ��';

--3) �л��� �⸻��� ������ ��� st_score ���̺� �����ϼ���.
--  st_score���̺� ������ ���� �ľ��� ������
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