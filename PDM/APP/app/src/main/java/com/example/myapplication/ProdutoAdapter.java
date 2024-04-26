package com.example.myapplication;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import java.util.ArrayList;

public class ProdutoAdapter extends BaseAdapter {

    private Context context;
    private int resource;
    private ArrayList<Produto> produtos;

    public ProdutoAdapter(Context context, int resource, ArrayList<Produto> produtos) {
        this.context = context;
        this.resource = resource;
        this.produtos = produtos;
    }

    @Override
    public int getCount() {
        return produtos.size();
    }

    @Override
    public Object getItem(int position) {
        return produtos.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if (view == null) {
            LayoutInflater inflater = LayoutInflater.from(context);
            view = inflater.inflate(resource, null);
        }

        Produto produto = (Produto) getItem(position);

        if (produto != null) {
            ImageView imageView = view.findViewById(R.id.imageViewProduto);
            TextView nomeTextView = view.findViewById(R.id.textViewNome);
            TextView valorTextView = view.findViewById(R.id.textViewValor);
            TextView descricaoTextView = view.findViewById(R.id.textViewDescricao);

            imageView.setImageResource(produto.getImagem());
            nomeTextView.setText(produto.getNome());
            valorTextView.setText(produto.getValor());
            descricaoTextView.setText(produto.getDescricao());
        }

        return view;
    }
}
