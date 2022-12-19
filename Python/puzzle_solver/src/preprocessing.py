from itertools import permutations

class Preprocess:

    left_cache = {}
    right_cache = {}
    win_cache = {}
    lose_cache = {}

    rows = [(0, 0, 0, 0, 0, 0, 0, 2),
            (0, 0, 0, 0, 0, 0, 2, 2),
            (0, 0, 0, 0, 0, 2, 2, 2),
            (0, 0, 0, 0, 2, 2, 2, 2),

            (1, 0, 0, 0, 2, 2, 2, 2),
            (1, 1, 0, 0, 2, 2, 2, 2),
            (1, 1, 1, 0, 2, 2, 2, 2),
            (1, 1, 1, 1, 2, 2, 2, 2),

            (1, 0, 0, 0, 0, 2, 2, 2),
            (1, 1, 0, 0, 0, 2, 2, 2),
            (1, 1, 1, 0, 0, 2, 2, 2),
            (1, 1, 1, 1, 0, 2, 2, 2),
            (1, 1, 1, 1, 1, 2, 2, 2),

            (1, 0, 0, 0, 0, 0, 2, 2),
            (1, 1, 0, 0, 0, 0, 2, 2),
            (1, 1, 1, 0, 0, 0, 2, 2),
            (1, 1, 1, 1, 0, 0, 2, 2),
            (1, 1, 1, 1, 1, 0, 2, 2),
            (1, 1, 1, 1, 1, 1, 2, 2),

            (1, 0, 0, 0, 0, 0, 0, 2),
            (1, 1, 0, 0, 0, 0, 0, 2),
            (1, 1, 1, 0, 0, 0, 0, 2),
            (1, 1, 1, 1, 0, 0, 0, 2),
            (1, 1, 1, 1, 1, 0, 0, 2),
            (1, 1, 1, 1, 1, 1, 0, 2),
            (1, 1, 1, 1, 1, 1, 1, 2)]

    @staticmethod
    def move_right(arr):
        new_arr = "".join([str(a) for a in arr])
        split = new_arr.split("1")
        for i, val in enumerate(split):
            split[i] = "".join(sorted(val))
        join = "1".join(split)
        new_arr = tuple([int(j) for j in join])
        return new_arr

    @staticmethod
    def move_left(arr):
        new_arr = "".join([str(a) for a in arr])
        split = new_arr.split("1")
        for i, val in enumerate(split):
            split[i] = "".join(sorted(val, reverse=True))
        join = "1".join(split)
        new_arr = tuple([int(j) for j in join])
        return new_arr

    @classmethod
    def set_data(cls, rows):
        for r in rows:
            perms = [p for p in permutations(r)]
            perms = set(perms)
            for p in perms:
                temp = cls.move_right(p)

                if temp[-4:].count(2) == 4:
                    cls.win_cache[p] = temp
                elif temp[-4:].count(2) > 0 and temp[-1] == 2:
                    cls.lose_cache[p] = temp
                cls.right_cache[p] = temp
                cls.left_cache[p] = cls.move_left(p)

        for k, v in list(cls.right_cache.items()):
            if k == v:
                del cls.right_cache[k]

        for k, v in list(cls.left_cache.items()):
            if k == v:
                del cls.left_cache[k]
