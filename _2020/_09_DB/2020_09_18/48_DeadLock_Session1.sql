[�����(Dead Lock)�� �߻��ϰ� ����� Ȯ���Ѵ� - Session 1]

2) '�尢'�л��� �࿡ ���� ����� �߻��ȴ�.
   '����'�л��� ������ �õ������� ��� session 0�� ������ݿ�
   ���� Wait ���·� �����ϰ� �ȴ�
SELECT sno, sname, major
 FROM student
 WHERE sname IN ('����', '�尢');
 
UPDATE student SET major='����'
 WHERE sname='�尢';
 
UPDATE student SET major='����'
 WHERE sname='����';
