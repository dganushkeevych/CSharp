import time
import random

# 1TASK

# n = 3000
# sum = 0
# start = time.time()
# for i in range(1, n):
#     for j in range(1, n):
#         sum += (1 / (i * j))
# end = time.time()
# print(f"time: {end - start}")

# 2TASK

start = time.time()
n= 10000
arr = [random.uniform(1.0, 1.1) for i in range(n)]
sum = 0
for i in range(1, n):
    for j in range(1, n):
        sum += 1 / (arr[i] * arr[j])
end = time.time()
time = end - start
print("time: ", time)


# 3TASK

# n = 500
# matrix = [[random.uniform(1.0, 1.1) for i in range(n)] for j in range(n)]
# matrix1 = [[random.uniform(1.0, 1.1) for i in range(n)] for j in range(n)]
#
# for i in range(n):
#     for j in range(n):
#         matrix[i][j] = random.uniform(1.0, 1.1)
#         matrix1[i][j] = random.uniform(1.0, 1.1)
#
# sum = [[0 for i in range(n)] for j in range(n)]
# start = time.time()
# for i in range(n):
#     for j in range(n):
#         for k in range(n):
#             sum[i][j] += matrix[i][k] * matrix1[k][j]
# end = time.time()
# print(f"time: {end - start} ")
