def createPairs(numbers, k):
    numbers.sort()
    pairs = set()
    iteration = set(numbers)
    for number in numbers:
        for i in iteration:
            if number < i and number + k == i:
                pairs.add((number, i))
    print(pairs)
    return len(pairs)

def is_pair(a, b, k):
    if a <= b and  a + k == b:
        return True
    else:
        return False


def createPairs2(numbers, k):
    numbers.sort()
    pairs = set()
    iteration = set(numbers)
    for number in numbers:
        pairs.add((number, b for b in iteration if (is_pair(number, b, k))))
    print(pairs)
    return len(pairs)






if __name__ == '__main__':
    sample1 = [1, 3, 4, 5, 7, 10, 12, 15]

    print(createPairs(sample1, 2))
    print(createPairs2(sample1, 2))
    print(createPairs(sample1, 1))
    print(createPairs2(sample1, 1))
    print(createPairs(sample1, 3))
    print(createPairs2(sample1, 3))