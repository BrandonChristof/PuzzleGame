'''
    Script used to generate puzzles with a
    given amount of moves as the optimal solution.

    Ex: To generate a puzzle with an optimal solution of 15:
        generate.py -m 15
'''
from puzzle import Puzzle
from solver import Solver
from enums import Directions
import argparse
import sys
import time
import random

parser = argparse.ArgumentParser()
parser.add_argument("-m", "--moves", help="Search for a puzzle with this" \
                                          "many moves as the optimal solution",
                                          default=5)

def random_puzzle():
    threshold = 0.83
    canvas = [  [2, 2, 0, 0, 0, 0, 0, 0],
                [2, 2, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, -1, -1, -1, -1]]

    for x, row in enumerate(canvas):
        for y, col in enumerate(row):
            if col == 2:
                continue
            elif col == -1:
                canvas[x][y] = 0
                continue
            r = random.uniform(0, 1)
            if r > threshold:
                canvas[x][y] = 1
    return [tuple(row) for row in canvas]


def generate_puzzle(min_moves):
    print("Generating...")
    min_moves = int(min_moves)
    while True:
        candidate = Puzzle(random_puzzle())
        solver = Solver(min_moves+1)
        if solver.is_solvable(candidate, [Directions.RIGHT, Directions.DOWN]):
            solver.solve(candidate)
            if solver.num_moves >= min_moves:
                print(candidate)
                print("Optimal solution: {} moves".format(solver.num_moves))
                print("Solution: {}".format(solver))
                return

if __name__ == "__main__":
    args = parser.parse_args()
    start_time = time.time()
    generate_puzzle(int(args.moves))
    end_time = time.time()
    print("Found in {:0.3f} seconds".format(end_time-start_time))
