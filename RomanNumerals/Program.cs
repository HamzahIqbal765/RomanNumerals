


List<int> testYears = new List<int>() { 4, 12, 644, 1883, 1999, 975, 111 };

Dictionary<string, int> numerals = new Dictionary<string, int>()    
{
                {"M", 1000 },
                { "CM", 900 },
                {"D", 500},
                {"CD", 400},
                {"C", 100},
                {"XC", 90},
                {"L", 50},
                {"XL", 40},
                {"X", 10},
                {"IX", 9},
                {"V", 5},
                {"IV", 4},
                {"I", 1}
};

foreach (int year in testYears)
{
    string romanNumeral = GetRomanNumeralsForYear(year, numerals);
    Console.WriteLine(romanNumeral);
}

static string GetRomanNumeralsForYear(int year, Dictionary<string, int> numerals)
{
    // I V	X	L	C	D	M
    // 1 5	10	50	100	500	1000

    //Rule: for each unique letter above, the letters accrue until the previous letters are used up in the production of the numeral
    // But for the numeral preceding a new letter, the previous numeral is prefixed to it
    // e.g 3 = III, 4 = IV, (5-1)
    // 8 = VIII (5 + 3), 9 = IX (10-1)
    // 39 = XXXIX (10 + 10 + 10 -1 + 10), 40 = XL (50 -10)
    //Starting from the largest roman numeral, subtract each numeral from the year and append to a string

    string romanNumeral = "";
    foreach (KeyValuePair<string, int> kvp in numerals)
    {
        while (year >= kvp.Value)
        {
            romanNumeral += kvp.Key;
            year -= kvp.Value;
        }
    }

    return romanNumeral;
}
