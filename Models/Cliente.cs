namespace Aula29MVCDB.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Endereco { get; set; }
    public string Cidade { get; set; }
    public string Regiao { get; set; }
    public string CodigoPostal { get; set; }
    public string Pais { get; set; }
    public string Telefone { get; set; }

    public Cliente() { }

    public Cliente(int id, string endereco, string cidade, string regiao, string codigoPostal, string pais, string telefone)
    {
        Id = id;
        Endereco = endereco;
        Regiao = regiao;
        CodigoPostal = codigoPostal;
        Pais = pais;
        Telefone = telefone;
    }
}