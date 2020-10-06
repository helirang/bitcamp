#include <stdio.h>
#include <stdlib.h>
#include <string.h>


int main(int argc, char** argv)
{
	char a[80] = { "name:jangs,type:10" };
	char* p;
	p = &a[0];
	char aoao[5][30] = { NULL };

	int y = 0; // 문자열 a 카운트
	int uu = 0; // aoao 2차 배열 열 카운트
	for (int i = 0; i < 80; ++i)
	{
		if (p[y] == ',')
		{
			++y;
			aoao[uu][i] = '\0'; // 모든 문자에 끝에는 nul문자 넣기
			++uu;
			i = 0;
		}
		aoao[uu][i] = p[y]; // 2차 배열, 대입 연산자, 1차 배열
		++y;
		if (p[y] == 0) // 문자열 끝 나오면 break;로 for문 탈출
		{
			++i;
			aoao[uu][i] = '\0';
			break;
		}
	}

	printf_s("%s\n\n", p);
	printf_s("%s\n", aoao[0]);
	printf_s("%s\n", aoao[1]);
	printf("\n-----------------------------------------------------------------------------------------\n");

	char aoaoi[4][30] = { NULL };
	int yn = 0;
	int uo = 0;
	int un = 0;
	int end = 0;

	for (int i = 0; i < 80; ++i)
	{
		if (aoao[uo][yn] == ':')
		{
			++yn;
			++un;
			i = 0;
		}
		else if (aoao[uo][yn] == 0) // 문자열 끝이 오면 열 바꾸고, 행 초기화
		{
			yn = 0;
			++uo;
			++un;
			i = 0;
			++end;
			if (aoao[uo][yn] == 0 && aoao[uo][yn + 2] == 0)
			{
				break;
			}
		}
		aoaoi[un][i] = aoao[uo][yn];

		++yn;
	}

	printf_s("\n%s\n\n", p);
	printf_s("%s\n", aoaoi[0]);
	printf_s("%s\n", aoaoi[1]);
	printf_s("%s\n", aoaoi[2]);
	printf_s("%s\n", aoaoi[3]);

}