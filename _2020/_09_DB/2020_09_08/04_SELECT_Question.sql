--1) �� �л��� ������ �˻��϶�(������ ���)
SELECT SNAME �̸�, avr ���� FROM student;

--2) �� ������ �������� �˻��϶�(������ ���)
SELECT cname ����, st_num ���� FROM course;

--3) �� ������ ������ �˻��϶�(������ ���)
SELECT pname �̸�, SECTION �а�, ORDERS ���� FROM PROFESSOR;

--4) �޿��� 10%�λ����� �� ���� ���޵Ǵ� �޿��� �˻��϶�(������ ���)
SELECT ename �̸�, job �μ�, sal ����, sal*1.1 "10%�λ� ����" FROM EMP;

--5) ���� �л��� ��� ������ 4.0�����̴�. �̸� 4.5�������� ȯ���ؼ� �˻��϶�(������ ���)
SELECT sname �̸�, syear �г�, major �а�, avr "4.0����", round(avr*1.125,2) "4.5����" FROM student;