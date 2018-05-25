// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class ProteinTranslationTest
{
    [Fact]
    public void Methionine_rna_sequence()
    {
        Assert.Equal(new[] { "Methionine" }, ProteinTranslation.Proteins("AUG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Phenylalanine_rna_sequence_1()
    {
        Assert.Equal(new[] { "Phenylalanine" }, ProteinTranslation.Proteins("UUU"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Phenylalanine_rna_sequence_2()
    {
        Assert.Equal(new[] { "Phenylalanine" }, ProteinTranslation.Proteins("UUC"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Leucine_rna_sequence_1()
    {
        Assert.Equal(new[] { "Leucine" }, ProteinTranslation.Proteins("UUA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Leucine_rna_sequence_2()
    {
        Assert.Equal(new[] { "Leucine" }, ProteinTranslation.Proteins("UUG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Serine_rna_sequence_1()
    {
        Assert.Equal(new[] { "Serine" }, ProteinTranslation.Proteins("UCU"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Serine_rna_sequence_2()
    {
        Assert.Equal(new[] { "Serine" }, ProteinTranslation.Proteins("UCC"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Serine_rna_sequence_3()
    {
        Assert.Equal(new[] { "Serine" }, ProteinTranslation.Proteins("UCA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Serine_rna_sequence_4()
    {
        Assert.Equal(new[] { "Serine" }, ProteinTranslation.Proteins("UCG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tyrosine_rna_sequence_1()
    {
        Assert.Equal(new[] { "Tyrosine" }, ProteinTranslation.Proteins("UAU"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tyrosine_rna_sequence_2()
    {
        Assert.Equal(new[] { "Tyrosine" }, ProteinTranslation.Proteins("UAC"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cysteine_rna_sequence_1()
    {
        Assert.Equal(new[] { "Cysteine" }, ProteinTranslation.Proteins("UGU"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Cysteine_rna_sequence_2()
    {
        Assert.Equal(new[] { "Cysteine" }, ProteinTranslation.Proteins("UGC"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Tryptophan_rna_sequence()
    {
        Assert.Equal(new[] { "Tryptophan" }, ProteinTranslation.Proteins("UGG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stop_codon_rna_sequence_1()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stop_codon_rna_sequence_2()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stop_codon_rna_sequence_3()
    {
        Assert.Empty(ProteinTranslation.Proteins("UGA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translate_rna_strand_into_correct_protein_list()
    {
        Assert.Equal(new[] { "Methionine", "Phenylalanine", "Tryptophan" }, ProteinTranslation.Proteins("AUGUUUUGG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translation_stops_if_stop_codon_at_beginning_of_sequence()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAGUGG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translation_stops_if_stop_codon_at_end_of_two_codon_sequence()
    {
        Assert.Equal(new[] { "Tryptophan" }, ProteinTranslation.Proteins("UGGUAG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translation_stops_if_stop_codon_at_end_of_three_codon_sequence()
    {
        Assert.Equal(new[] { "Methionine", "Phenylalanine" }, ProteinTranslation.Proteins("AUGUUUUAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translation_stops_if_stop_codon_in_middle_of_three_codon_sequence()
    {
        Assert.Equal(new[] { "Tryptophan" }, ProteinTranslation.Proteins("UGGUAGUGG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translation_stops_if_stop_codon_in_middle_of_six_codon_sequence()
    {
        Assert.Equal(new[] { "Tryptophan", "Cysteine", "Tyrosine" }, ProteinTranslation.Proteins("UGGUGUUAUUAAUGGUUU"));
    }
}