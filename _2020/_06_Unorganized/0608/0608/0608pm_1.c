#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main_1(int argc, char** argv)
{
	//배열 쪼개기
	char student[80] = { 0 };
	char* name = student;
	int* kor = student + 60; // 59개 wht? -> 59개 + 문자열 끝에 \0이 들어가니까
	int* eng = student + 64;
	int* math = student + 68;
	int* score = (int*)(student + 60); // 60번 주소. &student[60] // (int*)(student + 60); ?
	// 대입 연산자는 양쪽의 자료형을 같게 하여야 한다.
	// 포인터변수는 선언시 지정된 자료형에 따라 작동한다

	scanf_s("%s", name, 60); // 포인터변수의 크기 4
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
	// 동적할당 : 포인터 변수, 함수 - 결국 배열
	int length = 60; //sizeof(p) = 4 / 포인터라 4바이트라고 나옴 . sizeof(*p) = 1바이트
	char* p = (char*)malloc( length * sizeof(char)/*길이 + 요소, 즉 전체크기 할당, 주로 배열을 생성하기 위해서 사용*/);//동적할당 함수 / void * 타입을 정해서 써라.
	// p[0] ~ p[59]를 만든 함수.
	for (int i = 0; i < length; ++i)
	{
		p[i] = 'a' + i; //배열이다.
	}
	// 동적할당으로 생성된 공간, 배열은 반드시 해체한다.
	if (p != NULL)
	{
		free(p); // 메모리 비우기.
		// 할당받은 주소를 다시 써야한다. 
		// p를 변경하면 안된다.
		// 즉 포인터 p의 주소정보를 변경하면 안 된다.

		// 오류 keep pointer 
		// malloc 함수로 받은 주소가 변경된 경우.
		p = NULL;
	}
	return 0;
}

int main(void)
{
	// 정적 배열 선언의 제한. 동적 배열을 사용하는 이유
	int nums[10]; // 선언 시 길이에 변수를 사용할 수 없더.
	int len = 10;

	// 정적 배열은 길이를 추가(늘린다)가 불가
	// 동적 배열은 가변 길이로써 변경이 가능
	int* p = (int*)malloc(len * 4); // 동적 배열은 길이 변경 가능
	len += 12;
	p = (int*)realloc(p, len * 4); // 이 함수는 동적할당으로 생선된 것만 사용 가능
	// 동적 배열을 재정의 하는 함수


	// malloc
	// realloc
	// calooc( 60, 2) = 120개 만드는 애 / 주어진 것을 곱해서 만드는 애

	free(p);

	return 0;
}