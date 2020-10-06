--<����ΰ� ������>
--SELECT ���̺�1.�÷�, ���̺�2.�÷�, ...
--FROM ���̺�1, ���̺� 2,...
--WHERE ��������
--AND �Ϲ�����;
--  a) �������ǿ� '='�� ����ϴ� ���� �����
--     �ε�ȣ�� ����ϴ� ���� �������̶� �Ѵ�.

--1) �� ����� �ٹ� �μ��� �˻��Ѵ�
SELECT emp.eno ���, emp.ename �̸�, 
      dept.dno �μ���ȣ, dept.dname �μ���
FROM emp, dept
WHERE dept.dno = emp.dno;

--2) �λ꿡�� �ٹ��ϴ� ������ ����� �˻��Ѵ�(�μ���ȣ�� �μ��� �˻�)
SELECT ename,dname, loc, dept.dno
FROM emp, dept
WHERE emp.dno = dept.dno;

SELECT d.dno,ename,dname, loc
FROM emp e, dept d
WHERE e.dno = d.dno;

--3) �� ������ �޿� ����� �˻��϶� 
-- �� ���� // �ٸ� ���̺��� ���� ������ ���� �����ؼ� �������� ���� ���
SELECT eno ���, ename �̸�, sal �޿�, grade ���
FROM emp, salgrade
WHERE sal BETWEEN losal AND hisal;

SELECT eno ���, ename �̸�, sal �޿�, grade ���
FROM emp, salgrade
WHERE sal>= losal AND sal <= hisal
ORDER BY ���;

--4) �� ������ �޿��� 10% �λ��ϴ� ��� �޿� ����� �˻��Ѵ�
SELECT eno ���, ename �̸�, sal*1.1 "�λ�� �޿�", grade ���
FROM emp, salgrade
WHERE sal*1.1 BETWEEN losal AND hisal
ORDER BY ���;

--5) �߸��� ���� ����
--���������� ���Եǰų� �߸� ������ ����ϸ�
--��� ���� 1:1�� ������ �߸��� �����(Catersian Product)�� ��� �ȴ�.
--���� ����(Cross Join)�� �Ϲ������� �߸��� ����̴�.
--dept�� 7�� ���
--emp�� 15�� ���� ��� 1:1 ������ ���̴�

SELECT d.dno, dname, e.eno, ename
FROM dept d, emp e;