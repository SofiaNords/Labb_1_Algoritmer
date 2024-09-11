Console.WriteLine("Mata in en text: ");
string input = Console.ReadLine();

// Array of substrings
string[] substrings = FindValidSubstrings(input);


// Iterate through each substring in the substrings array
// Print the input string with the current substring highlighted
foreach (string substring in substrings)
{
    PrintHighlightedString(input, substring);
    Console.WriteLine();
}


// Function that highlights a specified substring within a given string
// by printing the string with the substring displayed in dark magenta text.
static void PrintHighlightedString(string original, string substring)
{
    int startIndex = original.IndexOf(substring);

    Console.Write(original.Substring(0, startIndex));
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(substring);
    Console.ResetColor();
    Console.Write(original.Substring(startIndex + substring.Length));
}


// Function that extracts substrings starting and ending with the same character
// FindValidSubstrings calls the function AreInnerCharsDifferentFromFirst
// FindValidSubstrings calls the function ContainsOnlyDigits
// FindValidSubstrings returns an array that is validated 
static string[] FindValidSubstrings(string str)
{
    string[] result = new string[str.Length * (str.Length - 1) / 2];
    int index = 0;

    for (int i = 0; i < str.Length; i++)
    {
        for (int j = i + 1; j < str.Length; j++)
        {
            if (str[i] == str[j])
            {
                string substring = str.Substring(i, j - i + 1);
                if (AreInnerCharsDifferentFromFirst(substring) && ContainsOnlyDigits(substring))
                {
                    result[index++] = substring;
                }
            }
        }
    }
    Array.Resize(ref result, index);
    return result;
}


// Function that checks the characters between the first and last character of a given string
// If any character matches the first character, the function returns false
// If no characters match the first character, the method returns true
static bool AreInnerCharsDifferentFromFirst(string str)
{
    char firstChar = str[0];

    for (int i = 1; i < str.Length - 1; i++)
    {
        if (str[i] == firstChar)
        {
            return false;
        }
    }
    return true;
}


// Function that checks that a string contains only digits
// If any character is not a digit the function returns false
// If all character is digits the function returns true
static bool ContainsOnlyDigits(string str)
{
    foreach(char c in str)
    {
        if (!Char.IsDigit(c))
        {
            return false;
        }
    }
    return true;
}
