[Session 1] 

2) Session 0�� '����'�л��� ���� ������ ���
   Session 1�� ��� ��µǴ°�?
   => ���̺��� ���� Session 0�� ���������Ƿ�
    Session 1�� UNDO SEGMENT �� ���� ���� �о�´�.
    
SELECT sno, sname, avr 
 FROM student
 WHERE sname='����';
 
4) Session 0�� COMMIT �� �� �ٽ� �˻�����
  => Exclusive Lock �� �����Ǿ����Ƿ�
   ���̺��� �����͸� ���������� �����ϰ� �ִ�.

SELECT sno, sname, avr 
 FROM student
 WHERE sname='����';