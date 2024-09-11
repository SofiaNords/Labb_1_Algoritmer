//Console.WriteLine("Mata in en textsträng: ");
string input = "29535123p48723487597645723645"; //Console.ReadLine();

// Array of substrings
string[] substrings = FindValidSubstrings(input);

foreach (string s in substrings)
{
    Console.WriteLine(s);
}

// Function that extracts substrings starting and ending with the same character
// FindValidSubstrings calls the function AreInnerCharsDifferentFromFirst
// FindValidSubstrings calls the function ContainsOnlyDigits
// Returns an array that is validated 
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
