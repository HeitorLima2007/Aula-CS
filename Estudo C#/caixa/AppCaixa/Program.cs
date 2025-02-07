enum ETipoProduto
{

BemDuravel = 1,
Perecivel = 2


}

internal class Program
{

private static void Main(string[] args)
{

Menu();

}


}

private static void MostraProdutoPorIndice(int indice)
{
var produto = new Produto();

produto.ConsultaProdutoIndice(indice);
}

private static void MostrarTodosProdutos()
{
var produto = new Produto();

produto.ConsultaTodosProdutos();
}

private static void CadastrarProduto(int codigo, double valor, string nome, DateTime validade,int quantidade, ETipoProduto tipoProduto)
{
var produto = new Produto();


produto.AdicionarProduto(codigo, valor, nome, validade, quantidade, tipoProduto);


}

private static void AdicionarProdutos()
{
string[,] produtos = Banco();

var produto = new Produto();
int codigo = 0;
double valor = 0.00;
string nome = "produto";
DateTime validade = new DateTime();
int quantidade = 0;
string tipoProduto = "";
ETipoProduto tipoProdutoEnum;

for (int i = 0; i < produtos.GetLength(0); i++)
{
codigo = int.Parse(produtos[i, 0]);
valor = double.Parse(produtos[i, 1]);
nome = produtos[i, 2];
validade = DateTime.Parse(produtos[i, 3]);
quantidade = int.Parse(produtos[i,4]);
tipoProduto = produtos[i,5];
tipoProdutoEnum = (ETipoProduto) Enum.Parse(typeof(ETipoProduto),tipoProduto);

produto.AdicionarProduto(codigo, valor, nome, validade,quantidade,tipoProdutoEnum);
}

}


private static string[,] Banco()
{

var benduravel = ETipoProduto.BemDuravel.ToString();
var perecivel = ETipoProduto.Perecivel.ToString();

string[,] produtos = new string[10, 6]
{
{ "1001", "19.99", "Produto A", "2025-12-31","10",benduravel},
{ "1002", "29.99", "Produto B", "2025-11-30","15",benduravel},
{ "1003", "9.99", "Produto C", "2026-01-15","7",perecivel},
{ "1004", "49.99", "Produto D", "2025-10-20","9",perecivel},
{ "1005", "15.99", "Produto E", "2025-09-12","10",perecivel},
{ "1006", "25.99", "Produto F", "2026-02-01","10" ,perecivel},
{ "1007", "39.99", "Produto G", "2026-03-22","111" ,benduravel},
{ "1008", "12.99", "Produto H", "2025-07-10","100" ,benduravel},
{ "1009", "89.99", "Produto I", "2025-08-15","10",benduravel},
{ "1010", "49.49", "Produto J", "2026-05-30","15",perecivel}
};
return produtos;
}
}