--<���� ������ ����ϼ���>
--1) ���캸�� ������ ����� �л��� �й��� �̸��� �˻��ϼ���
SELECT * FROM STUDENT;

SELECT SNO, SNAME, AVR 
FROM STUDENT
WHERE SNAME != '����' AND AVR > (SELECT AVR FROM STUDENT WHERE SNAME ='����')
ORDER BY SNO;

--2) ����� ������ �г� �л� �߿� ������ �縶���� ������ �л��� �˻��ϼ���
SELECT SNO, SNAME, AVR 
FROM STUDENT
WHERE SNAME != '�縶��' AND SYEAR = (SELECT SYEAR FROM STUDENT WHERE SNAME = '����')
AND AVR = (SELECT AVR FROM STUDENT WHERE SNAME = '�縶��')
ORDER BY SNO;

--3) ���캸�� �Ϲ� ȭ�а����� ������ �� ���� �л��� ����� ������ �˻��ϼ���
SELECT SNAME, RESULT
FROM STUDENT
JOIN SCORE USING (SNO)
JOIN COURSE USING (CNO)
WHERE CNAME = '�Ϲ�ȭ��' 
AND RESULT < (SELECT RESULT
FROM STUDENT
JOIN SCORE USING (SNO)
JOIN COURSE USING (CNO)
WHERE SNAME = '����' AND CNAME ='�Ϲ�ȭ��')
ORDER BY RESULT;

--4) �ο����� ���� ���� �а��� �˻��ϼ���
SELECT * FROM STUDENT;

SELECT MAJOR, COUNT(MAJOR) �ο� 
FROM STUDENT 
GROUP BY MAJOR
HAVING COUNT(MAJOR) = (SELECT MAX(COUNT(MAJOR)) FROM STUDENT GROUP BY MAJOR);

--(SELECT MIN(AVG(sal))
--                   FROM emp
--                   GROUP BY dno);
--5) �л� �� �⸻��� ������ ���� ���� �л��� ������ �˻��ϼ���
SELECT * FROM SCORE;

SELECT SNO, AVG(RESULT) 
FROM SCORE
GROUP BY SNO
HAVING AVG(RESULT) = (SELECT MIN(AVG(RESULT)) FROM SCORE GROUP BY SNO);
