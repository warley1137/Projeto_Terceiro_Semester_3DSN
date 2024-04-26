package com.example.myapplication.ui.home;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import com.example.myapplication.Produto;
import com.example.myapplication.ProdutoAdapter;
import com.example.myapplication.R;
import java.util.ArrayList;

public class HomeFragment extends Fragment {

    private ListView listViewProdutos;
    private ArrayList<Produto> produtos;

    @SuppressLint("MissingInflatedId")
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_home, container, false);

        listViewProdutos = rootView.findViewById(R.id.listProdutos);

        // Crie uma lista de produtos com imagem, nome, valor e descrição
        produtos = new ArrayList<>();
        produtos.add(new Produto(R.drawable.ic_produto1, "Roda Bones 56mm STF Rapture 84B", "R$ 589,90", "R$ 569,91 à vista com desconto ou 6x de R$ 99,98 Sem juros"));
        produtos.add(new Produto(R.drawable.ic_produto2, "Shape SDS Co 8.0 Cranial Base", "R$ 129,90", "R$ 123,41 à vista com desconto ou 5x de R$ 25,98 Sem juros"));
        produtos.add(new Produto(R.drawable.ic_produto3, "Truck Essência 129mm Eixo Prata Base Roxa", "R$ 199,90", "R$ 189,91 à vista com desconto ou 6x de R$ 33,32 Sem juros"));
        produtos.add(new Produto(R.drawable.ic_produto4, "Truck Trurium 139mm Low Sandro Sobral", "R$ 419,90", "R$ 398,91 à vista com desconto ou 6x de R$ 69,98 Sem juros"));
        produtos.add(new Produto(R.drawable.ic_produto5, "Shape Santa Cruz Hand Wood Powerlight", "R$ 269,90", "RS 242,91 à vista com desconto ou 6x de R$44,98 sem juros"));
        produtos.add(new Produto(R.drawable.ic_produto6, "Roda Moska 53mm Rock White 53D", "R$ 154,90", "R$ 147,16 à vista com desconto ou 6x de R$ 25,82 Sem juros"));

        // Crie um adaptador personalizado para exibir os produtos
        ProdutoAdapter adapter = new ProdutoAdapter(requireContext(), R.layout.item_produto, produtos);
        listViewProdutos.setAdapter(adapter);

        return rootView;
    }
}
