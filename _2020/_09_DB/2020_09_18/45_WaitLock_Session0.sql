[Ʈ����ǿ� ���� ��� ���� Ȯ�� - Session 0]

1) DML �� ������ �� COMMIT �� ���� �ʾұ� ������
  '����'�л��� �࿡ Exclusive Lock �� �߻��Ѵ�.
UPDATE student SET major='��ȸ'
 WHERE sname='����';
SELECT sno, sname, major
 FROM student
 WHERE sname='����';
 
4) Ʈ������� �Ϸ�����.

COMMIT;