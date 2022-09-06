minNumber = 0
nums = [0, 2, 4, 5, 1, -5, 4, 14]
for i in range(len(nums)):
    if minNumber > nums[i]:
        minNumber = nums[i]
print(minNumber)