--<���� �� �Լ��� ����ϼ���>
--1) �̸��� �� ������ �л��� �̸��� �˻��ϼ���
SELECT sname, LENGTH(sname)
FROM student
WHERE LENGTH(sname) = 2;

--2) '��'�� ���� ���� �л��� �̸��� �˻��ϼ���
SELECT sname
FROM student
WHERE SUBSTR(sname,1,1) = '��';

--3) ������ ������ �ѱ��ڷ� �˻��ϼ���(ex. ������ -> ��)
SELECT pname, SUBSTR(orders,1,1)
FROM professor;

--4) �Ϲ� ������ ���� �������� �����ؼ� ��� ������ �˻��ϼ���
--   (ex. �Ϲ�ȭ�� -> ����ȭ��)
SELECT REPLACE(cname, '�Ϲ�ȭ��', '����ȭ��')
FROM course;

--5) ���� �Է� �Ǽ��� student���̺��� sname�÷��� �����Ͱ� �Էµ� ��
--   ���ڿ� �������� ������ �߰��Ǿ��ٸ� �˻��� �� �̸� �����ϰ�
--   �˻��ϴ� SELECT ���� �ۼ��ϼ���

SELECT SUBSTR(SNAME, 1, LENGTH(sname)-1)
FROM student;