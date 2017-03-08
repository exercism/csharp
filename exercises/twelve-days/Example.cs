using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TwelveDaysSong
{
    public static string Sing()
    {
        return Verses(1, 12);
    }

    public static string Verse(int verseNumber)
    {
        switch(verseNumber)
        {
            case 1:
              return "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n";
            case 2:
              return "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 3:
              return "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 4:
              return "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 5:
              return "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 6:
              return "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 7:
              return "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 8:
              return "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 9:
              return "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 10:
              return "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 11:
              return "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            case 12:
              return "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n";
            default:
              return "";
        }
    }

    public static string Verses(int start, int end)
    {
        var stringBuilder = new StringBuilder();

        Enumerable.Range(start, end).ToList().ForEach(i => stringBuilder.Append(Verse(i)).Append("\n"));

        return stringBuilder.ToString();
    }
}