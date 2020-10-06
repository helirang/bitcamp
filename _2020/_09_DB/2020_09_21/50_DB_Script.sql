--테이블 명 : 고객
--컬럼 : 고객관리번호, 고객명, 주소, 전화

DROP TABLE client;

CREATE TABLE client(
  cnum NUMBER,
  cname VARCHAR2(50),
  addr VARCHAR2(200),
  tel VARCHAR2(20)
);