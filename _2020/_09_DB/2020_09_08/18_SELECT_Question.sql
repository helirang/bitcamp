--1) �л��߿� ���������� �˻��Ѵ�
SELECT st1.sno, st1.sname �л�1
FROM student st1, student st2
WHERE st1.sno != st2.sno and st1.sname = st2.sname
order by st1.sname;

--2) ��ü ���� ��ܰ� ������ ����ϴ� ������ �̸��� �а� ������ �˻��Ѵ�
SELECT pname, p.SECTION, cname
FROM professor p , course c
WHERE p.pno = c.pno(+)
ORDER BY p.SECTION;

--3) �̹� �б� ��ϵ� ��� ����� ��� ������ ���� ������ �˻��Ѵ� // �� �Ҹ���
SELECT pname, p.SECTION, cname, st_num
FROM professor p , course c
WHERE p.pno(+) = c.pno
ORDER BY c.ST_NUM desc;
