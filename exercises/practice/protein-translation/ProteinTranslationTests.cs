public class ProteinTranslationTests
{
    [Fact]
    public void Empty_rna_sequence_results_in_no_proteins()
    {
        Assert.Empty(ProteinTranslation.Proteins(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Methionine_rna_sequence()
    {
        string[] expected = ["Methionine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Phenylalanine_rna_sequence_1()
    {
        string[] expected = ["Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUU"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Phenylalanine_rna_sequence_2()
    {
        string[] expected = ["Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUC"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Leucine_rna_sequence_1()
    {
        string[] expected = ["Leucine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Leucine_rna_sequence_2()
    {
        string[] expected = ["Leucine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Serine_rna_sequence_1()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCU"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Serine_rna_sequence_2()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCC"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Serine_rna_sequence_3()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Serine_rna_sequence_4()
    {
        string[] expected = ["Serine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UCG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Tyrosine_rna_sequence_1()
    {
        string[] expected = ["Tyrosine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UAU"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Tyrosine_rna_sequence_2()
    {
        string[] expected = ["Tyrosine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UAC"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cysteine_rna_sequence_1()
    {
        string[] expected = ["Cysteine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGU"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Cysteine_rna_sequence_2()
    {
        string[] expected = ["Cysteine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGC"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Tryptophan_rna_sequence()
    {
        string[] expected = ["Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_codon_rna_sequence_1()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_codon_rna_sequence_2()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_codon_rna_sequence_3()
    {
        Assert.Empty(ProteinTranslation.Proteins("UGA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sequence_of_two_protein_codons_translates_into_proteins()
    {
        string[] expected = ["Phenylalanine", "Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUUUUU"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sequence_of_two_different_protein_codons_translates_into_proteins()
    {
        string[] expected = ["Leucine", "Leucine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UUAUUG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Translate_rna_strand_into_correct_protein_list()
    {
        string[] expected = ["Methionine", "Phenylalanine", "Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUGUUUUGG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Translation_stops_if_stop_codon_at_beginning_of_sequence()
    {
        Assert.Empty(ProteinTranslation.Proteins("UAGUGG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Translation_stops_if_stop_codon_at_end_of_two_codon_sequence()
    {
        string[] expected = ["Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGGUAG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Translation_stops_if_stop_codon_at_end_of_three_codon_sequence()
    {
        string[] expected = ["Methionine", "Phenylalanine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUGUUUUAA"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Translation_stops_if_stop_codon_in_middle_of_three_codon_sequence()
    {
        string[] expected = ["Tryptophan"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGGUAGUGG"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Translation_stops_if_stop_codon_in_middle_of_six_codon_sequence()
    {
        string[] expected = ["Tryptophan", "Cysteine", "Tyrosine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("UGGUGUUAUUAAUGGUUU"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sequence_of_two_non_stop_codons_does_not_translate_to_a_stop_codon()
    {
        string[] expected = ["Methionine", "Methionine"];
        Assert.Equal(expected, ProteinTranslation.Proteins("AUGAUG"));
    }
}
