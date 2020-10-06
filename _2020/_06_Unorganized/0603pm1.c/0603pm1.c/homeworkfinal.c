#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int display(int n)
{
	int W = 3;
	int H = 5;
	int O = 15;

	if (n < 10)
	{
		if (n == 9)
		{
			int dipla[5 * 3] = { 1,1,1,1,0,1,1,1,1,0,0,1,0,0,1 };;
			for (int r = 0; r < H; ++r)
			{
				for (int c = 0; c < W; ++c)
				{
					int v = dipla[r * W + c];
					if (v == 0)
					{
						printf(" ");
					}
					else if (v == 1)
					{
						printf("0");
					}
				}
				printf("\n");
			}
		}
	}
	return 0;
}

int main(void)
{
	int yy = 9;
	display(yy);
}