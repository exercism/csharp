using System;
using Xunit;

public class ProteinTranslationTest
{
    [InlineData("AUG")]
    public void Identifies_methionine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Methionine" }));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData("UUU")]
    [InlineData("UUC")]
    public void Identifies_phenylalanine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Phenylalanine" }));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData("UUA")]
    [InlineData("UUG")]
    public void Identifies_leucine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Leucine" }));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData("UCU")]
    [InlineData("UCC")]
    [InlineData("UCA")]
    [InlineData("UCG")]
    public void Identifies_serine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Serine" }));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData("UAU")]
    [InlineData("UAC")]
    public void Identifies_tyrosine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Tyrosine" }));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData("UGU")]
    [InlineData("UGC")]
    public void Identifies_cysteine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Cysteine" }));
    }

    [Theory(Skip="Remove to run test")]
    [InlineData("UGG")]
    public void Identifies_tryptophan_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Tryptophan" }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Translates_rna_strand_into_correct_protein()
    {
        Assert.That(ProteinTranslation.Translate("AUGUUUUGG"), Is.EquivalentTo(new[] { "Methionine", "Phenylalanine", "Tryptophan" }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stops_translation_if_stop_codon_present()
    {
        Assert.That(ProteinTranslation.Translate("AUGUUUUAA"), Is.EquivalentTo(new[] { "Methionine", "Phenylalanine" }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Stops_translation_of_longer_strand()
    {
        Assert.That(ProteinTranslation.Translate("UGGUGUUAUUAAUGGUUU"), Is.EquivalentTo(new[] { "Tryptophan", "Cysteine", "Tyrosine" }));
    }

    [Fact(Skip = "Remove to run test")]
    public void Throws_for_invalid_codons()
    {
        Assert.Throws<Exception>(() => ProteinTranslation.Translate("CARROT"));
    }
}
