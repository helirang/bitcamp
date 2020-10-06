#include "turboc.h" 


void main()
{
	setcursortype(NOCURSOR); // 커서가 없어지는

	int x = 0;
	for (x=0;x<=80;x++)
	{
		clrscr(); // 화면 깨끗이
		gotoxy(x, 12); // 20행 12열에 출력
		puts("#"); // 1글자만 출력
		delay(100); // 0.1초동안 잠시 멈춤
	}
}