#include <iostream>
#include<time.h>
using namespace std;


//глобальна функція(до всіх)
double random(double min, double max)
{
	return (double)(rand()) / RAND_MAX * (max - min) + min;
}

//1TASK

//int main()
//{
//	clock_t start, end;
//	start = clock();
//	int n = 3000;
//
//	double sum = 5;
//	for (double i = 1; i < n; i++) {
//		for (double j = 1; j < n; j++) {
//			sum = sum + (1 / (i * j));
//		}
//	}
//	end = clock();
//	double t1 = ((double)end - start) / ((double)CLOCKS_PER_SEC);
//	cout << "time: " << t1 << "\n";
//	system("pause");
//	//0.026 debug 0.011 release
//	return 0;
//}

//2TASK

//int main()
//{
//	clock_t start, end;
//	start = clock();
//	const int n = 10000;
//	double matrix[n];
//	for (int i = 0; i < n; i++) {
//		matrix[i] = random(1, 1.1);	
//	}
//
//	double sum = 0;
//	for (int i = 1; i < n; i++) {
//		for (int j = 1; j < n; j++) {
//			sum += 1 / (matrix[i] * matrix[j]);
//		}
//	}
//	end = clock();
//	double t1 = ((double)end - start) / ((double)CLOCKS_PER_SEC);
//	cout << "time: " << t1 << "\n";
//	system("pause");
//	//0.282 debug 0.001 release
//	return 0;
//}


//3TASK


int main()
{
	clock_t start, end;
	start = clock();
	int n = 500;

	double **matrix = new double*[n];
	for (int count = 0; count < n; count++)
		matrix[count] = new double[n];
	double **matrix1 = new double*[n];
	for (int count = 0; count < n; count++)
		matrix1[count] = new double[n];

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			matrix[i][j] = random(1, 1.1);
			matrix1[i][j] = random(1, 1.1);
		}
	}
	
	double **sum = new double*[n];
	for (int count = 0; count < n; count++)
		sum[count] = new double[n];
	for (int i = 1; i < n; i++) {
		for (int j = 1; j < n; j++) {
			for (int k = 1; k < n; k++) {
				sum[i][j] += matrix[i][k] * matrix1[k][j];
			}
		}
	}
	end = clock();
	double t1 = ((double)end - start) / ((double)CLOCKS_PER_SEC);
	cout << "time: " << t1 << "\n";
	for (int count = 0; count < n; count++)
	{
		delete[]matrix[count];
		delete[]matrix1[count];
	}

	system("pause");
	//0.997 debug 0.225 release
	return 0;
}
