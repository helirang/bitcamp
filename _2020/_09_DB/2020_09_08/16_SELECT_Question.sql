--1) �۰� ������ �����ϴ� ������ �˻��Ѵ�
SELECT pname, cname, course.pno
FROM professor p, course
WHERE p.PNO = course.pno AND p.PNAME = '�۰�';

--2) ȭ�� ���� ������ �����ϴ� ������ ����� �˻��Ѵ�
SELECT c.pno, pname, cname
FROM professor p, course c
WHERE p.pno = c.pno AND cname like '%ȭ��%'; 

--3) ������ 2������ ����� �̸� �����ϴ� ������ �˻��Ѵ�
SELECT c.pno, pname, cname, st_num
FROM professor p, course c
WHERE p.pno = c.pno and st_num = '2';

--4) ȭ�а� ������ �����ϴ� ������ �˻��Ѵ�
SELECT  c.pno, pname, section ,cname
FROM professor p, course c
WHERE p.pno = c.pno and section = 'ȭ��';

--5) ȭ�а� 1�г� �л��� �⸻��� ������ �˻��Ѵ�
SELECT sc.sno,st.SNAME, sc.CNO, result
FROM student st, score sc
WHERE st.sno = sc.sno AND st.syear = '1';

--6) �Ϲ�ȭ�� ������ �⸻��� ������ �˻��Ѵ�
select sno, cname, result
FROM course c, score s
WHERE c.cno = s.cno AND cname = '�Ϲ�ȭ��';

--7) ȭ�а� 1�г� �л��� �Ϲ�ȭ�� �⸻��� ������ �˻��Ѵ�
SELECT st.SNO, st.SNAME,st.SYEAR, st.MAJOR,cname, sc.RESULT
FROM student st, score sc, course c
WHERE st.sno = sc.sno AND c.CNO = sc.CNO and st.syear = '1' and c.CNAME = '�Ϲ�ȭ��' and major = 'ȭ��';

--8) ȭ�а� 1�г� �л��� �����ϴ� ������ �˻��Ѵ�
SELECT DISTINCT cname
FROM student st, score sc, course c
WHERE st.sno = sc.sno and st.syear = '1' and major = 'ȭ��'  and c.CNO = sc.CNO;

--9) ����ȭ�� ������ �������� F�� �л��� ����� �˻��Ѵ�
SELECT st.sname, c.cname, sc.result
FROM student st, score sc, course c
WHERE st.sno = sc.sno AND c.CNO = sc.CNO and cname = '����ȭ��' and  sc.RESULT < 40
ORDER BY result desc;
