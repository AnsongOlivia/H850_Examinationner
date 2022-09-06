# from pymavlink.dialects.v20 import common as mavlink2
import random
import time

from pymavlink.dialects.v10 import ardupilotmega as mavlink1
from pymavlink.dialects.v20 import ardupilotmega as mavlink2
from pymavlink.mavutil import mavlink
import serial  # 导入模块

ser = serial.Serial("COM2", 57600, timeout=5)


class fifo(object):
    def __init__(self):
        self.buf = []

    def write(self, data):
        self.buf += data
        ser.write(data)
        print(data)
        return len(data)

    def read(self):
        return self.buf.pop(0)


f = fifo()
mav = mavlink.MAVLink(f)


def get_random():
    return (random.random() - 0.5) / 10.0


satellites_visible = int(random.random() * 100)

while True:
    try:
        mav.attitude_send(10, get_random(), get_random(), get_random(), get_random(), get_random(), get_random())
        mav.gps_raw_int_send(10, 0, 0, 0, 0, 0, 0, 0, 0, satellites_visible=satellites_visible)
        mav.global_position_int_send(
            time_boot_ms=10,
            lat=int(31.1907501 * 10000000.0),
            lon=int(120.9310274 * 10000000.0),
            alt=0,
            relative_alt=int(2.5 * 1000),
            vx=int(get_random() * 100),
            vy=int(get_random() * 100),
            vz=int(get_random() * 100),
            hdg=0
        )
        time.sleep(0.1)
        # mav.ping_send(10, 0, 0, 0)
        # time.sleep(0.01)
    except InterruptedError:
        break

ser.close()  # 关闭串口
