--1) dept ���̺��� ��� �����͸� ������ ���� ROLLBACK �� COMMIT �� 
--�����ϰ� ����� Ȯ���ϼ���
SELECT *
FROM dept;

DELETE FROM dept;

SELECT *
FROM dept;

ROLLBACK;

SELECT *
FROM dept;

--2) emp �� dept ���̺��� ��� �����͸� �����Ϸ��ϼ���
SELECT * FROM emp;
SELECT * FROM dept;
DELETE FROM emp;
DELETE FROM dept;
SELECT * FROM emp;
SELECT * FROM dept;
COMMIT;
ROLLBACK;

--3) emp ���̺� ������ �Է��ϼ���
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1001','�迬��','����',NULL,'1991-02-01',4500,520,10);
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1002','�Ӳ���','ȸ��',NULL,'1992-03-03',4100,720,20);
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1003','�̸���','����',NULL,'1999-12-12',5500,820,30);
INSERT INTO emp(eno, ename, job, mgr, hdate, sal, comm, dno)
VALUES ('1004','��ȣ��','����',NULL,'1991-11-09',5500,620,40);
--SELECT * FROM emp;
--ROLLBACK;
COMMIT;
SELECT * FROM emp;

--4) emp ���̺� �����͸� �Է��ϵ� �Ի��Ͽ� ��¥�� �ð��� �Է��ϼ���
SELECT sysdate
FROM dual;
--date �� ��¥ ������ ��ġ�ؾ� �Էµȴ�
INSERT INTO emp (eno, ename, hdate)
VALUES ('5001', 'ȫ�浿', '1991-01-03:07:15:25');

ALTER SESSION SET nls_date_format='YYYY-MM-DD:HH24:MI:SS';
INSERT INTO emp (eno, ename, hdate)
VALUES ('5001', 'ȫ�浿', '1991-01-03:07:15:25');

SELECT * FROM emp;

--5) ��¥ ������ Ȯ���ϰ� TO_DATE() �� ����ؼ� �Է��϶�
ALTER SESSION SET nls_date_format='YYYY-MM-DD';
SELECT sysdate FROM dual;
ALTER SESSION SET nls_date_format='YY-MM-DD';
SELECT sysdate FROM dual;
ALTER SESSION SET nls_date_format='YY/MM/DD';
SELECT sysdate FROM dual;

INSERT INTO emp (eno, ename, hdate)
VALUES ('5002', '�峪��', 
        TO_DATE('1992-02-03:07:07:07', 'YYYY-MM-DD:HH24:MI:SS'));
SELECT * FROM emp;

SELECT eno, ename, TO_CHAR(hdate, 'YYYY-MM-DD:HH24:MI:SS')
FROM emp;

--6) ��¥�� ����Ǵ� ����Ʈ ���� Ȯ���Ѵ�
ALTER SESSION SET nls_date_format='YYYY-MM-DD:HH24:MI:SS';
INSERT INTO emp (eno, hdate)
VALUES ('1', TO_DATE('2000', 'YYYY'));
INSERT INTO emp (eno, hdate)
VALUES ('3', TO_DATE('99', 'YY'));
INSERT INTO emp (eno, hdate)
VALUES ('4', TO_DATE('99', 'RR'));
COMMIT;
SELECT * FROM emp;

--7) �迬���� �μ���ȣ�� 10������ �����ϰ� �޿��� 10%�λ��ϼ���
SELECT * FROM emp;
UPDATE emp SET dno='10', sal=sal*1.1
WHERE ename='�迬��';

















