#!/bin/python3
"""
Amy has an array, nums, of n positive integers and another array, maxes, of m positive integers. For each maxesi in maxes, she wants to know the total number of elements in nums which are less than or equal to that maxesi. For example, if nums = [1, 2, 3] and maxes = [2, 4], then there are 2 elements in nums that are ≤ maxes0 (which is 2) and 3 elements in nums that are ≤ maxes1 (which is 4). We can store these respective answers in another array, answer = [2, 3].

Complete the counts function in the editor below. It has two parameters: An array, nums, of n positive integers. An array, maxes, of m positive integers. The function must return an array of m positive integers in which the integer at each index i (where 0 ≤ i < m) denotes the total number of elements numsj (where 0 ≤ j < n) satisfying numsj ≤ maxesi.

Input Format Locked stub code in the editor reads the following input from stdin and passes it to the function: The first line contains an integer, n, denoting the number of elements in nums. Each line j of the n subsequent lines (where 0 ≤ j < n) contains an integer describing numsj. The next line contains an integer, m, denoting the number of elements in maxes. Each line i of the m subsequent lines (where 0 ≤ i < m) contains an integer describing maxesi.

Constraints 2 ≤ n, m ≤ 105 1 ≤ numsj ≤ 109, where 0 ≤ j < n. 1 ≤ maxesi ≤ 109, where 0 ≤ i < m.

Output Format The function must return an array of m integers where the value stored at each index i (where 0 ≤ i < m) denotes the total number of elements numsj (where 0 ≤ j < n) satisfying numsj ≤ maxesi. This is printed to stdout by locked stub code in the editor.
"""

from pprint import pprint as pp


def countingMaxes(numbers, maxes):

    numbers.sort()
    maxes.sort()
    maxesCount = {}

    for maxi in maxes:
        maxesCount[maxi] = 0
        for number in numbers:
            if number <= maxi:
                maxesCount[maxi] += 1

    pp(maxesCount)


if __name__ == "__main__":
    sample1Numbers = [1, 4, 2, 4]
    sample1Maxes = [3, 5] * 100

    sample2Numbers = [2, 10, 5, 4, 8]
    sample2Maxes = [3, 1, 7, 8, 1, 20]

    countingMaxes(sample1Numbers, sample1Maxes)
    countingMaxes(sample2Numbers, sample2Maxes)

