# Lab 1 - Algorithms

This is my first assignment in the course Programming with C# in the .NET Developer program at IT-högskolan in Gothenburg. The task was to create a console application that asks the user to input a text (string) in the console. The entered string should then be searched for all substrings that are numbers starting and ending with the same digit, without the start/end digit or any other character than digits appearing in between.

![./images/correct_output.png)

## The Task

### Lab 1 – Find Numbers in a String with Characters

Create a console application that asks the user to input a text (string) in the console. The entered string should then be searched for all substrings that are numbers starting and ending with the same digit, without the start/end digit or any other character than digits appearing in between.

For example, 3463 is a correct number, but 34363 is not because there is an additional 3 in the number, besides the start and end digit. Strings with letters in them, such as 95a9, are also not correct numbers.

**Print and Highlight Each Correct Substring**

For each substring that matches the above criteria, the program should print a line with the entire string, but with the substring highlighted in a different color. You can se the example output for input “29535123p48723487597645723645” in the image above.

## My solution

The user inputs a text which is stored in the variable **input**.

En array called **substrings** is declared and calls the function [FindValidSubstrings](#findvalidsubstrings) with the **input** variable as an argument. The **FindValidSubstrings** function returns an array with substrings.

A for loop iterates through the **substrings array** and calls the [PrintHiglightedString](#printhighlightedstring) function and creates a new line for every substring in the array. 

A variable called **totalSum** is declared and set to **0**. 

A foreach loop iterates through the **array of substrings** and summarise all substrings by parsing them to long variables. 

### FindValidSubstrings

This function extracts substrings starting and ending with the same character. 

First, an array named **result** is created. Since we do not know the length of the array from the beginning, we use a formula to calculate the size of the array that will hold all possible substrings that can be generated from a given string. The formula is used to calculate the maximum number of substrings that can be created from a string with its length.

Next, a variable named **index** is declared and set to **0**.

A for loop iterates through the entire string from **index 0** to the **last index**. Inside this for loop, the string is iterated again, but this time from the **current index + 1** to the **last index** of the string. Inside the nested for loop, the current “outer” index is compared with the current “inner” index. If these are equal, a substring is created. The substring’s start index is the current “outer” index, and its length is the current “inner” index minus the “outer” index + 1. Once the substring is created, the following functions are called:

- [AreInnerCharsDifferentFromFirst](#areinnercharsdifferentfromfirst)
- [ContainsOnlyDigits](#containsonlydigits)

If both functions return true, the current substring is added to the first available index in the **result** array.

If one or both functions return false, the inner for loop continues to iterate to find the next match of the current outer index with the current inner index.

When the inner loop has iterated through the entire string, the outer loop moves to the next index, and the above procedure is repeated until the entire string has been iterated through by the outer loop.

Before the **result** array is returned, we use the **Array.Resize method** to change the size of the result array. By referencing an array named result, result will refer to a new array with the specified size that we obtain from the index variable.

### AreInnerCharsDifferentFromFirst

This function checks that characters between the first and last character of a given string. 

This function takes a string parameter. A variable named **firstChar** is declared and initialized to index 0 in the received string. Then, the string is iterated from index 1 to the second-to-last index to compare all characters in between with firstChar. If any character between the first and last character in the string is equal to firstChar, the function returns **false**. Otherwise, the function returns **true**.

### ContainsOnlyDigits

This function checks that all characters in the string are digits using a foreach loop. In the loop, each character in the string is checked with the **Char.IsDigit method**. If a character is not a digit, the function returns **false**. If all characters are digits the function returns **true**.

### PrintHighlightedString

Function that highlights a specified substring within a given string by printing the string with the substring displayed in blue text.

This function takes an original string and a substring as parameters.

In the function, a variable named **startIndex** is declared and initialized to the first index where the substring starts in the original string.

First, the original string is printed up to the **startIndex** of the substring. Then, **ForegroundColor** is set to Blue and the substring is printed. The color is reset, and the rest of the original string is printed starting from the startIndex + the length of the substring.
