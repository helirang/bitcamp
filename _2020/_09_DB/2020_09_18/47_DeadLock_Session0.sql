[�����(Dead Lock)�� �߻��ϰ� ����� Ȯ���Ѵ� - Session 0]

1) '����'�л��� �࿡ ���� ����� �߻���
SELECT sno, sname, major
 FROM student
 WHERE sname IN ('����', '�尢');
 
UPDATE student SET major='����'
 WHERE sname='����';
 
3) ��� session 1�� ���� '�尢'�л��� ��������� �ɷ��ִµ�
 ���⼭ ������ �õ��ϹǷ� Wait ���·� �����ϰ� �ȴ�.
 �׷��� �̶� ��밡 Wait �����̹Ƿ�
 Dead Lock ���·� �����ϰ� �ȴ�.
UPDATE student SET major='��ȸ'
 WHERE sname='�尢';
 
 
4) 
Session 0�� Session 1�� ��� Wait ���·� ���������Ƿ�
�׳� �������θ� ���� Wait �� �ȴ�.
�� �̰��� Dead Lock�̶�� �Ѵ�.
����Ŭ�� Dead Lock�� �����ϰ� �Ǹ�
Dead Lock �� �߻���Ų ������ ������ ����� �����ϰ�
(Session 0�� ������ ��� - '�尢'�� '��ȸ'�� ����õ�)
Deat Lock �� ������ ��� ����(Session 1)�� ������ ���
(Session 1�� ������ ��� - '����'�� '����'�� ����õ�)
�� ROLLBACK �Ѵ�