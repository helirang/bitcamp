#include "turboc.h" 


void main()
{
	setcursortype(NOCURSOR); // 커서가 없어지는

	int x = 0, y = 12;
	int count = 0;

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
		while (1)
		{
			if (x > 20) { x = 20; }
			else if (x < 0) { x = 0; }
			else if (y > 20) { y = 20; }
			else if (y < 0) { y = 0; }

			if (count == 4)
			{
				clrscr();
				count = 0;
			}

			gotoxy(x, y);
			printf(" x:%d y:%d", x, y);

			if (x == 20)
			{
				for (; y >= 0; x--, y--)
				{
					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;
			}
			else if (x == 0)
			{
				for (;y <= 20; x++, y++)
				{
					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;
			}
			else if (y == 0)
			{
				for (;x >= 0; x--, y++)
				{

					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;
			}
			else if (y == 20)
			{
				for (;x <= 20; x++, y--)
				{
					gotoxy(x, y);
					puts("#");
					delay(100);
					gotoxy(x, y);
					puts(" ");
				}
				break;
			}
		}
		count++; 
	}
}
