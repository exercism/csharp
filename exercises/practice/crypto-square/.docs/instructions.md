# Instructions

Implement the classic method for composing secret messages called a square code.

Given an English text, output the encoded version of that text.

First, the input is normalized: the spaces and punctuation are removed from the English text and the message is downcased.

For example, the sentence:

```text
"If man was meant to stay on the ground, god would have given us roots."
```

is normalized to:

```text
"ifmanwasmeanttostayonthegroundgodwouldhavegivenusroots"
```

The normalized characters are then broken into rows of the same length, forming a rectangle which is as square as possible.
The size of the rectangle is determined by the length of the message, as well as the rules below.

If `c` is the number of columns and `r` is the number of rows, then for the rectangle `r` x `c` find the smallest possible integer `c` such that:

- `r * c >= length of message`,
- and `c >= r`,
- and `c - r <= 1`.

Our normalized text is 54 characters long, dictating a rectangle with `c = 8` and `r = 7`.
Since the split text must form a rectangle, fill any missing characters with spaces, as demonstrated in the last line below:

```text
"ifmanwas"
"meanttos"
"tayonthe"
"groundgo"
"dwouldha"
"vegivenu"
"sroots  "
```

The coded message is obtained by reading down the columns going left to right.

The message above is encoded as:

```text
"imtgdvsfearwermayoogoanouuiontnnlvtwttddesaohghnsseoau"
```

Output the encoded text in chunks that fill perfect rectangles `(r X c)`, with `c` chunks of `r` length, separated by spaces.

```text
"imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau "
```

Notice that if were we to stack these chunks, we could visually decode the ciphertext back in to the original message:

```text
"imtgdvs"
"fearwer"
"mayoogo"
"anouuio"
"ntnnlvt"
"wttddes"
"aohghn "
"sseoau "
```

