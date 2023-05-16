import datetime


def read():
    f = open("qwe.zxc", "r")
    print(f.read())
    f.close()


def write():
    f = open("qwe.zxc", "w")
    to_write = datetime.datetime.now()
    f.write(to_write)
    f.close()
    print(f"written: {to_write}")

while True:
    input_ = input("[r]/[w]: ")
    if input_ == "r": read()
    elif input_ == "w": write()
    elif input_ == "e": exit()