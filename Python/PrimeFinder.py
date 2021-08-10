def primeFinder(n):
    for i in range(2, n):
        if n % i == 0:
            return False
    return True

primelist = []
for i in range(0, 100):
    if (primeFinder(i) == True):
        primelist.append(i)

print(primelist)