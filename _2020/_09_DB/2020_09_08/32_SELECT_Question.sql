--1) ȭ�а��� �����ϰ� �л����� ���� ����� �˻��ϼ���
SELECT * FROM student;

SELECT major, round(AVG(avr),2)
FROM student
GROUP BY major
having major != 'ȭ��';

--2) ȭ�а��� ������ �� �а��� ��� ���� �߿� ������ 2.0 �̻��� ������ �˻��ϼ���
SELECT major, round(AVG(avr),2)
FROM student
where  major != 'ȭ��'
GROUP BY major
having round(AVG(avr),2) >= 2;

--3) �⸻��� ����� 60�� �̻��� �л��� ������ �˻��ϼ���(�й��� �⸻��� ���)
SELECT * FROM score;

SELECT sno �й�,  round(avg(result),2) �⸻���
FROM score
GROUP BY sno
having round(avg(result),2) >= 60;

--4) ���� �������� 3���� �̻��� ������ ������ �˻��ϼ���(������ȣ, �̸��� ��� ������)
 SELECT * FROM course;
 SELECT * FROM professor;
 
 SELECT pno, pname, cname, st_num
 FROM PROFESSOR
 JOIN COURSE using (pno)
 WHERE st_num >= 3;

--<������ ����>
--1) �׻� �����ϵ��� ����� ��(�̼����� ����)
--   �̼Ҵ� ������ �ſ� ������
--   (���� ��Ȳ���� ������ ã������ ����ϴ� ���)
--2) �����ϰ� �����ϴ� ����� �� ��(�ݼ�)
--3) ���� �Ͼ ��(����)
--4) �ǰ��� ��(����)
--5) �׻� ȣ����� ���� ��(���, ����)