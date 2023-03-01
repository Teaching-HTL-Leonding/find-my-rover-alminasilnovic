const char rovereast = '>';
const char roverwest = '<';
const char roversouth = 'V';
const char rovernorth = '^';
int counteast = 0;
int countwest = 0;
int countsouth = 0;
int countnorth = 0;
int number = 0;
string rovermovementlog = string.Empty;

do
{
    System.Console.Write("Enter movement logs using ^, >, V, <: ");
    rovermovementlog = Console.ReadLine()!;

    if (!rovermovementlog[1].ToString().Contains("<") && !rovermovementlog[1].ToString().Contains(">") && !rovermovementlog[1].ToString().Contains("^") && !rovermovementlog[1].ToString().Contains("V"))
    {
        for (int i = 1; i < rovermovementlog.Length; i += 2)
        {
            number = rovermovementlog[i] - '0';
            char symbol = rovermovementlog[i - 1];
            switch (symbol)
            {
                case '>': counteast += number; break;
                case '<': countwest += number; break;
                case '^': countnorth += number; break;
                case 'V': countsouth += number; break;
                default: break;
            }
        }
        System.Console.WriteLine(GiveCount());
    }
}
while (!rovermovementlog.Contains('<') && !rovermovementlog.Contains('>') && !rovermovementlog.Contains('^') && !rovermovementlog.Contains('V'));

if (!(rovermovementlog.Any(char.IsDigit)))
{ CalculateCoordinates(); }

void CalculateCoordinates()
{
    counteast = CountMovementLogs(counteast, rovereast, rovermovementlog);
    countwest = CountMovementLogs(countwest, roverwest, rovermovementlog);
    countnorth = CountMovementLogs(countnorth, rovernorth, rovermovementlog);
    countsouth = CountMovementLogs(countsouth, roversouth, rovermovementlog);

    System.Console.WriteLine();
    System.Console.WriteLine(GiveCount());
    System.Console.Write($"Manhattan distance = {countnorth + countwest}m");
    System.Console.WriteLine();
    System.Console.Write($"Linear distance = {Math.Round(Math.Sqrt(countnorth * countnorth + countwest * countwest), 2)}m");
}

string GiveCount()
{
    string result = string.Empty;
    countwest = countwest - counteast;
    countnorth = countnorth - countsouth;

    System.Console.Write("The rover is ");
    if (countnorth == 0 && countwest == 0)
    {
        return "in the base station";
    }
    if (countnorth < 0)
    {
        countnorth *= -1;
        result += $"{countnorth}m south and ";
    }
    else if (countnorth != 0)
    {
        result += $"{countnorth}m north and ";
    }
    if (countwest < 0)
    {
        countwest *= -1;
        result += $"{countwest}m east";
    }
    else if (countwest != 0)
    {
        result += $"{countwest}m west";
    }

    return result;
}

int CountMovementLogs(int count, int rover, string rovermovementlog)
{
    return count = rovermovementlog.Count(t => t == rover);
}