<���� ���� - ���� ��, ���� ��>
a) ���� �� : ���� �� ���� �˻�
   ���� �� ���������� ������ ������ ��� �����ڰ� �ٸ���
   ���� ���� =, != �� ����Ѵ�
   ���� ���� IN  : �˻��� ���߿� �ϳ��� ��ġ�ϸ� ��
            ANY : �˻��� ���߿� ������ �ϳ� �̻� ������ ��
            ALL : �˻��� ����� ��� ���ǿ� ������ ��
            
--1) 20�� �μ������ ������ �����ڷκ��� �����޴� ����� �˻��ϼ���
SELECT *
FROM emp
WHERE mgr IN (SELECT mgr
              FROM emp
              WHERE dno='20')
AND dno!='20';

--2) 10�� �μ����麸�� �޿��� ���� ����� �˻��ϼ���
SELECT eno, ename, dno
FROM emp
WHERE sal < ALL(SELECT sal
                FROM emp
                WHERE dno='10')
AND dno!='10';

SELECT eno, ename, dno
FROM emp
WHERE sal < (SELECT MIN(sal)
                FROM emp
                WHERE dno='10')
AND dno!='10';

--3) 20�� �μ������ ���ʽ��� ���� ����� �˻��ϼ���
SELECT eno, ename, dno, comm
FROM emp
WHERE comm IN (SELECT comm
               FROM emp
               WHERE dno='20')
AND dno!='20';

SELECT eno, comm
FROM emp
WHERE dno='20';

--null �� ���Ե� ���� 0���� ġȯ���� ��������
SELECT eno, ename, dno, comm
FROM emp
WHERE NVL(comm, 0) IN (SELECT NVL(comm, 0)
               FROM emp
               WHERE dno='20')
AND dno!='20';


<���� �� ��������>
; ���� �� �÷� �׸��� �˻��Ǵ� ��
; IN �����ڸ� ����Ѵ�

--4)���ϴð� ������ �������� ������ �����鼭 ������ ���� ����� �˻��ϼ���
--���߿��� ��� IN�� ����ϸ� ��� ���� �����Ǵ� ��츦 ã�´�
SELECT eno, ename, mgr, job
FROM emp
WHERE (mgr, job) IN (SELECT mgr, job
                     FROM emp
                     WHERE ename='���ϴ�');

SELECT eno, ename, mgr, job
FROM emp
WHERE (mgr, job) IN (SELECT mgr, job
                     FROM emp
                     WHERE ename='���ϴ�')
AND ename!='���ϴ�';

--�Ʒ��� �� ������ ���� �ƴϴ�
SELECT eno, ename, mgr, job
FROM emp
WHERE mgr IN (SELECT mgr
              FROM emp
              WHERE ename='���ϴ�')
AND job IN (SELECT job
            FROM emp
            WHERE ename='���ϴ�');

SELECT eno, ename, mgr, job
FROM emp
WHERE mgr IN (SELECT mgr
              FROM emp
              WHERE ename='���ϴ�')
AND job IN (SELECT job
            FROM emp
            WHERE ename='���ϴ�')
AND ename!='���ϴ�';


--5) �� �μ����� �ּ� �޿��� �޴� ����� ������ �˻��ϼ���
--   (�̸�, �޿�)
SELECT dno, ename, sal
FROM emp
WHERE (dno, sal) IN (SELECT dno, MIN(sal)
                     FROM emp
                     GROUP BY dno)
ORDER BY dno;







