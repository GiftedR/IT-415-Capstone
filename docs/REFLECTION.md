# Reflection

## Week 5

1. The easiest methods to implement were the linear search and the binary search. This is because the idea behind them was simple enough to get written and debug if needed. This is in contrast to Quick Sort which wasn't as simple to debug. There was also an issue where stack overflows would out print the console buffer (Print so many lines that the useful information was hidden). This caused me to rewrite Quick sort with a more iterative approach instead of recursively.

When it came to the performance between them, quick sort was the fastest for sorting, and binary search was the fastest for searching. Although the first run through of the method was substantially higher than subsequent runs due to some of the ways the compiler handles the methods. Needing to cache the methods before being able to run them and such.

As for which algorithm I would use in the capstone, for the capstone of 415 all of them would be used because we are just turning in the current project. As for the capstone of the degree, I will probably use quick sort and binary search to allow for quicker saving and loading of custom project files that will be used.

## Week 3

1. When comparing the built in stack and queue vs my custom implementation. I would definately use the built in over mine in almost any situation. The main reason for this is that I don't have to stress about wheither or not the stack or queue has hidden bugs when building applications. The only time I would use the custom version is when I need to be able to look in the middle of the stack or queue. Like for an actual ticketing system, where its not just the first one that matters, but all of them ordered by priority.

## Week 2

1. InsertIntoArray

	a. The method inserts an item at a specified index.

	b. At the worst case it has to shift every item.

	c. has to shift the array before inserting
2. DeleteFromArray

	a. Deletes the item from a specified index.

	b. At the worst case it has to shift every item.

	c. Works very similarly to inserting
3. ConcatenateNamesNaive

	a. Merges an array of names into one string by looping over them.

	b. It loops over every item to add them together. To do this it needs to loop over every character to copy them over.

	c. Youre actuallu doing multiple concatinations to add commas between each item.
4. ConcatenateNamesBuilder

	a. Merges an array of names into one string by using a StringBuilder.

	b. It inserts into an already made array and grows as it needs to. At worst case it needs to copy all the characters into the new section.

	c. Trys to bypass allocation time by preallocating the space needed.
5. InsertIntoList

	a. Inserts an item into a list.

	b. It inserts into an already made array and grows as it needs to. At worst case it needs to copy into the new array.

	c. Trys to bypass allocation time by preallocating the space needed.
![Test Results](Test-Results-10-05-2025.png)
![Test Results Output](Test-Results-Output-10-05-2025.png)

## Week 1
1. Constant Method

	a. The method returns the first item of the array.

	b. It is classified as O(1) because the time it takes is the same regardless of the size of the data being put into it.

	c. It stayed the same, It only adjusted by margin of error.

2. Linear Method

	a. The method loops through an array and determines whether or not to incude an input from the first array.
	
	b. It is classified as O(n) as it only loops through the array once.

	c. The difference in time was a 10x increase per step which matched the increase in the input size.

3. Quadratic Method

	a. The method adds the ascii value of each character matched with each other character in the string to give the word a score.
	
	b. It is classified as O(n²) because it loops through the data within a loop that is already looping the data.

	c. The time changed at a rate of 100x which matches the squared increase in the data size 10x²

![Test Explorer Results](TestResults-09-28-2025.png)
![Test Explorer Results](TestResults-Output-09-28-2025.png)