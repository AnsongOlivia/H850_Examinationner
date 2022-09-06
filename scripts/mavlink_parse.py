
from pymavlink.dialects.v10 import ardupilotmega as mavlink1
from pymavlink.dialects.v20 import ardupilotmega as mavlink2
from pymavlink.mavutil import mavlink


mav = mavlink.MAVLink(None)
s = mav.decode(b'FD1C00006A01011E0000A93000005F352A3C3A390A3BEAD1484090CD773980F4AD39C108FAB9EE00')
print(s)
