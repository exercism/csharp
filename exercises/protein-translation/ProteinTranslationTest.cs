using System;
using Xunit;

public class ProteinTranslationTest
{
    [Theory]
    [InlineData("AUG")]
    public void Identifies_methionine_codons(string codon)
    {
        Assert.Equal(new[] { "Methionine" }, ProteinTranslation.Translate(codon));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("UUU")]
    [InlineData("UUC")]
    public void Identifies_phenylalanine_codons(string codon)
    {
        Assert.Equal(new[] { "Phenylalanine" }, ProteinTranslation.Translate(codon));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("UUA")]
    [InlineData("UUG")]
    public void Identifies_leucine_codons(string codon)
    {
        Assert.Equal(new[] { "Leucine" }, ProteinTranslation.Translate(codon));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("UCU")]
    [InlineData("UCC")]
    [InlineData("UCA")]
    [InlineData("UCG")]
    public void Identifies_serine_codons(string codon)
    {
        Assert.Equal(new[] { "Serine" }, ProteinTranslation.Translate(codon));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("UAU")]
    [InlineData("UAC")]
    public void Identifies_tyrosine_codons(string codon)
    {
        Assert.Equal(new[] { "Tyrosine" }, ProteinTranslation.Translate(codon));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("UGU")]
    [InlineData("UGC")]
    public void Identifies_cysteine_codons(string codon)
    {
        Assert.Equal(new[] { "Cysteine" }, ProteinTranslation.Translate(codon));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("UGG")]
    public void Identifies_tryptophan_codons(string codon)
    {
        Assert.Equal(new[] { "Tryptophan" }, ProteinTranslation.Translate(codon));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translates_rna_strand_into_correct_protein()
    {
        Assert.Equal(new[] { "Methionine", "Phenylalanine", "Tryptophan" }, ProteinTranslation.Translate("AUGUUUUGG"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stops_translation_if_stop_codon_present()
    {
        Assert.Equal(new[] { "Methionine", "Phenylalanine" }, ProteinTranslation.Translate("AUGUUUUAA"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stops_translation_of_longer_strand()
    {
        Assert.Equal(new[] { "Tryptophan", "Cysteine", "Tyrosine" }, ProteinTranslation.Translate("UGGUGUUAUUAAUGGUUU"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Throws_for_invalid_codons()
    {
        Assert.Throws<Exception>(() => ProteinTranslation.Translate("CARROT"));
    }
}
