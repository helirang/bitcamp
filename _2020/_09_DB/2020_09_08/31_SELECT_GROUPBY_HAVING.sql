<�׷��Լ��� Having ��>
; �׷��Լ��� ������ ������ WHERE ���� ����� �� ����
  �׷��� HAVING ���� ����ؾ� �Ѵ�
  �Ϲ� �÷��� WHERE ���� ����Ѵ�

1) ���̺��� sal ���� ������ WHERE sal >= 3000�� ���� �����Ѵ�
 WHERE�� -> sal ����
SELECT sal
FROM emp
WHERE sal >= 3000;

--2) �μ��� ���
--GROUP BY -> ROUND(AVG(sal)) -> ROUND(AVG(sal)) >= 3000
SELECT ROUND(AVG(sal))
FROM emp
GROUP BY dno;

--3) ������ ���
SELECT ROUND(AVG(sal))
FROM emp
GROUP BY job;

--4) �μ��� �޿� ����� 3õ �̸��� �μ��� �μ���ȣ�� ��� �޿��� �˻��϶�
SELECT dno, ROUND(AVG(sal))
FROM emp
GROUP BY dno
HAVING AVG(sal) < 3000;

--5) �μ��� �ο����� ����ϼ���(��, ������ ������ �ƴ� �ο���)
--job �� �Ϲ� �÷� �����̹Ƿ� HAVING ���� ����� �� ����
SELECT dno, COUNT(*)
FROM emp
GROUP BY dno
HAVING job!='����';

--job �� WHERE ���� ������ �ο��ؾ� �Ѵ�
SELECT dno, COUNT(*)
FROM emp
WHERE job!='����'
GROUP BY dno;

--dno�� �Ϲ� �÷������� GROUP BY dno�� ����
--�׷��Լ��� ���̴� �Ϲ��÷��̹Ƿ�
--�̶��� HAVING ���� dno�� ����� �� �ִ�.
--�׷��� dno�� WHERE ���� ������ �ִ� ����
--��Ģ���� �Ѵ�

SELECT dno, COUNT(*)
FROM emp
GROUP BY dno
HAVING dno!='10';

SELECT dno, COUNT(*)
FROM emp
WHERE dno!='10'
GROUP BY dno;

--6) �׷� ��� �÷��� �˻�
--dno���� �׷��� ���̰� �ȴ�
SELECT dno, COUNT(*) �ο���
FROM emp
GROUP BY dno;

--GROUP BY dno, job ��
--dno���� ���̵� ���������� dno���� job �׷����� ������ ���
SELECT dno, job, COUNT(*) �ο���
FROM emp
GROUP BY dno, job
HAVING job!='����';

--�׷����� ������� �÷� ����� ���ϸ� �ؼ��ϱ� ����� ����� �ȴ�
--������ ��
SELECT dno, COUNT(*) �ο���
FROM emp
GROUP BY dno, job
HAVING job!='����';









