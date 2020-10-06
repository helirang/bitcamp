--<ON ���� �̿��� ����>
--SELECT ���̺�1.�÷�, ..., ���̺�2.�÷�, ...
--FROM ���̺�1
--JOIN ���̺�2 ON ��������
--WHERE �˻�����;
--a) ��� ������ ������ ǥ���� �� �ִ�
--  (�/�� ����)
  
--1) �� ����� �ٹ��μ��� �˻��Ѵ�
SELECT eno ���, ename �̸�, d.dno �μ���ȣ, dname �μ���
FROM emp e
JOIN dept d ON e.dno=d.dno;

SELECT eno, ename, d.dno, dname
FROM emp e, dept d
WHERE e.dno=d.dno;

SELECT eno, ename, dno, dname
FROM emp
NATURAL JOIN dept;

SELECT eno, ename, dno, dname
FROM emp
JOIN dept USING(dno);

SELECT PNO, PNAME FROM PROFESSOR JOIN COURSE USING(PNO);

SELECT eno, ename, d.dno, dname
FROM emp e
JOIN dept d ON e.dno=d.dno;


--2) ���� ������ ����ϴ� ����� �޿� ����� �˻��Ѵ�.
SELECT eno ���, ename �̸�, job ����, grade �޿����
FROM emp
JOIN salgrade ON sal BETWEEN losal AND hisal
WHERE job='����';

--3) ������ �μ���� �޿� ����� �˻��Ѵ�
SELECT eno ���, ename �̸�, dname �μ���, grade �޿����
FROM emp
JOIN dept USING(dno)
JOIN salgrade ON sal BETWEEN losal AND hisal;

SELECT eno ���, ename �̸�, dname �μ���, grade �޿����
FROM emp e
JOIN dept d ON e.dno=d.dno
JOIN salgrade ON sal BETWEEN losal AND hisal;

<�¿� �ܺ� ����(Left Right Outer Join)>
+ ��ȣ�� �̿��ϴ� �ܺ������� �ٸ� ǥ����
������ �ܺ������� ���ʿ��� +�� ���̴µ�
���⿡���� ��� +�� �߰��� �Ͱ� ������ ǥ���� �����ϴ�
SELECT ���̺�1.�÷�, ... ���̺�2.�÷�, ...
FROM ���̺�1
[LEFT|RIGHT|FULL] [OUTER] JOIN ���̺�2 [ON ��������| USING(�����÷�)]
WHERE �˻�����;
a) LEFT : '���̺�1'�� ���� ���̺��̶� �θ��� ���� ���̺� �������ǰ�
          ��ġ���� ���� �൵ �˻��� �����Ѵ�.
b) RIGHT : '���̺�2'�� ������ ���̺��̶� �θ��� ������ ���̺� �������ǰ�
          ��ġ���� ���� �൵ �˻��� �����Ѵ�.
C) FULL : ���� ���̺� ��ο��� ���� ���ǿ� ��ġ���� ���� ���� �˻���
          �����Ѵ�. ���� (+)��ȣ�� �̿��� �ܺ��������δ� �Ұ����� ǥ���̴�
d) ON ���̳� USING ���� ��� ����� �� �ִ�.

4) ����� �̸��� �Ҽ� �μ��� �˻��϶�
SELECT eno ���, ename �̸�, dno �μ���ȣ, dname �μ���
FROM emp
RIGHT JOIN dept USING(dno);

SELECT eno ���, ename �̸�, dno �μ���ȣ, dname �μ���
FROM emp
RIGHT OUTER JOIN dept USING(dno);

SELECT eno ���, ename �̸�, dno �μ���ȣ, dname �μ���
FROM emp
LEFT JOIN dept USING(dno);

SELECT eno ���, ename �̸�, dno �μ���ȣ, dname �μ���
FROM emp
FULL JOIN dept USING(dno);















