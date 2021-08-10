import asyncio
import time

def slow():
    time.sleep(3)
    print("Slow done")

def fast():
    time.sleep(1)
    print("Fast done")

async def main():
    print("Starting")
    task1 = loop.create_task(slow())
    task2 = loop.create_task(fast())
    await asyncio.wait({task1, task2}, asyncio.FIRST_COMPLETED)

if __name__ == '__main__':
    try:
        loop = asyncio.get_event_loop()
        loop.run_until_complete(main())
    except Exception as e:
        print(e)
    finally:
        loop.close()