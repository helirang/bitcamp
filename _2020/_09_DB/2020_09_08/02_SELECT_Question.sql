--1)student ���̺� ������ �˻��ض�(��ٵ�)
DESC student;

--2)course ���̺� ������ �˻��ض�
DESC course;

--3)professor ���̺� ������ �˻��ض�
DESC professor;

--4)score ���̺� ������ �˻��ض�
Desc score;

--5) ��� �л��� ������ �˻��ض�
SELECT * FROM student;

--7) ��� ������ ������ �˻��ض�
SELECT * FROM course;

--8) �⸻��� ���������� �˻��ض�
SELECT sno,result FROM score;

--9) �л����� �а��� �г��� �˻��ض�
SELECT sno, major, syear FROM student;

--10) �� ������ �̸��� ������ �˻��ض�
SELECT cname, st_num FROM course;

--11) ��� ������ ������ �˻��ض�
SELECT pno, orders FROM PROFESSOR;
