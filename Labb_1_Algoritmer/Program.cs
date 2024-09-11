//Console.WriteLine("Mata in en textsträng: ");
string input = "29535123p48723487597645723645"; //Console.ReadLine();

// Function that checks that a string contains only digits and returns a bool 
static bool OnlyDigitsInString(string str)
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

bool testDigit = OnlyDigitsInString("123b1345");

Console.WriteLine($"It is: {testDigit}");