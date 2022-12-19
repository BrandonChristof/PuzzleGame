import pytest
import itertools
from src.enums import Directions
from src.solver import Solver
from sample_puzzles import solvable_puzzles, unsolvable_puzzles
import time
from multiprocessing import Process

def initial_moves_permutations():
    # List of starting moves
    perms = list(tuple(itertools.permutations([Directions.RIGHT, Directions.LEFT, Directions.UP, Directions.DOWN])))
    return perms

@pytest.mark.parametrize("position, optimal_solution", solvable_puzzles)
@pytest.mark.parametrize("init_moves", initial_moves_permutations())
def test_solvable(puzzle, position, optimal_solution, init_moves):
    # Tests whether solvable positions are solvable
    puzzle.set_position(position)
    solver = Solver()
    assert solver.is_solvable(puzzle, init_moves)

@pytest.mark.parametrize("position", unsolvable_puzzles)
@pytest.mark.parametrize("init_moves", initial_moves_permutations())
def test_unsolvable(puzzle, position, init_moves):
    # Tests whether unsolvable positions are unsolvable
    puzzle.set_position(position)
    solver = Solver()
    assert not solver.is_solvable(puzzle, init_moves)

@pytest.mark.parametrize("position, optimal_solution", solvable_puzzles)
@pytest.mark.parametrize("init_moves", initial_moves_permutations())
def test_accuracy(puzzle, position, optimal_solution, init_moves):
    # Tests whether algorithm finds optimal solution
    puzzle.set_position(position)
    solver = Solver()
    solver.solve(puzzle, init_moves)
    assert solver.solvable
    assert solver.num_moves == optimal_solution

@pytest.mark.parametrize("position, optimal_solution", solvable_puzzles)
@pytest.mark.parametrize("init_moves", initial_moves_permutations())
def test_speed(puzzle, position, optimal_solution, init_moves):
    # Tests whether alogirthm is fast enough to find optimal solution
    timeout = 30
    puzzle.set_position(position)
    solver = Solver()
    p = Process(target=solver.solve, args=(puzzle, init_moves))
    p.start()
    p.join(timeout=timeout)
    assert not p.is_alive()
