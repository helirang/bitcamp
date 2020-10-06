#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(void)
{
	int n[10] = { 0 }; // 배열명은 첫 요소 주소
	printf("n : %d \n", n); // 배열명은 첫 요소의 주소
	printf("n : %d \n", sizeof(*n)); 
	//  sizeof(n) = 배열크기 /sizeof(*n) / 배열명은 요소의 주소, 즉 첫번째 요소의 주소이며, 따라서 이 명령은 첫번째 요소의 주소를 따라가 사이즈를 파악한다. 즉 첫번째 요소의 크기
	printf("%d", &n);
	printf("%d", sizeof(*(&n))); 	// 배열의 주소 = &배열명 ( 다차배열에서 중요! ) // 컴퓨터의 기본은 byte = 40 = 40 byte

	int* p1; // 배열명은 int 정수이니 정상 코드
	p1 = n; // 배열명 n은 주소 n == &n[0]
	int (*p2)[10] = &n; // 배열의 주소를 저장하는 배열 포인터

	return 0;
}
int main_02(void)
{
	// p는 포인터 변수다.
	char ch = 'A';
	printf("size : %d \n", sizeof(ch)); // ch 변수의 크기
	printf("addres : %d \n", &ch); // 변수의 주소
	printf("size : %d \n", sizeof(&ch)); // 포인터 변수의 크기

	char* p;
	printf("size : %d \n", sizeof(p)); // ch 변수의 크기
	printf("addres : %d \n", &p); // 변수의 주소
	printf("size : %d \n", sizeof(&p)); // 포인터 변수의 크기

	p = &ch; // ch 변수의 주소를 저장한다.
	printf("%d \n", p); // 주소
	printf("%d \n", *p); // 이름 // 즉 포인터가 값을 호출하는게 아니라, 주소를 활용해 해당 변수를 호출 하는 것.
	*p = 'B';
	printf("%c \n", ch); // 이름 ch 
	// 포인터 - 간접 참조, 간접 참조

	p = 'c';
	return 0;
}

/*
int main_01(void)
{
	//포인터 변수의 선언 : 자료형 * 변수명;
	// 포인터 변수에 저장된 주소에 어떤 유형이 있나

	&(ch); ch의 주소를 확인하는 방법.
	char ch; //문자를 1개 저장하는 변수
	char* p1; //char형 변수(이름)를 가리키는 포인터 변수 // char* p1 = char *p1 
	//char 변수 여러 개를 다룰 수 있다. ( 배열처럼) // 배열을 포인터로 접근 할 수 있다. 1차 포인터 
	char** p;
	//char 변수를 가리키는 포인터 변수를 가리키는 포인터 변수 / 2중 포인터 / 다차포인터 / ** 이상은 포인터의 주소를 저장하는 애들
	// 보통 삼중 포인터 이하. 

	char* ap1[3]; // 포인터 변수들을 요소로하는 1차 배열
	char (*ap2)[3]; // 배열을 가리키는 배열 포인터 변수
	char* (*ap3)[3]; // 배열을 가리키는 포인터 변수

	char (*fp)(void); // 함수를 가리키는 포인터 변수 함수 = (void)
	char (*evt[5])(void); // 함수 포인터 배열
}
*/