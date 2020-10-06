#include <stdio.h>
#include <stdlib.h>

int main(void)
{
	//길이 15인 정수형 1차 배열 선언하기
	int numbers[15] = { 0 };
	int length = 15; //sizeof(배열명) // sizeof(int);
	srand((unsigned int)time(NULL));// 난수 발생 기준값 변경 - rand() 난수 값 변경
	// srand값을 변하게 해야 매 프로그램 실행마다 바뀌어서 나옴.
	// 모든 요소에 임의 정수를 저장하기
	for (int i = length - 1; i >= 0; --i)
	{
		numbers[i] = rand(); // + 나 - 로 수 제한 가능 // 0~32656
	}
	for (int i = 0; i < length; ++i)
	{
		printf("%6d\n", numbers[i]); //%6d = 6자리 간격으로 출력한다.
	}
	printf("\n");

	// 배열 처리 시 기본 기능
	int min; // 값찾기 배열
	int max;
	min = max = numbers[0];  // min과 max를 numbers 배열 첫번째로 지정
	// 찾기 : 찾을거 구별 잘하기, 값을 찾는 것인지 or 요소를 찾는 것인지
	for (int i = 1; i < length; ++i)
	{
		if (min > numbers[i]) // min이 numbers의 2번째(1 + i) 값보다 작은가?
		{
			min = numbers[i]; // 작으면 min은 더 작은 수로 갱신된다.
		}
		if (max < numbers[i]) // max가 numbers의 2번째(1 + i) 값보다 큰가?
		{
			max = numbers[i]; // 크면 min은 더 큰 수로 갱신된다.
		}
	}
	printf("Max : %d, Min : %d \n", max, min);
	//요소번호 찾기 배열

	min = max = 0; // min과 max = 0으로 초기화

	for (int i = 1; i < length; ++i)
	{
		if (numbers[min] > numbers[i]) // numbers 1번(두번째)가 0번(첫전째) 보다 작은가?
		{
			min = i; //  작은면 min은 i로 갱신한다.
		}
		if (numbers[max] < numbers[i])// numbers 1번(두번째)가 0번(첫전째) 보다 큰가?
		{

			max = i; //  크면 max는 i로 갱신한다.
		}
	}
	printf("Max : %d, Min : %d \n", max + 1, min + 1);

	// 배열 요소들을 크기 순서대로 재배치 - 정령 sort
	// 정렬 방법 - 알고리즘(다양하다)
	// 비교 - 교환
	// 정렬 - 아래 코드는 매 반복마다 최대값과 최소값은 하나씩 제거하는 알고리즘.

	int first = 0; // 첫번째 요소번호
	int last = length - 1; // 마지막 요소번호
	for (int k = 0; k < (length / 2); ++k) // 중첩시 변수 이름 중복 x
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

	// 정렬 - 아래 코드는 매 반복마다 최대값과 최소값은 하나씩 제거하는 알고리즘.
	first = 0; // 첫번째 요소번호
	last = length - 1; // 마지막 요소번호
	for (int k = 0; k < (length / 2); ++k) // 중첩시 변수 이름 중복 x
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
		// 교환
		int t = numbers[min];
		numbers[min] = numbers[first];
		numbers[first] = t;
		t = numbers[max];
		numbers[max] = numbers[last];
		numbers[last] = t;
		++first;
		--last;
	}
	// 정렬 후 출력 
	for (int i = 0; i < length; ++i)
	{
		printf("%d\t", numbers[i]);
	}
	printf("\n");
	return 0;
}