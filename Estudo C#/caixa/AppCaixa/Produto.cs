class Produto{

    public int Codigo;

public double Valor;

public string Nome;

public DateTime Validade = new DateTime();

private string[,] bancoProduto = new string[20, 6];

public ETipoProduto TipoProduto;

public int Quantidade;

public Produto(){
    
}
public Produto(int codigo, double valor, string nome, DateTime validade, ETipoProduto tipoProduto, int quantidade)
{

Codigo = codigo;
Valor = valor;
Nome = nome;
Validade = validade;
TipoProduto = tipoProduto;
Quantidade = quantidade;

}

public void ConsultaProdutoIndice(int i)
{
try
{
Console.WriteLine($"Índice :{i + 1}, Código : {bancoProduto[i, 0]}, Valor : {bancoProduto[i, 1]}, Nome : {bancoProduto[i, 2]}, Validade :{bancoProduto[i, 3]}");
}
catch (System.Exception ex)
{
Console.WriteLine("Índice não encontrado" + ex.Message + ex.InnerException);
throw;
}



}

public void ConsultaTodosProdutos()
{
for (int i = 0; i < bancoProduto.GetLength(0); i++)
{
Console.WriteLine($"Índice :{i + 1}, Código : {bancoProduto[i, 0]}, Valor : {bancoProduto[i, 1]}, Nome : {bancoProduto[i, 2]}, Validade :{bancoProduto[i, 3]}");
}

}

public void AdicionarProduto(int cod, double val, string nom, DateTime vad,int quant, ETipoProduto tip)
{

var indice = IndiceVazio();
if (indice != -1)
{
bancoProduto[indice, 0] = cod.ToString();
bancoProduto[indice, 1] = val.ToString();
bancoProduto[indice, 2] = nom;
bancoProduto[indice, 3] = vad.ToString();
bancoProduto[indice,4] = quant.ToString();
bancoProduto[indice, 5] = tip.ToString();

}

}

public int IndiceVazio()
{

var indice = -1;

for (int i = 0; i < bancoProduto.GetLength(0); i++)
{

if (bancoProduto[i, 0] == " ")
{

indice = i;
break;
}
}


return indice;

}


public void AtualizarProduto(int linha, int coluna, string valor)
{
bancoProduto[linha, coluna] = valor;
}


}