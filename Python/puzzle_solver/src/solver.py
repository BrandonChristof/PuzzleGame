from enums import Directions, Status
from puzzle import Puzzle
import copy


class Solver():

    initial_moves = [Directions.RIGHT,
                     Directions.DOWN,
                     Directions.LEFT,
                     Directions.UP]

    def __init__(self, max_depth=32):
        self.solvable = None
        self.max_depth = max_depth # Max depth solver will look for
        self.num_moves = self.max_depth

        self.next_moves = { Directions.RIGHT: [Directions.DOWN, Directions.UP],
                            Directions.LEFT: [Directions.DOWN, Directions.UP],
                            Directions.UP: [Directions.RIGHT, Directions.LEFT],
                            Directions.DOWN: [Directions.RIGHT, Directions.LEFT]}

        self.visited = set()
        self.visited_with_depth = {}
        self.move_list = [0]*self.max_depth

    def __str__(self):
        direction_str = {   Directions.RIGHT: "Right",
                            Directions.LEFT: "Left",
                            Directions.UP: "Up",
                            Directions.DOWN: "Down"}
        if self.solvable:
            moves = [direction_str[dir] for dir in self.move_list]
            return str(moves)
        else:
            return "Unsolved"

    def solve(self, puzzle, moves=initial_moves, depth=0):
        if depth >= self.max_depth:
            return
        elif puzzle.status == Status.WIN:
            self.solvable = True
            if depth < self.max_depth:
                self.max_depth = self.num_moves = depth
            return
        elif puzzle.status == Status.LOSE:
            return

        depth += 1

        for move in moves:
            temp_puzzle = Puzzle(puzzle.get_position())
            moved = temp_puzzle.move(move)

            if not moved:
                continue

            hsh = temp_puzzle.get_hash_position()
            if hsh in self.visited:
                continue

            if not self.solvable:
                self.move_list[depth-1] = move

            self.visited.add(hsh)
            self.solve(temp_puzzle, self.next_moves[move], depth)
            self.visited.remove(hsh)


    def is_solvable(self, puzzle, moves=initial_moves, depth=0):
        if self.solvable:
            return
        elif depth >= self.max_depth:
            return
        elif puzzle.status == Status.WIN:
            self.solvable = True
            return
        elif puzzle.status == Status.LOSE:
            return

        depth += 1

        for move in moves:
            temp_puzzle = Puzzle(puzzle.get_position())
            moved = temp_puzzle.move(move)

            if not moved:
                continue

            hsh = temp_puzzle.get_hash_position()
            if hsh in self.visited:
                continue

            self.visited.add(hsh)
            self.is_solvable(temp_puzzle, self.next_moves[move], depth)
            self.visited.remove(hsh)

        return self.solvable
