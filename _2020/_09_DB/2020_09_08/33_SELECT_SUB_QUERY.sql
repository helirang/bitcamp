<���� ���� - ���� �� ���� ����>

a) ���� ������ ����
  a-1) ���� �� ��������
     ; ���������� �ϳ��� �÷����� �ϳ��� ���� �˻��Ѵ�
  a-2) ���� �� ��������
     ; ���������� �ϳ��� �÷����� ���� ���� ���� �˻��Ѵ�
  a-3) ���� �� ��������
     ; ���������� ���� ���� �÷��� �˻��Ѵ�
     

--1) �迬�ƺ��� �޿��� ���� �޴� ����� �˻��ϼ���
SELECT eno, ename
FROM emp
WHERE sal > (SELECT sal
            FROM emp
            WHERE ename='�迬��');
            
--2) '����'�� ������ ������ �л��� ������ �˻��ϼ���
SELECT *
FROM student
WHERE avr = (SELECT avr
             FROM student
             WHERE sname='����');
             
SELECT *
FROM student
WHERE avr IN (SELECT avr
             FROM student
             WHERE sname='����');
             
--3) �迬�ƿ� �μ��� �ٸ��� ������ ������ �ϴ� ����� ������ �˻��ϼ���
SELECT *
FROM emp
WHERE dno!=(SELECT dno
            FROM emp
            WHERE ename='�迬��')
AND job=(SELECT job
         FROM emp
         WHERE ename='�迬��');
         
--4) �μ� �� ���� �޿��� ���� �޴� �μ��� �˻��ϼ���
SELECT dno "�޿�MAX�μ�", ROUND(AVG(sal))
FROM emp
GROUP BY dno
HAVING AVG(sal) = (SELECT MAX(AVG(sal))
                   FROM emp
                   GROUP BY dno);

--5) �μ� �� ���� �޿��� ���� �޴� �μ��� �˻��ϼ���
SELECT e.dno "�޿�MIN�μ�", dname, ROUND(AVG(sal))
FROM emp e, dept d
WHERE e.dno=d.dno
GROUP BY e.dno, dname
HAVING AVG(sal) = (SELECT MIN(AVG(sal))
                   FROM emp
                   GROUP BY dno);
                   
--6) �λ꿡�� �ٹ��ϴ� ����� ������ �˻��ϼ���
SELECT *
FROM emp
WHERE dno = (SELECT dno
             FROM dept
             WHERE loc='�λ�');
             
SELECT *
FROM emp e, dept d
WHERE e.dno=d.dno
AND loc='�λ�';




















