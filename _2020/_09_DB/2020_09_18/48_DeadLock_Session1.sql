[데드락(Dead Lock)을 발생하고 결과를 확인한다 - Session 1]

2) '장각'학생의 행에 독점 잠금이 발생된다.
   '관우'학생의 수정을 시도했으나 상대 session 0의 독점잠금에
   의해 Wait 상태로 진입하게 된다
SELECT sno, sname, major
 FROM student
 WHERE sname IN ('관우', '장각');
 
UPDATE student SET major='경제'
 WHERE sname='장각';
 
UPDATE student SET major='경제'
 WHERE sname='관우';
