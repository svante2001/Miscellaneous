import threading
import time

def square(numbers):
    for n in numbers:
        print('Square of %d is %d' % (n, n*n))

def cube(numbers):
    for n in numbers:
        time.sleep(0.5)
        print('Cube of %d is %d' % (n, n*n*n))

arr = [2,4,6,8,10]

t1= threading.Thread(target=square, args=(arr,))
t2= threading.Thread(target=cube, args=(arr,))

t1.start()
t2.start()

t1.join()
t2.join()

print('Done')