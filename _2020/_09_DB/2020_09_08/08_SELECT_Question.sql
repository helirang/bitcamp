--1) ���������� �л��� �̸��� �˻��϶�
SELECT avr ����, sname �̸�
FROM student
ORDER BY ���� DESC;

--2) �а��� ���������� �л��� ������ �˻��϶�
SELECT *
FROM student
ORDER BY major,avr DESC;

--3) �г⺰ ���������� �л��� ������ �˻��϶�
SELECT syear �г�, avr ����
FROM student
ORDER BY �г� DESC,���� DESC;

--4) �а��� �г⺰�� �л��� ������ ���������� �˻��϶�
SELECT *
FROM student
ORDER BY  major , syear  DESC, avr  DESC;

SELECT major �а�, syear �г�, avr ����
FROM student
ORDER BY major, �г� DESC,���� DESC;

--5) ���������� ���� �̸��� �˻��϶�
SELECT st_num ����, cname "���� �̸�"
FROM course
ORDER BY ���� DESC;

--6) �� �а����� ������ ������ �˻��϶�
select *
from PROFESSOR;

SELECT section �а�, pname ����
FROM professor
ORDER BY �а� DESC;

--7) �������� ������ ������ �˻��϶�
SELECT orders ����, pname ����
FROM professor
ORDER BY ���� desc;

--8) �� �а����� ������ ������ �������� ������ �˻��϶�
SELECT *
FROM professor
ORDER BY section, hiredate;
