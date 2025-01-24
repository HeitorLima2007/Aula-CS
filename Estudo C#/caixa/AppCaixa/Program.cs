
struct Produto
{

public int codigo;

public double valor;

public string nome;

public DateTime validade = new DateTime();

private string[,] bancoProduto = new string[20, 6];

public ETipoProduto TipoProduto;

public Produto(int c, double v, string n, DateTime va, ETipoProduto tipoProduto)


{

codigo = c;
valor = v;
nome = n;
validade = va;
tipoProduto = TipoProduto;

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

public void AdicionarProduto(int cod, double val, string nom, DateTime vad, int quant, ETipoProduto tip)
{

var indece = IndiceVazio();
if (indece != -1)
{
bancoProduto[indece, 0] = cod.ToString();
bancoProduto[indece, 1] = val.ToString();
bancoProduto[indece, 2] = nom;
bancoProduto[indece, 3] = vad.ToString();
bancoProduto[indece, 4] = quant.ToString();
bancoProduto[indece, 5] = tip.ToString();

}

}

public int IndiceVazio()
{

var indece = -1;

for (int i = 0; i < bancoProduto.GetLength(0); i++)
{

if (bancoProduto[i, 0] == " ")
{

indece = i;
break;
}
}


return indece;

}


public void AtualizarProduto()
{

}


}

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


private static void Menu()
{

    char selecao = 'n';
    int pegaIndice = 0;
    double peso = 0.00;
    Console.WriteLine("Iniciar Caixa");
    var pagamentos = new double[5];


do
{

string[,] itens = new string[5, 2] { { "pão", "17,50" }, { "salgadinho", "5,00" }, { "batata", "7,00" }, { "laranja", "5,30" }, { "contra-filé", "49,99" } };


Console.WriteLine("Digite para Venda == v ,Consulta de Preço == c ,Fechamento de Caixa == f, Fechamento do aplicativo == s");
string? pegaSelecao = Console.ReadLine();

if (pegaSelecao.Length == 1)
{
selecao = pegaSelecao[0];
}


if (selecao == 'v')
{
Console.WriteLine("-----------------Produtos---------------");

for (int i = 0; i < 5; i++)
{
Console.WriteLine($"Índice : {i} , Produto : {itens[i, 0]}, valor : {itens[i, 1]}");
}

Console.WriteLine("Quantide de Produtos");
int qtaProdutos = int.Parse(Console.ReadLine());
int contaProdutos = 0;

while (contaProdutos < qtaProdutos)
{
    
Console.WriteLine("Digite o índice");
pegaIndice = int.Parse(Console.ReadLine());
Console.WriteLine("Digite o peso");
peso = double.Parse(Console.ReadLine());
pagamentos[contaProdutos] = double.Parse(itens[pegaIndice, 1]) * peso;
Console.WriteLine($"contaProdutos {contaProdutos}");
contaProdutos++;
}

double valorPagar = 0.00;

Console.WriteLine("------Opçoes de Pagamento-------");
Console.WriteLine("---Cartões de Crédito --Digite C");
Console.WriteLine("---Cartões de Débito -- Digite D");
Console.WriteLine("---QRCode ------------- Digite Q");
Console.WriteLine("---Dinheiro ----------- Digite I");

char tipoPagamento = 'I';

string? tipoPagamentoDigitado = Console.ReadLine();

if (tipoPagamentoDigitado.Length == 1)
{

tipoPagamento = tipoPagamentoDigitado[0];
}

switch (tipoPagamento)
{
case 'C':
Console.WriteLine("Pagamento com Cartão de Crédito");
break;
case 'D':
Console.WriteLine("Pagamento com Cartão de Débito");
break;
case 'Q':
Console.WriteLine("Pagamento com QRCode");
break;
default:
Console.WriteLine("Pagamento com Dinheiro");
break;

}


//Console.WriteLine("Produto :" + produto + " Código :" + codigo + " Valor à Pagar :" + valorPagar);

double valorTotal = 0.00;

foreach (var item in pagamentos)
{
Console.WriteLine($"Valor da Venda : {item}");
valorTotal = valorTotal + item;

}
int contaPagamento = 0;

contaPagamento = 0;
Console.WriteLine($"Valor Total:{valorTotal}");


}
else if (selecao == 'c')
{
Console.WriteLine("--Consulta de Produtos--");
Console.WriteLine("Produto :" + itens[0, 0]);
Console.WriteLine("Produto :" + itens[1, 0]);
Console.WriteLine("Produto :" + itens[2, 0]);
Console.WriteLine("Produto :" + itens[3, 0]);
Console.WriteLine("Produto :" + itens[4, 0]);

}
else if (selecao == 'f')
{
Console.WriteLine("--Fechamento de Caixa--");
}
else
{
Console.WriteLine("--Fechamento do Aplicativo--");
}

} while (selecao != 's');

}

private static void MostraProdutoPorIndece()
{

}

private static void MostrarTodosProdutos()
{

}

private static void CadastrarProduto(int codigo, double valor, string nome, DateTime validade, int quantidade, ETipoProduto tipoProdutoEnum)
{

    var produto = new Produto();

    produto.AdicionarProduto(codigo,valor,nome,validade, quantidade, tipoProdutoEnum);

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
codigo = int.Parse(produtos[i,0]);
valor = double.Parse(produtos[i,1]);
nome = produtos[i,2];
validade = DateTime.Parse(produtos[i,3]);
quantidade = int.Parse(produtos[i,4]);
tipoProduto = produtos[i,5];
tipoProdutoEnum = (ETipoProduto)Enum.Parse(typeof(ETipoProduto), tipoProduto);

produto.AdicionarProduto(codigo,valor,nome,validade, quantidade, tipoProdutoEnum);
}

}


private static string[,] Banco()
{

    var bemduravel = ETipoProduto.BemDuravel.ToString();
    var perecivel = ETipoProduto.Perecivel.ToString();
string[,] produtos = new string[10, 6]
{
{ "1001", "19.99", "Produto A", "2025-12-31", "18", perecivel},
{ "1002", "29.99", "Produto B", "2025-11-30", "56", bemduravel},
{ "1003", "9.99", "Produto C", "2026-01-15", "35", bemduravel},
{ "1004", "49.99", "Produto D", "2025-10-20", "15", perecivel},
{ "1005", "15.99", "Produto E", "2025-09-12", "65", perecivel},
{ "1006", "25.99", "Produto F", "2026-02-01", "82", bemduravel},
{ "1007", "39.99", "Produto G", "2026-03-22", "72", perecivel},
{ "1008", "12.99", "Produto H", "2025-07-10", "10", bemduravel},
{ "1009", "89.99", "Produto I", "2025-08-15", "29", bemduravel},
{ "1010", "49.49", "Produto J", "2026-05-30", "82", perecivel}
};
return produtos;
}
}