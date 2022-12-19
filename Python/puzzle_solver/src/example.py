
from puzzle import Puzzle
from solver import Solver
import timeit
import time

puzzle_to_solve =  [(2, 2, 0, 1, 0, 0, 0, 0),
                    (2, 2, 1, 0, 1, 0, 0, 0),
                    (1, 0, 0, 0, 0, 0, 0, 0),
                    (0, 0, 0, 0, 1, 1, 0, 0),
                    (0, 1, 0, 0, 0, 1, 0, 0),
                    (1, 0, 1, 0, 0, 0, 0, 0),
                    (0, 0, 0, 0, 0, 0, 1, 0),
                    (0, 0, 0, 1, 0, 0, 0, 0)]

# Create puzzle object by passing puzzle definition
puzzle = Puzzle(puzzle_to_solve)

# Create solver object to find optimal solution or determine if solvable
solver = Solver()

start_time = time.time()
solver.solve(puzzle) # Finds optimal solution
end_time = time.time()

if solver.solvable:
    print("Solved in {:0.3f} seconds".format(end_time-start_time))
    print("Optimal solution: {} moves".format(solver.num_moves))
    print("Solution: {}".format(solver))
else:
    print("Unsolvable")
    print("Took {} seconds".format(end_time-start_time))
