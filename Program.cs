using System.IO;
using System.Globalization;
using System;
#region Detailed Plan
/*
 * declare phValues[] as double[]
 * declare dates[] as string[]
 * declare count as int
 * declare finish as boolean
 * 
 * 
 * driver
 * loop do while(not done)
 *  display the main menu(DisplayMainMenu)
 *  declare logEntry as string
 *  reads the menu choice 
 *  switch (menu choice)
 *      case Load log(LoadLogFile)
 *      case Save log(SaveLogFile)
 *      case DisplayLog(DisplayEntries)
 *      case Edit Etry (EnterLogEntries***)
 *      case Analysis(submenu driver subroutine)
 *      case exit
 *      default bad menu option
 *     eos
 *  eol
 *  //end of driver
 *  
 *  Analysis menu method
 *  loop do while(not done)
 *      display the analysis sub menu(DisplayAnalysisMenu)
 *      read the menu choice
 *      switch(menu choice)
 *          case Median, average, highest, lowest
 *          case Chart Entries(DisplayChart)
 *          case return to main menu
 *          default bad menu option
 *      eos
 *  eol

 method void DisplayMainMenu()
    Prompt("\nMAIN MENU");
    Prompt("----------------------------------------------------");

    Prompt("[N]ew Daily pH Entry");
    Prompt("[S]ave Entries to files");
    Prompt("[E]dit pH Entries");
    Prompt("[L]oad pH Log File");
    Prompt("[V]iew loaded Log File");
    Prompt("[M]onthily Statistics");
    Prompt("[D]isplay Main Menu");
    Prompt("[Q]uit Program");


method void DisplayAnalysisMenu()
    Prompt("[A]verage pH");
    Prompt("[H]ighest pH");
    Prompt("[L]owest pH");
    Prompt("[M]edian pH");
    Prompt("[G]raph View");
    Prompt("[R]eturn to Main Menu");
    Promot("Enter your choice: ");

 void DisplayEntries(double[] pHValues, string[] dates, int count)
    loop for (int i = 0;i < count;i++)
        Prompt($"{dates[i]}   {pHValues[i]}");
    
 method SaveLogFile(string filename, double[] pHValues, string[] dates, int count)
   declare streamWriter as StreamWriter
   streamWriter=null

    using (streamWriter = new StreamWriter("../../../" + filename)) {
        loop if (File.Exists("../../../" + fileName))
            streamWriter.WriteLine( "Dates, pH values");
                loop for (int i =1 ; i < count; i++)
                    streamWriter.Prompt(dates[i]+","+phValues[i]);
                
            if error
                Prompt($"Writing Error: {ex.Message}");
                if (streamWriter != null) 
                
                    streamWriter.Close(); 
int LoadLogFiles(string fileName, double[] phValues, string[] dates)
    delcare count as int
    declare streamReader as StreamReader
    streamReader = null
    loop if(File.Exists(filename))
        try
            streamReader=new StreamReader(filename);
            declare line as string
            line=streamReader.Readline()
            loop while(!streamReader.EndStream)
                line=streamReader.Readline();
                declare splitLine[] as string[]
                split[]=line.Split(',')
                loop if(splitLine.Length == 2 && double.TryParse(splitLine[1], out double pHvalues) && validDate(splitLine[0]))
                    phValues[count] = pHvalues;
                    dates[count] = splitLine[0];
                    count++;
                else
                    Prompt$"Invalid {line}"
        catch (Exception ex)
            Prompt($"Error in reading the file {ex.Message}");
        finally
            loop if (streamReader != null)
                streamReader.Close();
        loop if (count > 0)
            Prompt($"The record that has been read are: {count}");
        else
            Prompt("No record was read");
    else
        Prompt("The file enterd does not exist");
    return count;

void EditEntries(double[] pHvalues, string[] dates, int count)
    DisplayEntries(pHvalues, dates, count)
    prompt("Enter the entry you would like to edit 1 to{count}:")
    int indexchange read

    prompt("Date: ")
    int indexdate read
    date[indexchange]=indexdate

    prompt("pHValue:")
    int indexphvalue read
    pHvalue[indexchange]=indexphvalue

    SaveLogFile(filename, pHvalues, dates, count)
    return count

//Analysis Menu

double maxNum(double[] num, int count)
      declare max as double
      loop for (int i=1; i<count; i++)
          loop if num[i]>max
          max=num[i]
      prompt($"the max num is {max}")

double minNum(double[] nums, int count)
    declare min as double
    min=nums[1];
    
    loop for(int i=1;i<count;i++)
        loop if(nums[i]<min)
            min=nums[i]
    Prompt(min)

double meanAverage(double[] nums, int count)
    declare sum as double
    loop for(int i=0; i<count;i++)
        sum=sum+nums[i]
    declare result as double
    result=sum/count;
    Prompt($"The average number is {meanAverage}");

double Median(double[] nums, int count)
    declare medianNum[] as double[]
    Array.Copy(nums, medianNum, count);
    Array.Sort(medianNum);
    
    loop if (count%2==0)
        declare index1 as int
        declare indec2 as int
        declare result as double
        result=(medianNum[index1]+median[index2])/a
    else
        declare index as int
        index = count/2
        result=medianNum[index]
    Prompt(result)

void DisplayChart(string filename, double[] phValues, string[] dates, int count)
    add * according to phValue level


bool validDate(string date)
    DateTime dt;
    return Datetime.TryParse(date, "MM-dd-yyyy")



*/
#endregion

Console.WriteLine("====================================================");
Console.WriteLine("=                                                  =");
Console.WriteLine("=                Riverbed pH Logger                =");
Console.WriteLine("=                                                  =");
Console.WriteLine("====================================================");

DisplayMainMenu();
int physicalSize = 30;
double[] phValues = new double[physicalSize];
string[] dates = new string[physicalSize];
int count = 0;

string fileName="";
bool finish = false;

do
{
    
    Console.Write("\nEnter main menu option ('D' to display menu): ");
    string logEntry = Console.ReadLine();
    
    switch (logEntry.ToUpper())
    {
        case "N"://[N]ew Daily pH Entry
            count = EnterLogEntries(phValues, dates, count);
            break;
        case "S"://[S]ave Entries to files
            SaveLogFile(fileName,phValues, dates, count);
            break;
        case "E"://[E]dit pH Entries
            EditEntries(fileName, phValues, dates, count);
            break;
        case "L"://[L]oad pH Log File
            count=LoadLogFile(fileName, phValues, dates);
            break;
        case "V"://[V]iew loaded Log File
            DisplayEntries(phValues, dates, count);
            break;
        case "M":
            Analysis(); 
            break;
        case "D":
            DisplayMainMenu();
            break;
        case "Q":
            Console.Write("Are you sure you want to quit (Y/N): ");
            string inputValue_ = Console.ReadLine();
            if (inputValue_.ToUpper() == "Y")
            {
                finish = true;
            }
            else
            {
                finish = false;
            }
            break;
        default:
            Console.WriteLine("Invaild choice. Please enter a valid value.");
            break;
    }


} while (!finish);
int LoadLogFile(string fileName, double[] phValues, string[] dates)
{
    Console.Write("\nEnter a file name to open: ");
    fileName = Console.ReadLine();

    int count = 0;
    StreamReader streamReader = null;
    if (File.Exists("../../../" + fileName))
    {
        try
        {
            streamReader = new StreamReader("../../../" + fileName);
            string line = streamReader.ReadLine();
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                string[] splitLine = line.Split(',');

                if (splitLine.Length == 2 && double.TryParse(splitLine[1], out double pHvalues) && validDate(splitLine[0]))
                {
                    phValues[count] = pHvalues;
                    dates[count] = splitLine[0];
                    count++;
                }
                
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in reading the file {ex.Message}");
        }
        finally
        {
            if (streamReader != null)
            {
                streamReader.Close();
            }
        }
        if (count > 0)
        {
            Console.WriteLine($"\n{fileName} have been read successfully!!");
        }
        else
        {
            Console.WriteLine("No record was read");
        }
    }
    else
    {
        Console.WriteLine("The file enterd does not exist");
        
    }
    return count;
}
int EnterLogEntries(double[] phValues, string[] date, int count)
{
    bool anotherValue = true;
    string getDate;
    double getpH;

    getpH = PromptDouble("Enter pH value: ");

    while (getpH > 14 || getpH < 0)
    {
        Console.WriteLine("Invalid Value!!");
        getpH = PromptDouble("Enter valid pH value 1-14: ");
    }
    getDate = Prompt("Enter Date: ");

    while (!validDate(getDate))
    {
        Console.WriteLine("Invalid Value!!");
        getDate = Prompt("Enter a valid date (MM-DD-YYYY): ");
    }

    
    date[count] = getDate;
    phValues[count] = getpH;
    count++;

    Console.Write("Do you want to continue entering the data Y/N: ");
    string inputValue = Console.ReadLine();
    inputValue = inputValue.ToUpper();

    if (inputValue == "Y")
    {
        anotherValue = true;
    }
    else
    {
        anotherValue = false;
    }
   
    return count;
}
void SaveLogFile(string filename, double[] pHValues, string[] dates, int count)
{
    //write in this file
    StreamWriter streamWriter = null;

    streamWriter = new StreamWriter("../../../" + filename);
        if (File.Exists("../../../" + fileName))
        {
            streamWriter.WriteLine( "Dates, pH values");
            try
            {
                for (int i =1 ; i < count; i++)
                {
                    streamWriter.WriteLine(dates[i]+","+phValues[i]);
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Writing Error: {ex.Message}"); 
            }
            finally 
            { 
                if (streamWriter != null) 
                {
                    streamWriter.Close(); 
                } 
            }
        }
    
}
string Prompt(string promptString)
{
    Console.Write(promptString);
    return Console.ReadLine();
}
double PromptDouble(string promptString)
{
    string inputValue;
    double toDouble;
    do
    {
        Console.Write(promptString);
        inputValue = Console.ReadLine();
    } while (!double.TryParse(inputValue, out toDouble));
    
    return toDouble;
}
void DisplayMainMenu()
{
    Console.WriteLine("\nMAIN MENU");
    Console.WriteLine("----------------------------------------------------");

    Console.WriteLine("[N]ew Daily pH Entry");
    Console.WriteLine("[S]ave Entries to files");
    Console.WriteLine("[E]dit pH Entries");
    Console.WriteLine("[L]oad pH Log File");
    Console.WriteLine("[V]iew loaded Log File");
    Console.WriteLine("[M]onthily Statistics");
    Console.WriteLine("[D]isplay Main Menu");
    Console.WriteLine("[Q]uit Program");

}
// do driver for analysis
void Analysis()
{
    bool finishAna = false;
    do
    {
        string choice;
        DisplayAnalysisMenu();
        Console.Write("Enter your choice: ");
        choice = Console.ReadLine();
        switch (choice.ToUpper())
        {
            case "A":
                meanAverage(phValues, count);
                break;
            case "H":
                maxNum(phValues, count);
                break;
            case "L":
                minNum(phValues, count);
                break;
            case "M":
                Median(phValues, count);
                break;
            case "G":
                DisplayChart(phValues, dates, count);
                break;
            case "R":
                finishAna = true;
                return;
            default:
                Console.WriteLine("Invalid Valid, Enter the right value!");
                break;
        }
    } while (!finishAna);
    
}
double meanAverage(double[] nums, int count)
{
    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += nums[i];
    }
    double result = sum / count;
    Console.WriteLine($"\nMean average pH: {result}");
    return count;
}
double Median(double[] nums, int count)
{
    double[] medianNum = new double[count];
    Array.Copy(nums, medianNum, count);
    Array.Sort(medianNum);
    double result;
    if (count % 2 == 0)
    {
        int index1 = count / 2 - 1;
        int index2 = count / 2;
        result = (medianNum[index1] + medianNum[index2]) / 2;
    }
    else
    {
        int index = count / 2;
        result = medianNum[index];
    }

    Console.WriteLine($"\nMedian pH: {result:00.00}");
    return count;
}
double maxNum(double[] num, int count)
{
    double max = num[1];

    for (int i = 1; i < count; i++)
    {
        if (num[i] > max)
        {
            max = num[i];
        }
    }
    Console.WriteLine($"\nHighest pH: {max:00.00}");
    return max;
}
double minNum(double[] nums, int count)
{
    double min = nums[1];
    for (int i = 1; i < count; i++)
    {
        if (nums[i] < min)
        {
            min = nums[i];
        }
    }
    Console.WriteLine($"\nLowest pH: {min:00.00}");
    return min;
}
void DisplayAnalysisMenu()
{
    Console.WriteLine("\nANALYSIS");
    Console.WriteLine("\n===========================");
    Console.WriteLine("[A]verage pH");
    Console.WriteLine("[H]ighest pH");
    Console.WriteLine("[L]owest pH");
    Console.WriteLine("[M]edian pH");
    Console.WriteLine("[G]raph View");
    Console.WriteLine("[R]eturn to Main Menu");
}
//ti check if a date enterd is valid
bool validDate(string date)
{
    DateTime dateValues;
    return DateTime.TryParseExact(date, "MM-dd-yyyy", new CultureInfo("en-us"), System.Globalization.DateTimeStyles.None, out dateValues);
}
void DisplayChart(double[] phValues, string[] dates ,int count)
{
    double minpH = phValues[0];
    double maxpH = phValues[0];

    for (int i=0;i<count;i++)
    {
        if (phValues[i] < minpH)
        {
            minpH = phValues[i]; 
        }
        if (phValues[i] > maxpH) 
        { 
            maxpH = phValues[i]; 
        }   
    }

    Console.WriteLine("pH");
    Console.WriteLine("---");

    int index = 0;
    for(double i = maxpH; i >= minpH; i = i - 0.1)
    {
        Console.Write($"  {i:F1} |");

        for(int j = 0; j < count; j++)
        {
            if (phValues[j] == Math.Round(i,1))
            {
                Console.Write(" * ");
            }
            else
            {
                Console.Write("   ");
            }
        }
        Console.WriteLine();
        index++;
    }

    Console.WriteLine("-------------------------------");

    Console.Write("Dates |");
    for (int i = 1; i < (count+1); i++)
    {
        Console.Write($"{i:00} ");
    }

    Console.Write("\n\nPress Enter to continue..");
    string continueValue=Console.ReadLine();
    if (continueValue =="")
    {
        return;
    }
}
void DisplayEntries(double[] pHValues, string[] dates, int count)
{
    Console.WriteLine("\n Current Log entries");
    Console.WriteLine("=======================\n");
    Console.WriteLine("Date          pH Values");
    Console.WriteLine("------------  ---------");
    
    for (int i = 0;i < count;i++)
    {
        Console.WriteLine($"{dates[i]}   {pHValues[i]}");
    }
}
void EditEntries(string fileName, double[] pHValues, string[] dates, int count)
{
    DisplayEntries(pHValues, dates, count);
    string indexChange;
    indexChange=Prompt("Enter entry the date for edit: ");
    bool dateExist=false;

    while (!validDate(indexChange))
    {
        Console.WriteLine("Invalid Value!!");
        indexChange = Prompt("Enter a valid date for edit(MM-DD-YYYY): ");
    }

    for(int i=0;i<dates.Length;i++)
    {
        if (indexChange == dates[i])
        {
            dateExist = true;
            break;
        }
        else
        {
            Console.WriteLine("The date entered does not exists!");
            return;
        }
    }

    for(int i=0;i<dates.Length;i++)
    {
        if (indexChange==dates[i])
        {
            string indexDate = "";
            double indexpHValue = 0.0;
            indexDate = Prompt("Enter a date edited (MM-DD-YYYY): ");

            while (!validDate(indexDate))
            {
                Console.WriteLine("Invalid Value!!");
                indexDate = Prompt("Enter a valid date edited(MM-DD-YYYY): ");
            }

            dates[i] = indexDate;
            indexpHValue = PromptDouble("\nEnter pH Value edited: ");

            while (indexpHValue > 14 || indexpHValue < 0)
            {
                Console.WriteLine("Invalid Value!!");
                indexpHValue = PromptDouble("Enter valid pH value 1-14 edited: ");
            }

            pHValues[i] = indexpHValue;
        }
  
    }
   
    SaveLogFile(fileName, pHValues, dates, count);
}
