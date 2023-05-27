using System;
using System.Collections.Generic;

namespace SpendingTracker
{
    class Expense
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public string Description { get; set; }
    }



    class Projekt
    {


        private static List<Expense> expenses = new List<Expense>();

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Spending tracker");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Add an expense");
                Console.WriteLine("2. Check expenses");
                Console.WriteLine("3. Exit");
                Console.WriteLine("---------------------------");
                Console.WriteLine();

                Console.Write("Enter option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddExpense();
                        break;
                    case "2":
                        ViewExpenses();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a correct option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddExpense()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Add an expense");
            Console.WriteLine("---------------------------");

            Expense expense = new Expense();

            Console.Write("Amount (in PLN): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                expense.Amount = amount;
            }

            Console.Write("Date (DD/MM/YYYY): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                expense.Date = date;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in DD/MM/YYYY format.");
                return;
            }

            Console.Write("Category: ");
            expense.Category = Console.ReadLine();

            Console.Write("Description: ");
            expense.Description = Console.ReadLine();

            expenses.Add(expense);

            Console.WriteLine("An expense has been added to your list. To check your current expenses, press 2.");
        }

        static void ViewExpenses()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Check expenses");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Enter the category to filter. Type 'list' to see the list of current categories. Type 'all' to see all the expenses: ");
            Console.WriteLine("---------------------------");
            string categoryFilter = Console.ReadLine();

            bool categoryExists = false;

            if (expenses.Count == 0)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("No expenses to display.");
                Console.WriteLine("---------------------------");
                Console.WriteLine();
            }
            else if (categoryFilter.ToLower() == "list")
            {
                Console.WriteLine("Current Categories:");

                HashSet<string> categorySet = new HashSet<string>();

                foreach (var expense in expenses)
                {
                    categorySet.Add(expense.Category);
                }

                foreach (var category in categorySet)
                {
                    Console.WriteLine(category);
                }

                Console.WriteLine();
                Console.Write("Enter the category to view expenses (or '2' to return to the main menu): ");
                string option = Console.ReadLine();

                if (option == "2")
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Returning to the main menu...");
                    Console.WriteLine("---------------------------");
                }
                else
                {
                    Console.WriteLine();

                    foreach (var expense in expenses)
                    {
                        if (expense.Category.ToLower() == option.ToLower())
                        {
                            Console.WriteLine($"Amount: {expense.Amount}");
                            Console.WriteLine($"Date: {expense.Date.ToShortDateString()}");
                            Console.WriteLine($"Category: {expense.Category}");
                            Console.WriteLine($"Description: {expense.Description}");
                            Console.WriteLine();

                            categoryExists = true;
                        }
                    }

                    if (!categoryExists)
                    {
                        Console.WriteLine($"No expenses found for category: {option}");
                    }
                }
            }
            else if (categoryFilter.ToLower() == "all")
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("All expenses:");
                Console.WriteLine("---------------------------");
                Console.WriteLine();

                foreach (var expense in expenses)
                {
                    Console.WriteLine($"Amount: {expense.Amount}");
                    Console.WriteLine($"Date: {expense.Date.ToShortDateString()}");
                    Console.WriteLine($"Category: {expense.Category}");
                    Console.WriteLine($"Description: {expense.Description}");
                    Console.WriteLine();

                    categoryExists = true;
                }
            }
            else
            {
                foreach (var expense in expenses)
                {
                    if (expense.Category.ToLower() == categoryFilter.ToLower())
                    {
                        Console.WriteLine($"Amount: {expense.Amount}");
                        Console.WriteLine($"Date: {expense.Date.ToShortDateString()}");
                        Console.WriteLine($"Category: {expense.Category}");
                        Console.WriteLine($"Description: {expense.Description}");
                        Console.WriteLine();

                        categoryExists = true;
                    }
                }

                if (!categoryExists)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"No expenses found for category: {categoryFilter}. Going back to main menu...");
                    Console.WriteLine("---------------------------");
                }
            }
        }
    }
}