[Session 0]
1) '마초'학생 행에 Exclusive Lock 이 발생한다
   Session 0 은 테이블의 변경된 값을 읽어오고 있다.
   
UPDATE student SET avr=0.1
 WHERE sname='마초';
SELECT sno, sname, avr 
 FROM student
 WHERE sname='마초';
 
--3) 트랜잭션을 완료하여 Exclusive Lock 을 해제하자
--   (테이블에 걸린 Share Lock 도 함께 해제된다)
   
COMMIT;