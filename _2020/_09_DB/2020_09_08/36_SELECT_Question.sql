--1) ȭ�а� �л��� ������ ������ �л����� �˻��ϼ���
SELECT * FROM STUDENT;

SELECT sname, major, avr
FROM student
where major != 'ȭ��'
and avr in ( SELECT avr FROM student where major = 'ȭ��')
order by avr;

--2) ȭ�а� ������ �������� ���� ������ �˻��ϼ���
SELECT * FROM professor;

SELECT pno, pname, section, hiredate 
FROM professor
where section != 'ȭ��'
and hiredate in (SELECT hiredate FROM professor where section = 'ȭ��');

--3) ȭ�а� �л��� ���� �г⿡�� ������ ������ �л����� �˻��ϼ���
SELECT sname, major, syear, avr
FROM student
where major != 'ȭ��'
and (avr, syear) in ( SELECT avr, syear FROM student where major = 'ȭ��')
order by avr;