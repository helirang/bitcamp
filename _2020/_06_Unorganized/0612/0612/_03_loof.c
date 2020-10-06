#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>

int main(int argc, char** argv)
{
	printf("1. 주소 입력\n");
	printf("2. 주소 검색\n");
	printf("3. 주소 수정\n");
	printf("4. 주소 삭제\n");
	printf("5. 주소 출력\n");
	/*char sel = getchar(); 문자 + 엔터*/
	//f1을 누르면 설명을 알려줌

	char sel = _getch(); // 문자만
	printf("\n %c 번 선택하셨습니다 \n", sel);

	// 키보드와 콘솔을 연결해주는 버퍼, getchar() -> 버퍼에 저장.
	// _getch()는 버퍼를 거치지 않는다. 
	return 0;
}
