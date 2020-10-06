--1) ������ 3.0���� 4.0������ �л��� �˻��϶�
SELECT *
FROM student
WHERE avr BETWEEN '3.0' AND '4.0'
ORDER BY avr desc;

--2) 1994�⿡�� 1995����� ������ ������ ����� �˻��϶�
SELECT *
FROM professor
WHERE hiredate between '1994/01/01:00:00:00' and '1995/12/31:23:59:59'
ORDER BY hiredate;

--3) ȭ�а��� �����а�, �����а� �л��� �˻��϶�
SELECT *
FROM student
WHERE major IN ('ȭ��','����','����')
ORDER BY major;

--4) �������� �������� �˻��϶�
SELECT *
FROM professor
WHERE orders IN ('������', '������')
ORDER BY orders;

--5) �������� 1����, 2������ ������ �˻��϶�
SELECT *
FROM course
WHERE st_num IN ('1','2')
ORDER BY st_num;

--6) 1, 2�г� �л� �߿� ������ 2.0���� 3.0������ �л��� �˻��϶�
SELECT *
FROM student
WHERE syear IN ('1','2') 
AND avr BETWEEN '2.0' AND '3.0'
ORDER BY syear DESC;

--7) ȭ��, �����а� �л� �� 1, 2 �г� �л��� ���������� �˻��϶�
SELECT *
FROM student
WHERE major IN ('ȭ��', '����')
AND syear IN ('1','2')
ORDER BY avr DESC;