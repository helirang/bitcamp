#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#pragma warning(disable:4996)
#pragma pack(1)

char* toString() // �ּҴ� ��Ⱥ������, ���������� �Լ� ���� �� ������Ƿ�. �ش� �ּҷ� ������ ���� �����Ͱ� ����.
{
	// �����Ҵ� - ���� �����Ǿ �Լ��ʹ� ���� ���� ���� ����
	//���������� �Լ� ���� �� �������.
	char *name = (char*)malloc(80); //������ �ʱ�ȭ������ ���� ���� ����.
	// ���� �Ҵ� ��, main�Լ��� ���� ����
	// ���ڿ��� ����(����)
	// name = "jangs ma"; // �迭���� ���, ���Կ��� �Ұ�
	strncpy(name, "jangs ma", 80 ); // ���ڿ��� �迭�� ������ ���� �Լ� �̿�

	//free(name); �ϸ� ������ ���ư�

	return name; //�迭���� �ּ�, ���� ��ȯ������ ����Ʈ
	// NULL Ȯ���ϱ�
}

int getString(char* param, int size)
{
	int i;
	for (i = 0; i < size -1 ; ++i) // sizeof(param)/sizeof(char) = 4 , �����ʹ� ũ�Ⱑ 4����Ʈ�̴�.
	{
		param[i] = '0' + i;
	}
	param[i] = 0; // �������� �ݵ�� 0�̶�� ��(nul, ��)�� �ֱ�
	return 0;
	// keep ����
	// stack around�� �迭 ���� ����
}

int main(int argc, char** argv)
{
	char* p = toString(); 
	// ���� ���� ����. ���� �迭�� nul���ڷ� ���� �� �ֱ� ������ ��ȯ�ص� �۵���.
	// �׷��� int�� double ���� ����, �Ǽ� �迭�� ���� ó���� �� �� ����.
	if (p == NULL)
	{
		printf("���ڿ��� ���� \n");
	}
	else
	{
		printf("%s \n", p);
		free(p);
	}

	char name[80];
	getString(name, 80); // �迭�� �����ض�. �迭��, ����
	// ���ڿ��� ������ �͵��� ��ȯó�� x. �����÷ο� �߻�
	// ���� ó���� �ؾ� �Ѵ�. _s = ���� ���� �ֶ�� ��.

	//���ڿ��� �� ���� �־ ��ȯ ó�� ����
	// �� �ܿ��� �迭�� ��ȯ�ϴ� ó���� ���� �ʴ´�.
	// ���� ��ȯ�� �ؾ� �Ѵٸ�, ����ü�� �迭�� ���̸� �ְ� ��ȯó���� �� �� �ִ�.

	printf("%s \n", name);

	return 0;
}

/*
�߿� - ���ڿ� / nul���ڶ�� ���� �ִ�.
���ڿ��� �迭 - ���� ���ڿ��� �ϳ� �����Ϸ��� �迭 3���� �ʿ��ϴ�.

��ȯ���� �����Ѵ�.
�����ϴ� ����� �����ؾ��Ѵ�.
*/