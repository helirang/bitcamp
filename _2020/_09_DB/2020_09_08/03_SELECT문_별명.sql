--������ �̿��� �˻�
--SELECT �÷� as "����,�÷� as "����,...
--FROM ���̺�;

1) �� ����� �̸��� �������� �˻��϶�
SELECT eno ���, ename �̸�, job ����
FROM emp;

SELECT eno as ���, ename as �̸�, job as ����
FROM emp;

SELECT eno as "���", ename as "�̸�", job as "����"
FROM emp;

SELECT eno "�� ��", ename "�� ��", job "�� ��"
FROM emp;

--2) �� ����� �޿��� 1�Ⱓ �����ϴ� �޿��� �˻��϶�
SELECT eno ���, ename �̸�, sal*12 "�Ⱓ �޿�"
FROM emp;

--3)�� ����� ������ �˻��϶�(12���� �޿� + ���ʽ�(comm))
SELECT eno ���, ename �̸�, sal �޿�, comm ���ʽ�, sal*12+comm ����
FROM emp;

--�����ͺ��̽������� 0�� null�� ���� �ٸ���
--0�� ���� 0�� ��
--null�� ���� �� �� ����/ ���� �������� �ʾҴ��� �ǹ��̴�.
--�� ��� 2������ ����� �����ؾ� �Ѵ�
--  a) sal*12+comm���� �����ؼ� null �÷��� ���ԵǾ�����,
--   ����� null�� ������ ����
--  b) sal*12+NVL(comm,0)���� �����ؼ� null�� 0���� ġȯ���� ������ ����

--4) ����� ������ �˻��Ѵ� (��, null�� 0���� ġȯ�Ѵ�)

SELECT eno ���, ename �̸�, sal �޿�, comm ���ʽ�, sal*12+NVL(comm,0) ����
FROM emp;