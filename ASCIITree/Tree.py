length = 6
for i in range(length):
    msgSpace = ' ' * (length - i - 1)
    msgAsterix = '*' * (1 + i * 2)
    print(f'{msgSpace}{msgAsterix}')
msgSpace = ' ' * (length - 1)
print(f'{msgSpace}|')