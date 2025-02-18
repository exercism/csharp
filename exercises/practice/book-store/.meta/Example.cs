using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    private const decimal BookPrice = 8.0m;

    public static decimal Total(int[] books)
    {
        if (books.Length == 0)
            return 0.0m;

        var bookGroups = BookGroupsWithCount(books);

        return Enumerable.Range(1, bookGroups.Length)
            .Min(size => CalculateTotalCost(bookGroups, size, 0.0m));
    }

    private static int[] BookGroupsWithCount(int[] books)
        => books
            .GroupBy(book => book)
            .Select(book => book.Count())
            .OrderByDescending(book => book)
            .ToArray();

    private static decimal CalculateTotalCost(int[] bookGroups, int numberOfBooksToRemove, decimal totalCost)
    {
        var numberOfBooks = Math.Min(numberOfBooksToRemove, bookGroups.Length);
        if (numberOfBooks == 0)
        {
            return totalCost + RegularPrice(bookGroups.Sum());
        }

        var updatedBookGroups = RemoveBooks(bookGroups, numberOfBooks);
        var updatedTotalCost = totalCost + BooksPrice(numberOfBooks);
        return CalculateTotalCost(updatedBookGroups, numberOfBooks, updatedTotalCost);
    }

    private static int[] RemoveBooks(int[] bookGroups, int numberOfBooks)
        => bookGroups
            .Take(numberOfBooks)
            .Select(RemoveBook)
            .Concat(bookGroups.Skip(numberOfBooks))
            .Where(i => i > 0)
            .OrderByDescending(x => x)
            .ToArray();

    private static int RemoveBook(int books) => books - 1;

    private static decimal BooksPrice(int differentBooks)
        => ApplyDiscount(RegularPrice(differentBooks), DiscountPercentage(differentBooks));

    private static decimal RegularPrice(int books) => books * BookPrice;

    private static decimal DiscountPercentage(int differentBooks)
    {
        switch (differentBooks)
        {
            case 5: return 25.0m;
            case 4: return 20.0m;
            case 3: return 10.0m;
            case 2: return 5.0m;
            default: return 0.0m;
        }
    }

    private static decimal ApplyDiscount(decimal price, decimal discountPercentage)
        => Math.Round(price * (100.0m - discountPercentage) / 100.0m, 2);
}