#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main_1(int argc, char** argv)
{
	//�迭 �ɰ���
	char student[80] = { 0 };
	char* name = student;
	int* kor = student + 60; // 59�� wht? -> 59�� + ���ڿ� ���� \0�� ���ϱ�
	int* eng = student + 64;
	int* math = student + 68;
	int* score = (int*)(student + 60); // 60�� �ּ�. &student[60] // (int*)(student + 60); ?
	// ���� �����ڴ� ������ �ڷ����� ���� �Ͽ��� �Ѵ�.
	// �����ͺ����� ����� ������ �ڷ����� ���� �۵��Ѵ�

	scanf_s("%s", name, 60); // �����ͺ����� ũ�� 4
	scanf_s("%d %d %d", score + 0, score + 1, score + 2);
	printf("%s : {%d, %d, %d} \n", name, *kor, *eng, *math);
	// printf("%s : {%d, %d, %d} \n", name, score[0], score[1], score[2]);


	return 0;
}

struct _std
{
	char student[80];
	int kor;
	int eng;
	int math;
};
int main_2(void)
{
	// �����Ҵ� : ������ ����, �Լ� - �ᱹ �迭
	int length = 60; //sizeof(p) = 4 / �����Ͷ� 4����Ʈ��� ���� . sizeof(*p) = 1����Ʈ
	char* p = (char*)malloc( length * sizeof(char)/*���� + ���, �� ��üũ�� �Ҵ�, �ַ� �迭�� �����ϱ� ���ؼ� ���*/);//�����Ҵ� �Լ� / void * Ÿ���� ���ؼ� ���.
	// p[0] ~ p[59]�� ���� �Լ�.
	for (int i = 0; i < length; ++i)
	{
		p[i] = 'a' + i; //�迭�̴�.
	}
	// �����Ҵ����� ������ ����, �迭�� �ݵ�� ��ü�Ѵ�.
	if (p != NULL)
	{
		free(p); // �޸� ����.
		// �Ҵ���� �ּҸ� �ٽ� ����Ѵ�. 
		// p�� �����ϸ� �ȵȴ�.
		// �� ������ p�� �ּ������� �����ϸ� �� �ȴ�.

		// ���� keep pointer 
		// malloc �Լ��� ���� �ּҰ� ����� ���.
		p = NULL;
	}
	return 0;
}

int main(void)
{
	// ���� �迭 ������ ����. ���� �迭�� ����ϴ� ����
	int nums[10]; // ���� �� ���̿� ������ ����� �� ����.
	int len = 10;

	// ���� �迭�� ���̸� �߰�(�ø���)�� �Ұ�
	// ���� �迭�� ���� ���̷ν� ������ ����
	int* p = (int*)malloc(len * 4); // ���� �迭�� ���� ���� ����
	len += 12;
	p = (int*)realloc(p, len * 4); // �� �Լ��� �����Ҵ����� ������ �͸� ��� ����
	// ���� �迭�� ������ �ϴ� �Լ�


	// malloc
	// realloc
	// calooc( 60, 2) = 120�� ����� �� / �־��� ���� ���ؼ� ����� ��

	free(p);

	return 0;
}