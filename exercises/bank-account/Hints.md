## Hints
This exercise requires you to handling data related to currency and money. A normal approuch is to use the [Decimal] (https://msdn.microsoft.com/en-US/library/system.decimal.aspx) struct to store currency values. But this only stores the numeric of a currency. 
When you want a full string to display on your user interface, you can use the [Decimal.ToString(IFormatProvider)] (https://msdn.microsoft.com/en-US/library/3ebe5aks.aspx) or use the [Decimal.ToString(String)] (https://msdn.microsoft.com/en-US/library/fzeeb5cd.aspx).

