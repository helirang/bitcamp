[Session 0]
1) '����'�л� �࿡ Exclusive Lock �� �߻��Ѵ�
   Session 0 �� ���̺��� ����� ���� �о���� �ִ�.
   
UPDATE student SET avr=0.1
 WHERE sname='����';
SELECT sno, sname, avr 
 FROM student
 WHERE sname='����';
 
--3) Ʈ������� �Ϸ��Ͽ� Exclusive Lock �� ��������
--   (���̺� �ɸ� Share Lock �� �Բ� �����ȴ�)
   
COMMIT;