--<���� �� �Լ��� �̿��ϼ���>
--1) �������� ������ �޿� �ٹ��� �ϼ��� �� ������ �˻��ϼ���
SELECT pno, pname, LAST_DAY(HIREDATE)-HIREDATE+1 "���ӿ� �ٹ���"
FROM professor;

--2) �������� ���ñ��� �ٹ��� �ְ� �� ������ �˻��ϼ���
SELECT * FROM PROFESSOR;

SELECT PNO, PNAME, trunc((trunc(sysdate, 'DD') - trunc(HIREDATE, 'DD')+1)/7) "���ñ��� ���� ��" FROM PROFESSOR;

--3) 1991�⿡�� 1995�� ���̿� ������ ������ �˻��ϼ���
SELECT * FROM professor where HIREDATE >= '91/01/01' and HIREDATE < '96/01/01';

SELECT * FROM professor where trunc(HIREDATE,'yy') >= '91/01/01' and  trunc(HIREDATE,'yy') < '96/01/01';

--4) �л����� 4.5 ȯ�� ������ �˻��ϼ���(�� �Ҽ� ���� ��°�ڸ�����)
SELECT * FROM student;

select sno, sname, syear, major, round(avr*(9/8),2) from student;