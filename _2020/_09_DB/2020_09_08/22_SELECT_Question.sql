--1) �� ������ ������ ��� ������ �������� �˻��϶�
SELECT pname, cname
FROM course
RIGHT JOIN professor USING(pno);

--2) ȭ�а� �л��� �⸻��� ������ ��� �˻��϶�
SELECT sname, cno, result
FROM student
RIGHT JOIN score USING(sno)
order by sname;

--3) ����ȭ�а��� �������� �⸻��� ���������� �˻��϶�
SELECT sno, sname,cname, result
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
WHERE cname = '����ȭ��';

--4) ȭ�а� �л��� �����ϴ� ������ ����ϴ� ������ ����� �˻��϶�
SELECT DISTINCT pname, cname
FROM student
JOIN score USING (sno)
JOIN course USING (cno)
JOIN professor USING (pno)
WHERE major = 'ȭ��';

--5) ��� ������ ��ܰ� ��� ������ �˻��Ѵ�
SELECT pname, cname
FROM professor
LEFT JOIN course USING (pno);

--6) ��� ������ ��ܰ� ��� ������ �˻��Ѵ�(�� ��� ���� ���� �˻��Ѵ�)
SELECT pname, cname
FROM professor
FULL JOIN course USING (pno);