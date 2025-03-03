# Instructions

Your job is to help implement the message sequencer to add the parity bit to the messages and the decoder to receive messages.

The entire message, itself, is sequence of a number of bytes.
The transmitters and receivers can only transmit and receive one byte at a time, so parity bit needs to be added every eighth bit. 
The algorithm for adding the bits is as follows:
1. Divide the message bits into groups of 7, starting from the left (the message is transmitted from left to right).
2. If the last group has less than 7 bits, append some 0s to pad the group to 7 bits.
3. For each group, determine if there are an odd or even number of 1s.
4. If the group has even number of 1s or none at all, append a 0 to the group. Otherwise, append 1 if there is odd number.

For example, consider the message 0xC0_01_C0_DE.
Writing this out in binary and locating every 7th bit:

```text
C    0    0    1    C    0    D    E
1100_0000 0000_0001 1100_0000 1101_1110
       ↑        ↑        ↑       ↑        (7th bits)
```

The last group has only 4 bits (0b1110), so three 0 bits are appended to make it 7 bits:

```text
| 1100_000 | 0000_000 | 0111_000 | 0001_101 | 1110_000 |
```

The first group contains two 1s (an even number of 1s), so 0 is appended to the group.
The second group has none, so append 0.
The rest have three, so they append 1.

```text
| 1100_0000 | 0000_0000 | 0111_0001 | 0001_1011 | 1110_0001 |
| C    0    | 0    0    | 7    1    | 1    B    | E    1    |  (in hex)
```

Thus, the transmission sequence is 0xC0_00_71_1B_E1.
