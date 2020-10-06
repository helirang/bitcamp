--���迬����
--AND, OR, NOT
--���� ������ ���� ������ �����ϰ� �Ѵ�.

--1) 20�� �μ� ����߿� �޿��� 2000�̻��� ����� �˻��϶�
SELECT *
FROM emp
WHERE dno='20'
AND sal >= 2000;

--2) 20�� �μ� ����߿� �޿��� 2000�̻��̰� �𵨸� ������ ����ϴ� ����� �˻��϶�
SELECT *
FROM emp
WHERE dno='20'
AND sal >= 2000
AND job='�м�';

--3) ������ �����?
--������ �켱����
-- NOT > AND > OR
-- ���迬���ڸ� ����� ���� ()�� ����ϴ� ���� �����ϴ�.
SELECT *
FROM emp
WHERE dno='10'
OR sal >= 1600
AND comm > 600;

SELECT *
FROM emp
WHERE (dno='10'
OR sal >= 1600)
AND comm > 600;

-- [ LIKE ������ ���� ] 
--SELECT �÷�, �÷�, ...
--FROM ���̺�
--WHERE �÷� LIKE '�� ���ڿ�'
--ORDER BY �÷�, �÷�, ...;
--[# WHERE ���� ���Ǵ� ���� ������ �񱳿������̴�
--  ���ڿ��� �Ϻθ����� �˻��ϴ� ��� ���ȴ�
--  ���ڿ����� ������ ã���ִ� �������̴�
--  �� ���� ���ϵ� ���ڸ� �̿��Ѵ�
--    '_' : �ݵ�� �� ���� ���ڸ� ��ü�Ѵ�
--   '%' : ���ڿ��� ��ü�Ѵ�(���ڰ� ���� ��쵵 �����Ѵ�)
--    ���ϵ� ���� ��ü�� �˻��ϴ� ��� ESCAPE ���� �̿��Ѵ�.

--��)
--'��%' - ��, ����, �����, �濵�а�, ...
--'%��' - ��, �ٰ�, ȭȮ��, ...
--'%��%' - ��, �达, ����, �ǻ�����,...
--'ȭ_' - 'ȭ'�� �����ϴ� �α��� �ܾ� / ȭ��, ȭ��, ȭ��...
--'__ȭ' - 'ȭ'�� ������ ������ �ܾ� / ����ȭ, �ش�ȭ, �ȭ...
--'_��_' - '��'�� ��� ���� ������ �ܾ� / ������, ������ ...
--'%��#%%' - ESCAPE '#'���� ������ ���, '��%'�� ���Ե� ���ڿ�
--'_#%_' - ESCAPE '#'���� ������ ���, '%��' ���c�� ������ �ܾ�

--4) �达���� ���� ���
SELECT *
FROM emp
WHERE ename LIKE '��%';

--5) �̸��� '�ϴ�'�� ���
SELECT *
FROM emp
WHERE ename LIKE '%�ϴ�';

--6) ���� �̸��� ���� �� ������ ���
SELECT *
FROM emp
WHERE ename LIKE '__';

--7) ���� �Ǽ��ϴ� ��
SELECT *
FROM emp
WHERE ename = '��%';

--8) �̸��� '%'���ڰ� ���Ե� ����� �˻�
SELECT *
FROM emp
WHERE ename = '%#%%' ESCAPE '#';