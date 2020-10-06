#include <stdio.h>
#include <stdlib.h>
#include<string.h>

int main(void)
{
	int shape[40] = { 1 };
	int cur = 1;

	while (1)
	{
		system("cls"); //윈도우 화면 지우기
		for (int i = 0; i < 40; ++i)
		{
			// 요소의 값에 따라 출력할 문자열이 다르다...
			printf("%s", shape[i] ? "@" : " ");
		}
		printf("\n"); // 강제종료 = ctrl + c
		// 1을 한 칸씩 오른쪽으로 옮긴다.
		shape[cur - 1] = 0;
		shape[cur] = 1; // 요소배열
		cur++;
		cur %= 40; // 0~39
	}
	return 0;
	//조건연산자 (삼항) = (조건식) ? 참 : 거짓; = 삼항연산 or 조건연산자 //연산자는 아무데서나 쓸 수 있다.
}