<������ �Լ� - ���� �Լ�>
a) ������ �Լ�
   ����sw�� �ڵ带 ���̰�
   DB�� ������ �ִ��� Ȱ��(������ �����͸� ����)
   - ���� �Լ�
   - ���� �Լ�
   - ��¥ �Լ�
   - ��ȯ �Լ�
   - �Ϲ� �Լ�
   
b) LOWER : ���ڿ��� �ҹ��ڷ� ��ȯ�Ѵ�
           LOWER('ORACLE') -> oracle
   UPPER : ���ڿ��� �빮�ڷ� ��ȯ�Ѵ�
           UPPER('oracle') -> ORACLE
   INITCAP : ù���ڸ� �빮�ڷ� ��ȯ�ϰ� �������� �ҹ��ڷ� ��ȯ�Ѵ�
            INITCAP('orAclE') -> Oracle
            
c) CONCAT : �ΰ��� ���ڿ��� �����Ѵ�
            �̰ͺ��ٴ� ���Ῥ���ڸ� �ַ� ����Ѵ�('||')
            CONCAT('��', '����') -> �迬��
            '��'||'����'
   SUBSTR : ���ڿ� ���� ������ ��ġ�� ���ڿ��� ��ȯ�Ѵ�
            SUBSTR(���ڿ�, ������ġ, ��¹����� ����)
            SUBSTR('oracle', 1, 2) -> or
   LENGTH : ���ڿ��� ���̸� ��ȯ�Ѵ�
            LENGTH(���ڿ�)
            LENGTH('oracle') -> 6
   INSTR : ������ ������ ��ġ�� �����Ѵ�
           INSTR(���ڿ�, �˻�����, [������ġ, [ȸ��]])
           INSTR('oracle', 'a') -> 3
   TRIM : ���ξ ���̾ �߶󳽴�
          TRIM(leading|trailing|both] ���ܹ��� FROM ���ڿ�
          ���ܹ��ڸ� �������� ������ ���鹮�ڸ� �߶󳽴�
          TRIM('o' FROM 'oracle') -> racle
          _oracle_ : _�� space���ڷ� �����Ѵ�
          TRIM('_oracle_') -> oracle
   LPAD, RPAD : ������ ���ڿ��� ���̸�ŭ ��κп� ���ڸ� ä���.
          LPAD(���ڿ�, �����, ä����)
          LPAD('20000', 10, '*') -> *****20000
          RPAD('20000', 10, '#') -> 20000#####  
          
d) ���� ġȯ �Լ�
  TRANSLATE : ���ڴ��� ġȯ�� ���� �����Ѵ�
              TRANSLATE(���ڿ�, �˻�����, ġȯ����)
              TRANSLATE('oracle', 'a', '#') -> #racle
  REPLACE : ���ڿ� ���� ġȯ�� ���� �����Ѵ�
              REPLACE(���ڿ�, �˻����ڿ�, ġȯ���ڿ�)
              REPLACE('oracle', 'or', '##') -> ##acle
            
--1) ERP �μ��� �ִ� ������ �˻��϶�
SELECT loc "ERP �μ� ����"
FROM dept
WHERE LOWER(dname)='erp';

--2) �μ��� ��� ��ġ�� �ϳ��� �÷����� �˻��Ѵ�
SELECT CONCAT(dname, ' '||loc)
FROM dept;

SELECT dname||' '||loc
FROM dept;

--3) �μ���� �μ����� ���̸� ����϶�
SELECT dname, LENGTH(dname)
FROM dept;

--4) SUBSTR �Լ��� �̿��ؼ� �÷��� �Ϻ� ���븸�� �˻��϶�
--SQL�� ù��°�� 0�� �ƴ϶� 1�� �����Ѵ�
SELECT ename, SUBSTR(ename, 2),   -- 2��° ���ں���
              SUBSTR(ename, -2),  -- �ڿ��� 2��° ���ں���
              SUBSTR(ename, 1, 2), -- 1��° ���ں��� 2����
              SUBSTR(ename, -2, 2) -- �ڿ��� 2��° ���ں��� 2����
FROM emp;

--5) ����̸��� 'a'�� ��Ÿ���� ��ġ�� ����϶�
SELECT INSTR('database', 'a'),    -- 'a'�� ó�� ��Ÿ���� ��ġ
       INSTR('database', 'a', 3), -- 'a'�� ����3���� ��Ÿ���� ��ġ
       INSTR('database', 'a', 1, 3) -- ó������ 'a'�� 3��° ��Ÿ���� ��ġ
FROM dual;

--6) TRIM�Լ��� ����ؼ� ���ڿ��� �˻��϶�
SELECT TRIM('��' from '���Ⳳ'),
       TRIM(leading '��' from '���Ⳳ'),
       TRIM(trailing '��' from '���Ⳳ')
FROM dual;

--7) �̸��� �޿��� ���� 10 �÷����� �˻��϶�
SELECT RPAD(ename, 10, '*'), LPAD(sal, 10, '*')
FROM emp;

--8) �μ����� ������ ���ڸ� �����ϰ� �˻��϶�
SELECT dname, SUBSTR(dname, 1, LENGTH(dname)-1) dname
FROM dept;

--9) TRANSLATE, REPLACE ����ϱ�
SELECT TRANSLATE('World of Warcraft', 'Wo', '--') Translate,
       REPLACE('World of Warcraft', 'Wo', '--') Replace
FROM dual;

SELECT REPLACE('red Hat', 'red', '�Ķ�-blue') ġȯ
FROM dual;


            
           
           
           
           
           
           
           
           
           
           
           
           