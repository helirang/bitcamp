--���ĵ� ������ �˻�
--SELECT [DISTINCT | ALL] �÷�, �÷�, ...
--FROM ���̺�
--ORDER BY �÷� [ASC/DESC], �÷� [ASC/DESC] ...,

--1) ����� �̸��� �޿� ������ �˻��϶�
SELECT eno ���, ename �̸�, sal �޿�
FROM emp
ORDER BY sal DESC;

--2) ����� ����� �̸��� ���� ������ �˻��϶�
SELECT eno ���, ename �̸�
FROM emp
ORDER BY sal*12+NVL(comm,0) DESC;

SELECT eno ���, ename �̸�, sal*12+NVL(comm,0) ����
FROM emp
ORDER BY ���� DESC;

SELECT eno ���, ename �̸�, sal*12+NVL(comm,0) ����
FROM emp
ORDER BY 3 DESC;

--������ �̿��� ���� �˻�
--3) �������� ����� ������ �˻��Ѵ�
SELECT job ����, eno ���, ename �̸�, sal �޿�
FROM emp
ORDER BY ����;

--4) �� �μ����� ����� �޿��� �˻��Ѵ�.
--  �� �޿��� ���� �޴� ������� �˻��Ѵ�.
  
SELECT dno �μ���ȣ, eno ���, ename �̸�, sal �޿�
FROM emp
ORDER BY �μ���ȣ, �޿� DESC;

SELECT dno �μ���ȣ, eno ���, ename �̸�, sal �޿�
FROM emp
ORDER BY �μ���ȣ ASC, �޿� DESC;
