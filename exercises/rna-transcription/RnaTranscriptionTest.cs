// This file was auto-generated based on version 1.0.1 of the canonical data.

using Xunit;
using System;

public class RnaTranscriptionTest
{
    [Fact]
    public void Rna_complement_of_cytosine_is_guanine()
    {
        Assert.Equal("G", RnaTranscription.ToRna("C"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement_of_guanine_is_cytosine()
    {
        Assert.Equal("C", RnaTranscription.ToRna("G"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement_of_thymine_is_adenine()
    {
        Assert.Equal("A", RnaTranscription.ToRna("T"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement_of_adenine_is_uracil()
    {
        Assert.Equal("U", RnaTranscription.ToRna("A"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Rna_complement()
    {
        Assert.Equal("UGCACCAGAAUU", RnaTranscription.ToRna("ACGTGGTCTTAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Correctly_handles_invalid_input_rna_instead_of_dna_()
    {
        Assert.Throws<ArgumentException>(() => RnaTranscription.ToRna("U"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Correctly_handles_completely_invalid_dna_input()
    {
        Assert.Throws<ArgumentException>(() => RnaTranscription.ToRna("XXX"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Correctly_handles_partially_invalid_dna_input()
    {
        Assert.Throws<ArgumentException>(() => RnaTranscription.ToRna("ACGTXXXCTTAA"));
    }
}