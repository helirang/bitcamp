[데드락(Dead Lock)을 발생하고 결과를 확인한다 - Session 0]

1) '관우'학생의 행에 독점 잠금이 발생됨
SELECT sno, sname, major
 FROM student
 WHERE sname IN ('관우', '장각');
 
UPDATE student SET major='경제'
 WHERE sname='관우';
 
3) 상대 session 1에 의해 '장각'학생은 독점잠금이 걸려있는데
 여기서 수정을 시도하므로 Wait 상태로 진입하게 된다.
 그런데 이때 상대가 Wait 상태이므로
 Dead Lock 상태로 진입하게 된다.
UPDATE student SET major='사회'
 WHERE sname='장각';
 
 
4) 
Session 0과 Session 1은 모두 Wait 상태로 진입했으므로
그냥 내버려두면 무한 Wait 가 된다.
즉 이것을 Dead Lock이라고 한다.
오라클은 Dead Lock을 감지하게 되면
Dead Lock 을 발생시킨 세션의 마지막 명령을 보존하고
(Session 0의 마지막 명령 - '장각'을 '사회'로 변경시도)
Deat Lock 을 유발한 상대 세션(Session 1)의 마지막 명령
(Session 1의 마지막 명령 - '관우'를 '경제'로 변경시도)
을 ROLLBACK 한다