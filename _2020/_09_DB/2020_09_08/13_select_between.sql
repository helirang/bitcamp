--BETWEEN..AND ������
--SELECT �÷�, �÷�...
--FROM ���̺�
--WHERE �÷� BETWEEN ��1 AND ��2;
--; �÷� >= ��1 AND �÷� <= ��2; �÷� �� ��1�� ��2������ �����͸� �����Ѵ�;

--1) �޿��� 1000���� 2000�̳��� ���
SELECT *
FROM emp
WHERE sal BETWEEN 1000 AND 2000;

--2) 10��, 20�� �μ� ���

SELECT *
FROM emp
WHERE dno BETWEEN 10 AND 20;

--3) 1992�⿡�� 1996�� ���̿� �Ի��� ����� �˻��϶�
SELECT *
FROM emp
WHERE hdate BETWEEN '1992/01/01' AND '1996/12/31'
ORDER BY hdate;

ALTER SESSION SET nls_date_format='YYYY/MM/DD:HH24:MI:SS';

SELECT *
FROM emp
WHERE hdate BETWEEN '1992/01/01:00:00:00' 
AND '1996/12/31:23:59:59'
ORDER BY hdate;

--4) �޿��� 1000���� 2000 ������ ����� �˻��϶� // between�� ���� ���ڰ� �տ� �;��Ѵ�.
SELECT *
FROM emp
WHERE sal BETWEEN 1000
AND 2000;

--[IN ������]
--SELECT �÷�, �÷�
--FROM ���̺�
--WHERE �÷� IN (��1, ��2, ...)
--ORDER BY �÷�, ...;
--������ ���߿� ��ġ�ϴ� ���� �ϳ��� ������ �˻�

--5) �����̳� ȸ�� ������ ����ϴ� ���
SELECT *
FROM emp
WHERE job IN ('����', '����')
ORDER BY job;

--6) 10, 20�� �μ����
SELECT *
FROM emp
WHERE dno IN ('10','20')
ORDER BY  dno;