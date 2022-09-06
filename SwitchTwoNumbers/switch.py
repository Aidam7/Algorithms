# firstNumber = 0
# secondNumber = 1
# temp = firstNumber
# print(f'First:{firstNumber}\nSecond:{secondNumber}')
# firstNumber = secondNumber
# secondNumber = temp
# print(f'First:{firstNumber}\nSecond:{secondNumber}')
x = 1
y = 5
print(f'First:{x}\nSecond:{y}')
x = x + y

y = x - y

x = x - y
print(f'First:{x}\nSecond:{y}')