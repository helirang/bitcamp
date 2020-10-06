--1) �۰� ������ �����ϴ� ������ �˻��Ѵ�
SELECT pname, cname
FROM course
NATURAL JOIN professor
where professor.pname = '�۰�';

--2) ȭ�� ���� ������ �����ϴ� ������ ����� �˻��Ѵ�
SELECT pname, cname
FROM professor
NATURAL JOIN course
where cname LIKE '%ȭ��%';

--3) ������ 2������ ����� �̸� �����ϴ� ������ �˻��Ѵ�
SELECT pname, cname, course.ST_NUM
FROM professor
NATURAL JOIN course
where st_num =2;

--4) ȭ�а� ������ �����ϴ� ������ �˻��Ѵ�
SELECT pname, section,cname
FROM professor
NATURAL JOIN course
where professor.SECTION = 'ȭ��';

--5) ȭ�а� 1�г� �л��� �⸻��� ������ �˻��Ѵ�
SELECT sname, syear, major , cname,result
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
where syear = 1
AND major = 'ȭ��';

--6) �Ϲ�ȭ�� ������ �⸻��� ������ �˻��Ѵ�
SELECT sno, cname,result
FROM score
JOIN course USING (cno)
where cname = '�Ϲ�ȭ��'
order by sno;

--7) ȭ�а� 1�г� �л��� �Ϲ�ȭ�� �⸻��� ������ �˻��Ѵ�
SELECT sname, syear, major , cname,result
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
where syear = 1
AND major = 'ȭ��'
AND cname = '�Ϲ�ȭ��';

SELECT *
FROM course, student, score;

--8) ȭ�а� 1�г� �л��� �����ϴ� ������ �˻��Ѵ�
SELECT DISTINCT cname, syear, major
FROM course
JOIN score USING (cno)
JOIN student USING (sno)
where syear = 1
AND major = 'ȭ��';