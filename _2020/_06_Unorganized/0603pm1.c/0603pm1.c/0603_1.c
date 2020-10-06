#include <stdio.h>
#include <stdlib.h>

int main(void)
{
	//���� 15�� ������ 1�� �迭 �����ϱ�
	int numbers[15] = { 0 };
	int length = 15; //sizeof(�迭��) // sizeof(int);
	srand((unsigned int)time(NULL));// ���� �߻� ���ذ� ���� - rand() ���� �� ����
	// srand���� ���ϰ� �ؾ� �� ���α׷� ���ึ�� �ٲ� ����.
	// ��� ��ҿ� ���� ������ �����ϱ�
	for (int i = length - 1; i >= 0; --i)
	{
		numbers[i] = rand(); // + �� - �� �� ���� ���� // 0~32656
	}
	for (int i = 0; i < length; ++i)
	{
		printf("%6d\n", numbers[i]); //%6d = 6�ڸ� �������� ����Ѵ�.
	}
	printf("\n");

	// �迭 ó�� �� �⺻ ���
	int min; // ��ã�� �迭
	int max;
	min = max = numbers[0];  // min�� max�� numbers �迭 ù��°�� ����
	// ã�� : ã���� ���� ���ϱ�, ���� ã�� ������ or ��Ҹ� ã�� ������
	for (int i = 1; i < length; ++i)
	{
		if (min > numbers[i]) // min�� numbers�� 2��°(1 + i) ������ ������?
		{
			min = numbers[i]; // ������ min�� �� ���� ���� ���ŵȴ�.
		}
		if (max < numbers[i]) // max�� numbers�� 2��°(1 + i) ������ ū��?
		{
			max = numbers[i]; // ũ�� min�� �� ū ���� ���ŵȴ�.
		}
	}
	printf("Max : %d, Min : %d \n", max, min);
	//��ҹ�ȣ ã�� �迭

	min = max = 0; // min�� max = 0���� �ʱ�ȭ

	for (int i = 1; i < length; ++i)
	{
		if (numbers[min] > numbers[i]) // numbers 1��(�ι�°)�� 0��(ù��°) ���� ������?
		{
			min = i; //  ������ min�� i�� �����Ѵ�.
		}
		if (numbers[max] < numbers[i])// numbers 1��(�ι�°)�� 0��(ù��°) ���� ū��?
		{

			max = i; //  ũ�� max�� i�� �����Ѵ�.
		}
	}
	printf("Max : %d, Min : %d \n", max + 1, min + 1);

	// �迭 ��ҵ��� ũ�� ������� ���ġ - ���� sort
	// ���� ��� - �˰���(�پ��ϴ�)
	// �� - ��ȯ
	// ���� - �Ʒ� �ڵ�� �� �ݺ����� �ִ밪�� �ּҰ��� �ϳ��� �����ϴ� �˰���.

	int first = 0; // ù��° ��ҹ�ȣ
	int last = length - 1; // ������ ��ҹ�ȣ
	for (int k = 0; k < (length / 2); ++k) // ��ø�� ���� �̸� �ߺ� x
	{
		for (int i = first; i <= last; ++i) // 14 = last = 15 -1 
		{
			printf("%d ", numbers[i]);
		}
		printf("\n");
		++first;
		--last;
	}
	printf("\n");

	// ���� - �Ʒ� �ڵ�� �� �ݺ����� �ִ밪�� �ּҰ��� �ϳ��� �����ϴ� �˰���.
	first = 0; // ù��° ��ҹ�ȣ
	last = length - 1; // ������ ��ҹ�ȣ
	for (int k = 0; k < (length / 2); ++k) // ��ø�� ���� �̸� �ߺ� x
	{
		int min = first;
		int max = first;
		for (int i = first + 1; i <= last; ++i) // 14 = last = 15 -1 
		{
			if (numbers[min] > numbers[i])
			{
				min = i;
			}
			if (numbers[max] < numbers[i])
			{
				max = i;
			}
		}
		// ��ȯ
		int t = numbers[min];
		numbers[min] = numbers[first];
		numbers[first] = t;
		t = numbers[max];
		numbers[max] = numbers[last];
		numbers[last] = t;
		++first;
		--last;
	}
	// ���� �� ��� 
	for (int i = 0; i < length; ++i)
	{
		printf("%d\t", numbers[i]);
	}
	printf("\n");
	return 0;
}