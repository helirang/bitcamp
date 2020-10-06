--1) 3�г� �л��� �а��� ���� ��հ� �л� �� ������ �˻��ϼ���
SELECT major �а�, round(avg(avr),2) "���� ���", round(VARIANCE(avr)) �л�,round(STDDEV(avr),2) ����
FROM STUDENT
GROUP BY MAJOR;

SELECT * FROM student;
--2) ȭ�а� �г⺰ ��� ������ �˻��ϼ���
SELECT syear, major,  round(avg(avr),2) "���� ���"
FROM STUDENT
where major = 'ȭ��'
GROUP BY syear, major
order by syear;

--3) �� �л��� �⸻��� ����� �˻��ϼ���
SELECT * FROM score;

SELECT sno, round(avg(result),2) "���� ���"
FROM score
GROUP BY sno
order by sno;

--4) �� �а��� �л� ���� �˻��ϼ���
SELECT * FROM student;

SELECT MAJOR, COUNT(MAJOR) �л���
FROM student
GROUP BY MAJOR;

--5) ȭ�а��� �����а� �л� 4.5 ȯ�� ������ ����� ���� �˻��ϼ���
SELECT major,  round(avg(avr)*9/8,2) "4.5 ���� ���"
FROM STUDENT
where major = 'ȭ��' or major = '����'
GROUP BY major
order by major;

--6) �������� 10�� �̻� �� ���޺�(������, ������, �α���) ������ ���� 
--   �˻��ϼ���
ALTER SESSION SET nls_date_format='YYYY/MM/DD';
SELECT * FROM professor;

SELECT ORDERS, COUNT(ORDERS) "���� 10�� �̻� ����"
FROM PROFESSOR
WHERE trunc(MONTHS_BETWEEN(sysdate, hiredate)/12+1) > 9
GROUP BY ORDERS;

--7) ����� ȭ���� ���Ե� ������ ������ ������ �˻��ϼ���
SELECT * FROM COURSE;

SELECT count(cname) "ȭ�� ����", SUM(ST_NUM) "���� ����"
FROM COURSE
WHERE CNAME LIKE '%ȭ��%';

--8) ȭ�а� �л����� �⸻��� ������ ���������� �˻��ϼ���
SELECT * FROM student;
SELECT * FROM score;

SELECT * 
FROM score
JOIN student using(sno);

--9) �а��� �⸻��� ����� ���������� �˻��ϼ���