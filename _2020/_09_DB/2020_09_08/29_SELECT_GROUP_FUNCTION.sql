<�׷� �Լ�>
; ������� ���� ���� ���Ǵ� �Լ�
���� ���� ���� �࿡�� ���ǰų� �����ϴ� ���� �����ϴ� �Լ�
a) 
MAX : ���� �߿� �ִ� ���� ��ȯ�Ѵ�
      MAX(�÷�)
MIN : ���� �߿� �ּ� ���� ��ȯ�Ѵ�
      MIN(�÷�)
AVG : ��� ���� ����Ѵ�
      AVG(�÷�)
COUNT : ��ȯ�� ���� ���� ����Ѵ�
       COUNT(�÷�|*)
SUM  : �հ踦 ����Ѵ�
       SUM(�÷�)
STDDEV : ǥ�������� ����Ѵ�
       STDDEV(�÷�)
VARIANCE : �л��� ����Ѵ�
       VARIANCE(�÷�)
       
b) null ���� ���õȴ�
   �ݵ�� �� �ϳ��� ������ ��ȯ�Ѵ�
   GROUP BY ���� ���� �Ϲ� �÷��� ����� �� ����.
   
   
--1) ����� �޿� ����� �˻��Ѵ�.
SELECT AVG(sal) ��ձ޿�, ROUND(AVG(sal)) ��ձ޿�
FROM emp;

--2) ����鿡�� ���޵� ���ʽ� ���հ� ���ʽ� ����� �˻��ϼ���
SELECT SUM(comm) �Ѿ�,
       ROUND(AVG(comm)) ���,
       COUNT(comm) �����ο�,
       ROUND(AVG(NVL(comm,0))) ȯ�����,
       COUNT(*) ��ü�ο�
FROM emp;

SELECT COUNT(*)
FROM emp
WHERE comm IS NOT NULL;

SELECT COUNT(*)
FROM emp
WHERE comm IS NULL;

SELECT COUNT(*)
FROM emp;

--<�׷� �Լ��� GROUP BY ��>

--3) ��� �޿��� ��� ������ �˻��ϼ���
SELECT ROUND(AVG(sal)) ��ձ޿�, 
       ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM emp;

--4) �μ��� ��� �޿��� ��� ������ �˻��ϼ���
SELECT dno, ROUND(AVG(sal)) ��ձ޿�, 
       ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM emp;

ī��θ�Ƽ�� ���̰� �־ ������ �߻��Ѵ�
ī��θ�Ƽ(Cadinality) : ��� ���� ����

14���� ����� ���´�
SELECT dno
FROM emp;

1���� ����� ���´�
SELECT ROUND(AVG(sal)) ��ձ޿�, 
       ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM emp;


--5) �μ��� ��� �޿��� ��� ������ �˻��ϼ���
--�μ��� : GROUP BY dno
--�׷��Լ��� �Բ� ���Ǵ� �Ϲ� �÷���
--�ݵ�� GROUP BY ���� ���Ǿ�� �Ѵ�
SELECT dno, ROUND(AVG(sal)) ��ձ޿�, 
       ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM emp
GROUP BY dno;

--6) ������ ��� �޿��� ��� ������ �˻��ϼ���
SELECT job ����, ROUND(AVG(sal)) ��ձ޿�, 
       ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM emp;

SELECT job ����, ROUND(AVG(sal)) ��ձ޿�, 
       ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM emp
GROUP BY job;

--7) �μ��� ��տ����� ���ϼ���(�μ���ȣ�� �μ������ ����ϼ���)
SELECT d.dno, dname, ROUND(AVG(sal*12+NVL(comm,0))) ��տ���
FROM dept d, emp e
WHERE d.dno=e.dno
GROUP BY d.dno, dname;

--8) �μ��� �޿� ����� �ִ밪�� �ּҰ��� �˻��ϼ���
SELECT dno, AVG(sal) ���
FROM emp
GROUP BY dno;

--GROUP BY dno�� ���� dno�� ī��θ�Ƽ�� 7���̴�
--�׸��� GROUP BY dno�� �Բ� ���Ǵ� AVG(sal)�� ī��θ�Ƽ�� 7���̴�
--�׷��� MAX(AVG(sal))�� �μ��߿� �ִ밪�� �����ϴ� ���̹Ƿ�
--      ī��θ�Ƽ�� 1���̴�
--      MIN(AVG(sal))�� �μ��߿� �ּҰ��� �����ϴ� ���̹Ƿ�
--      ī��θ�Ƽ�� 1���̴�
--�׷��Ƿ� �Ʒ��� SQL ���� ī��θ�Ƽ�� ����ġ�� ����
--������ �߻��Ѵ�.
--
--�׷��� �� ������ '��������'�� �̿��ؾ� �Ѵ�
SELECT dno, MAX(AVG(sal)) �ִ����, MIN(AVG(sal)) �ּ����
FROM emp
GROUP BY dno;

SELECT dno
FROM emp
GROUP BY dno;

SELECT MAX(AVG(sal)) �ִ����, MIN(AVG(sal)) �ּ����
FROM emp
GROUP BY dno;




   
   
   
   
   