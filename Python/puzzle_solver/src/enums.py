from enum import IntEnum

class Directions(IntEnum):
    RIGHT = 0
    UP = 1
    LEFT = 2
    DOWN = 3

class Status(IntEnum):
    ACTIVE = 0
    LOSE = 1
    WIN = 2
