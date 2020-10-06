--���� �˻�
--select �÷�, �÷�, ...
--FROM ���̺�
--WHERE ����
--ODRER BY �÷�;

--1) ����߿� �޿��� 4000�̻��� ����� �˻��϶�
SELECT eno ���, ename �̸�, sal �޿�
FROM emp
WHERE sal >= 4000;

--2) �̸��� '�迬��'�� ����� ������ �˻��϶�
SELECT *
FROM emp
WHERE ename = '�迬��';

--3) 10�� �μ��� ������ ����� ����� �˻��϶�
--dno�� Ÿ���� varchar2 �̹Ƿ�
--�˻��� �� �� '10'���� �˻��ؾ� �Ѵ�
--�׷��� �ʰ� ���ڷ� �˻��ϰ� �Ǹ�
--1�ึ�� ����ȯ�� �̷���� �� �񱳿����� �̷������ �ȴ�
--���� ������ ��뷮 ���̺��� ���
--�˻��ӵ��� ũ�� ���̳��� �ȴ�
SELECT *
FROM emp
WHERE dno != '10';

--4) ������ 30,000 �̻��� ����� �̸��� �˻��϶�
SELECT eno ���, ename �̸�, sal*12+NVL(comm,0) ����
FROM emp
WHERE sal*12+NVL(comm,0) >= 30000;

--���Ǻ񱳴� ������ �ȵȴ� / ������ ������ �ȴ�.
--SELECT eno ���, ename �̸�, sal*12+NVL(comm,0) ����
--FROM emp
--WHERE ���� >= 30000;

--5) ���ʽ��� 200 ������ ����� �˻��϶�
SELECT eno ���, ename �̸�, comm ���ʽ�
FROM emp
WHERE comm <= 200;

SELECT eno ���, ename �̸�, comm ���ʽ�
FROM emp
WHERE NVL(comm,0) <= 200;

--6) �Ի����� 1996�� ������ ����� ������ �˻��϶�
SELECT *
FROM emp
WHERE hdate > '1995/12/31'
ORDER BY hdate;

ALTER SESSION SET nls_date_format='YYYY/MM/DD';
ALTER SESSION SET nls_date_format='YY/MM/DD';

--7) ���ʽ� �÷��� �� ���� ����� �˻��϶�
SELECT *
FROM emp
WHERE comm IS null;

--8)  ���ʽ� �÷��� �� ���� �ƴ� ����� �˻��϶�
SELECT *
FROM emp
WHERE comm IS NOT null;