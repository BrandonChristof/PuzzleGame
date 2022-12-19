from enums import Directions, Status
from preprocessing import Preprocess

class Puzzle(Preprocess):

    Preprocess().set_data(Preprocess.rows)
    left_cache = Preprocess.left_cache
    right_cache = Preprocess.right_cache
    win_cache = Preprocess.win_cache
    lose_cache = Preprocess.lose_cache

    def __init__(self, position=None):
        if position is not None:
            self.position = position
            self.position_rot = position
            self.update_rotated_matrix()

        self.size = 8
        self.sliders = 4
        self.last_move = None
        self.status = Status.ACTIVE
        self.move_list = []
        self.move_count = 0

    def set_position(self, position):
        self.position = position
        self.position_rot = position
        self.update_rotated_matrix()

    def __str__(self):
        for row in self.position:
            print(row)
        return ""

    def get_position(self):
        return [pos for pos in self.position]

    def update_normal_matrix(self):
        self.position = list(zip(*self.position_rot))[::-1]

    def update_rotated_matrix(self):
        self.position_rot = list(zip(*self.position[::-1]))

    def get_hash_position(self):
        return tuple(self.position)

    def move_right(self):
        moved = False
        for i, row in enumerate(self.position):
            if i == 7:
                if row in self.win_cache:
                    self.position[i] = (1, 1, 1, 1, 1, 1, 1, 1)
                    self.status = Status.WIN
                    moved = True
                    break
                if row in self.lose_cache:
                    self.position[i] = (1, 1, 1, 1, 1, 1, 1, 1)
                    self.status = Status.LOSE
                    moved = True
                    break
            if row in self.right_cache:
                self.position[i] = self.right_cache[row]
                moved = True
        if moved:
            self.move_count+=1
            self.update_rotated_matrix()
        return moved

    def move_left(self):
        moved = False
        for i, row in enumerate(self.position):
            if row in self.left_cache:
                self.position[i] = self.left_cache[row]
                moved = True
        if moved:
            self.move_count+=1
            self.update_rotated_matrix()
        return moved

    def move_down(self):
        moved = False
        for i, row in enumerate(self.position_rot):
            if row in self.left_cache:
                self.position_rot[i] = self.left_cache[row]
                moved = True
        if moved:
            self.move_count+=1
            self.update_normal_matrix()
        return moved

    def move_up(self):
        moved = False
        for i, row in enumerate(self.position_rot):
            if row in self.right_cache:
                self.position_rot[i] = self.right_cache[row]
                moved = True
        if moved:
            self.move_count+=1
            self.update_normal_matrix()
        return moved


    def move(self, direction):
        moved = False
        if direction == Directions.RIGHT:
            moved = self.move_right()
        elif direction == Directions.UP:
            moved = self.move_up()
        elif direction == Directions.LEFT:
            moved = self.move_left()
        elif direction == Directions.DOWN:
            moved = self.move_down()
        return moved

    def reset(self):
        self.position = copy.deepcopy(self.initial_position)
        self.position_rot = copy.deepcopy(self.initial_position_rot)
        self.status = Status.ACTIVE
        self.move_list = []
        self.last_move = None
        self.move_count = 0

    def random_move(self):
        if self.last_move == Directions.RIGHT or self.last_move == Directions.LEFT:
            rand_move = random.choice([Directions.UP, Directions.DOWN])
        elif self.last_move == Directions.UP or self.last_move == Directions.DOWN:
            rand_move = random.choice([Directions.RIGHT, Directions.LEFT])
        else:
            rand_move = random.choice(list(Directions))

        self.last_move = rand_move
        self.move_list.append(rand_move)
        self.move(rand_move)
