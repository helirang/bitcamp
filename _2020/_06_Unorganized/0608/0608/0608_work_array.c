#include <stdio.h>
#include <stdlib.h>
#include <string.h>


int main(int argc, char** argv)
{
	char a[80] = { "name:jangs,type:10" };
	char* p;
	p = &a[0];
	char aoao[5][30] = { NULL };

	int y = 0; // ���ڿ� a ī��Ʈ
	int uu = 0; // aoao 2�� �迭 �� ī��Ʈ
	for (int i = 0; i < 80; ++i)
	{
		if (p[y] == ',')
		{
			++y;
			aoao[uu][i] = '\0'; // ��� ���ڿ� ������ nul���� �ֱ�
			++uu;
			i = 0;
		}
		aoao[uu][i] = p[y]; // 2�� �迭, ���� ������, 1�� �迭
		++y;
		if (p[y] == 0) // ���ڿ� �� ������ break;�� for�� Ż��
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
		else if (aoao[uo][yn] == 0) // ���ڿ� ���� ���� �� �ٲٰ�, �� �ʱ�ȭ
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