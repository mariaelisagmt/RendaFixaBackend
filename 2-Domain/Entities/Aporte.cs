﻿namespace RendaFixa.Domain.Entities;

public class Aporte : BaseEntity
{
    public int RendaFixaId { get;  set; }
    public int ContaId { get;  set; }
    public DateTime DataOperacao { get;  set; }
    public int Quantidade { get;  set; }
    public virtual ProdutoRendaFixa RendaFixa { get;  set; }
    public virtual Conta Conta { get;  set; }

    public Aporte() { }
    public Aporte(
        int rendaFixaId,
        int contaId,
        DateTime dataOperacao,
        int quantidade)
    {
        RendaFixaId = rendaFixaId;
        ContaId = contaId;
        DataOperacao = dataOperacao;
        Quantidade = quantidade;
    }
}
