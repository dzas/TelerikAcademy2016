﻿namespace _10_ADO.Net
{
    using System;

    using Data;

    using Files;

    internal class Startup
    {
        //Change connection strings as nessesary
        private const string SqlConnectionString = "Server=.; Database=NorthWind; Integrated Security=true";

        private const string OledbConnectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../scores.xlsx;Mode=ReadWrite;Extended Properties=""Excel 8.0;HDR=YES;MaxScanRows=0;IMEX=0"";";

        private const string MySqlConnectionString =
            "Server=localhost; port=3309; database=library; UID=root; password=zxc123";

        private const string ResultFormat = "{0}: {1}";

        private static void Main()
        {
            var sqlEngine = new SqlDbEngine(SqlConnectionString);

            //Task 1
            var categoryCount = sqlEngine.GetNumberOfRowsFor("Categories");
            WriteLine("Total categories: " + categoryCount);
            Divide();

            //Task 2
            var categoryNamesAndDescriptions = sqlEngine.GetCategoryNamesAndDescriptions();
            foreach (var category in categoryNamesAndDescriptions)
            {
                WriteLine(string.Format(ResultFormat, category.CategoryName, category.Description));
            }

            Divide();

            //Task 3
            var categoryWithProducts = sqlEngine.GetProductsGroupedByCategory();
            foreach (var category in categoryWithProducts)
            {
                WriteLine(string.Format(ResultFormat, category.CategoryName, category.Products));
            }

            Divide();

            //Task 4
            sqlEngine.InsertProduct("Pesho", 2, 3, "Many peshos per unit", 1050000.3m, 5000);

            //Task 5
            var images = sqlEngine.GetAllCategoryImages();
            var fileManager = new ImageFileManager();
            for (var i = 0; i < images.Count; i++)
            {
                fileManager.WriteToDisk($"..\\..\\CategoryImages\\image-{i + 1}.jpg", images[i].Picture);
            }

            WriteLine("Downloaded and saved category images to ..\\..\\CategoryImages\\");
            Divide();

            //Task 6
            var oleDbEngine = new OleDbEngine(OledbConnectionString);
            var scores = oleDbEngine.GetPersonScores();
            foreach (var personScore in scores)
            {
                WriteLine(string.Format(ResultFormat, personScore.Name, personScore.Score));
            }

            Divide();

            //Task 7
            //oleDbEngine.InsertPerson("Tosho", 50);

            //Task 8
            var pattern = GetUserInput("product");

            var searchResult = sqlEngine.SearchProductsByName(pattern);

            foreach (var product in searchResult)
            {
                WriteLine(product.ProductName);
            }
            Divide();

            //Task 9
            var mySqlDb = new MySqlDbEngine(MySqlConnectionString);
            var allBooks = mySqlDb.ListAllBooks();
            foreach (var book in allBooks)
            {
                WriteLine(string.Format(ResultFormat, book.Author, book.Name));
            }
            Divide();

            //Task 9.1
            var bookSearchPattern = GetUserInput("book");
            var bookSearchResult = mySqlDb.SearchForBooksByName(bookSearchPattern);
            foreach (var book in bookSearchResult)
            {
                WriteLine(string.Format(ResultFormat, book.Author, book.Name));
            }
            Divide();

            //Task 9.2
            mySqlDb.AddBook("The Art of War", "Sun Tzu", "56453-5654-4512", DateTime.Now);
        }

        private static void Divide()
        {
            WriteLine(new string('-', 50));
        }

        private static void WriteLine(string toWrite)
        {
            Console.WriteLine(toWrite);
        }

        private static string GetUserInput(string prompt)
        {
            WriteLine($"Please enter {prompt} search word: ");
            var pattern = Console.ReadLine();
            while (string.IsNullOrEmpty(pattern))
            {
                WriteLine($"Please enter {prompt} search word: ");
                pattern = Console.ReadLine();
            }

            return pattern;
        }
    }
}