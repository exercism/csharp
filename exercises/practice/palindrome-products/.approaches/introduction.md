# Introduction

To solve the Palindrome Products exercise we first need to be able to identify if a number is a palindrome. 
The ways in this can be done are explored in the [Is palindrome number check][is-palindrome-article] article.
The approaches presented here assume that there is a method `bool IsPalindrome(int number)` that returns `true` if the number is a palindrome and `false` otherwise. 

## Approach: Factors First

The obvious solution to the problem is to start with generating all the possible factor pairs first. 
Once this is done, we have to multiply the pairs and check if the product is a palindrome number. 
Many of the [community solutions][community-solutions] follow this pattern. 

For more details, including implementation, performance overview and possible optimisations see [the factors first approach][factors-first-approach].


[community-solutions]: https://exercism.org/tracks/csharp/exercises/palindrome-products/solutions
[is-palindrome-article]: https://exercism.org/tracks/csharp/exercises/palindrome-products/articles/is-palindrome-check
[factors-first-approach]: https://exercism.org/tracks/csharp/exercises/palindrome-products/approaches/factors-first