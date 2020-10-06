<�ڿ� ����(Natural Join)>
SELECT �÷�, ...
FROM ���̺�1
NATURAL JOIN ���̺�2
WHERE �˻�����;
a) ������ �̸�/Ÿ���� �÷��� ������ �� 
   ���������� ������� �ʾƵ�
   �ڵ����� ã�Ƽ� ������ ���ش�
b) ���� �÷��� �ݵ�� �ϳ� �����ؾ� �Ѵ�
   �� �̻��� ���� ����� �� ����
   �̷� ���� USING ���� ����� �� �ִ�.
  
--1) �ڿ� �������� �� ����� �ٹ� �μ��� �˻��϶�
SELECT eno ���, ename �̸�, dno �μ���ȣ, dname �μ���
FROM emp
NATURAL JOIN dept;

SELECT eno ���, ename �̸�, d.dno �μ���ȣ, dname �μ���
FROM emp e, dept d
WHERE e.dno=d.dno;

--2) '����'���� �ٹ��ϴ� ������ ����� �˻��϶�(�μ���ȣ�� �μ��� �˻�)
SELECT loc �ٹ�ó, dno �μ���ȣ, dname �μ���,
       eno ���, ename �̸�
FROM emp
NATURAL JOIN dept
WHERE loc='����';

SELECT loc �ٹ�ó, dno �μ���ȣ, dname �μ���,
       eno ���, ename �̸�
FROM dept
NATURAL JOIN emp
WHERE loc='����';
   
<USING ��>
SELECT �÷�, �÷�, ...
FROM ���̺�1
JOIN ���̺�2 USING (���� �÷�)
WHERE �˻�����;
   
--3) �ڿ� �������� �� ����� �ٹ� �μ��� �˻��϶�
SELECT eno ���, ename �̸�, dno �μ���ȣ, dname �μ���
FROM emp
JOIN dept USING (dno);

--4)'����'���� �ٹ��ϴ� ������ ����� �˻��϶�(�μ���ȣ�� �μ��� �˻�)
SELECT loc �ٹ�ó, dno �μ���ȣ, dname �μ���,
       eno ���, ename �̸�
FROM dept
JOIN emp USING(dno)
WHERE loc='����';

--5) ȭ�а� 1�г� �л����� ����ȭ�� ������ �˻��϶�
SELECT sno, sname, cname, result
FROM student
JOIN SCORE USING (SNO)
JOIN course USING (CNO)
WHERE major='ȭ��'
AND syear = 1
AND cname = '����ȭ��'
ORDER BY result;

SELECT sno, sname, cname, result
FROM student
NATURAL JOIN SCORE
NATURAL JOIN course
WHERE major='ȭ��'
AND syear = 1
AND cname = '����ȭ��'
ORDER BY result;

SELECT s.sno, sname, cname, result
FROM student s, course c, score r
WHERE s.sno=r.sno 
AND c.cno=r.cno
AND major='ȭ��'
AND syear = 1
AND cname = '����ȭ��'
ORDER BY result;
   
   
   
   
   
   
   
   
   
   
   
   
   