// This file was auto-generated based on version 2.1.0 of the canonical data.

using System;
using Xunit;

public class HammingTest
{
    [Fact]
    public void Empty_strands()
    {
        Assert.Equal(0, Hamming.Distance("", ""));
    }

    [Fact(Skip = "Remove to run test")]
    public void Identical_strands()
    {
        Assert.Equal(0, Hamming.Distance("A", "A"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Long_identical_strands()
    {
        Assert.Equal(0, Hamming.Distance("GGACTGA", "GGACTGA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Complete_distance_in_single_nucleotide_strands()
    {
        Assert.Equal(1, Hamming.Distance("A", "G"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Complete_distance_in_small_strands()
    {
        Assert.Equal(2, Hamming.Distance("AG", "CT"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Small_distance_in_small_strands()
    {
        Assert.Equal(1, Hamming.Distance("AT", "CT"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Small_distance()
    {
        Assert.Equal(1, Hamming.Distance("GGACG", "GGTCG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Small_distance_in_long_strands()
    {
        Assert.Equal(2, Hamming.Distance("ACCAGGG", "ACTATGG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_unique_character_in_first_strand()
    {
        Assert.Equal(1, Hamming.Distance("AAG", "AAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Non_unique_character_in_second_strand()
    {
        Assert.Equal(1, Hamming.Distance("AAA", "AAG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Same_nucleotides_in_different_positions()
    {
        Assert.Equal(2, Hamming.Distance("TAG", "GAT"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_distance()
    {
        Assert.Equal(4, Hamming.Distance("GATACA", "GCATAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Large_distance_in_off_by_one_strand()
    {
        Assert.Equal(9, Hamming.Distance("GGACGGATTCTG", "AGGACGGATTCT"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Disallow_first_strand_longer()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("AATG", "AAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Disallow_second_strand_longer()
    {
        Assert.Throws<ArgumentException>(() => Hamming.Distance("ATA", "AGTG"));
    }
}