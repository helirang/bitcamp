#include "turboc.h" 


void main()
{
	setcursortype(NOCURSOR); // 커서가 없어지는
	srand(time(NULL));

	int x = 0, y = 12;
	int LoopCase = 0;
	int CountReset = 0;

	for (x = 0;x <= 20;x++)
	{
		gotoxy(x, y);
		puts("#");
		delay(100);
		gotoxy(x, y);
		puts(" ");
	}


		while (1)
		{
			int RandMove = rand() % 3;

			/*
			정리 부분 - 반복문은 해당 상태가 지속되는 동안 반복하는 제어문.
			따라서 x <= 20은 x가 20과 같거나 작은동안 이므로, 해당 반복문에서 빠져나온 x의 값은 21이다. 0 또한 이와 같기에 20과 0을 조건으로 사용하려면 21과 -1을 정리해주어야 한다.
			*/
			if (x > 20) { x = 20; }
			else if (x < 0) { x = 0; }
			else if (y > 20) { y = 20; }
			else if (y < 0) { y = 0; }

			/*
			랜덤으로 x, y값에 관여하므로 쓸모없어진 BASE의 IF문의 X,Y조건을 삭제. LoopCase로 이동 패턴에 관여한다.
			*/
			if (x == 20) { LoopCase = 1; }
			else if (x == 0) { LoopCase = 2; }
			else if (y == 0) { LoopCase = 3; }
			else if (y == 20) { LoopCase = 4; }

			/*
			랜덤하게 이동 시키기
			*/
			for (int i = 0; i < RandMove; ++i)
			{
				switch (LoopCase)
				{
				case 1: 
					if (y == 0) { break; } 
					y -= 1;
					break;

				case 2: 
					if (y == 20) { break; }
					y += 1;
					break;

				case 3:
					if (x == 0) { break; }
					x -= 1;
					break;
				case 4:
					if (x == 20) { break; }
					x += 1;
					break;

				default:
					break;
				}
			}


			/*
			예외 처리 부분 - 0.0 20.0 0.20 20.20은 제대로 동작하지 않는 예외기에 해당 경우에 작동 방법을 지정해주어야 한다.
			*/
			if (x == 20 && y == 20 || x == 0 && y == 0 || x == 20 && y == 0 || x == 0 && y == 20)
			{
				if (RandMove == 1 || RandMove == 0) // randmove가 0이거나 1이면 멈추는 경우를 해결.
				{
					if (x == 20 && y == 20) { y -= 2; LoopCase = 1; }
					else if (x == 0 && y == 0) { y += 2; LoopCase = 2; }
					else if (x == 20 && y == 0) { x -= 2; LoopCase = 3; }
					else if (x == 0 && y == 20) { x += 2; LoopCase = 4; }
				}
				else // 반복되는 구간 탈출 방법.
				{
					for (int i = 0; i < RandMove; ++i)
					{
						switch (LoopCase)
						{
						case 1:
							if (y == 0) { break; }
							y -= 1;
							break;

						case 2:
							if (y == 20) { break; }
							y += 1;
							break;

						case 3:
							if (x == 0) { break; }
							x -= 1;
							break;
						case 4:
							if (x == 20) { break; }
							x += 1;
							break;

						default:
							break;
						}
					}
				}
	
			}

			if (CountReset == 5) { CountReset = 0; clrscr(); } //화면 초기화 
			gotoxy(x, y);
			printf(" x:%d y:%d", x, y);

			switch (LoopCase)
			{
			case 1:
				for (; y >= 0; x--, y--)
				{
					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;

			case 2:
				for (;y <= 20; x++, y++)
				{
					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;

			case 3:
				for (;x >= 0; x--, y++)
				{

					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;

			case 4:
				for (;x <= 20; x++, y--)
				{
					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;

			default:
				break;
			}
			CountReset++;
		}
}
