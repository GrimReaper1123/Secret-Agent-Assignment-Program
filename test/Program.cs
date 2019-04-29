//Stand and feel your worth

using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;


namespace test
{
    #region Classes
    class Person //Agent Class
    {
        public string name { get; set; }
        public string id { get; set; }

        public bool isActive = false;
        public Person()
        {
            
        }
        public Person(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Person(string id, string name, bool status)
        {
            this.id = id;
            this.name = name;
            this.isActive = status;
        }

        
        public string toString()
        {
            return System.DateTime.Now + "\nID : " + id + "\nName : " + name + "\n" + getState() + "\n";
        }
        public void setState(bool state)
        {
            isActive = state;
        }
        public string getState()
        {
            if (isActive)
            {
                return name + " is active.";
                
            }
            else
            {
                return name + " is not active.";
            }
        }
      
    }
    #endregion
    #region Program
    class Program //Main class containing runnable method
    {
        static string [] statusLine = new string[9];
        protected static DateTime startTime;
        protected static List<string> details = new System.Collections.Generic.List<string>();
        #region Main Method
        static void Main(string[] args) //Main Method (Runnable) 
        {
            /*List<int> temp = new System.Collections.Generic.List<int>(); 
            temp.Add(1);
            */
            printWelcome();

            Console.WriteLine("Commission Agent?");
            string ans = Console.ReadLine().ToLower();
            while (ans.Equals("y"))
            {
                commissionAgent();
                Console.WriteLine("Commission another Agent?");
                ans = Console.ReadLine().ToLower();
            }
            closeProgram();

        }
        #endregion

        #region Shape Graphics
        public static void drawX() //Draws a cross of *
        {
            Console.WriteLine();
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == i)
                    {
                        Console.Write("*");
                    }
                    else if (j == 10 - i)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void drawSquare() //Draws a square of * 
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 || i == 9)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write("* ");
                    }
                }
                else
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (k == 0 || k == 9)
                        {
                            Console.Write("* ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
        #endregion

        
        #region Agent Commission
     public static void commissionAgent() // Method that encompasses all functionality required to activate an agent
        {
            Person p = new Person();
            Console.WriteLine("Enter Agent ID");
            string id = (Console.ReadLine()).ToLower();
            
            /* Console.WriteLine("Enter Name");
             string name = Console.ReadLine();*/
            
             string name  = getAgent(id);
            
    
            if (name.Equals("null"))
            {
                // closeProgram();
                return;
            }

            p.id = id;
            p.name = name;
            string st = getStatus(Convert.ToInt16(id));
            if (!st.Equals("error"))
            {
                if (st.Equals("t"))
                {
                    p.setState(true);
                }
                else
                {
                    p.setState(false);
                }
            }
            else
            {
                return;
            }
            //Console.Clear();
            //Console.WriteLine(p.toString());
            //drawX(); 
            Console.WriteLine();
            //drawSquare();
            Console.WriteLine(p.toString());
            if (!p.isActive)
            {
                Console.WriteLine("Activate? y/n");
                string ans = Console.ReadLine().ToLower();
                if (ans.Equals("y"))
                {
                    activate(name);
                    p.setState(true);
                    changeStatus(Convert.ToInt16(p.id));
                    

                    // System.Threading.Thread.Sleep(2000);         
                    Console.WriteLine(p.toString());
                }
                else
                {
                    return;
                }
            }
            
            else
            {
                Console.WriteLine("Deactivate? y/n");
                string ans = Console.ReadLine().ToLower();
                if (ans.Equals("y"))
                {
                    deactivate(name);
                    p.setState(false);
                    changeStatus(Convert.ToInt16(p.id));

                    // System.Threading.Thread.Sleep(2000);         
                    Console.WriteLine(p.toString());
                    
                    Console.WriteLine("Agent decommissioned.\n");
                    details.Add("Agent " + p.id + " has been decommissioned" + Environment.NewLine );


                    // closeProgram();
                    return;
                }
                else
                {
                    return;
                }
            }
            enterDetails(p.id);
           
           
            //Console.ReadLine();
            //Console.WriteLine("Enter a shape");
            //string shape = Console.ReadLine();l

        }
        public static void enterDetails(string id)
        {
            try
            {
                Console.WriteLine("Enter Country");
                string country = formatNicely(Console.ReadLine().Trim().ToLower());
                Console.WriteLine("Enter authorization code");
                string authCode = formatNicely(Console.ReadLine().Trim().ToLower());
                Console.WriteLine("Enter target");
                string targ = formatNicely(Console.ReadLine().Trim().ToLower());
                Console.WriteLine("Enter location");
                string loc = formatNicely(Console.ReadLine().Trim().ToLower());
                Console.WriteLine("Enter Method Of Operation parameters");
                string param = formatNicely(Console.ReadLine().Trim().ToLower());

                Console.WriteLine();
                Console.WriteLine("Target: " + targ + "\nLocation: " + loc + ", " + country + "\nMethod of Operation: " + param);
                if (id == "all")
                {
                    Console.WriteLine("Every Agent has been granted " + authCode + "authorisation.");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Agents commissioned.\n");
                    details.Add("Every Agent has been granted " + authCode + "authorisation." + Environment.NewLine + "Target: " + targ + Environment.NewLine + "Location: " + loc + ", " + country + Environment.NewLine + "Method of Operation: " + param);
                }
                else
                {
                    Console.WriteLine("Agent " + id + " has been granted " + authCode + "authorisation.");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Agent commissioned.\n");
                    details.Add("Agent " + id + " has been granted " + authCode + "authorisation." + Environment.NewLine + "Target: " + targ + Environment.NewLine + "Location: " + loc + ", " + country + Environment.NewLine + "Method of Operation: " + param);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occured:\n" + e.Message);

            }
        }
        public static string getStatus(int id)
        {
            id = id - 1;
            try
            {
              statusLine = File.ReadAllLines(@"C:\Users\X464323\source\repos\test\status.txt");
               // statusLine = statusLine[0].Split("");
                Debug.WriteLine(statusLine.Length);
                Debug.WriteLine(id);
                return statusLine[id];
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return "error";
            }
            
        }
        public static bool changeStatus(int id)
        {
            id = id - 1;
            if (statusLine[id].Equals("t"))
            {
                statusLine[id] = "f";
            }
            else
            {
                statusLine[id] = "t";
            }
            try
            {
                
                File.WriteAllLines(@"C:\Users\X464323\source\repos\test\status.txt", statusLine);
                Debug.WriteLine(statusLine[id]);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                return false;
            }
           
        }
         public static void printWelcome() //Display screen heading
        {
            startTime = System.DateTime.Now;
            Console.WriteLine("Agent Assignment System V1.3\nDate: " + System.DateTime.Now +"\n");
        

        }
        
        public static string formatNicely(string inStr) //String handling 
        {
            
                if (inStr.Contains(" "))
                {
                    string[] strArr = inStr.Split(" ");
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (strArr[i].StartsWith("("))
                        {
                            strArr[i] = "(" + strArr[i].Substring(1, 2).ToUpper();
                            break;
                        }
                        string newStr = strArr[i].Substring(0, 1).ToUpper();
                        strArr[i] = newStr + strArr[i].Substring(1);

                    }

                    string returnString = "";
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        returnString += strArr[i] + " ";
                    }

                    return returnString;
                }
                else if (inStr.Contains("/"))
                {
                string[] strArr = inStr.Split("/");
                string newStr = "";
                for (int i = 0; i < strArr.Length; i++)
                {
                    if (i < strArr.Length - 1)
                    {
                        newStr += strArr[i].Substring(0, 1).ToUpper() + strArr[i].Substring(1) + "/";
                    }
                    else
                    {
                        newStr += strArr[i].Substring(0, 1).ToUpper() + strArr[i].Substring(1);
                    }
                   
                }
                return newStr;
            }
                else
                {
                    return inStr.Substring(0, 1).ToUpper() + inStr.Substring(1)+" ";
                }
           
        }
        public static void closeProgram() //Display end messages and invoke log writing method
        {
            Random rand = new Random();
            string sessID = rand.Next().ToString() + "_" + System.DateTime.Now.TimeOfDay;
            string sessLog = Environment.NewLine+"ID: " +sessID  + Environment.NewLine +
               System.DateTime.Now + Environment.NewLine+"Time Used : " + (System.DateTime.Now.TimeOfDay - startTime.TimeOfDay);
            Console.WriteLine("\n--------------------------------------------------------" +
                "\n\t\tSystem Exit Procedure\n--------------------------------------------------------" +
                "\n\nEncryption Status : Secured\nDatabase Lock Status : Secured\nInformation Integrity Status : Secured\n"+sessLog);
            //Console.WriteLine("System exiting in:"); 
            //for (int i = 5; i >0 ; i--)
            //{
            //    Console.WriteLine("\n"+i);
            //    System.Threading.Thread.Sleep(1050); 
            //}
            string holder = "";
            if (details.Count > 0)
            {
              

                
                for (int i = 0; i < details.ToArray().Length; i++)
                {
                    holder += details.ToArray()[i] + Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                holder = "No agents were assigned in this session.";
            }
            writeLog(Environment.NewLine + Environment.NewLine+"Log: "+sessID+Environment.NewLine+ "------------------------------------------" +Environment.NewLine+ holder+sessLog+Environment.NewLine+ "------------------------------------------");
            
            Console.WriteLine("\nEnter r to read log or press enter to close...");
            string ans=Console.ReadLine().ToLower();
            if (ans == "r")
            {
               Process.Start("notepad.exe", @"C:\Users\X464323\source\repos\test\log.txt");
            }
            
            //Debug.Print(Environment.StackTrace);
            Environment.Exit(0);
        }
       
        public static void activate(string name) //activate agent display method
        {
            Console.WriteLine("Activating " + name);
            try
            {
                
                for (int i = 0; i < 17; i++)
                {
                    Console.Write('-');
                    System.Threading.Thread.Sleep(100);
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(150);
                //System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void deactivate(string name) //deactivate agent display method
        {
            Console.WriteLine("Deactivating " + name);
            try
            {

                for (int i = 0; i < 17; i++)
                {
                    Console.Write('-');
                    System.Threading.Thread.Sleep(100);
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(150);
                //System.Threading.Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void writeLog(string log) //write log.txt
        {
            try
            {
                File.AppendAllText(@"C:\Users\X464323\source\repos\test\log.txt", log);
                Debug.WriteLine("File written successfully");
                Console.WriteLine("\n------Session Successfuly Logged------\n");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\n------Session not Logged------\n");


            }
            
        }
        public static string getAgent(string id) //return agent name from ID
        {
            string name;
            switch (id)
            {
                case "001":
                    name = "Calais";
                    break;
                case "002":
                    name = "Pierce";
                    break;
                case "003":
                    name = "Ceaser";
                    break;
                case "004":
                    name = "Sepiol";
                    break;
                case "005":
                    name = "Sampson";
                    break;
                case "006":
                    name = "Xang";
                    break;
                case "007":
                    name = "Bond";
                    break;
                case "008":
                    name = "Brutus";
                    break;
                case "009":
                    name = "Antony";
                    break;
                case "all":
                    name = "Every agent";
                    break;
                default:
                    name = "null";
                    break;


            }
            return name;
        }
       
    }
    #endregion
    #endregion
}
//To live is to fight the long defeat...