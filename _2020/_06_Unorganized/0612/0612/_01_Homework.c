#include "turboc.h" 


void main()
{
	setcursortype(NOCURSOR); // 커서가 없어지는

	int x = 0;

	for (x = 0;x <= 80;x++) // 반복, 맵 
	{
		// clrscr(); // 전체 화면 깨끗이
		if (x == 80)
		{
			x = 0;
		}
		gotoxy(x, 12); // 20행 12열에 출력
		puts("#"); // 1글자만 출력
		delay(100); // 0.1초동안 잠시 멈춤
		gotoxy(x, 12);
		puts(" "); // 커서가 이동해서 지워주는 효과
		// 과제 끝까지 가면 사라지는 거
		// #이 다시 시작위치에서 반복되도록
		// #이 왕복하도록 
		// #이 반사되도록 만들기.  < - x,y 모두 변화하게
	}
}