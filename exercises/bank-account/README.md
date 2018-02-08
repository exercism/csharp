# Bank Account

Simulate a bank account supporting opening/closing, withdrawals, and deposits
of money. Watch out for concurrent transactions!

A bank account can be accessed in multiple ways. Clients can make
deposits and withdrawals using the internet, mobile phones, etc. Shops
can charge against the account.

Create an account that can be accessed from multiple threads/processes
(terminology depends on your programming language).

It should be possible to close an account; operations against a closed
account must fail.

## Instructions

Run the test file, and fix each of the errors in turn. When you get the
first test to pass, go to the first pending or skipped test, and make
that pass as well. When all of the tests are passing, feel free to
submit.

Remember that passing code is just the first step. The goal is to work
towards a solution that is as readable and expressive as you can make
it.

Have fun!

## Hints
This exercise requires you to handle data related to currency and money. A normal approuch is to use the [Decimal](https://msdn.microsoft.com/en-US/library/system.decimal.aspx) struct to store currency values. 
Note though that you then only store the numeric value of a currency. 



## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
