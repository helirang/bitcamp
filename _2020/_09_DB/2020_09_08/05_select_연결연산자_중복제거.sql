--���� �������� ���
--SELECT �÷� || '���ͷ�' ||...
--FROM ���̺�;

1) ����� �̸��� �޿� �Ǵ� ������ �Բ� �˻��϶�
SELECT ename||sal
FROM emp;

SELECT ename||' '||sal "�̸� �޿�"
FROM emp;

SELECT ename||'�� ������ '|| job||'�Դϴ�.' ������
FROM emp;

--2) �����ؾ� �� ������ // ���� �����ڰ� +���� �켱������ ����.
SELECT ename|| ' ' || sal+100
FROM emp;

SELECT ename|| ' ' || (sal+100)
FROM emp;

--�ߺ�����
--SELECT [DITINCT | ALL] �÷�, �÷�, ...
--FROM ���̺�

3) �������� �������� � ���� ������ �˻�(������ ������ �˻��϶�)
SELECT job ����
FROM emp;

SELECT ALL job ����
FROM emp;

SELECT DISTINCT job ����
FROM emp;