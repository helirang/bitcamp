--<���� �� �Լ� - ����, ��¥�� �Լ�>
--a) ROUND : n�ڸ����� �ݿø��Ѵ�
--           ROUND(m, n)
--           ROUND(123.4567, 3) -> 123.457
--   
--   TRUNC : n�ڸ��̸��� �����Ѵ�
--           TRUNC(m, n)
--           TRUNC(123.4567, 3) -> 123.456
--  
--   MOD : m�� n���� ���� ������ ����Ѵ�
--           MOD(m, n)
--           MOD(10, 4) -> 2
--         
--   POWER : m�� n���� ����Ѵ�
--           POWER(m, n)
--           POWER(2, 4) -> 16
--           
--   CEIL : m���� ū ���� ���� ������ ã�´�
--          CEIL(m)
--          CEIL(2.34) -> 3
--          
--   FLOOR : m���� ���� ���� ū ������ ã�´�
--          FLOOR(m)
--          FLOOR(2.34) -> 2
--          
--   ABS : m�� ���밪�� ����Ѵ�
--         ABS(m)
--         ABS(-4) -> 4
--         
--   SQRT : m�� �������� ����Ѵ�(��Ʈ)
--          SQRT(m)
--          SQRT(9) -> 3
--          
--   SIGN : m�� ������ �� -1, ����� �� 1, 0�̸� 0�� ��ȯ�Ѵ�(��ȣ)
--          SIGN(m)
--          SIGN(-3) -> -1
           
           
--1) ROUND �Լ��� ���
SELECT ROUND(98.765), TRUNC(98.765),
       ROUND(98.765, 2), TRUNC(98.765, 2)
FROM dual;

--2) MOD �Լ��� ���
SELECT MOD(19, 3), MOD(-19, 3)
FROM dual;

--3) 10�� �μ��� ������ ����Ѵ�. �� 100 ���� �̸��� �����Ѵ�
SELECT eno, ename, TRUNC(sal*12+NVL(comm,0), -2) ����
FROM emp
WHERE dno='10';

--<��¥ �Լ�>
--4) ���� ��¥�� �˻��ϰ� ��¥ ��� ����� �����ϼ���
SELECT sysdate
FROM dual;

ALTER SESSION SET nls_date_format='YYYY/MM/DD:HH24:MI:SS';

ALTER SESSION SET nls_date_format='YYYY/MM/DD';

ALTER SESSION SET nls_date_format='YY/MM/DD';

--5) ���� ��¥, �Ի� ����, �ӻ��Ϸκ��� ���ñ��� �Ⱓ, �Ի��� ����
--  100���� ������ ���� �˻��ϼ���
SELECT sysdate, hdate, sysdate-hdate, hdate+100
FROM emp
WHERE ename='�迬��';

<��¥ �Լ�>
; ���󵵰� ����
YYYY : �⵵
MM : ��
DD : ��¥
HH : �ð�
MI : ��
SS : ��

ROUND : ���Ŀ� ���߾� �ݿø��� ��¥�� ��ȯ�Ѵ�
        ROUND(��¥, ����)
        ROUND(sysdate, 'DD') -> 2020/09/11
TRUNC : ���Ŀ� ���߾� ������ ��¥�� ��ȯ�Ѵ�
        TRUNC(��¥, ����)
        TRUNC(sysdate, 'DD') -> 2020/09/10
        TRUNC(sysdate, 'YYYY') -> 2020/01/01
MONTHS_BETWEEN : �� ��¥���� �Ⱓ�� �� ���� ����Ѵ�
        MONTHS_BETWEEN(��¥1, ��¥2)
        MONTHS_BETWEEN('2020/06/01', '2020/09/10')
ADD_MONTHS : ��¥�� n���� ���� ��¥�� ����Ѵ�
        ADD_MONTHS(��¥, n)
        ADD_MONTHS('2020/06/01', 5)
NEXT_DAY : ��¥ ���� ������ ���Ͽ� �ش��ϴ� ��¥�� ����Ѵ�
        NEXT_DAY(��¥, ����)
        ���� ǥ���� 'sun'/'�Ͽ���', 1 �� ���� �پ��� ǥ���� �����ϴ�
        NEXT_DAY('2020/09/10', '�Ͽ���')
LAST_DAY : ��¥�� ������ ���� ������ ��¥�� ����Ѵ�
        LAST_DAY(��¥)
        LAST_DAY('2020/09/10') -> 2020/09/30
        
--6) ���ڿ� ��¥�� �ݿø��ϰų� �����Ͽ� ����ϼ���
SELECT sysdate, ROUND(sysdate, 'YY') ��,
                ROUND(sysdate, 'MM') ��,
                ROUND(sysdate, 'DD') ��
FROM dual;

SELECT sysdate, TRUNC(sysdate, 'YY') ��,
                TRUNC(sysdate, 'MM') ��,
                TRUNC(sysdate, 'DD') ��
FROM dual;

--7) �迬�ư� ���ñ��� ���� �ϼ��� �˻��ϼ���
--ȫ�浿�� 1�� ~ 10�ϱ��� ������ �� ���� �ϼ���?
--(10-1)+1 = 10�� ����
SELECT TRUNC(sysdate, 'DD') - TRUNC(hdate, 'DD') + 1 "���� �ϼ�"
FROM emp
WHERE ename='�迬��';

--8) 20�� �μ� ������� ������� �ٹ��� ���� ���� �˻��ϼ���
SELECT eno, ename, TRUNC(MONTHS_BETWEEN(sysdate,hdate)) �ٹ�����
FROM emp
WHERE dno='20';

--9) 20�� �μ� ������� �Ի� 100��° �Ǵ� ���� 10��° �Ǵ� ���� ���ϼ���
SELECT eno, ename, hdate �Ի���,
      hdate+99 "100��", ADD_MONTHS(hdate,120) "10��"
FROM emp
WHERE dno='20';

--10) 20�� �μ������� �Ի��� ���� ù ��° �Ͽ����� �˻��ϼ���
SELECT eno, ename, hdate, NEXT_DAY(hdate, '�Ͽ���') Sunday
FROM emp
WHERE dno='20';

--11) 10�� �μ������� �Ի��� ���� ������ ��¥��
--   �Ի��� ���� �ٹ� �ϼ��� �˻��ϼ���
--   (��, �Ի����� �ٹ��Ͽ��� �����մϴ�)
SELECT eno, ename, hdate, LAST_DAY(hdate) ��������,
       LAST_DAY(TRUNC(hdate))-TRUNC(hdate) "�������� �ٹ��ϼ�"
FROM emp
WHERE dno='20';










           
           
           