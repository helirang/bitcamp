[Ʈ����ǿ� ���� ��� ���� Ȯ�� - Session 1]

--2) Session 0�� ���� '����'�л��� �а��� ����Ǿ���
--  COMMIT �� ���� �ʾƼ� Exclusive Lock �� �ɸ� �����̴�.
--  �׷��Ƿ� Session 1�� UNDO SEGMENT �� ���� �а��� �о�´�.
  
SELECT sno, sname, major
 FROM student
 WHERE sname='����';
 
3) Session 1�� '����'�� �а��� '����'�� �����Ϸ��� �Ѵ�
   Session 0�� ���� Exclusive Lock �� �߻��� ����
   ���� �𸣴� �����̴�.
   => Session 0�� ���� ���� ����� �Ǹ�
      Session 1�� DML �� ���̺��� ���� ������ �� ����
      ��ٸ��� �ȴ�(��� ���¿� �����Ѵ�)
      �׷��ٰ� Session 0�� COMMIT �� �ϸ�
      �׶� Session 1�� ���̺��� ���� �����ϰ� 
      ���� ����� �ɰ� �ȴ�.
   
UPDATE student SET major='����'
 WHERE sname='����';