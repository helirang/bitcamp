[Session 1] 

2) Session 0이 '마초'학생의 행을 독점한 경우
   Session 1은 어떻게 출력되는가?
   => 테이블의 행을 Session 0이 독점했으므로
    Session 1은 UNDO SEGMENT 의 이전 값을 읽어온다.
    
SELECT sno, sname, avr 
 FROM student
 WHERE sname='마초';
 
4) Session 0이 COMMIT 된 후 다시 검색하자
  => Exclusive Lock 이 해제되었으므로
   테이블의 데이터를 정상적으로 접근하고 있다.

SELECT sno, sname, avr 
 FROM student
 WHERE sname='마초';