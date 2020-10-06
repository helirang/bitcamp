#include "turboc.h" //로컬 헤더 파일은 ""로, <> 스튜디오에 ㅍ포함된 헤더
// f12번 누르면 헤더로 이동

void main()
{
	setcursortype(NOCURSOR); // 커서가 없어지는
	clrscr(); // 화면 깨끗이
	gotoxy(20, 12); // 20행 12열에 출력
	printf("감사합니다\n");
}