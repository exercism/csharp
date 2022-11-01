if (letter >= 'a' && letter <= 'z')
{
    if ((letter_flags & (1 << (letter - 'a'))) != 0)
        return false;
    else
        letter_flags |= (1 << (letter - 'a'));
}
