using System;
using NUnit.Framework;

[TestFixture]
public class ProteinTranslationTest
{
    [TestCase("AUG")]
    public void Identifies_methionine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Methionine" }));
    }

    [TestCase("UUU", Ignore = "Remove to run test case")]
    [TestCase("UUC", Ignore = "Remove to run test case")]
    public void Identifies_phenylalanine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Phenylalanine" }));
    }

    [TestCase("UUA", Ignore = "Remove to run test case")]
    [TestCase("UUG", Ignore = "Remove to run test case")]
    public void Identifies_leucine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Leucine" }));
    }

    [TestCase("UCU", Ignore = "Remove to run test case")]
    [TestCase("UCC", Ignore = "Remove to run test case")]
    [TestCase("UCA", Ignore = "Remove to run test case")]
    [TestCase("UCG", Ignore = "Remove to run test case")]
    public void Identifies_serine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Serine" }));
    }

    [TestCase("UAU", Ignore = "Remove to run test case")]
    [TestCase("UAC", Ignore = "Remove to run test case")]
    public void Identifies_tyrosine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Tyrosine" }));
    }

    [TestCase("UGU", Ignore = "Remove to run test case")]
    [TestCase("UGC", Ignore = "Remove to run test case")]
    public void Identifies_cysteine_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Cysteine" }));
    }

    [TestCase("UGG", Ignore = "Remove to run test case")]
    public void Identifies_tryptophan_codons(string codon)
    {
        Assert.That(ProteinTranslation.Translate(codon), Is.EquivalentTo(new[] { "Tryptophan" }));
    }

    [Test]
    [Ignore("Remove to run test")]
    public void Translates_rna_strand_into_correct_protein()
    {
        Assert.That(ProteinTranslation.Translate("AUGUUUUGG"), Is.EquivalentTo(new[] { "Methionine", "Phenylalanine", "Tryptophan" }));
    }

    [Test]
    [Ignore("Remove to run test")]
    public void Stops_translation_if_stop_codon_present()
    {
        Assert.That(ProteinTranslation.Translate("AUGUUUUAA"), Is.EquivalentTo(new[] { "Methionine", "Phenylalanine" }));
    }

    [Test]
    [Ignore("Remove to run test")]
    public void Stops_translation_of_longer_strand()
    {
        Assert.That(ProteinTranslation.Translate("UGGUGUUAUUAAUGGUUU"), Is.EquivalentTo(new[] { "Tryptophan", "Cysteine", "Tyrosine" }));
    }

    [Test]
    [Ignore("Remove to run test")]
    public void Throws_for_invalid_codons()
    {
        Assert.Throws<Exception>(() => ProteinTranslation.Translate("CARROT"));
    }
}
