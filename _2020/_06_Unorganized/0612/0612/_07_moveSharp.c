#include "turboc.h" 


void main()
{
	setcursortype(NOCURSOR); // Ŀ���� ��������

	int x = 0;
	for (x=0;x<=80;x++)
	{
		clrscr(); // ȭ�� ������
		gotoxy(x, 12); // 20�� 12���� ���
		puts("#"); // 1���ڸ� ���
		delay(100); // 0.1�ʵ��� ��� ����
	}
}