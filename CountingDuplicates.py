#!/bin/python3
"""
Consider an array of n integers, numbers. We define a non-unique value of numbers to be an integer that appears at least twice in the array. For example, if numbers = [1, 1, 2, 2, 2, 3, 4, 3, 9], then there are a total of 3 non-unique values in the array (i.e., 1, 2, and 3).

Complete the countDuplicates function in the editor below. It has 1 parameter: an array of integers, numbers. It must return an integer denoting the number of non-unique values in the numbers array.

Input Format Locked stub code in the editor reads the following input from stdin and passes it to the function: The first line contains an integer, n, denoting the size of the numbers array. Each line i of the n subsequent lines (where 0 ≤ i < n) contains an integer describing the value of numbersi.

Constraints 1 ≤ n ≤ 1000 1 ≤ numbersi ≤ 1000

Output Format The function must return an integer denoting the number of non-unique values in numbers. This is printed to stdout by locked stub code in the editor.
"""


def countingDuplicates(numbers):
    numbers.sort()
    uniques = set()
    count = 0

    for number in numbers:
        if number in uniques:
            count += 1
        else:
            uniques.add(number)

    print("There are %s repeated numbers" % count)


if __name__ == "__main__":
    sample1 = [1, 3, 1, 4, 5, 6, 3, 2]
    sample2 = [1, 1, 2, 2, 2, 3]

    countingDuplicates(sample1)
    countingDuplicates(sample2)





