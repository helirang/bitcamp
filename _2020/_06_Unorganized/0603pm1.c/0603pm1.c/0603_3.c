#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{
	int W = 19;
	int H = 19;
	int omokpan[19 * 19] = { 1,0,1,1,0 };; /// 19 * 19�迭 
	// ����� ���� 0 �̸� ��

	for (int r = 0; r < H; ++r) // int r�� H���� ���� ���� �ݺ��Ѵ�.
	{
		for (int c = 0; c < W; ++c) // int C�� W���� ���� ���� �ݺ��Ѵ�.
		{
			int v = omokpan[r * W + c]; //  0 ~ 18 1�� = + C //int v�� omokpan�迭[ r*W +c ]�� ���� ������.
			// 0~18 �� => 0�� 1�� ���ڸ� 18 => 0�� 1�� ù�ڸ� �� = r*W+c = 19+0
			if (omokpan[r * W + c] == 0) // omokpan�迭[ r*W +c ]�� ���� 0�̸� "�� "�� ����Ѵ�.
			{
				printf("�� ");
			}
			else if (v == 1) // omokpan�迭[ r*W +c ]�� ���� 0�̸� "�� "�� ����Ѵ�.
			{
				printf("��");
			} // �����
		}
		printf("\n"); // 0 ~ 18 1�� = +C
	}
	return 0;
}