package com.example.myapplication;

public class Produto {
    private int imagem;
    private String nome;
    private String valor;
    private String descricao;

    public Produto(int imagem, String nome, String valor, String descricao) {
        this.imagem = imagem;
        this.nome = nome;
        this.valor = valor;
        this.descricao = descricao;
    }

    public int getImagem() {
        return imagem;
    }

    public String getNome() {
        return nome;
    }

    public String getValor() {
        return valor;
    }

    public String getDescricao() {
        return descricao;
    }
}
