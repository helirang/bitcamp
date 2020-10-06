#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{
	int W = 19;
	int H = 19;
	int omokpan[19 * 19] = { 1,0,1,1,0 };; /// 19 * 19배열 
	// 요소의 값이 0 이면 ┼

	for (int r = 0; r < H; ++r) // int r이 H보다 작을 동안 반복한다.
	{
		for (int c = 0; c < W; ++c) // int C가 W보다 작을 동안 반복한다.
		{
			int v = omokpan[r * W + c]; //  0 ~ 18 1행 = + C //int v는 omokpan배열[ r*W +c ]의 값을 가진다.
			// 0~18 열 => 0열 1행 끝자리 18 => 0행 1열 첫자리 값 = r*W+c = 19+0
			if (omokpan[r * W + c] == 0) // omokpan배열[ r*W +c ]의 값이 0이면 "┼ "을 출력한다.
			{
				printf("┼ ");
			}
			else if (v == 1) // omokpan배열[ r*W +c ]의 값이 0이면 "┼ "을 출력한다.
			{
				printf("○");
			} // 깃허브
		}
		printf("\n"); // 0 ~ 18 1행 = +C
	}
	return 0;
}