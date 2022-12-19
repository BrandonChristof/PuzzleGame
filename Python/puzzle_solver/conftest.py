import pytest
import itertools
from src.enums import Directions
from src.puzzle import Puzzle

@pytest.fixture
def puzzle():
    # Puzzle object
    return Puzzle()
