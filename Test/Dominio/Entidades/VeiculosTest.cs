namespace MinimalApi.Dominio.Entidades;

[TestClass]
public class VeiculosTest
{
    [TestMethod]
    public void TestarGetSetProps()
    {
        //arange (variaveis)
        var veiculo = new Veiculo();

        // act (acoes)
        veiculo.Id = 1;
        veiculo.Nome = "veiculoteste";
        veiculo.Marca = "teste";
        veiculo.Ano = 1999;

        //assert (validacao)

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("veiculoteste", veiculo.Nome);
        Assert.AreEqual("teste", veiculo.Marca);
        Assert.AreEqual(1999, veiculo.Ano);
    }
}